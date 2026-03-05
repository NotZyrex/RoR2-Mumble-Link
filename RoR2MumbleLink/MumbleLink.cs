using BepInEx;
using R2API.Utils;

namespace RoR2MumbleLink
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [NetworkCompatibility(CompatibilityLevel.NoNeedForSync, VersionStrictness.DifferentModVersionsAreOk)]
    public class MumbleLink : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "Zyrex";
        public const string PluginName = "MumbleLink";
        public const string PluginVersion = "1.0.0";

        private MumbleLinkFile _mumble;
        private PlayerTracker _playerTracker;

        public void Awake()
        {
            Log.Init(Logger);
            Log.Message("Loaded Mumble Link!");

            _mumble = new MumbleLinkFile();
            _playerTracker = new PlayerTracker();
        }

        private void Update()
        {
            _playerTracker.Update(_mumble);
        }

        private void OnDestroy()
        {
            _mumble?.Dispose(); 
        }
    }
}
