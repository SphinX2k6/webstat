using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x020018EF RID: 6383
[NullableContext(1)]
[Nullable(0)]
public class PhantomFilter : CommonFilter
{
	// Token: 0x0600B758 RID: 46936 RVA: 0x0030C9B9 File Offset: 0x0030ABB9
	protected object GetPhantomItemId(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((IPhantomItemData)data).MonsterId;
	}

	// Token: 0x0600B759 RID: 46937 RVA: 0x0030C9CB File Offset: 0x0030ABCB
	protected object GetPhantomRarity(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((IPhantomItemData)data).Rarity;
	}

	// Token: 0x0600B75A RID: 46938 RVA: 0x0030C9E0 File Offset: 0x0030ABE0
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.Phantom, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.PhantomRarity, new TFilterConfig(this.GetPhantomRarity));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity1, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity2, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity3, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity4, new TFilterConfig(this.GetPhantomItemId));
	}
}
