using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Phantom.Vision.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024F4 RID: 9460
[NullableContext(2)]
[Nullable(0)]
public class VisionDetailInfoComponent : UiPanelBase
{
	// Token: 0x060125FF RID: 75263 RVA: 0x0050D729 File Offset: 0x0050B929
	[NullableContext(1)]
	public VisionDetailInfoComponent(UUIItem actor)
	{
		this.SourceItem = actor;
	}

	// Token: 0x06012600 RID: 75264 RVA: 0x0050D738 File Offset: 0x0050B938
	public UniTask Init()
	{
		VisionDetailInfoComponent.<Init>d__9 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<VisionDetailInfoComponent.<Init>d__9>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06012601 RID: 75265 RVA: 0x0050D77C File Offset: 0x0050B97C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06012602 RID: 75266 RVA: 0x0050D828 File Offset: 0x0050BA28
	protected override UniTask OnBeforeStartAsync()
	{
		VisionDetailInfoComponent.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionDetailInfoComponent.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012603 RID: 75267 RVA: 0x0050D86B File Offset: 0x0050BA6B
	protected override void OnStart()
	{
		this.RoleVisionAttribute = new RoleVisionAttribute(base.GetItem(1));
		this.RoleVisionAttribute.Init();
	}

	// Token: 0x06012604 RID: 75268 RVA: 0x0050D88A File Offset: 0x0050BA8A
	[NullableContext(1)]
	public void SetClickCallBack(Action call)
	{
		this.OnClickMainItemCall = call;
	}

	// Token: 0x06012605 RID: 75269 RVA: 0x0050D893 File Offset: 0x0050BA93
	protected void OnClickArrow()
	{
		Action onClickMainItemCall = this.OnClickMainItemCall;
		if (onClickMainItemCall == null)
		{
			return;
		}
		onClickMainItemCall();
	}

	// Token: 0x06012606 RID: 75270 RVA: 0x0050D8A5 File Offset: 0x0050BAA5
	[NullableContext(1)]
	public void Refresh(VisionDetailInfoComponentData data, bool ifCompare, bool ifSimple)
	{
		this.CurrentData = data;
		this.VisionDetailTop.Update(this.CurrentData.DataBase);
		this.VisionDetailTop.SetActive(true);
		this.RefreshMain();
		this.RefreshSub();
		this.RefreshDescComponent();
	}

	// Token: 0x06012607 RID: 75271 RVA: 0x0050D8E2 File Offset: 0x0050BAE2
	public UUIItem GetTxtItemByIndex(int index)
	{
		VisionDetailDescComponent visionDetailDescComponent = this.VisionDetailDescComponent;
		if (visionDetailDescComponent == null)
		{
			return null;
		}
		return visionDetailDescComponent.GetTxtItemByIndex(index);
	}

	// Token: 0x06012608 RID: 75272 RVA: 0x0050D8F6 File Offset: 0x0050BAF6
	private void RefreshDescComponent()
	{
		this.VisionDetailDescComponent.Refresh(this.CurrentData.DescData, false);
		this.VisionDetailDescComponent.SetActive(true);
	}

	// Token: 0x06012609 RID: 75273 RVA: 0x0050D91C File Offset: 0x0050BB1C
	private void RefreshMain()
	{
		VisionAttrRecommendInfo roleCostAttrRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleCostAttrRecommendInfo(this.CurrentData.RoleId, this.CurrentData.Cost);
		List<AttrListScrollData> mainPropData = this.CurrentData.GetMainPropData(false);
		List<AttrListScrollData> mainPropData2 = this.CurrentData.GetMainPropData(true);
		int count = mainPropData2.Count;
		List<AttrRecommendInfo> list = (roleCostAttrRecommendInfo != null) ? roleCostAttrRecommendInfo.GetMainAttrRecommendInfo() : null;
		for (int i = 0; i < count; i++)
		{
			if (roleCostAttrRecommendInfo != null)
			{
				int count2 = list.Count;
				for (int j = 0; j < count2; j++)
				{
					if (mainPropData2[i].AddValue == (double)list[j].GetAddType() && mainPropData2[i].Id == list[j].GetAttrId())
					{
						mainPropData[i].NeedHighLight = true;
					}
				}
			}
		}
		this.RoleVisionAttribute.Refresh(mainPropData, false);
	}

	// Token: 0x0601260A RID: 75274 RVA: 0x0050D9FC File Offset: 0x0050BBFC
	private void RefreshSub()
	{
		List<VisionSubPropData> subPropData = this.CurrentData.GetSubPropData();
		if (subPropData.Count > 0)
		{
			RoleVisionIdentifyAttribute roleVisionSubAttribute = this.RoleVisionSubAttribute;
			List<VisionSubPropData> data = subPropData;
			VisionDetailInfoComponentData currentData = this.CurrentData;
			roleVisionSubAttribute.Refresh(data, (currentData != null) ? currentData.DataBase : null, this.CurrentData);
			this.RoleVisionSubAttribute.SetActive(true);
			return;
		}
		this.RoleVisionSubAttribute.SetActive(false);
	}

	// Token: 0x04008F4B RID: 36683
	private VisionDetailTop VisionDetailTop;

	// Token: 0x04008F4C RID: 36684
	private VisionDetailInfoComponentData CurrentData;

	// Token: 0x04008F4D RID: 36685
	private RoleVisionAttribute RoleVisionAttribute;

	// Token: 0x04008F4E RID: 36686
	private RoleVisionIdentifyAttribute RoleVisionSubAttribute;

	// Token: 0x04008F4F RID: 36687
	private VisionDetailDescComponent VisionDetailDescComponent;

	// Token: 0x04008F50 RID: 36688
	private Action OnClickMainItemCall;

	// Token: 0x04008F51 RID: 36689
	private readonly UUIItem SourceItem;

	// Token: 0x0200880B RID: 34827
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DF52 RID: 188242
		TopPanel,
		// Token: 0x0402DF53 RID: 188243
		AttributeItem,
		// Token: 0x0402DF54 RID: 188244
		AttributeItemSub,
		// Token: 0x0402DF55 RID: 188245
		ItemParent
	}
}
