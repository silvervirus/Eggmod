using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class GhostRayBlueEggSprite : CustomResource
{
    // Token: 0x06000008 RID: 8 RVA: 0x000027F8 File Offset: 0x000009F8
    public override Object LoadResource()
    {
        bool flag = this.Resource == null;
        if (flag)
        {
        }
        return this.Resource;
    }

    // Token: 0x06000009 RID: 9 RVA: 0x00002822 File Offset: 0x00000A22
    public GhostRayBlueEggSprite(string path, string key) : base(path, key)
    {
        this.LoadResource();
    }
}
