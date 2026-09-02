using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ED0 RID: 20176
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseLevelView : UiTickViewBase
	{
		// Token: 0x060341CD RID: 213453 RVA: 0x00D06905 File Offset: 0x00D04B05
		public TowerDefenseLevelView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060341CE RID: 213454 RVA: 0x00D0691C File Offset: 0x00D04B1C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060341CF RID: 213455 RVA: 0x00D06A09 File Offset: 0x00D04C09
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		}

		// Token: 0x060341D0 RID: 213456 RVA: 0x00D06A43 File Offset: 0x00D04C43
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		}

		// Token: 0x060341D1 RID: 213457 RVA: 0x00D06A80 File Offset: 0x00D04C80
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseLevelView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseLevelView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060341D2 RID: 213458 RVA: 0x00D06AC3 File Offset: 0x00D04CC3
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x060341D3 RID: 213459 RVA: 0x00D06ACC File Offset: 0x00D04CCC
		protected override void OnBeforeShow()
		{
			TowerDefenseRewardEntranceItem pointsEntrance = this.PointsEntrance;
			if (pointsEntrance == null)
			{
				return;
			}
			pointsEntrance.RefreshItem();
		}

		// Token: 0x060341D4 RID: 213460 RVA: 0x00D06AE0 File Offset: 0x00D04CE0
		protected override void OnAfterShow()
		{
			this.MatchingCountDownItem.BindOnClickBtnCancelMatching(delegate
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.CancelMatchRequest();
			});
			this.MatchingCountDownItem.BindOnAfterCloseAnimation(delegate(string sequenceName)
			{
				if (sequenceName == "Close")
				{
					InstanceDungeonMatchingCountDown matchingCountDownItem2 = this.MatchingCountDownItem;
					if (matchingCountDownItem2 == null)
					{
						return;
					}
					matchingCountDownItem2.SetUiActive(false);
				}
			});
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Matching)
			{
				InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
				if (matchingCountDownItem != null)
				{
					matchingCountDownItem.PlayAnimation("Start");
				}
				this.MatchingCountDownItem.StartTimer();
			}
		}

		// Token: 0x060341D5 RID: 213461 RVA: 0x00D06B5C File Offset: 0x00D04D5C
		private void OnMatchingBegin()
		{
			TowerDefenseLevelDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel != null)
			{
				detailPanel.RefreshChallengeBtnMatchingState();
			}
			InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
			if (matchingCountDownItem != null)
			{
				matchingCountDownItem.PlayAnimation("Start");
			}
			InstanceDungeonMatchingCountDown matchingCountDownItem2 = this.MatchingCountDownItem;
			if (matchingCountDownItem2 != null)
			{
				matchingCountDownItem2.BindOnStopTimer(() => ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching);
			}
			this.BeginMatching();
		}

		// Token: 0x060341D6 RID: 213462 RVA: 0x00D06BC8 File Offset: 0x00D04DC8
		private void OnMatchingChange()
		{
			TowerDefenseLevelDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel != null)
			{
				detailPanel.RefreshChallengeBtnMatchingState();
			}
			switch (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState())
			{
			case EInstanceMatchState.Default:
			{
				InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
				if (matchingCountDownItem == null)
				{
					return;
				}
				matchingCountDownItem.PlayAnimation("Close");
				return;
			}
			case EInstanceMatchState.Matching:
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MatchingOtherCancel", Array.Empty<object>());
				InstanceDungeonMatchingCountDown matchingCountDownItem2 = this.MatchingCountDownItem;
				if (matchingCountDownItem2 != null)
				{
					matchingCountDownItem2.PlayAnimation("Start");
				}
				this.BeginMatching();
				return;
			}
			case EInstanceMatchState.MatchConfirm:
			{
				InstanceDungeonMatchingCountDown matchingCountDownItem3 = this.MatchingCountDownItem;
				if (matchingCountDownItem3 != null)
				{
					matchingCountDownItem3.PlayAnimation("Finish");
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineInstanceMatchTips, null, null);
				return;
			}
			case EInstanceMatchState.Waiting:
				break;
			case EInstanceMatchState.ConfirmToReady:
			{
				InstanceDungeonMatchingCountDown matchingCountDownItem4 = this.MatchingCountDownItem;
				if (matchingCountDownItem4 != null)
				{
					matchingCountDownItem4.SetUiActive(false);
				}
				ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InstanceDungeonMonsterPreView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.InstanceDungeonMonsterPreView, null);
				}
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingId(), true, true, false, null);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnEnterTeam);
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x060341D7 RID: 213463 RVA: 0x00D06CE9 File Offset: 0x00D04EE9
		private void BeginMatching()
		{
			this.MatchingCountDownItem.SetMatchingTime(0);
			this.MatchingCountDownItem.StartTimer();
		}

		// Token: 0x060341D8 RID: 213464 RVA: 0x00D06D04 File Offset: 0x00D04F04
		protected override void OnBeforeDestroy()
		{
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Matching)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MatchingBackground", Array.Empty<object>());
			}
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = 0;
			ControllerBase<TowerDefenseController>.Instance.SetIsUiFlowOpen(false);
			this.MatchingCountDownItem = null;
		}

		// Token: 0x060341D9 RID: 213465 RVA: 0x00D06D60 File Offset: 0x00D04F60
		protected override void OnTick(float delta)
		{
			if (this.LevelScroll == null)
			{
				return;
			}
			foreach (TowerDefenseLevelItem towerDefenseLevelItem in this.LevelScroll.GetScrollItemList())
			{
				towerDefenseLevelItem.RefreshOnTick();
			}
		}

		// Token: 0x060341DA RID: 213466 RVA: 0x00D06DC0 File Offset: 0x00D04FC0
		private List<TowerDefenseGroupData> BuildGroupDataList()
		{
			List<ITowerDefenseParsedStageMessage> stageListCache = ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.StageListCache;
			if (stageListCache == null)
			{
				return new List<TowerDefenseGroupData>();
			}
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in stageListCache)
			{
				TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(towerDefenseParsedStageMessage.Id);
				if (towerDefenseConfigById != null)
				{
					List<int> list;
					if (!dictionary.TryGetValue(towerDefenseConfigById.Value.GroupId, out list))
					{
						list = new List<int>();
						dictionary[towerDefenseConfigById.Value.GroupId] = list;
					}
					list.Add(towerDefenseParsedStageMessage.Id);
				}
			}
			List<TowerDefenseGroupData> list2 = new List<TowerDefenseGroupData>();
			foreach (KeyValuePair<int, List<int>> keyValuePair in dictionary)
			{
				int num;
				List<int> list3;
				keyValuePair.Deconstruct(out num, out list3);
				int groupId = num;
				List<int> list4 = list3;
				list4.Sort(new Comparison<int>(this.CompareSubLevel));
				list2.Add(new TowerDefenseGroupData
				{
					GroupId = groupId,
					SubStageIds = list4,
					OnClickSubLevel = new Action<int>(this.OnClickSubLevel),
					IsSelectedGetter = new Func<int, bool>(this.IsStageSelected)
				});
			}
			return list2;
		}

		// Token: 0x060341DB RID: 213467 RVA: 0x00D06F38 File Offset: 0x00D05138
		private int CompareSubLevel(int a, int b)
		{
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(a);
			TowerDefenceInstance? towerDefenseConfigById2 = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(b);
			if (towerDefenseConfigById.Value.Difficulty != towerDefenseConfigById2.Value.Difficulty)
			{
				return towerDefenseConfigById.Value.Difficulty - towerDefenseConfigById2.Value.Difficulty;
			}
			return towerDefenseConfigById.Value.SortId - towerDefenseConfigById2.Value.SortId;
		}

		// Token: 0x060341DC RID: 213468 RVA: 0x00D06FBC File Offset: 0x00D051BC
		private void OnClickSubLevel(int stageId)
		{
			if (stageId <= 0 || stageId == this.CurrentStageId)
			{
				return;
			}
			this.CurrentStageId = stageId;
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(stageId);
			int num = (towerDefenseConfigById != null) ? towerDefenseConfigById.Value.InstanceId : 0;
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = num;
			ModelBase<TowerDefenseModel>.Instance.SetLevelHasClickByInstanceId(num);
			if (this.LevelScroll != null)
			{
				foreach (TowerDefenseLevelItem towerDefenseLevelItem in this.LevelScroll.GetScrollItemList())
				{
					towerDefenseLevelItem.RefreshSelectionVisual();
					towerDefenseLevelItem.RefreshRedDot();
				}
			}
			TowerDefenseLevelDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel != null)
			{
				detailPanel.SetUiActive(true);
			}
			TowerDefenseLevelDetailPanel detailPanel2 = this.DetailPanel;
			if (detailPanel2 != null)
			{
				detailPanel2.RefreshItem(num);
			}
			this.RefreshBackground(stageId);
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.StopSequenceByKey("Switch", false, false);
			}
			LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 == null)
			{
				return;
			}
			sequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x060341DD RID: 213469 RVA: 0x00D070D8 File Offset: 0x00D052D8
		private bool IsStageSelected(int stageId)
		{
			return stageId == this.CurrentStageId;
		}

		// Token: 0x060341DE RID: 213470 RVA: 0x00D070E4 File Offset: 0x00D052E4
		private void RefreshBackground(int stageId)
		{
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(stageId);
			string text = (towerDefenseConfigById != null) ? (towerDefenseConfigById.Value.BgPath ?? "") : "";
			if (string.IsNullOrEmpty(text) || text == this.CurrentBgPath)
			{
				return;
			}
			this.CurrentBgPath = text;
			base.SetTextureByPath(text, base.GetTexture(0), null, null);
		}

		// Token: 0x060341DF RID: 213471 RVA: 0x00D0715C File Offset: 0x00D0535C
		private void ScrollToTargetGroup(List<TowerDefenseGroupData> groups)
		{
			if (this.CurrentStageId <= 0)
			{
				return;
			}
			int num = groups.FindIndex((TowerDefenseGroupData group) => group.SubStageIds.Contains(this.CurrentStageId));
			if (num < 0)
			{
				return;
			}
			GenericScrollViewNew<TowerDefenseLevelItem, TowerDefenseGroupData> levelScroll = this.LevelScroll;
			UUIItem uuiitem = (levelScroll != null) ? levelScroll.GetItemByIndex(num) : null;
			if (uuiitem != null)
			{
				base.GetScrollViewWithScrollbar(2).ScrollToTopLater(uuiitem, false);
			}
		}

		// Token: 0x0401E18C RID: 123276
		private const int MATCHING_ITEM_OFFSET = -98;

		// Token: 0x0401E18D RID: 123277
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TabComponentWithCaptionItem<CommonTabItemBase> Caption;

		// Token: 0x0401E18E RID: 123278
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<TowerDefenseLevelItem, TowerDefenseGroupData> LevelScroll;

		// Token: 0x0401E18F RID: 123279
		[Nullable(2)]
		private TowerDefenseLevelDetailPanel DetailPanel;

		// Token: 0x0401E190 RID: 123280
		[Nullable(2)]
		private TowerDefenseRewardEntranceItem PointsEntrance;

		// Token: 0x0401E191 RID: 123281
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0401E192 RID: 123282
		[Nullable(2)]
		private InstanceDungeonMatchingCountDown MatchingCountDownItem;

		// Token: 0x0401E193 RID: 123283
		private int CurrentStageId;

		// Token: 0x0401E194 RID: 123284
		private string CurrentBgPath = "";

		// Token: 0x0200AE73 RID: 44659
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403628C RID: 221836
			public const int BgTex = 0;

			// Token: 0x0403628D RID: 221837
			public const int CaptionItem = 1;

			// Token: 0x0403628E RID: 221838
			public const int LevelScroll = 2;

			// Token: 0x0403628F RID: 221839
			public const int LevelItem = 3;

			// Token: 0x04036290 RID: 221840
			public const int PointsItem = 4;

			// Token: 0x04036291 RID: 221841
			public const int LevelDetailPnl = 5;
		}
	}
}
