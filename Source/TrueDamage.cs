using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using NineSolsAPI;
using UnityEngine;
using XInputDotNetPure;

namespace TrueDamage;

[BepInDependency(NineSolsAPICore.PluginGUID)]
[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class TrueDamage : BaseUnityPlugin {
    public static TrueDamage Instance { get; private set; }
    private Harmony harmony = null!;

    public ConfigEntry<bool> isTrueDamage = null!;

    private void Awake() {
        Log.Init(Logger);
        RCGLifeCycle.DontDestroyForever(gameObject);

        harmony = Harmony.CreateAndPatchAll(typeof(TrueDamage).Assembly);

        isTrueDamage = Config.Bind("", "Enable True Damage", true, "No internal damage direct hurt");

        Instance = this;
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }

    private void OnDestroy() {

        harmony.UnpatchSelf();
    }
}