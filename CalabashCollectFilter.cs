using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x020018E1 RID: 6369
[NullableContext(1)]
[Nullable(0)]
public class CalabashCollectFilter : CommonFilter
{
	// Token: 0x0600B71A RID: 46874 RVA: 0x0030BED8 File Offset: 0x0030A0D8
	protected object GetPhantomItemId(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((CalabashDevelopRewardData)data).DevelopRewardData.MonsterId;
	}

	// Token: 0x0600B71B RID: 46875 RVA: 0x0030BF00 File Offset: 0x0030A100
	protected object GetPhantomRarity(object data, Dictionary<int, string> currentSelectMap)
	{
		int monsterId = ((CalabashDevelopRewardData)data).DevelopRewardData.MonsterId;
		return ModelBase<PhantomBattleModel>.Instance.GetMonsterRarity(monsterId);
	}

	// Token: 0x0600B71C RID: 46876 RVA: 0x0030BF34 File Offset: 0x0030A134
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
