using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029E5 RID: 10725
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerTeamRecommendView : UiViewBase
{
	// Token: 0x06015603 RID: 87555 RVA: 0x005EC638 File Offset: 0x005EA838
	public ShipTowerTeamRecommendView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015604 RID: 87556 RVA: 0x005EC644 File Offset: 0x005EA844
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06015605 RID: 87557 RVA: 0x005EC6AD File Offset: 0x005EA8AD
	private void InitDataParam()
	{
		object openParam = this.OpenParam;
	}

	// Token: 0x06015606 RID: 87558 RVA: 0x005EC6B8 File Offset: 0x005EA8B8
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerTeamRecommendView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerTeamRecommendView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015607 RID: 87559 RVA: 0x005EC6FB File Offset: 0x005EA8FB
	protected override void OnBeforeShow()
	{
		this.UpdateData();
	}

	// Token: 0x06015608 RID: 87560 RVA: 0x005EC703 File Offset: 0x005EA903
	private ShipTowerTeamRecommendItem CreateRecommendItem()
	{
		return new ShipTowerTeamRecommendItem
		{
			ClickCallBack = new Action<ShipTowerTeamRecommendItemData>(this.UseTeamRecommend)
		};
	}

	// Token: 0x06015609 RID: 87561 RVA: 0x005EC71C File Offset: 0x005EA91C
	public void UpdateData()
	{
		ShipTowerTeamRecommendViewParams shipTowerTeamRecommendViewParams = this.OpenParam as ShipTowerTeamRecommendViewParams;
		ShipTowerStageData shipTowerStageData = (shipTowerTeamRecommendViewParams != null) ? shipTowerTeamRecommendViewParams.StageData : null;
		List<ShipTowerTeamRecommendItemData> list = ((shipTowerStageData != null) ? shipTowerStageData.TeamRecommendList : null) ?? new List<ShipTowerTeamRecommendItemData>();
		GenericScrollViewNew<ShipTowerTeamRecommendItem, ShipTowerTeamRecommendItemData> scrollTeam = this.ScrollTeam;
		if (scrollTeam != null)
		{
			scrollTeam.RefreshByData(list, null, false);
		}
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(list.Count <= 0);
	}

	// Token: 0x0601560A RID: 87562 RVA: 0x005EC788 File Offset: 0x005EA988
	private void UseTeamRecommend(ShipTowerTeamRecommendItemData data)
	{
		ShipTowerTeamRecommendViewParams shipTowerTeamRecommendViewParams = this.OpenParam as ShipTowerTeamRecommendViewParams;
		ShipTowerStageData shipTowerStageData = (shipTowerTeamRecommendViewParams != null) ? shipTowerTeamRecommendViewParams.StageData : null;
		if (shipTowerStageData == null || !shipTowerStageData.IsCanApplyTeamRecommend(data))
		{
			return;
		}
		if (shipTowerStageData == null || !shipTowerStageData.UseTeamRecommend(data))
		{
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GhostShipTeamUsed_Text", Array.Empty<object>());
		base.CloseMe(null);
	}

	// Token: 0x0400A499 RID: 42137
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ShipTowerTeamRecommendItem, ShipTowerTeamRecommendItemData> ScrollTeam;

	// Token: 0x02008D56 RID: 36182
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F86E RID: 194670
		public const int ScrollBarRoot = 0;

		// Token: 0x0402F86F RID: 194671
		public const int TxtNo = 1;
	}
}
