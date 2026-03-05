using System;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace RoR2MumbleLink
{
    public sealed class MumbleLinkFile : IDisposable
    {
        private const string FILE_NAME = "MumbleLink";

        private readonly MemoryMappedFile _file;
        private readonly MemoryMappedViewAccessor _accessor;
        private bool _disposed;

        public MumbleLinkFile()
        {
            _file = MemoryMappedFile.CreateOrOpen(FILE_NAME, Marshal.SizeOf<LinkedMem>(), MemoryMappedFileAccess.ReadWrite);
            _accessor = _file.CreateViewAccessor();
        }

        public void Write(LinkedMem lm)
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);

            int size = Marshal.SizeOf<LinkedMem>();
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(lm, ptr, false);
                byte[] buf = new byte[size];
                Marshal.Copy(ptr, buf, 0, size);
                _accessor.WriteArray<byte>(0, buf, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            _accessor.Dispose();
            _file.Dispose();
        }
    }
}