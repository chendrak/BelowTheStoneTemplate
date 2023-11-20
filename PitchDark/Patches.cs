using BelowTheStone;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace PitchDark {
    [HarmonyPatch]
    public static class Patches {
        [HarmonyPatch(typeof(PlayerObject), nameof(PlayerObject.Awake)), HarmonyPostfix]
        public static void PlayerLightChange(PlayerObject __instance) {
            GameObject playerLamp = GameObject.Find("Player Lamp");

            if (playerLamp) {
                foreach (Light2D light in playerLamp.GetComponentsInChildren<Light2D>()) {
                    light.pointLightInnerRadius = Plugin.playerLightInnerRadius.Value;
                    light.pointLightOuterRadius = Mathf.Max(Plugin.playerLightInnerRadius.Value, Plugin.playerLightOuterRadius.Value);
                }
            }
        }

        [HarmonyPatch(typeof(PlacedEntity), "Awake")]
        [HarmonyPatch(typeof(EquippedItem), "Awake")]
        [HarmonyPostfix]
        public static void TorchLightChange(PlacedEntity __instance) {
            if (__instance.name == "torch_placed(Clone)" || __instance.name == "placeable_item_prefab_torch(Clone)") {
                foreach (Light2D light in __instance.GetComponentsInChildren<Light2D>()) {
                    light.pointLightInnerRadius = Plugin.torchLightInnerRadius.Value;
                    light.pointLightOuterRadius = Mathf.Max(Plugin.torchLightInnerRadius.Value, Plugin.torchLightOuterRadius.Value);
                }
            }
        }
    }
}
