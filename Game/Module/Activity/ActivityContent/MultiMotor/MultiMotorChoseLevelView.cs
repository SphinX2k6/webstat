using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006650 RID: 26192
	[NullableContext(1)]
	[Nullable(0)]
	public class MultiMotorChoseLevelView : UiTickViewBase
	{
		// Token: 0x0604166C RID: 267884 RVA: 0x010C75A2 File Offset: 0x010C57A2
		public MultiMotorChoseLevelView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0604166D RID: 267885 RVA: 0x010C75AC File Offset: 0x010C57AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 23;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickRewardBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(21, new Action(this.OnClickStartBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604166E RID: 267886 RVA: 0x010C793A File Offset: 0x010C5B3A
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		}

		// Token: 0x0604166F RID: 267887 RVA: 0x010C7974 File Offset: 0x010C5B74
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		}

		// Token: 0x06041670 RID: 267888 RVA: 0x010C79B0 File Offset: 0x010C5BB0
		protected override UniTask OnBeforeStartAsync()
		{
			MultiMotorChoseLevelView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MultiMotorChoseLevelView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041671 RID: 267889 RVA: 0x010C79F3 File Offset: 0x010C5BF3
		protected override void OnStart()
		{
			this.RefreshLevelScrollView();
			this.RefreshRoleTexture();
			this.RefreshTimeText();
			this.RefreshRewardText();
		}

		// Token: 0x06041672 RID: 267890 RVA: 0x010C7A0D File Offset: 0x010C5C0D
		protected override void OnBeforeShow()
		{
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Default)
			{
				InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
				if (matchingCountDownItem != null)
				{
					matchingCountDownItem.PlayAnimation("Close");
				}
				InstanceDungeonMatchingCountDown matchingCountDownItem2 = this.MatchingCountDownItem;
				if (matchingCountDownItem2 != null)
				{
					matchingCountDownItem2.SetUiActive(false);
				}
			}
			this.RefreshRewardRedDot();
		}

		// Token: 0x06041673 RID: 267891 RVA: 0x010C7A4C File Offset: 0x010C5C4C
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
					this.SetMatchingItemActive(false);
				}
			});
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Matching)
			{
				this.SetMatchingItemActive(true);
				InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
				if (matchingCountDownItem != null)
				{
					matchingCountDownItem.PlayAnimation("Start");
				}
				this.MatchingCountDownItem.StartTimer();
				return;
			}
			this.SetMatchingItemActive(false);
		}

		// Token: 0x06041674 RID: 267892 RVA: 0x010C7AD8 File Offset: 0x010C5CD8
		private void RefreshLevelScrollView()
		{
			List<int> allLevels = ModelBase<MultiMotorModel>.Instance.GetCurrentOpenActivityAllLevel();
			GenericScrollViewNew<MultiMotorChoseLevelItem, int> levelScrollView = this.LevelScrollView;
			if (levelScrollView == null)
			{
				return;
			}
			levelScrollView.RefreshByData(allLevels, delegate
			{
				MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
				int index = 0;
				for (int i = 0; i < allLevels.Count; i++)
				{
					int num = allLevels[i];
					if (!ModelBase<MultiMotorModel>.Instance.GetLevelUnLock(num))
					{
						break;
					}
					MultiMotorLevelData multiMotorLevelData = null;
					if (activityData != null)
					{
						activityData.LevelDataMap.TryGetValue(num, out multiMotorLevelData);
					}
					if (multiMotorLevelData == null || !multiMotorLevelData.IsFinish)
					{
						index = i;
						break;
					}
					index = i;
				}
				GenericScrollViewNew<MultiMotorChoseLevelItem, int> levelScrollView2 = this.LevelScrollView;
				MultiMotorChoseLevelItem multiMotorChoseLevelItem = (levelScrollView2 != null) ? levelScrollView2.GetScrollItemByIndex(index) : null;
				if (multiMotorChoseLevelItem == null)
				{
					return;
				}
				multiMotorChoseLevelItem.SelectToggle();
			}, false);
		}

		// Token: 0x06041675 RID: 267893 RVA: 0x010C7B28 File Offset: 0x010C5D28
		private void RefreshRoleTexture()
		{
			bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female;
			string resourceId = flag ? "T_LevelSelectBgFemale" : "T_LevelSelectBgMale";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
			string resourceId2 = flag ? "T_RoleFemale" : "T_RoleMale";
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2);
			base.SetTextureByPath(resourcePath2, base.GetTexture(1), null, null);
		}

		// Token: 0x06041676 RID: 267894 RVA: 0x010C7BAC File Offset: 0x010C5DAC
		private void RefreshRewardRedDot()
		{
			MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
			base.GetItem(8).SetUIActive(activityData != null && activityData.HasAnyRewardRedDot);
		}

		// Token: 0x06041677 RID: 267895 RVA: 0x010C7BDC File Offset: 0x010C5DDC
		private void RefreshRewardText()
		{
			MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
			Dictionary<int, MultiMotorTaskData> dictionary = (activityData != null) ? activityData.TaskDataMap : null;
			int num = 0;
			int num2 = 0;
			if (dictionary != null)
			{
				foreach (KeyValuePair<int, MultiMotorTaskData> keyValuePair in dictionary)
				{
					num++;
					if (keyValuePair.Value.IsReceived)
					{
						num2++;
					}
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "MultRacing_RewardTitle", new <>z__ReadOnlyArray<object>(new object[]
			{
				num2.ToString(),
				num.ToString()
			}));
		}

		// Token: 0x06041678 RID: 267896 RVA: 0x010C7C90 File Offset: 0x010C5E90
		protected override void OnTick(float delta)
		{
			if (this.RefreshTimeAccum > 500f)
			{
				this.RefreshTimeText();
				this.RefreshLockToUnlockTimeText();
				this.RefreshTimeAccum = 0f;
			}
			this.RefreshTimeAccum += delta;
		}

		// Token: 0x06041679 RID: 267897 RVA: 0x010C7CC4 File Offset: 0x010C5EC4
		private void RefreshTimeText()
		{
			MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			bool uiactive = activityData.CheckIfInLimitTime();
			base.GetText(7).SetUIActive(uiactive);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(activityData.EndShowTime, localTextNew);
			base.GetText(7).SetText(remainTimeText ?? "", true);
		}

		// Token: 0x0604167A RID: 267898 RVA: 0x010C7D2C File Offset: 0x010C5F2C
		private void RefreshLevelInfo()
		{
			if (this.CurrentLevel <= 0)
			{
				return;
			}
			OnlineMotorLevel? motorMultiParkourLevelById = ConfigBase<MultiMotorConfig>.Instance.GetMotorMultiParkourLevelById(this.CurrentLevel);
			if (motorMultiParkourLevelById == null)
			{
				return;
			}
			if (ModelBase<MultiMotorModel>.Instance.GetLevelUnLock(this.CurrentLevel))
			{
				this.SetLockState(false);
				base.SetTextureByPath(motorMultiParkourLevelById.Value.LevelTexture, base.GetTexture(10), null, null);
				this.RefreshFinishedInfo();
			}
			else
			{
				this.SetLockState(true);
				this.ShowFinishState(false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), motorMultiParkourLevelById.Value.Name, Array.Empty<object>());
			List<bool> list = new List<bool>();
			for (int i = 0; i < motorMultiParkourLevelById.Value.Difficulty; i++)
			{
				list.Add(true);
			}
			GenericLayout<MultiMotorLevelDifficultyItem, bool> difficultyLayout = this.DifficultyLayout;
			if (difficultyLayout == null)
			{
				return;
			}
			difficultyLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0604167B RID: 267899 RVA: 0x010C7E18 File Offset: 0x010C6018
		private void SetLockState(bool isLock)
		{
			base.GetTexture(10).SetUIActive(!isLock);
			base.GetItem(13).SetUIActive(!isLock);
			base.GetItem(11).SetUIActive(isLock);
			base.GetText(12).SetUIActive(isLock);
			if (isLock)
			{
				this.RefreshLockToUnlockTimeText();
			}
		}

		// Token: 0x0604167C RID: 267900 RVA: 0x010C7E6C File Offset: 0x010C606C
		private void RefreshLockToUnlockTimeText()
		{
			if (this.CurrentLevel <= 0)
			{
				return;
			}
			MultiMotorLevelData multiMotorLevelData = null;
			MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
			if (activityData != null)
			{
				activityData.LevelDataMap.TryGetValue(this.CurrentLevel, out multiMotorLevelData);
			}
			long num = (multiMotorLevelData != null) ? multiMotorLevelData.UnlockTime : 0L;
			UUIText text = base.GetText(12);
			if (num == 0L)
			{
				text.SetUIActive(false);
				return;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num2 = (double)num - serverTime;
			if (num2 > 0.0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MultRacing_UnlockInfo", new <>z__ReadOnlySingleElementList<object>(Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat8(num2).CountDownText));
				return;
			}
			if (!ModelBase<MultiMotorModel>.Instance.GetLevelUnLock(this.CurrentLevel))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "MultiMotor_Unlock_Tips", Array.Empty<object>());
				return;
			}
			if (base.GetItem(11).IsUIActiveSelf())
			{
				this.RefreshLevelInfo();
				this.RefreshLevelScrollView();
			}
		}

		// Token: 0x0604167D RID: 267901 RVA: 0x010C7F54 File Offset: 0x010C6154
		private void RefreshFinishedInfo()
		{
			MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			MultiMotorLevelData multiMotorLevelData;
			activityData.LevelDataMap.TryGetValue(this.CurrentLevel, out multiMotorLevelData);
			if (multiMotorLevelData == null)
			{
				this.ShowFinishState(false);
				return;
			}
			base.GetItem(16).SetUIActive(multiMotorLevelData.BestRanking > 0);
			if (multiMotorLevelData.BestRanking > 0)
			{
				string resourceId;
				MultiMotorDefine.MultiMotorRankSprite.TryGetValue(multiMotorLevelData.BestRanking, out resourceId);
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
				this.SetSpriteByPath(resourcePath, base.GetSprite(17), false, null, null);
			}
			base.GetItem(18).SetUIActive(multiMotorLevelData.BestRecordTime != 0);
			base.GetItem(20).SetUIActive(multiMotorLevelData.BestRecordTime == 0);
			string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5((double)multiMotorLevelData.BestRecordTime * Singleton<TimeUtil>.Instance.Millisecond);
			UUIText text = base.GetText(19);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeDataFormat, true);
		}

		// Token: 0x0604167E RID: 267902 RVA: 0x010C8047 File Offset: 0x010C6247
		private void ShowFinishState(bool isFinish)
		{
			base.GetItem(16).SetUIActive(isFinish);
			base.GetItem(18).SetUIActive(isFinish);
			base.GetItem(20).SetUIActive(!isFinish);
		}

		// Token: 0x0604167F RID: 267903 RVA: 0x010C8076 File Offset: 0x010C6276
		private MultiMotorChoseLevelItem InitLevelItem()
		{
			return new MultiMotorChoseLevelItem
			{
				OnClickToggleCallBack = new Action<int, UUIExtendToggle>(this.OnClickLevelScrollView)
			};
		}

		// Token: 0x06041680 RID: 267904 RVA: 0x010C808F File Offset: 0x010C628F
		private MultiMotorLevelDifficultyItem InitDifficultyItem()
		{
			return new MultiMotorLevelDifficultyItem();
		}

		// Token: 0x06041681 RID: 267905 RVA: 0x010C8098 File Offset: 0x010C6298
		private void OnClickRewardBtn()
		{
			if (this.CurrentLevel <= 0)
			{
				return;
			}
			MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			MultiMotorLevelData multiMotorLevelData;
			activityData.LevelDataMap.TryGetValue(this.CurrentLevel, out multiMotorLevelData);
			if (multiMotorLevelData == null)
			{
				return;
			}
			IMultiMotorParkourRewardViewData param = new IMultiMotorParkourRewardViewData
			{
				ActivityData = activityData,
				SelectLevelData = multiMotorLevelData
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiMotorRewardView, param, null);
		}

		// Token: 0x06041682 RID: 267906 RVA: 0x010C80FC File Offset: 0x010C62FC
		private void OnClickStartBtn()
		{
			int instanceId = this.GetInstanceId();
			if (instanceId == 0)
			{
				return;
			}
			if (!ControllerBase<OnlineController>.Instance.ShowTipsWhenOnlineDisabled(null))
			{
				return;
			}
			OnlineMotorLevel? motorMultiParkourLevelById = ConfigBase<MultiMotorConfig>.Instance.GetMotorMultiParkourLevelById(this.CurrentLevel);
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig((motorMultiParkourLevelById != null) ? motorMultiParkourLevelById.GetValueOrDefault().InstId : 0);
			if (!(((config != null) ? config.GetValueOrDefault().GetSubPackageIdListArray() : null) ?? Array.Empty<int>()).All((int id) => ModelBase<SubPackageDownLoadModel>.Instance.CheckSubPackageDownLoadBySubPackageId(id)))
			{
				return;
			}
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(instanceId, false, false);
				this.MatchingCountDownItem.BindOnStopTimer(() => ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching);
				return;
			}
			int currentTeamSize = ModelBase<OnlineModel>.Instance.GetCurrentTeamSize();
			if (currentTeamSize <= 1)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(instanceId, false, false);
				return;
			}
			if (currentTeamSize < ModelBase<OnlineModel>.Instance.TeamMaxSize)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(instanceId, true, false);
				this.MatchingCountDownItem.BindOnStopTimer(() => ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching);
				return;
			}
			ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
			ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = false;
			ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingId(instanceId);
			ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(instanceId, true);
		}

		// Token: 0x06041683 RID: 267907 RVA: 0x010C827E File Offset: 0x010C647E
		private void OnClickCloseBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041684 RID: 267908 RVA: 0x010C8288 File Offset: 0x010C6488
		private void OnClickLevelScrollView(int levelId, UUIExtendToggle toggle)
		{
			this.CurrentLevel = levelId;
			if (toggle != this.CurrentSelectToggle)
			{
				UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
				if (currentSelectToggle == null || currentSelectToggle.ToggleState != EToggleState.ETT_UnDetermined)
				{
					UUIExtendToggle currentSelectToggle2 = this.CurrentSelectToggle;
					if (currentSelectToggle2 != null)
					{
						currentSelectToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
					}
				}
			}
			this.CurrentSelectToggle = toggle;
			this.RefreshLevelInfo();
		}

		// Token: 0x06041685 RID: 267909 RVA: 0x010C82E4 File Offset: 0x010C64E4
		private int GetInstanceId()
		{
			OnlineMotorLevel? motorMultiParkourLevelById = ConfigBase<MultiMotorConfig>.Instance.GetMotorMultiParkourLevelById(this.CurrentLevel);
			if (motorMultiParkourLevelById == null)
			{
				return 0;
			}
			return motorMultiParkourLevelById.GetValueOrDefault().InstId;
		}

		// Token: 0x06041686 RID: 267910 RVA: 0x010C831C File Offset: 0x010C651C
		private void SetMatchingItemActive(bool isShow)
		{
			base.GetItem(22).SetUIActive(isShow);
			bool flag = ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<OnlineModel>.Instance.GetIsMyTeam();
			base.GetButton(21).RootUIComp.Get().SetUIActive(!isShow && !flag);
		}

		// Token: 0x06041687 RID: 267911 RVA: 0x010C8378 File Offset: 0x010C6578
		private void OnMatchingChange()
		{
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
				this.SetMatchingItemActive(true);
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
				this.SetMatchingItemActive(false);
				ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InstanceDungeonMonsterPreView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.InstanceDungeonMonsterPreView, null);
				}
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingId(), true, true, false, null);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnEnterTeam);
				break;
			default:
				return;
			}
		}

		// Token: 0x06041688 RID: 267912 RVA: 0x010C8484 File Offset: 0x010C6684
		private void OnMatchingBegin()
		{
			this.SetMatchingItemActive(true);
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

		// Token: 0x06041689 RID: 267913 RVA: 0x010C84E4 File Offset: 0x010C66E4
		private void BeginMatching()
		{
			this.MatchingCountDownItem.SetMatchingTime(0);
			this.MatchingCountDownItem.StartTimer();
		}

		// Token: 0x04024927 RID: 149799
		private const int REFRESH_TIME = 500;

		// Token: 0x04024928 RID: 149800
		private const int MATCHING_ITEM_OFFSET = -98;

		// Token: 0x04024929 RID: 149801
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402492A RID: 149802
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<MultiMotorChoseLevelItem, int> LevelScrollView;

		// Token: 0x0402492B RID: 149803
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<MultiMotorLevelDifficultyItem, bool> DifficultyLayout;

		// Token: 0x0402492C RID: 149804
		[Nullable(2)]
		private InstanceDungeonMatchingCountDown MatchingCountDownItem;

		// Token: 0x0402492D RID: 149805
		private int CurrentLevel;

		// Token: 0x0402492E RID: 149806
		[Nullable(2)]
		private UUIExtendToggle CurrentSelectToggle;

		// Token: 0x0402492F RID: 149807
		private float RefreshTimeAccum;

		// Token: 0x0200C66F RID: 50799
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D17B RID: 250235
			public const int RoleATexture = 0;

			// Token: 0x0403D17C RID: 250236
			public const int RoleBTexture = 1;

			// Token: 0x0403D17D RID: 250237
			public const int CaptionItem = 2;

			// Token: 0x0403D17E RID: 250238
			public const int LevelScrollView = 3;

			// Token: 0x0403D17F RID: 250239
			public const int LevelItem = 4;

			// Token: 0x0403D180 RID: 250240
			public const int RewardBtn = 5;

			// Token: 0x0403D181 RID: 250241
			public const int RewardText = 6;

			// Token: 0x0403D182 RID: 250242
			public const int TimeText = 7;

			// Token: 0x0403D183 RID: 250243
			public const int RewardRedDotItem = 8;

			// Token: 0x0403D184 RID: 250244
			public const int LevelText = 9;

			// Token: 0x0403D185 RID: 250245
			public const int LevelTexture = 10;

			// Token: 0x0403D186 RID: 250246
			public const int LockItem = 11;

			// Token: 0x0403D187 RID: 250247
			public const int LockToUnlockTimeText = 12;

			// Token: 0x0403D188 RID: 250248
			public const int DetailItem = 13;

			// Token: 0x0403D189 RID: 250249
			public const int LevelFlagLayout = 14;

			// Token: 0x0403D18A RID: 250250
			public const int LevelFlagItem = 15;

			// Token: 0x0403D18B RID: 250251
			public const int LevelRankItem = 16;

			// Token: 0x0403D18C RID: 250252
			public const int LevelRankSprite = 17;

			// Token: 0x0403D18D RID: 250253
			public const int LevelTimeItem = 18;

			// Token: 0x0403D18E RID: 250254
			public const int LevelTimeText = 19;

			// Token: 0x0403D18F RID: 250255
			public const int LevelEmptyItem = 20;

			// Token: 0x0403D190 RID: 250256
			public const int StartBtn = 21;

			// Token: 0x0403D191 RID: 250257
			public const int MatchItem = 22;
		}
	}
}
