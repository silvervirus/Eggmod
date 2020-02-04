using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UWE;
using SMLHelper.V2.Handlers;

// Token: 0x02000005 RID: 5
public class GhostRayRedEggPrefab 
{
    // Token: 0x0600000A RID: 10 RVA: 0x00002838 File Offset: 0x00000A38
    public void Patch()
    {
        PrefabDatabasePatcher.customPrefabs.Add(this);
        EntTechDataPatcher.customTechData.Add(Path.GetFileName(this.Path), (TechType)6969);
        LanguagePatcher.customLanguageLines.Add("GhostRayRedEgg", "Crimson Ray Egg");
        LanguagePatcher.customLanguageLines.Add("Tooltip_GhostRayRedEgg", "The egg of a lava zone Crimson Ray");
        LanguagePatcher.customLanguageLines.Add("GhostRayRedEggUndiscovered", "Inactive Lava Zone egg");
        LanguagePatcher.customLanguageLines.Add("Tooltip_GhostRayRedEggUndiscovered", "Undiscovered Egg from the Inactive Lava Zone");
        CraftDataHandler.SetHarvestType(Techtype."GhostRayRedEgg", HarvestType.Pick);
        CraftDataHandler.GetCraftDataDictionary<Dictionary<TechType, string>>("pickupSoundList").Add((TechType)6969, "event:/loot/pickup_egg");
        CraftDataHandler.GetCraftDataDictionary<Dictionary<TechType, string>>("pickupSoundList").Add((TechType)6968, "event:/loot/pickup_egg");
        CraftDataHandler.GetCraftDataDictionary<Dictionary<TechType, Vector2int>>("itemSizes").Add((TechType)6968, new Vector2int(2, 2));
        CraftDataHandler.GetCraftDataDictionary<Dictionary<TechType, Vector2int>>("itemSizes").Add((TechType)6969, new Vector2int(2, 2));
        LootPatcher.customLootTables.Add(this.Key, new LootDistributionData.SrcData
        {
            prefabPath = this.Path,
            distribution = new List<LootDistributionData.BiomeData>
            {
                new LootDistributionData.BiomeData
                {
                    biome = BiomeType.InactiveLavaZone_Chamber_Floor,
                    count = 1,
                    probability = 0.1f
                }
            }
        });
        WorldEntityInfoPatcher.customWorldEntityInfo.Add(new WorldEntityInfo
        {
            cellLevel = LargeWorldEntity.CellLevel.Near,
            classId = this.Key,
            techType = (TechType)6969,
            slotType = EntitySlot.Type.Small,
            localScale = Vector3.one,
            prefabZUp = true
        });
        this.LoadResource();
    }

    // Token: 0x0600000B RID: 11 RVA: 0x000029E8 File Offset: 0x00000BE8
    public override Object LoadResource()
    {
        bool flag = this.Resource == null;
        if (flag)
        {
            GameObject gameObject = Resources.Load<GameObject>("WorldEntities/Eggs/BonesharkEgg");
            GameObject gameObject2 = AssetBundleLoader.LoadedBundle.LoadAsset("Capsule 1") as GameObject;
            SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
            gameObject2.name = "GhostRayRedEgg";
            PrefabIdentifier prefabIdentifier = gameObject2.AddComponent<PrefabIdentifier>();
            gameObject2.AddComponent<LargeWorldEntity>().cellLevel = LargeWorldEntity.CellLevel.Near;
            prefabIdentifier.ClassId = this.Key;
            Rigidbody component = gameObject2.GetComponent<Rigidbody>();
            component.isKinematic = true;
            Pickupable pickupable = gameObject2.AddComponent<Pickupable>();
            CreatureEgg creatureEgg = gameObject2.AddComponent<CreatureEgg>();
            creatureEgg.daysBeforeHatching = 1.5f;
            gameObject2.AddComponent<EntityTag>().slotType = EntitySlot.Type.Small;
            WorldForces worldForces = gameObject2.AddComponent<WorldForces>();
            worldForces.handleGravity = true;
            worldForces.underwaterGravity = 2f;
            worldForces.useRigidbody = component;
            worldForces.aboveWaterGravity = 9.81f;
            worldForces.underwaterDrag = 1f;
            worldForces.aboveWaterDrag = 0.1f;
            worldForces.handleDrag = true;
            SkyApplier skyApplier = gameObject2.AddComponent<SkyApplier>();
            MeshRenderer component2 = gameObject2.GetComponent<MeshRenderer>();
            skyApplier.renderers = new Renderer[]
            {
                component2
            };
            skyApplier.anchorSky = Skies.Auto;
            Texture mainTexture = component2.sharedMaterial.mainTexture;
            Texture mainTexture2 = component2.material.mainTexture;
            component2.material.shader = componentInChildren.material.shader;
            component2.material.color = new Color(0.75f, 0f, 0f);
            component2.sharedMaterial.shader = componentInChildren.sharedMaterial.shader;
            component2.material.SetFloat("_SpecInt", 16f);
            component2.material.SetFloat("_Shininess", 7.5f);
            component2.material.SetTexture("_SpecText", mainTexture2);
            LiveMixin liveMixin = gameObject2.AddComponent<LiveMixin>();
            liveMixin.data = ScriptableObject.CreateInstance<LiveMixinData>();
            LiveMixinData data = liveMixin.data;
            liveMixin.health = 25f;
            data.maxHealth = 25f;
            data.knifeable = true;
            data.destroyOnDeath = true;
            data.explodeOnDestroy = true;
            ResourceTracker resourceTracker = gameObject2.AddComponent<ResourceTracker>();
            resourceTracker.overrideTechType = TechType.GenericEgg;
            resourceTracker.prefabIdentifier = prefabIdentifier;
            resourceTracker.rb = component;
            resourceTracker.pickupable = pickupable;
            creatureEgg.overrideEggType = (TechType)6968;
            Animator animator = gameObject2.AddComponent<Animator>();
            creatureEgg.animator = animator;
            creatureEgg.hatchingCreature = TechType.GhostRayRed;
            gameObject2.AddComponent<ScaleFixer>().scale = new Vector3(0.5f, 0.5f, 0.5f);
            this.Resource = gameObject2;
        }
        return this.Resource;
    }

    // Token: 0x0600000C RID: 12 RVA: 0x000027E9 File Offset: 0x000009E9
    public GhostRayRedEggPrefab(string path, string key) : base(path, key)
    {
    }
}
