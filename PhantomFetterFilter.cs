using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using FilterDefine;

// Token: 0x020018EE RID: 6382
public class PhantomFetterFilter : CommonFilter
{
	// Token: 0x0600B755 RID: 46933 RVA: 0x0030C914 File Offset: 0x0030AB14
	[NullableContext(1)]
	protected object GetPhantomItemIdList(object data, Dictionary<int, string> currentSelectMap)
	{
		PhantomFetterGroup phantomFetterGroup = (PhantomFetterGroup)data;
		return ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(phantomFetterGroup.Id).ToArray<int>();
	}

	// Token: 0x0600B756 RID: 46934 RVA: 0x0030C940 File Offset: 0x0030AB40
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity1, new TFilterConfig(this.GetPhantomItemIdList));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity2, new TFilterConfig(this.GetPhantomItemIdList));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity3, new TFilterConfig(this.GetPhantomItemIdList));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity4, new TFilterConfig(this.GetPhantomItemIdList));
	}
}
