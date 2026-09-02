using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;
using FilterDefine;

// Token: 0x020018F5 RID: 6389
public class SilentAreaDetectFilter : CommonFilter
{
	// Token: 0x0600B771 RID: 46961 RVA: 0x0030CDBC File Offset: 0x0030AFBC
	[NullableContext(1)]
	private object GetSilentAreaDetectConfig(object data, Dictionary<int, string> currentSelectMap)
	{
		ISilentAreaDetectionDynamicData silentAreaDetectionDynamicData = (ISilentAreaDetectionDynamicData)data;
		if (silentAreaDetectionDynamicData.SilentAreaDetectionData != null)
		{
			return silentAreaDetectionDynamicData.SilentAreaDetectionData.Conf.Secondary;
		}
		return silentAreaDetectionDynamicData.SilentAreaTitleData.TypeDescription;
	}

	// Token: 0x0600B772 RID: 46962 RVA: 0x0030CE01 File Offset: 0x0030B001
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.SilentAreaDetect, new TFilterConfig(this.GetSilentAreaDetectConfig));
	}
}
