using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062CC RID: 25292
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisLevelDetailView : UiViewBase
	{
		// Token: 0x0603F9F1 RID: 260593 RVA: 0x0104E4EA File Offset: 0x0104C6EA
		public TetrisLevelDetailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F9F2 RID: 260594 RVA: 0x0104E500 File Offset: 0x0104C700
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(12, typeof(UUIArtText)),
				new ValueTuple<int, Type>(13, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickedEnterButton))
			};
		}

		// Token: 0x0603F9F3 RID: 260595 RVA: 0x0104E674 File Offset: 0x0104C874
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
			Singleton<EventSystem>.Instance.Add(EEventName.OnTetrisChallengeStateUpdate, new Action<int>(this.OnTetrisChallengeStateUpdate));
		}

		// Token: 0x0603F9F4 RID: 260596 RVA: 0x0104E6AE File Offset: 0x0104C8AE
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTetrisChallengeStateUpdate, new Action<int>(this.OnTetrisChallengeStateUpdate));
		}

		// Token: 0x0603F9F5 RID: 260597 RVA: 0x0104E6E8 File Offset: 0x0104C8E8
		private void OnTetrisChallengeStateUpdate(int challengeId)
		{
			this.GetCurrentDifficulty();
			this.RefreshAllGridToggleState();
			this.Refresh(false);
		}

		// Token: 0x0603F9F6 RID: 260598 RVA: 0x0104E700 File Offset: 0x0104C900
		protected override UniTask OnBeforeStartAsync()
		{
			TetrisLevelDetailView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TetrisLevelDetailView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F9F7 RID: 260599 RVA: 0x0104E744 File Offset: 0x0104C944
		protected override void OnStart()
		{
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedCloseButton));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelpBtn));
			this.Param = (this.OpenParam as ITetrisSelectGroupData);
			int activityId = ControllerBase<ActivityTetrisController>.Instance.ActivityId;
			this.Levels = ConfigBase<ActivityTetrisConfig>.Instance.GetGroupLevels(activityId, this.Param.GroupId);
			this.DifficultyScroll = new GenericLayout<TetrisLevelDetailGridView, Tetris>(base.GetVerticalLayout(8), new Func<TetrisLevelDetailGridView>(this.InitDifficultyItem), null, false, true);
			this.RewardListScroll = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(11), new Func<CommonItemSmallItemGrid>(this.InitRewardItem), null, false, true);
			this.TargetListScroll = new GenericLayout<TetrisTargetItemPanel, ITetrisTargetData>(base.GetVerticalLayout(4), new Func<TetrisTargetItemPanel>(this.InitTargetItem), null, false, true);
		}

		// Token: 0x0603F9F8 RID: 260600 RVA: 0x0104E840 File Offset: 0x0104CA40
		private void GetCurrentDifficulty()
		{
			if (this.Levels == null)
			{
				return;
			}
			ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
			if (tetrisData == null)
			{
				return;
			}
			for (int i = 0; i < this.Levels.Count; i++)
			{
				if (this.Levels[i].UnlockId == 0 || tetrisData.CheckChallengeComplete(this.Levels[i].UnlockId))
				{
					this.DifficultyIndex = i;
				}
			}
		}

		// Token: 0x0603F9F9 RID: 260601 RVA: 0x0104E8B7 File Offset: 0x0104CAB7
		protected override void OnBeforeShow()
		{
			this.GetCurrentDifficulty();
			this.Refresh(false);
			this.RefreshScroller();
		}

		// Token: 0x0603F9FA RID: 260602 RVA: 0x0104E8CC File Offset: 0x0104CACC
		public void Refresh(bool isSwitch = false)
		{
			this.RefreshDesc(isSwitch);
			this.RefreshReward();
			this.RefreshTarget();
			this.RefreshLockBtn();
			this.DetailIconItem.Refresh(this.Param);
		}

		// Token: 0x0603F9FB RID: 260603 RVA: 0x0104E8F8 File Offset: 0x0104CAF8
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
		}

		// Token: 0x0603F9FC RID: 260604 RVA: 0x0104E914 File Offset: 0x0104CB14
		private void RefreshAllGridToggleState()
		{
			foreach (TetrisLevelDetailGridView tetrisLevelDetailGridView in this.GridViews)
			{
				int? challengeDifficulty = tetrisLevelDetailGridView.GetChallengeDifficulty();
				int? num = challengeDifficulty;
				int difficultyIndex = this.DifficultyIndex;
				tetrisLevelDetailGridView.SetToggleActive(num.GetValueOrDefault() == difficultyIndex & num != null);
			}
		}

		// Token: 0x0603F9FD RID: 260605 RVA: 0x0104E988 File Offset: 0x0104CB88
		private void RefreshDesc(bool isSwitch = false)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(this.Param.ChallengeIds[this.DifficultyIndex]).LevelName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(this.Param.ChallengeIds[this.DifficultyIndex]).LevelDes, Array.Empty<object>());
			base.GetArtText(12).SetText(this.Param.GroupId.ToString());
		}

		// Token: 0x0603F9FE RID: 260606 RVA: 0x0104EA34 File Offset: 0x0104CC34
		private void RefreshReward()
		{
			int dropId = this.Levels[this.DifficultyIndex].DropId;
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId);
			this.RewardListScroll.RefreshByData(dropPackagePreviewItemList, null, false);
		}

		// Token: 0x0603F9FF RID: 260607 RVA: 0x0104EA75 File Offset: 0x0104CC75
		private void RefreshTarget()
		{
			this.TargetListScroll.RefreshByData(this.GenTargetData(), null, false);
		}

		// Token: 0x0603FA00 RID: 260608 RVA: 0x0104EA8C File Offset: 0x0104CC8C
		private void RefreshLockBtn()
		{
			ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
			if (tetrisData == null)
			{
				return;
			}
			bool flag = tetrisData.CheckPreChallengeComplete(this.Levels[this.DifficultyIndex].Id);
			base.GetItem(13).SetUIActive(!flag);
			UUIButtonComponent button = base.GetButton(7);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(flag);
		}

		// Token: 0x0603FA01 RID: 260609 RVA: 0x0104EAF8 File Offset: 0x0104CCF8
		private void RefreshScroller()
		{
			if (TetrisUtils.IsEggLevel(ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(this.Param.ChallengeIds[this.DifficultyIndex])))
			{
				this.ClearEggLevelRedDot();
				return;
			}
			this.DifficultyScroll.RefreshByData(this.Levels, new Action(this.RefreshAllGridToggleState), false);
		}

		// Token: 0x0603FA02 RID: 260610 RVA: 0x0104EB54 File Offset: 0x0104CD54
		private void ClearEggLevelRedDot()
		{
			int activityId = ControllerBase<ActivityTetrisController>.Instance.ActivityId;
			int key = this.Param.ChallengeIds[this.DifficultyIndex];
			ModelBase<ActivityModel>.Instance.SaveActivityData(activityId, 10001, key, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}

		// Token: 0x0603FA03 RID: 260611 RVA: 0x0104EBA8 File Offset: 0x0104CDA8
		private List<ITetrisTargetData> GenTargetData()
		{
			List<ITetrisTargetData> list = new List<ITetrisTargetData>();
			IntIntMap value = this.Levels[this.DifficultyIndex].TargetResults(0).Value;
			int mapIntIntLength = value.MapIntIntLength;
			for (int i = 0; i < mapIntIntLength; i++)
			{
				DicIntInt value2 = value.MapIntInt(i).Value;
				list.Add(new TetrisTargetData
				{
					Icon = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(value2.Key).Value.TargetIconPath,
					Num = value2.Value,
					Tip = ((value2.Key == 0) ? "Tetristext_09" : "Tetristext_10")
				});
			}
			return list;
		}

		// Token: 0x0603FA04 RID: 260612 RVA: 0x0104EC68 File Offset: 0x0104CE68
		private TetrisTargetItemPanel InitTargetItem()
		{
			return new TetrisTargetItemPanel();
		}

		// Token: 0x0603FA05 RID: 260613 RVA: 0x0104EC6F File Offset: 0x0104CE6F
		public CommonItemSmallItemGrid InitRewardItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = ((TItem _) => ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().CheckChallengeComplete(this.Levels[this.DifficultyIndex].Id))
			};
		}

		// Token: 0x0603FA06 RID: 260614 RVA: 0x0104EC88 File Offset: 0x0104CE88
		private TetrisLevelDetailGridView InitDifficultyItem()
		{
			TetrisLevelDetailGridView tetrisLevelDetailGridView = new TetrisLevelDetailGridView();
			this.GridViews.Add(tetrisLevelDetailGridView);
			return tetrisLevelDetailGridView;
		}

		// Token: 0x0603FA07 RID: 260615 RVA: 0x0104ECA8 File Offset: 0x0104CEA8
		private void OnClickedEnterButton()
		{
			ControllerBase<TetrisController>.Instance.OpenActivityTetris(this.Levels[this.DifficultyIndex].Id);
		}

		// Token: 0x0603FA08 RID: 260616 RVA: 0x0104ECD8 File Offset: 0x0104CED8
		private void OnClickedCloseButton()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.TetrisLevelDetailView, null);
		}

		// Token: 0x0603FA09 RID: 260617 RVA: 0x0104ECEA File Offset: 0x0104CEEA
		public void ChangeDifficultyIndex(int value)
		{
			this.DifficultyIndex = value;
			this.RefreshAllGridToggleState();
			this.Refresh(true);
		}

		// Token: 0x0603FA0A RID: 260618 RVA: 0x0104ED00 File Offset: 0x0104CF00
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(528);
		}

		// Token: 0x0603FA0B RID: 260619 RVA: 0x0104ED11 File Offset: 0x0104CF11
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			if (closeActivities.Contains(ControllerBase<ActivityTetrisController>.Instance.ActivityId))
			{
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
			}
		}

		// Token: 0x04023B79 RID: 146297
		private const int HELP_ID = 528;

		// Token: 0x04023B7A RID: 146298
		[Nullable(2)]
		private ITetrisSelectGroupData Param;

		// Token: 0x04023B7B RID: 146299
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023B7C RID: 146300
		[Nullable(2)]
		private TetrisDetailIconPanel DetailIconItem;

		// Token: 0x04023B7D RID: 146301
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardListScroll;

		// Token: 0x04023B7E RID: 146302
		private GenericLayout<TetrisLevelDetailGridView, Tetris> DifficultyScroll;

		// Token: 0x04023B7F RID: 146303
		private GenericLayout<TetrisTargetItemPanel, ITetrisTargetData> TargetListScroll;

		// Token: 0x04023B80 RID: 146304
		private int DifficultyIndex;

		// Token: 0x04023B81 RID: 146305
		[Nullable(2)]
		private IReadOnlyList<Tetris> Levels;

		// Token: 0x04023B82 RID: 146306
		[Nullable(2)]
		private LevelSequencePlayer ViewSequencePlayer;

		// Token: 0x04023B83 RID: 146307
		private readonly List<TetrisLevelDetailGridView> GridViews = new List<TetrisLevelDetailGridView>();

		// Token: 0x04023B84 RID: 146308
		[Nullable(2)]
		private LockBtnPanel LockBtnItem;
	}
}
