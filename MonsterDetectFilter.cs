using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;
using FilterDefine;

// Token: 0x020018EC RID: 6380
[NullableContext(1)]
[Nullable(0)]
public class MonsterDetectFilter : CommonFilter
{
	// Token: 0x0600B74D RID: 46925 RVA: 0x0030C7B0 File Offset: 0x0030A9B0
	private object GetMonsterDetectConfig(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((MonsterDetectionRecord)data).Conf.DangerType;
	}

	// Token: 0x0600B74E RID: 46926 RVA: 0x0030C7D8 File Offset: 0x0030A9D8
	private object GetMonsterTypeConfig(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((MonsterDetectionRecord)data).Conf.TypeDescription2;
	}

	// Token: 0x0600B74F RID: 46927 RVA: 0x0030C7FD File Offset: 0x0030A9FD
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.MonsterDetect, new TFilterConfig(this.GetMonsterDetectConfig));
		this.FilterMap.Add(FilterDefine.EFilterType.MonsterType, new TFilterConfig(this.GetMonsterTypeConfig));
	}
}
