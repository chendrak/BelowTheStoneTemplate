using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace PitchDark {
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin {
        public const string PluginGUID = "com.maxsch.BelowTheStone.PitchDark";
        public const string PluginName = "Pitch Dark";
        public const string PluginVersion = "0.1.0";

        public static ManualLogSource Log { get; private set; }
        
        public static ConfigEntry<float> playerLightInnerRadius;
        public static ConfigEntry<float> playerLightOuterRadius;
        public static ConfigEntry<float> torchLightInnerRadius;
        public static ConfigEntry<float> torchLightOuterRadius;

        private void Awake() {
            Log = Logger;

            Harmony harmony = new Harmony(PluginGUID);
            harmony.PatchAll();

            AcceptableValueRange<float> lightRadiusRange = new AcceptableValueRange<float>(0f, 25f);

            playerLightInnerRadius = Config.Bind("1 - General", "Player Inner Light Radius", 0.5f, new ConfigDescription("The inner radius of the player's light", null, lightRadiusRange));
            playerLightOuterRadius = Config.Bind("1 - General", "Player Outer Light Radius", 2f, new ConfigDescription("The outer radius of the player's light", null, lightRadiusRange));

            torchLightInnerRadius = Config.Bind("1 - General", "Torch Inner Light Radius", 0.5f, new ConfigDescription("The inner radius of player placed torch lights", null, lightRadiusRange));
            torchLightOuterRadius = Config.Bind("1 - General", "Torch Outer Light Radius", 5f, new ConfigDescription("The outer radius of player placed torch lights", null, lightRadiusRange));
        }
    }
}
