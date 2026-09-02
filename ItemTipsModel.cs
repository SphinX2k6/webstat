using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Item;

// Token: 0x02001994 RID: 6548
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ItemTipsModel : ModelBase<ItemTipsModel>
{
	// Token: 0x17000F4F RID: 3919
	// (get) Token: 0x0600BBFE RID: 48126 RVA: 0x0031EC6C File Offset: 0x0031CE6C
	public int DebugCacheTipsItemId
	{
		get
		{
			return this.DebugCacheTipsItemIdInternal;
		}
	}

	// Token: 0x0600BBFF RID: 48127 RVA: 0x0031EC74 File Offset: 0x0031CE74
	public void SetCurrentItemTipsData(ItemTipsData itemTipsData)
	{
		this.CurrentItemTipsData = itemTipsData;
		if (!Singleton<Info>.Instance.IsBuildShipping && itemTipsData != null)
		{
			this.DebugCacheTipsItemIdInternal = itemTipsData.ConfigId;
		}
	}

	// Token: 0x0600BC00 RID: 48128 RVA: 0x0031EC98 File Offset: 0x0031CE98
	public ItemTipsData GetCurrentItemTipsData()
	{
		return this.CurrentItemTipsData;
	}

	// Token: 0x040058FB RID: 22779
	private ItemTipsData CurrentItemTipsData;

	// Token: 0x040058FC RID: 22780
	public ItemTipsParam SharpTempOpenParam;

	// Token: 0x040058FD RID: 22781
	private int DebugCacheTipsItemIdInternal;
}
