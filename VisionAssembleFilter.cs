using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x020018F6 RID: 6390
public class VisionAssembleFilter : CommonFilter
{
	// Token: 0x0600B774 RID: 46964 RVA: 0x0030CE24 File Offset: 0x0030B024
	[NullableContext(1)]
	private object GetVisionAssembleGroupAttribute(object data, Dictionary<int, string> currentSelectMap)
	{
		List<int> list = new List<int>();
		foreach (VisionAssembleAttrData visionAssembleAttrData in ModelBase<VisionEquipGroupModel>.Instance.GetVisionAssembleViewAttrData((int)data, false, 0))
		{
			int attrId = visionAssembleAttrData.AttrId;
			int num = (!visionAssembleAttrData.IfPercentage) ? 1 : 2;
			int item = attrId * 10 + num;
			if (!list.Contains(item))
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600B775 RID: 46965 RVA: 0x0030CEB4 File Offset: 0x0030B0B4
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.Attribute, new TFilterConfig(this.GetVisionAssembleGroupAttribute));
	}
}
