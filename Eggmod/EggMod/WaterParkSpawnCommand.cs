using System;
using UnityEngine;
using UWE;

// Token: 0x02000008 RID: 8
public class WaterParkSpawnCommand : MonoBehaviour
{
    // Token: 0x06000015 RID: 21 RVA: 0x00003007 File Offset: 0x00001207
    public void Awake()
    {
        DevConsole.RegisterConsoleCommand(this, "waterparkspawn", false, false);
    }

    // Token: 0x06000016 RID: 22 RVA: 0x00003018 File Offset: 0x00001218
    public void OnConsoleCommand_waterparkspawn(NotificationCenter.Notification n)
    {
        bool flag = !Player.main.currentWaterPark;
        if (flag)
        {
            ErrorMessage.AddDebug("Not currently inside a waterpark!");
        }
        else
        {
            bool flag2 = n != null && n.data != null && n.data.Count > 0;
            if (flag2)
            {
                string text = (string)n.data[0];
                TechType techType;
                bool flag3 = UWE.Utils.TryParseEnum<TechType>(text, out techType);
                if (flag3)
                {
                    bool flag4 = CraftData.IsAllowed(techType);
                    if (flag4)
                    {
                        GameObject prefabForTechType = CraftData.GetPrefabForTechType(techType, true);
                        bool flag5 = prefabForTechType != null;
                        if (flag5)
                        {
                            bool flag6 = prefabForTechType.GetComponent<Creature>();
                            if (flag6)
                            {
                                int num = 1;
                                int num2;
                                bool flag7 = n.data.Count > 1 && int.TryParse((string)n.data[1], out num2);
                                if (flag7)
                                {
                                    num = num2;
                                }
                                bool flag8 = n.data.Count > 2;
                                if (flag8)
                                {
                                    float num3 = float.Parse((string)n.data[2]);
                                }
                                Debug.Log(string.Format("Spawning {0} {1}", num, techType));
                                for (int i = 0; i < num; i++)
                                {
                                    WaterParkCreature.Born(techType, Player.main.currentWaterPark, Player.main.transform.position);
                                }
                            }
                            else
                            {
                                ErrorMessage.AddDebug("Not valid creature!");
                            }
                        }
                        else
                        {
                            ErrorMessage.AddDebug("Could not find prefab for TechType = " + techType);
                        }
                    }
                }
                else
                {
                    ErrorMessage.AddDebug("Could not parse " + text + " as TechType");
                }
            }
        }
    }
}
