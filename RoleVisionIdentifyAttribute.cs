using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028EE RID: 10478
public class RoleVisionIdentifyAttribute : UiPanelBase
{
	// Token: 0x06014D0A RID: 85258 RVA: 0x005C3DEC File Offset: 0x005C1FEC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014D0B RID: 85259 RVA: 0x005C3E55 File Offset: 0x005C2055
	protected override void OnStart()
	{
		this.AttributeScroller = new GenericLayout<VisionIdentifyItem, VisionSubPropViewData>(base.GetVerticalLayout(0), new Func<VisionIdentifyItem>(this.InitItem), null, false, true);
	}

	// Token: 0x06014D0C RID: 85260 RVA: 0x005C3E78 File Offset: 0x005C2078
	[NullableContext(1)]
	private VisionIdentifyItem InitItem()
	{
		return new VisionIdentifyItem();
	}

	// Token: 0x06014D0D RID: 85261 RVA: 0x005C3E80 File Offset: 0x005C2080
	[NullableContext(2)]
	public void Refresh([Nullable(1)] List<VisionSubPropData> data, PhantomBattleData dataBase, VisionDetailInfoComponentData detailData)
	{
		VisionAttrRecommendInfo roleCostAttrRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleCostAttrRecommendInfo(detailData.RoleId, detailData.Cost);
		List<AttrRecommendInfo> list = (roleCostAttrRecommendInfo != null) ? roleCostAttrRecommendInfo.GetSubAttrRecommendInfo() : null;
		int num = (list != null) ? list.Count : 0;
		List<VisionSubPropViewData> list2 = new List<VisionSubPropViewData>();
		foreach (VisionSubPropData visionSubPropData in data)
		{
			VisionSubPropViewData visionSubPropViewData = new VisionSubPropViewData();
			visionSubPropViewData.Data = visionSubPropData;
			visionSubPropViewData.SourceView = "VisionEquipmentView";
			visionSubPropViewData.CurrentVisionData = dataBase;
			if (visionSubPropData.PhantomSubProp != null)
			{
				PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(visionSubPropData.PhantomSubProp.PhantomPropId);
				if (roleCostAttrRecommendInfo != null)
				{
					for (int i = 0; i < num; i++)
					{
						if (phantomSubPropertyById.AddType == list[i].GetAddType() && phantomSubPropertyById.PropId == list[i].GetAttrId())
						{
							visionSubPropViewData.NeedHighLight = true;
						}
					}
				}
			}
			list2.Add(visionSubPropViewData);
		}
		this.AttributeScroller.RefreshByData(list2, null, false);
	}

	// Token: 0x0400A02F RID: 41007
	[Nullable(new byte[]
	{
		2,
		1,
		2
	})]
	public GenericLayout<VisionIdentifyItem, VisionSubPropViewData> AttributeScroller;

	// Token: 0x02008C47 RID: 35911
	private enum EComponent
	{
		// Token: 0x0402F3F6 RID: 193526
		VerticalLayout,
		// Token: 0x0402F3F7 RID: 193527
		LayoutItem
	}
}
