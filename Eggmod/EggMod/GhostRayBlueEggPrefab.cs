using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UWE;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Handlers;
// Token: 0x02000003 RID: 3
public class GhostRayBlueEggPrefab 
{
    // Token: 0x06000005 RID: 5 RVA: 0x0000235C File Offset: 0x0000055C
    public  void Patch()
    {

        TechTypeHandler.customTechData.Add(Path.GetFileName(this.Path), (TechType)9999);
        LanguageHandler.SetLanguageLine("GhostRayBlueEgg", "Ghost Ray Egg");
        LanguageHandler.SetLanguageLine("Tooltip_GhostRayBlueEgg", "The egg of a lost river Ghost Ray");
        LanguageHandler.SetLanguageLine("GhostRayBlueEggUndiscovered", "Lost River Egg");
        LanguageHandler.SetLanguageLine("Tooltip_GhostRayBlueEggUndiscovered", "Undiscovered Egg from the Lost River");
        CraftDataHelper.GetCraftDataDictionary<Dictionary<TechType, HarvestType>>("harvestTypeList").Add((TechType)9999, HarvestType.Pick);
        CraftDataHelper.GetCraftDataDictionary<Dictionary<TechType, string>>("pickupSoundList").Add((TechType)9999, "event:/loot/pickup_egg");
        CraftDataHelper.GetCraftDataDictionary<Dictionary<TechType, string>>("pickupSoundList").Add((TechType)9998, "event:/loot/pickup_egg");
        CraftDataHelper.GetCraftDataDictionary<Dictionary<TechType, Vector2int>>("itemSizes").Add((TechType)9998, new Vector2int(2, 2));
        CraftDataHelper.GetCraftDataDictionary<Dictionary<TechType, Vector2int>>("itemSizes").Add((TechType)9999, new Vector2int(2, 2));
        LootPatcher.customLootTables.Add(this.Key, new LootDistributionData.SrcData
        {
            prefabPath = this.Path,
            distribution = new List<LootDistributionData.BiomeData>
            {
                new LootDistributionData.BiomeData
                {
                    biome = BiomeType.TreeCove_LakeFloor,
                    count = 1,
                    probability = 0.2f
                }
            }
        });
        WorldEntityInfoPatcher.customWorldEntityInfo.Add(new WorldEntityInfo
        {
            cellLevel = LargeWorldEntity.CellLevel.Near,
            classId = this.Key,
            
            slotType = EntitySlot.Type.Small,
            localScale = Vector3.one,
            prefabZUp = true
        });
        this.LoadResource();
    }

    // Token: 0x06000006 RID: 6 RVA: 0x0000250C File Offset: 0x0000070C
    public override Object LoadResource()
    {
        bool flag = this.Resource == null;
        if (flag)
        {
            GameObject gameObject = Resources.Load<GameObject>("WorldEntities/Eggs/JellyrayEgg");
            Debug.Log("hhhh " + (AssetBundle.LoadedBundle == null).ToString());
            GameObject gameObject2 = AssetBundleLoader.LoadedBundle.LoadAsset("Capsule") as GameObject;
            SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
            gameObject2.name = "GhostRayBlueEgg";
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
            component2.material.color = new Color(0f, 0.490196079f, 0.490196079f);
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
            creatureEgg.overrideEggType = (TechType)9998;
            Animator animator = gameObject2.AddComponent<Animator>();
            creatureEgg.animator = animator;
            creatureEgg.hatchingCreature = TechType.GhostRayBlue;
            gameObject2.AddComponent<ScaleFixer>().scale = new Vector3(0.5f, 0.5f, 0.5f);
            this.Resource = gameObject2;
        }
        return this.Resource;
    }

    // Token: 0x06000007 RID: 7 RVA: 0x000027E9 File Offset: 0x000009E9
    public GhostRayBlueEggPrefab(string path, string key) : base(path, key)
    {
    }
}
