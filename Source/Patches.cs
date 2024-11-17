using HarmonyLib;
using NineSolsAPI;

namespace TrueDamage;

[HarmonyPatch]
public class Patches {

    [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.ReceiveRecoverableDamage))]
    [HarmonyPostfix]
    private static void PatchReceiveRecoverableDamage(ref PlayerHealth __instance,ref float damage) {
        if(TrueDamage.Instance.isTrueDamage.Value)
            Traverse.Create(__instance).Field("recoverableValue").SetValue(0f);
    }
}