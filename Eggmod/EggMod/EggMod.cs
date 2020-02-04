using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Harmony;
using UnityEngine;
using SMLHelper.V2.Handlers;

// Token: 0x02000002 RID: 2

namespace EggMod
{
    public class Qpatch
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public void PrePatch()
        {
            AssetBundle.LoadFromFile(Path.Combine("Qmods" + "EggMod" + "eggs.assets"));
            TechTypeHandler.AddTechType("GhostRayBlueEgg", "Ghost Ray Egg", "this is the egg from the ghostRay");
            TechTypeHandler.AddTechType("GhostRayBlueEggUndiscovered", "GhostRayBlueEggUndiscovered", "ghostrayegg");
            TechTypeHandler.AddTechType("GhostRayRedEgg", "GhostRayRedEgg", "ghost Ray Red Egg");
            TechTypeHandler.AddTechType("GhostRayRedEggUndiscovered", "GhostRayRedEggUndiscovered", "GhostRayRedEggUndiscovered");
            Dictionary<TechType, float> dictionary = typeof(BaseBioReactor).GetField("charge", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as Dictionary<TechType, float>;
            WaterParkCreature.waterParkCreatureParameters[TechType.GhostRayBlue] = new WaterParkCreatureParameters(0.05f, 0.2f, 0.5f, 1f, false);
            WaterParkCreature.waterParkCreatureParameters[TechType.GhostRayRed] = new WaterParkCreatureParameters(0.05f, 0.2f, 0.5f, 1f, false);
            WaterParkCreature.waterParkCreatureParameters[TechType.ReaperLeviathan] = new WaterParkCreatureParameters(0.03f, 0.05f, 0.5f, 1f, false);
            WaterParkCreature.waterParkCreatureParameters[TechType.GhostLeviathan] = new WaterParkCreatureParameters(0.03f, 0.05f, 0.5f, 1f, false);
            WaterParkCreature.waterParkCreatureParameters[TechType.GhostLeviathanJuvenile] = new WaterParkCreatureParameters(0.03f, 0.05f, 0.5f, 1f, false);
            WaterParkCreature.waterParkCreatureParameters[TechType.SeaDragon] = new WaterParkCreatureParameters(0.03f, 0.05f, 0.5f, 1f, false);
            WaterParkCreature.creatureEggs[TechType.GhostRayBlue] = (TechType)9999;
            WaterParkCreature.creatureEggs[TechType.GhostRayRed] = (TechType)6969;
            CraftDataHandler.SetItemSize(TechType.GhostRayBlue, 3, 3);
            CraftDataHandler.SetItemSize(TechType.GhostRayRed, 3, 3);
            GhostRayBlueEggPrefab ghostRayBlueEggPrefab = new GhostRayBlueEggPrefab("WorldEntities/Eggs/GhostRayBlueEgg", "GhostRayBlueEggID");
            ghostRayBlueEggPrefab.LoadResource();
            PrefabHandler.RegisterPrefab(this);
            GhostRayRedEggPrefab ghostRayRedEggPrefab = new GhostRayRedEggPrefab("WorldEntities/Eggs/GhostRayRedEgg", "GhostRayRedEggID");
            ghostRayRedEggPrefab.LoadResource();
            CustomResourceManager.customResources.Add(ghostRayRedEggPrefab);
        }

        // Token: 0x06000002 RID: 2 RVA: 0x000022F4 File Offset: 0x000004F4
        public static void Something()
        {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("com.suspensionrailway.eggmod");
            harmonyInstance.Patch(typeof(Player).GetMethod("Awake"), new HarmonyMethod(typeof(Qpatch).GetMethod("Prefix")), null, null);
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002343 File Offset: 0x00000543
        public static void Prefix(Player __instance)
        {
            __instance.gameObject.AddComponent<WaterParkSpawnCommand>();
        }

        // Token: 0x04000001 RID: 1
        public static AssetBundle bund;
    }
}
