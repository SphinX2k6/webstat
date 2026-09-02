using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;
using FilterDefine;

// Token: 0x020018E8 RID: 6376
public class DungeonDetectFilter : CommonFilter
{
	// Token: 0x0600B73A RID: 46906 RVA: 0x0030C300 File Offset: 0x0030A500
	[NullableContext(1)]
	private object GetDungeonDetectConfig(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((DungeonDetectionRecord)data).Conf.Secondary;
	}

	// Token: 0x0600B73B RID: 46907 RVA: 0x0030C325 File Offset: 0x0030A525
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.DungeonDetect, new TFilterConfig(this.GetDungeonDetectConfig));
	}
}
