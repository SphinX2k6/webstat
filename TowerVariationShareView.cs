using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C0A RID: 11274
public class TowerVariationShareView : UiPanelBase
{
	// Token: 0x060167D6 RID: 92118 RVA: 0x006405AC File Offset: 0x0063E7AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x060167D7 RID: 92119 RVA: 0x006406BC File Offset: 0x0063E8BC
	protected override UniTask OnBeforeStartAsync()
	{
		TowerVariationShareView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TowerVariationShareView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060167D8 RID: 92120 RVA: 0x00640700 File Offset: 0x0063E900
	protected override void OnStart()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "InstanceDungeonTitle_31_CommonText", Array.Empty<object>());
		int difficultyMaxStars = ModelBase<TowerModel>.Instance.GetDifficultyMaxStars(3, false);
		int difficultyAllStars = ModelBase<TowerModel>.Instance.GetDifficultyAllStars(3, false);
		base.GetText(2).SetText(difficultyMaxStars.ToString(), true);
		base.GetText(3).SetText("/" + difficultyAllStars.ToString(), true);
		int[] difficultyAllAreaFirstFloor = ModelBase<TowerModel>.Instance.GetDifficultyAllAreaFirstFloor(3, false);
		int num = 0;
		TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(difficultyAllAreaFirstFloor[num]);
		int areaStars = ModelBase<TowerModel>.Instance.GetAreaStars(towerInfo.Value.Difficulty, towerInfo.Value.AreaNum, false);
		base.GetText(4).SetText(areaStars.ToString(), true);
		int[] difficultyAreaAllFloor = ModelBase<TowerModel>.Instance.GetDifficultyAreaAllFloor(towerInfo.Value.Difficulty, towerInfo.Value.AreaNum);
		this.TowerOneTeamItem.Refresh(difficultyAreaAllFloor[difficultyAreaAllFloor.Length - 1], true, 0);
		int num2 = 2;
		TowerConfig? towerInfo2 = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(difficultyAllAreaFirstFloor[num2]);
		int areaStars2 = ModelBase<TowerModel>.Instance.GetAreaStars(towerInfo2.Value.Difficulty, towerInfo2.Value.AreaNum, false);
		base.GetText(6).SetText(areaStars2.ToString(), true);
		int[] difficultyAreaAllFloor2 = ModelBase<TowerModel>.Instance.GetDifficultyAreaAllFloor(towerInfo2.Value.Difficulty, towerInfo2.Value.AreaNum);
		this.TowerTwoTeamItem.Refresh(difficultyAreaAllFloor2[difficultyAreaAllFloor2.Length - 1], true, 0);
		int num3 = 1;
		TowerConfig? towerInfo3 = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(difficultyAllAreaFirstFloor[num3]);
		int areaStars3 = ModelBase<TowerModel>.Instance.GetAreaStars(towerInfo3.Value.Difficulty, towerInfo3.Value.AreaNum, false);
		base.GetText(8).SetText(areaStars3.ToString(), true);
		this.TowerThreeTeamsLayout = new GenericLayout<TowerVariationShareTeamItem, int>(base.GetVerticalLayout(9), new Func<TowerVariationShareTeamItem>(this.InitTowerThreeTeamItem), null, false, true);
		int[] difficultyAreaAllFloor3 = ModelBase<TowerModel>.Instance.GetDifficultyAreaAllFloor(towerInfo3.Value.Difficulty, towerInfo3.Value.AreaNum);
		this.TowerThreeTeamsLayout.RefreshByData(difficultyAreaAllFloor3, null, false);
		bool flag = true;
		foreach (int towerId in difficultyAreaAllFloor3)
		{
			if (ModelBase<TowerModel>.Instance.GetFloorFormation(towerId).Count > 0)
			{
				flag = false;
				break;
			}
		}
		this.TowerThreeTeamsLayout.GetRootUiItem().SetUIActive(!flag);
		base.GetItem(11).SetUIActive(flag);
	}

	// Token: 0x060167D9 RID: 92121 RVA: 0x006409BA File Offset: 0x0063EBBA
	[NullableContext(1)]
	private TowerVariationShareTeamItem InitTowerThreeTeamItem()
	{
		return new TowerVariationShareTeamItem();
	}

	// Token: 0x0400AE01 RID: 44545
	[Nullable(2)]
	private TowerVariationShareTeamItem TowerOneTeamItem;

	// Token: 0x0400AE02 RID: 44546
	[Nullable(2)]
	private TowerVariationShareTeamItem TowerTwoTeamItem;

	// Token: 0x0400AE03 RID: 44547
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerVariationShareTeamItem, int> TowerThreeTeamsLayout;

	// Token: 0x02008F08 RID: 36616
	private enum EComponents
	{
		// Token: 0x040300BC RID: 196796
		Icon,
		// Token: 0x040300BD RID: 196797
		TitleText,
		// Token: 0x040300BE RID: 196798
		StarNumText,
		// Token: 0x040300BF RID: 196799
		StarMaxNumText,
		// Token: 0x040300C0 RID: 196800
		TowerOneStarNumText,
		// Token: 0x040300C1 RID: 196801
		TowerOneTeamItem,
		// Token: 0x040300C2 RID: 196802
		TowerTwoStarNumText,
		// Token: 0x040300C3 RID: 196803
		TowerTwoTeamItem,
		// Token: 0x040300C4 RID: 196804
		TowerThreeStarNumText,
		// Token: 0x040300C5 RID: 196805
		TowerThreeTeamsLayout,
		// Token: 0x040300C6 RID: 196806
		TowerThreeTeamItem,
		// Token: 0x040300C7 RID: 196807
		TowerThreeEmptyItem
	}
}
