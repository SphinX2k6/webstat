using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200272E RID: 10030
[NullableContext(2)]
[Nullable(0)]
public class RacingBetsActivityView : ActivitySubViewBase
{
	// Token: 0x06013C81 RID: 81025 RVA: 0x00580D55 File Offset: 0x0057EF55
	protected override void OnSetData()
	{
		this.RacingBetSeasonData = (this.ActivityBaseData as RacingBetsSeasonData);
	}

	// Token: 0x06013C82 RID: 81026 RVA: 0x00580D68 File Offset: 0x0057EF68
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsPlayerInfoUpdate, new Action(this.RefreshPlayerBetInfo));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsRewardRefresh, new Action(this.RefreshRedDot));
	}

	// Token: 0x06013C83 RID: 81027 RVA: 0x00580DA2 File Offset: 0x0057EFA2
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsPlayerInfoUpdate, new Action(this.RefreshPlayerBetInfo));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsRewardRefresh, new Action(this.RefreshRedDot));
	}

	// Token: 0x06013C84 RID: 81028 RVA: 0x00580DDC File Offset: 0x0057EFDC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 23;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013C85 RID: 81029 RVA: 0x0058110C File Offset: 0x0057F30C
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsActivityView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsActivityView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013C86 RID: 81030 RVA: 0x00581150 File Offset: 0x0057F350
	protected override void OnStart()
	{
		Activity? localConfig = this.RacingBetSeasonData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		this.TitleItem.SetActivityBaseData(this.RacingBetSeasonData);
		this.TitleItem.SetTitleByText(this.RacingBetSeasonData.GetTitle());
		string descTheme = localConfig.Value.DescTheme;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleItem.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleItem.SetSubTitleByTextId(descTheme, Array.Empty<string>());
			string descThemeIcon = localConfig.Value.DescThemeIcon;
			if (!string.IsNullOrEmpty(descThemeIcon))
			{
				this.TitleItem.SetSubTitleIconByPath(descThemeIcon, null);
			}
		}
		this.DescriptionItem.SetContentByTextId(localConfig.Value.Desc, Array.Empty<string>());
		List<TItem> previewReward = this.RacingBetSeasonData.GetPreviewReward(null);
		this.RewardListItem.SetTitleByTextId("CollectActivity_reward");
		this.RewardListItem.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListItem.InitCommonGridItem));
		this.RewardListItem.RefreshItemLayout(previewReward, null);
		this.FunctionalItem.FunctionButton.SetFunction(new Action(this.FunctionExecute));
		this.ActivityInternalRewardItem.BindRedDot(ERedDotName.RedDotRacingBetsActivityInternalReward, 0);
		this.ActivityInternalRewardItem.SetFunction(new Action(this.OnClickActivityInternalRewardItem));
		this.ActivityRewardItem.BindRedDot(ERedDotName.RedDotRacingBetsActivityReward, 0);
		this.ActivityRewardItem.SetFunction(new Action(this.OnClickActivityRewardItem));
	}

	// Token: 0x06013C87 RID: 81031 RVA: 0x005812D9 File Offset: 0x0057F4D9
	protected override void OnBeforeShow()
	{
		base.GetSpine(6).SetAnimation(0, "start", false).AnimationComplete.Add(delegate(UTrackEntry _)
		{
			base.GetSpine(6).SetAnimation(0, "idle", true);
		});
	}

	// Token: 0x06013C88 RID: 81032 RVA: 0x00581304 File Offset: 0x0057F504
	protected override void OnBeforeHide()
	{
		base.GetSpine(6).ClearTracks();
	}

	// Token: 0x06013C89 RID: 81033 RVA: 0x00581314 File Offset: 0x0057F514
	protected override void OnRefreshView()
	{
		bool flag = this.RacingBetSeasonData.IsUnLock();
		this.FunctionalItem.SetPanelConditionVisible(!flag);
		this.RefreshActivityTimerText();
		if (!flag)
		{
			this.FunctionalItem.SetPerformanceConditionLock(this.RacingBetSeasonData.ConditionGroupId, this.RacingBetSeasonData.Id);
		}
		this.FunctionalItem.FunctionButton.SetUiActive(flag);
		this.FunctionalItem.FunctionButton.SetRedDotVisible(this.RacingBetSeasonData.RedPointShowState);
		this.RefreshPanelInfo();
	}

	// Token: 0x06013C8A RID: 81034 RVA: 0x00581398 File Offset: 0x0057F598
	protected override void OnTimer(float gap)
	{
		this.RefreshActivityTimerText();
		this.RefreshPanelInfo();
	}

	// Token: 0x06013C8B RID: 81035 RVA: 0x005813A8 File Offset: 0x0057F5A8
	private void RefreshActivityTimerText()
	{
		string item = this.GetTimeVisibleAndRemainTime().Item2;
		this.TitleItem.SetTimeTextByText(item);
	}

	// Token: 0x06013C8C RID: 81036 RVA: 0x005813CD File Offset: 0x0057F5CD
	private void RefreshRedDot()
	{
		this.FunctionalItem.FunctionButton.SetRedDotVisible(this.RacingBetSeasonData.RedPointShowState);
	}

	// Token: 0x06013C8D RID: 81037 RVA: 0x005813EA File Offset: 0x0057F5EA
	private void RefreshPlayerBetInfo()
	{
	}

	// Token: 0x06013C8E RID: 81038 RVA: 0x005813EC File Offset: 0x0057F5EC
	private void FunctionExecute()
	{
		if (this.RacingBetSeasonData.GetIfFirstOpen())
		{
			ControllerBase<ActivityController>.Instance.RequestReadActivity(this.RacingBetSeasonData);
		}
		if (!this.RacingBetSeasonData.GetPreGuideQuestFinishState())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.RacingBetSeasonData.GetUnFinishPreGuideQuestId(), null);
		}
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(racingBetsSeasonData.GetSeasonConfig().DungeonInstanceId, new List<int>
		{
			ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId().Value
		}, racingBetsSeasonData.GetSeasonConfig().DungeonEntranceId, 0, null, null).Forget<bool>();
		ModelBase<RacingBetsModel>.Instance.SetIsFromActivityOpenDungeon();
	}

	// Token: 0x06013C8F RID: 81039 RVA: 0x005814A4 File Offset: 0x0057F6A4
	private void OnClickActivityRewardItem()
	{
		RacingBetsGroupRewardData groupRewardData = this.RacingBetSeasonData.GetGroupRewardData(ERacingBetsRewardType.BetsCount);
		RacingBetsGroupRewardData groupRewardData2 = this.RacingBetSeasonData.GetGroupRewardData(ERacingBetsRewardType.DailyEarn);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsActivityRewardView, new List<RacingBetsGroupRewardData>
		{
			groupRewardData,
			groupRewardData2
		}, null);
	}

	// Token: 0x06013C90 RID: 81040 RVA: 0x005814F0 File Offset: 0x0057F6F0
	private void OnClickActivityInternalRewardItem()
	{
		RacingBetsGroupRewardData groupRewardData = this.RacingBetSeasonData.GetGroupRewardData(ERacingBetsRewardType.DailyGameEarn);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsRewardView, new List<RacingBetsGroupRewardData>
		{
			groupRewardData
		}, null);
	}

	// Token: 0x06013C91 RID: 81041 RVA: 0x00581528 File Offset: 0x0057F728
	private void RefreshPanelInfo()
	{
		RacingBetsLegMatchData curLegMatchData = this.RacingBetSeasonData.GetCurLegMatchData();
		if (curLegMatchData == null)
		{
			return;
		}
		if (ModelBase<RacingBetsModel>.Instance.IsFinalLegMatch(curLegMatchData.Id) && curLegMatchData.IsLegMatchFinished())
		{
			base.GetItem(19).SetUIActive(true);
			base.GetItem(8).SetUIActive(false);
			this.RefreshWinnerInfo(curLegMatchData);
			return;
		}
		base.GetItem(19).SetUIActive(false);
		base.GetItem(8).SetUIActive(true);
		RacingBetsLegMatchData legMatchDataForMatchStateText = this.RacingBetSeasonData.GetLegMatchDataForMatchStateText();
		if (legMatchDataForMatchStateText == null)
		{
			return;
		}
		this.RefreshMatchStateInfo(legMatchDataForMatchStateText);
	}

	// Token: 0x06013C92 RID: 81042 RVA: 0x005815B4 File Offset: 0x0057F7B4
	[NullableContext(1)]
	private void RefreshWinnerInfo(RacingBetsLegMatchData legMatchData)
	{
		int championDangoId = legMatchData.GetChampionDangoId();
		DangoConfig instance = ConfigBase<DangoConfig>.Instance;
		Dango? dango = (instance != null) ? instance.GetDangoById(championDangoId) : null;
		if (dango == null)
		{
			return;
		}
		base.SetTextureByPath(dango.Value.Icon, base.GetTexture(21), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), "DangoFinalChampionName", new <>z__ReadOnlySingleElementList<object>(new TableTextArgNew(dango.Value.Name, Array.Empty<object>())));
		if (!this.HasPlayedWinSequence)
		{
			this.HasPlayedWinSequence = true;
			this.WinnerSequencePlayer.PlaySequencePurely("Win", false, false, null, null, false);
		}
	}

	// Token: 0x06013C93 RID: 81043 RVA: 0x00581678 File Offset: 0x0057F878
	[NullableContext(1)]
	private void RefreshMatchStateInfo(RacingBetsLegMatchData legMatchData)
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		RacingBetsGroupMatchData parentGroupMatchData = legMatchData.ParentGroupMatchData;
		IEnumerable<RacingBetsMatch> matchTableConfigBySeasonId = ConfigBase<RacingBetsConfig>.Instance.GetMatchTableConfigBySeasonId(racingBetsSeasonData.Id);
		RacingBetsMatch? racingBetsMatch = null;
		foreach (RacingBetsMatch value in matchTableConfigBySeasonId)
		{
			int[] groupMatchListArray = value.GetGroupMatchListArray();
			bool flag = false;
			if (groupMatchListArray != null)
			{
				int[] array = groupMatchListArray;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == parentGroupMatchData.Id)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				racingBetsMatch = new RacingBetsMatch?(value);
				break;
			}
		}
		if (racingBetsMatch == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "赌马赛程|RacingBetsMatch未找到比赛配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("legMatchDataId", legMatchData.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		base.GetText(10).ShowTextNew(racingBetsMatch.Value.Name);
		base.GetText(11).ShowTextNew(legMatchData.ShortName);
		int legMatchState = (int)legMatchData.GetLegMatchState();
		bool flag2 = ModelBase<RacingBetsModel>.Instance.IsFinalLegMatch(legMatchData.Id);
		bool flag3 = legMatchState == 4;
		int betDangoId = legMatchData.BetDangoId;
		bool flag4 = legMatchData.BetDangoId != 0;
		string resourceId = flag4 ? "T_RaceBannerBlue" : "T_RaceBannerGreen";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(9), null, null);
		if (flag4)
		{
			Dango? dangoById = ConfigBase<DangoConfig>.Instance.GetDangoById(betDangoId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "Dango_MainPage_BetStatus_Bet", new <>z__ReadOnlySingleElementList<object>(new TableTextArgNew(dangoById.Value.Name, Array.Empty<object>())));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "Dango_MainPage_BetStatus_NotBet", Array.Empty<object>());
		}
		if (flag3)
		{
			int championDangoId = legMatchData.GetChampionDangoId();
			Dango? dangoById2 = ConfigBase<DangoConfig>.Instance.GetDangoById(championDangoId);
			if (flag4)
			{
				base.SetTextureByPath(ConfigBase<DangoConfig>.Instance.GetDangoById(betDangoId).Value.Icon, base.GetTexture(13), null, null);
				bool flag5 = betDangoId == championDangoId;
				if (!flag5)
				{
					base.GetArtText(17).SetText(legMatchData.GetBetDangoRank().ToString());
				}
				base.GetItem(16).SetUIActive(!flag5);
				base.GetItem(15).SetUIActive(flag5);
			}
			else
			{
				base.SetTextureByPath(dangoById2.Value.Icon, base.GetTexture(13), null, null);
				base.GetItem(15).SetUIActive(true);
				base.GetItem(16).SetUIActive(false);
			}
			base.GetSprite(12).SetUIActive(false);
			base.GetTexture(13).SetUIActive(true);
		}
		else
		{
			if (flag4)
			{
				base.SetTextureByPath(ConfigBase<DangoConfig>.Instance.GetDangoById(betDangoId).Value.Icon, base.GetTexture(13), null, null);
			}
			base.GetItem(15).SetUIActive(false);
			base.GetItem(16).SetUIActive(false);
			base.GetTexture(13).SetUIActive(flag4);
			base.GetSprite(12).SetUIActive(!flag4);
		}
		base.GetText(18).SetText(this.RacingBetSeasonData.GetMatchStateDisplayTextForLeg(legMatchData), true);
		base.GetText(11).SetUIActive(!flag2);
	}

	// Token: 0x040099FE RID: 39422
	private RacingBetsSeasonData RacingBetSeasonData;

	// Token: 0x040099FF RID: 39423
	private ActivityTitleTypeA TitleItem;

	// Token: 0x04009A00 RID: 39424
	private ActivityDescriptionTypeA DescriptionItem;

	// Token: 0x04009A01 RID: 39425
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListItem;

	// Token: 0x04009A02 RID: 39426
	private ActivityFunctionalTypeA FunctionalItem;

	// Token: 0x04009A03 RID: 39427
	private ActivityButtonItem ActivityInternalRewardItem;

	// Token: 0x04009A04 RID: 39428
	private ActivityButtonItem ActivityRewardItem;

	// Token: 0x04009A05 RID: 39429
	private LevelSequencePlayer WinnerSequencePlayer;

	// Token: 0x04009A06 RID: 39430
	private bool HasPlayedWinSequence;

	// Token: 0x02008AD7 RID: 35543
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ECE9 RID: 191721
		public const int TitleItem = 0;

		// Token: 0x0402ECEA RID: 191722
		public const int DescriptionItem = 1;

		// Token: 0x0402ECEB RID: 191723
		public const int RewardItem = 2;

		// Token: 0x0402ECEC RID: 191724
		public const int FunctionItem = 3;

		// Token: 0x0402ECED RID: 191725
		public const int ActivityInternalRewardItem = 4;

		// Token: 0x0402ECEE RID: 191726
		public const int ActivityRewardItem = 5;

		// Token: 0x0402ECEF RID: 191727
		public const int SpineActor = 6;

		// Token: 0x0402ECF0 RID: 191728
		public const int PanelInfo = 7;

		// Token: 0x0402ECF1 RID: 191729
		public const int PanelMatchState = 8;

		// Token: 0x0402ECF2 RID: 191730
		public const int MatchStateBgTexture = 9;

		// Token: 0x0402ECF3 RID: 191731
		public const int GroupMatchNameText = 10;

		// Token: 0x0402ECF4 RID: 191732
		public const int LegMatchNameText = 11;

		// Token: 0x0402ECF5 RID: 191733
		public const int NoBetSprite = 12;

		// Token: 0x0402ECF6 RID: 191734
		public const int DangoTexture = 13;

		// Token: 0x0402ECF7 RID: 191735
		public const int BetStateText = 14;

		// Token: 0x0402ECF8 RID: 191736
		public const int NoOneItem = 15;

		// Token: 0x0402ECF9 RID: 191737
		public const int RankItem = 16;

		// Token: 0x0402ECFA RID: 191738
		public const int RankArtText = 17;

		// Token: 0x0402ECFB RID: 191739
		public const int MatchStateText = 18;

		// Token: 0x0402ECFC RID: 191740
		public const int PanelWinner = 19;

		// Token: 0x0402ECFD RID: 191741
		public const int WinnerText = 20;

		// Token: 0x0402ECFE RID: 191742
		public const int WinnerDangoTexture = 21;

		// Token: 0x0402ECFF RID: 191743
		public const int PanelRoleWinner = 22;
	}
}
