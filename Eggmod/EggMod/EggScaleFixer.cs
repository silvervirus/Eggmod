using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class EggScaleFixer : MonoBehaviour
{
    // Token: 0x0600000F RID: 15 RVA: 0x00002CCE File Offset: 0x00000ECE
    public void Awake()
    {
        base.gameObject.transform.localScale = this.scale;
        this.egg = base.gameObject.GetComponent<CreatureEgg>();
    }

    // Token: 0x06000010 RID: 16 RVA: 0x00002CF9 File Offset: 0x00000EF9
    public void Start()
    {
        base.gameObject.transform.localScale = this.scale;
    }

    // Token: 0x06000011 RID: 17 RVA: 0x00002D14 File Offset: 0x00000F14
    public void OnDropped(Pickupable pickupable)
    {
        bool flag = base.gameObject.transform.parent == null;
        if (flag)
        {
            bool flag2 = base.gameObject.transform.localScale != this.scale;
            if (flag2)
            {
                base.gameObject.transform.localScale = this.scale;
            }
        }
        else
        {
            Transform parent = base.gameObject.transform.parent;
            this.AdjustedScale.x = this.scale.x / parent.localScale.x;
            this.AdjustedScale.y = this.scale.y / parent.localScale.y;
            this.AdjustedScale.z = this.scale.z / parent.localScale.z;
            bool flag3 = base.gameObject.transform.localScale != this.AdjustedScale;
            if (flag3)
            {
                base.gameObject.transform.localScale = this.AdjustedScale;
            }
        }
    }

    // Token: 0x06000012 RID: 18 RVA: 0x00002E2C File Offset: 0x0000102C
    public void UpdateAdjustedScale()
    {
        Transform parent = base.gameObject.transform.parent;
        this.AdjustedScale.x = this.scale.x / parent.localScale.x;
        this.AdjustedScale.y = this.scale.y / parent.localScale.y;
        this.AdjustedScale.z = this.scale.z / parent.localScale.z;
        parent = parent.parent;
        while (parent != null)
        {
            this.AdjustedScale.x = this.AdjustedScale.x / parent.localScale.x;
            this.AdjustedScale.y = this.AdjustedScale.y / parent.localScale.y;
            this.AdjustedScale.z = this.AdjustedScale.z / parent.localScale.z;
            parent = parent.parent;
        }
    }

    // Token: 0x06000013 RID: 19 RVA: 0x00002F34 File Offset: 0x00001134
    public void Update()
    {
        bool flag = base.gameObject.transform.parent == null;
        if (flag)
        {
            bool flag2 = base.gameObject.transform.localScale != this.scale;
            if (flag2)
            {
                base.gameObject.transform.localScale = this.scale;
            }
        }
        else
        {
            this.UpdateAdjustedScale();
            bool flag3 = base.gameObject.transform.localScale != this.AdjustedScale;
            if (flag3)
            {
                base.gameObject.transform.localScale = this.AdjustedScale;
            }
        }
    }

    // Token: 0x04000002 RID: 2
    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);

    // Token: 0x04000003 RID: 3
    private Vector3 AdjustedScale = Vector3.zero;

    // Token: 0x04000004 RID: 4
    private CreatureEgg egg;
}
