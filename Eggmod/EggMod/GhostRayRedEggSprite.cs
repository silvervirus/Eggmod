using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class GhostRayRedEggSprite : CustomResource
{
    // Token: 0x0600000D RID: 13 RVA: 0x00002CA4 File Offset: 0x00000EA4
    public override Object LoadResource()
    {
        bool flag = this.Resource == null;
        if (flag)
        {
        }
        return this.Resource;
    }

    // Token: 0x0600000E RID: 14 RVA: 0x00002822 File Offset: 0x00000A22
    public GhostRayRedEggSprite(string path, string key) : base(path, key)
    {
        this.LoadResource();
    }
}
