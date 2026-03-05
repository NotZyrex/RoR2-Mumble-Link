using RoR2;
using System.Text;
using System;
using UnityEngine;

namespace RoR2MumbleLink
{
    internal class PlayerTracker
    {
        private CharacterBody _localPlayerBody;
        private LinkedMem lm;
        private bool initialized = false;
        internal PlayerTracker() 
        {
            CharacterBody.onBodyStartGlobal += OnBodyStart;
            CharacterBody.onBodyDestroyGlobal += OnBodyDestroy;

            lm.uiVersion = 2;
            lm.name = "Risk of Rain 2";
            lm.description = "RoR2 Mumble Link Positional Audio";

            lm.context = new byte[256];
            byte[] contextBytes = Encoding.ASCII.GetBytes("RoR2ServerContext");
            Array.Copy(contextBytes, lm.context, contextBytes.Length);
            lm.context_len = (uint)contextBytes.Length;

        }

        private void OnBodyStart(CharacterBody body)
        {
            if (!body.isPlayerControlled) return;

            if (body.hasEffectiveAuthority) _localPlayerBody = body;
        }

        private void OnBodyDestroy(CharacterBody body)
        {
            if (body == _localPlayerBody) _localPlayerBody = null;
        }
        public void Update(MumbleLinkFile file)
        {
            Camera cam = Camera.main;

            if (PlayerCharacterMasterController.instances.Count <= 1) return;
            if (_localPlayerBody == null || file == null || cam == null) return;

            if (!initialized)
            {
                lm.identity = _localPlayerBody.name;
                initialized = true;
            }

            if (string.IsNullOrEmpty(lm.identity))
            {
                lm.identity = _localPlayerBody.name;
            }

            lm.uiTick++;

            Transform t = _localPlayerBody.transform;

            lm.fAvatarPosition = new float[] { t.position.x, t.position.y, t.position.z };

            lm.fAvatarFront = new float[] { t.forward.x, t.forward.y, t.forward.z };
            lm.fAvatarTop = new float[] { t.up.x, t.up.y, t.up.z };
            
            Transform ct = cam.transform;

            lm.fCameraPosition = new float[] { ct.position.x, ct.position.y, ct.position.z };

            lm.fCameraFront = new float[] { ct.forward.x, ct.forward.y, ct.forward.z };
            lm.fCameraTop = new float[] { ct.up.x, ct.up.y, ct.up.z };

            file.Write(lm);
        }
    }
}
