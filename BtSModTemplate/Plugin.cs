using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace BtSModTemplate {
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin {
        public const string PluginGUID = "com.your.plugin.Name";
        public const string PluginName = "Your Plugin Name";
        public const string PluginVersion = "0.1.0";

        public static ManualLogSource Log { get; private set; }

        private Harmony _harmony;
        
        public static ConfigEntry<float> floatConfigEntry;

        private void Awake() {
            Log = Logger;

            _harmony = new Harmony(PluginGUID);
            harmony.PatchAll();

            AcceptableValueRange<float> floatConfigEntryAcceptableRange = new AcceptableValueRange<float>(0f, 25f);

            floatConfigEntry = Config.Bind("Config Section", "Float Config Entry", 0.5f, new ConfigDescription("An example entry for a config option", null, floatConfigEntryAcceptableRange));
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
        }
    }
}
