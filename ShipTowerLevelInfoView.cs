using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029BA RID: 10682
public class ShipTowerLevelInfoView : UiViewBase
{
	// Token: 0x060154E7 RID: 87271 RVA: 0x005E7D15 File Offset: 0x005E5F15
	[NullableContext(1)]
	public ShipTowerLevelInfoView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060154E8 RID: 87272 RVA: 0x005E7D20 File Offset: 0x005E5F20
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText))
		};
	}

	// Token: 0x060154E9 RID: 87273 RVA: 0x005E7E5C File Offset: 0x005E605C
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerLevelInfoView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerLevelInfoView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060154EA RID: 87274 RVA: 0x005E7EA0 File Offset: 0x005E60A0
	protected override void OnBeforeShow()
	{
		IShipTowerScoreItemViewParams shipTowerScoreItemViewParams = this.OpenParam as IShipTowerScoreItemViewParams;
		if (shipTowerScoreItemViewParams == null)
		{
			return;
		}
		this.RefreshFeatureInfo();
		this.RefreshBuffInfo();
		this.RefreshBurningTideInfo();
		this.RefreshScoreInfo(shipTowerScoreItemViewParams.CurScore, shipTowerScoreItemViewParams.MaxScore);
	}

	// Token: 0x060154EB RID: 87275 RVA: 0x005E7EE4 File Offset: 0x005E60E4
	private void RefreshFeatureInfo()
	{
		ShipTowerStageData currentStage = ModelBase<ShipTowerModel>.Instance.GetCurrentStage();
		ShipTowerTeamData shipTowerTeamData = (currentStage != null) ? currentStage.GetCurrentTeamData() : null;
		if (shipTowerTeamData == null)
		{
			return;
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew("GhostShipMonster_Text1");
		}
		InstanceDungeon? instanceDungeonCfg = shipTowerTeamData.GetInstanceDungeonCfg(null);
		UUIText text2 = base.GetText(3);
		if (text2 == null)
		{
			return;
		}
		text2.ShowTextNew(((instanceDungeonCfg != null) ? instanceDungeonCfg.GetValueOrDefault().DungeonDesc : null) ?? "");
	}

	// Token: 0x060154EC RID: 87276 RVA: 0x005E7F68 File Offset: 0x005E6168
	private void RefreshBuffInfo()
	{
		IBattleUiHoverTipsD inTheBattleBuffInfo = ModelBase<ShipTowerModel>.Instance.GetInTheBattleBuffInfo();
		UUIText text = base.GetText(5);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, inTheBattleBuffInfo.TitleKey, Array.Empty<object>());
		UUIText text2 = base.GetText(6);
		if (!string.IsNullOrEmpty(inTheBattleBuffInfo.SubTitleKey))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, inTheBattleBuffInfo.SubTitleKey, Array.Empty<object>());
		}
		else if (text2 != null)
		{
			text2.SetText("", true);
		}
		if (!string.IsNullOrEmpty(inTheBattleBuffInfo.DescTitleKey))
		{
			UUIText text3 = base.GetText(7);
			if (text3 != null)
			{
				text3.ShowTextNew(inTheBattleBuffInfo.DescTitleKey);
			}
		}
		if (inTheBattleBuffInfo.DescInfoList != null && inTheBattleBuffInfo.DescInfoList.Count > 0)
		{
			UUIText text4 = base.GetText(8);
			if (text4 == null)
			{
				return;
			}
			text4.ShowTextNew(inTheBattleBuffInfo.DescInfoList[0].DescKey);
		}
	}

	// Token: 0x060154ED RID: 87277 RVA: 0x005E8038 File Offset: 0x005E6238
	private void RefreshBurningTideInfo()
	{
		SlashAndTowerSeason? curSeasonCfg = ModelBase<ShipTowerModel>.Instance.CurSeasonCfg;
		if (curSeasonCfg == null)
		{
			return;
		}
		UUIText text = base.GetText(11);
		if (text != null)
		{
			text.ShowTextNew(curSeasonCfg.Value.HotDesc ?? "");
		}
		UUIText text2 = base.GetText(12);
		if (text2 == null)
		{
			return;
		}
		text2.ShowTextNew(curSeasonCfg.Value.BuringTideDesc ?? "");
	}

	// Token: 0x060154EE RID: 87278 RVA: 0x005E80AF File Offset: 0x005E62AF
	private void RefreshScoreInfo(int curScore, int maxScore)
	{
		ShipTowerBurningTideItem shipTowerBurningTideItem = this.ShipTowerBurningTideItem;
		if (shipTowerBurningTideItem == null)
		{
			return;
		}
		shipTowerBurningTideItem.UpdateValue(curScore, maxScore);
	}

	// Token: 0x0400A43C RID: 42044
	[Nullable(2)]
	private ShipTowerBurningTideItem ShipTowerBurningTideItem;

	// Token: 0x02008D14 RID: 36116
	private static class EChildType
	{
		// Token: 0x0402F74A RID: 194378
		public const int CaptionItem = 0;

		// Token: 0x0402F74B RID: 194379
		public const int LevelFeatureItem = 1;

		// Token: 0x0402F74C RID: 194380
		public const int LevelFeatureTitleText = 2;

		// Token: 0x0402F74D RID: 194381
		public const int LevelFeatureText = 3;

		// Token: 0x0402F74E RID: 194382
		public const int BuffItem = 4;

		// Token: 0x0402F74F RID: 194383
		public const int BuffNameText = 5;

		// Token: 0x0402F750 RID: 194384
		public const int BuffLevelText = 6;

		// Token: 0x0402F751 RID: 194385
		public const int BuffDescTitleText = 7;

		// Token: 0x0402F752 RID: 194386
		public const int BuffDescText = 8;

		// Token: 0x0402F753 RID: 194387
		public const int BurningTideInfoPanel = 9;

		// Token: 0x0402F754 RID: 194388
		public const int BurningTideItem = 10;

		// Token: 0x0402F755 RID: 194389
		public const int HotEffectDesc = 11;

		// Token: 0x0402F756 RID: 194390
		public const int BurningTideDesc = 12;
	}
}
