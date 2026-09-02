using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AE7 RID: 6887
[NullableContext(2)]
[Nullable(0)]
public class DangoAbyssInsSelectView : UiViewBase
{
	// Token: 0x0600C61B RID: 50715 RVA: 0x00345054 File Offset: 0x00343254
	[NullableContext(1)]
	public DangoAbyssInsSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C61C RID: 50716 RVA: 0x00345060 File Offset: 0x00343260
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUITexture)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIItem)),
			new ValueTuple<int, Type>(30, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnBtnBackClick)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnBtnNextClick))
		};
	}

	// Token: 0x0600C61D RID: 50717 RVA: 0x0034538C File Offset: 0x0034358C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssUnlockChallengeStateUpdate, new Action(this.OnAbyssUnlockChallengeStateUpdate));
	}

	// Token: 0x0600C61E RID: 50718 RVA: 0x003453F0 File Offset: 0x003435F0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssUnlockChallengeStateUpdate, new Action(this.OnAbyssUnlockChallengeStateUpdate));
	}

	// Token: 0x0600C61F RID: 50719 RVA: 0x00345454 File Offset: 0x00343654
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssInsSelectView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssInsSelectView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C620 RID: 50720 RVA: 0x00345498 File Offset: 0x00343698
	private void OnConfirmB2tnClick(int _)
	{
		if (!ModelBase<DangoAbyssModel>.Instance.GetAbyssUnLockState(this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.Id))
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.AbyssUnlockTip);
			Dictionary<int, int> dictionary = this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.ConsumeItem();
			if (dictionary.Count > 0)
			{
				int key = dictionary.Keys.ToList<int>()[0];
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					dictionary[key].ToString()
				});
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					ControllerBase<DangoAbyssController>.Instance.RequestChallengeUnlock(this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.Id);
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
		}
		else
		{
			int id = this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.Id;
			int instId = this.ViewData.ActivityData.GetAbyssChallengeDataById(id).GetConfig().Value.InstId;
			InstOnlineType onlineType = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instId).Value.OnlineType;
			if (!ModelBase<GameModeModel>.Instance.IsMulti || onlineType == InstOnlineType.Single)
			{
				this.OnClickSingle();
				return;
			}
			this.OnClickMultiple();
		}
	}

	// Token: 0x0600C621 RID: 50721 RVA: 0x00345604 File Offset: 0x00343804
	private void OnConfirm1BtnClick(int _)
	{
		if (!ModelBase<DangoAbyssModel>.Instance.GetAbyssUnLockState(this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.Id))
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.AbyssUnlockTip);
			Dictionary<int, int> dictionary = this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.ConsumeItem();
			if (dictionary.Count > 0)
			{
				int key = dictionary.Keys.ToList<int>()[0];
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					dictionary[key].ToString()
				});
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					ControllerBase<DangoAbyssController>.Instance.RequestChallengeUnlock(this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.Id);
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
		}
		else
		{
			this.OnClickMatch();
		}
	}

	// Token: 0x0600C622 RID: 50722 RVA: 0x003456E4 File Offset: 0x003438E4
	private void OnClickMatch()
	{
		if (!ControllerBase<OnlineController>.Instance.ShowTipsWhenOnlineDisabled(new EDisableOnlineType[]
		{
			EDisableOnlineType.TrialRole
		}))
		{
			return;
		}
		AbyssInst value = this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value;
		int challengeId = value.InstId;
		int instEntranceId = value.InstEntranceId;
		ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId = instEntranceId;
		ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
		this.MatchingCountDownItem.BindOnStopTimer(() => ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching);
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10021))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("IsNotOpenOnline", Array.Empty<object>());
			return;
		}
		if (ControllerBase<InstanceDungeonController>.Instance.IsForbidDungeon(challengeId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInstanceTip", Array.Empty<object>());
			return;
		}
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(challengeId, false, true);
			return;
		}
		int currentTeamSize = ModelBase<OnlineModel>.Instance.GetCurrentTeamSize();
		if (currentTeamSize <= 1)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(challengeId, false, true);
			return;
		}
		if (currentTeamSize < ModelBase<OnlineModel>.Instance.TeamMaxSize)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InstanceDungeonMatchStart);
			Action value2 = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(challengeId, true, true);
			};
			Action value3 = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.StartMatchRequest(challengeId, false, true);
			};
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap.Add(2, value2);
			confirmBoxDataNew.FunctionMap.Add(1, value3);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CanNotMatching", Array.Empty<object>());
	}

	// Token: 0x0600C623 RID: 50723 RVA: 0x00345894 File Offset: 0x00343A94
	private void OnClickSingle()
	{
		ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = false;
		int id = this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.Id;
		ModelBase<DangoAbyssModel>.Instance.CurrentSelectEntranceId = this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.InstEntranceId;
		ModelBase<DangoAbyssModel>.Instance.CurrentSelectChallengeId = id;
		ControllerBase<DangoAbyssController>.Instance.StartAbyssChallenge(id);
	}

	// Token: 0x0600C624 RID: 50724 RVA: 0x0034591C File Offset: 0x00343B1C
	private void OnClickMultiple()
	{
		AbyssInst value = this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value;
		int challengeId = value.InstId;
		int instEntranceId = value.InstEntranceId;
		ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId = instEntranceId;
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			Singleton<Log>.Instance.Error(ELogModule.InstanceDungeon, ELogAuthor.YZY, "非联机下无法进行组队挑战，请联系程序查BUG", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
		ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingId(challengeId);
		if (ModelBase<OnlineModel>.Instance.GetCurrentTeamSize() <= 1)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(challengeId, false);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InstanceDungeonMultiStart);
		Action value2 = delegate()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(challengeId, true);
		};
		Action value3 = delegate()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.TeamChallengeRequest(challengeId, false);
		};
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap.Add(2, value2);
		confirmBoxDataNew.FunctionMap.Add(1, value3);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600C625 RID: 50725 RVA: 0x00345A2C File Offset: 0x00343C2C
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
		}
	}

	// Token: 0x0600C626 RID: 50726 RVA: 0x00345AB0 File Offset: 0x00343CB0
	public void RefreshRedDot()
	{
		AbyssButtonItem limitRewardBtnItem = this.LimitRewardBtnItem;
		if (limitRewardBtnItem != null)
		{
			ERedDotName redDotName = ERedDotName.RedDotDangoLimitReward;
			DangoAbyssInsSelectViewData viewData = this.ViewData;
			int? uId;
			if (viewData == null)
			{
				uId = null;
			}
			else
			{
				DangoAbyssActivityData activityData = viewData.ActivityData;
				uId = ((activityData != null) ? new int?(activityData.Id) : null);
			}
			limitRewardBtnItem.BindRedDot(redDotName, uId);
		}
		AbyssButtonItem activityRewardBtnItem = this.ActivityRewardBtnItem;
		if (activityRewardBtnItem != null)
		{
			ERedDotName redDotName2 = ERedDotName.RedDotDangoCommonReward;
			DangoAbyssInsSelectViewData viewData2 = this.ViewData;
			int? uId2;
			if (viewData2 == null)
			{
				uId2 = null;
			}
			else
			{
				DangoAbyssActivityData activityData2 = viewData2.ActivityData;
				uId2 = ((activityData2 != null) ? new int?(activityData2.Id) : null);
			}
			activityRewardBtnItem.BindRedDot(redDotName2, uId2);
		}
		AbyssButtonItem friendRankBtnItem = this.FriendRankBtnItem;
		if (friendRankBtnItem == null)
		{
			return;
		}
		friendRankBtnItem.SetRedDotVisible(false);
	}

	// Token: 0x0600C627 RID: 50727 RVA: 0x00345B60 File Offset: 0x00343D60
	private void UnbindRedDot()
	{
		AbyssButtonItem limitRewardBtnItem = this.LimitRewardBtnItem;
		if (limitRewardBtnItem != null)
		{
			limitRewardBtnItem.UnBindRedDot();
		}
		AbyssButtonItem activityRewardBtnItem = this.ActivityRewardBtnItem;
		if (activityRewardBtnItem == null)
		{
			return;
		}
		activityRewardBtnItem.UnBindRedDot();
	}

	// Token: 0x0600C628 RID: 50728 RVA: 0x00345B83 File Offset: 0x00343D83
	[NullableContext(1)]
	private DangoScrollItem InitItem()
	{
		return new DangoScrollItem();
	}

	// Token: 0x0600C629 RID: 50729 RVA: 0x00345B8A File Offset: 0x00343D8A
	[NullableContext(1)]
	public CommonItemSmallItemGrid InitCommonGridItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600C62A RID: 50730 RVA: 0x00345B91 File Offset: 0x00343D91
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C62B RID: 50731 RVA: 0x00345B9C File Offset: 0x00343D9C
	private void OnBtnBackClick()
	{
		base.PlaySequence("PreLeft", null, false);
		this.CurrentSelectedIndex--;
		this.RefreshView();
		if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Default)
		{
			InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
			if (matchingCountDownItem != null)
			{
				matchingCountDownItem.PlayAnimation("Close");
			}
			InstanceDungeonMatchingCountDown matchingCountDownItem2 = this.MatchingCountDownItem;
			if (matchingCountDownItem2 == null)
			{
				return;
			}
			matchingCountDownItem2.SetUiActive(false);
		}
	}

	// Token: 0x0600C62C RID: 50732 RVA: 0x00345C00 File Offset: 0x00343E00
	private void OnBtnNextClick()
	{
		base.PlaySequence("PreRight", null, false);
		this.CurrentSelectedIndex++;
		this.RefreshView();
		if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Default)
		{
			InstanceDungeonMatchingCountDown matchingCountDownItem = this.MatchingCountDownItem;
			if (matchingCountDownItem != null)
			{
				matchingCountDownItem.PlayAnimation("Close");
			}
			InstanceDungeonMatchingCountDown matchingCountDownItem2 = this.MatchingCountDownItem;
			if (matchingCountDownItem2 == null)
			{
				return;
			}
			matchingCountDownItem2.SetUiActive(false);
		}
	}

	// Token: 0x0600C62D RID: 50733 RVA: 0x00345C64 File Offset: 0x00343E64
	protected override void OnBeforeShow()
	{
		DangoWorldQuestItem dangoWorldQuestItem = this.DangoWorldQuestItem;
		if (dangoWorldQuestItem != null)
		{
			dangoWorldQuestItem.Refresh();
		}
		ModelBase<DangoAbyssModel>.Instance.SetInAbyssFlow(false);
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName("DangoAbyssLoop2", true, true, "1001", false, null, null);
		ModelBase<DangoAbyssModel>.Instance.SetInAbyssFlow(false);
		this.RefreshView();
		this.RefreshRedDot();
	}

	// Token: 0x0600C62E RID: 50734 RVA: 0x00345CC6 File Offset: 0x00343EC6
	protected override void OnBeforeHide()
	{
		this.UnbindRedDot();
	}

	// Token: 0x0600C62F RID: 50735 RVA: 0x00345CD0 File Offset: 0x00343ED0
	private void RefreshView()
	{
		int id = this.ViewData.AbyssDataList[this.CurrentSelectedIndex].GetConfig().Value.Id;
		this.RefreshTitleByChallengeId(id);
		this.RefreshSubTitleByChallengeId(id);
		this.RefreshDescByChallengeId(id);
		this.RefreshDangoRewardByChallengeId(id);
		this.RefreshRewardItemLayout(id);
		this.RefreshConsumeInfoByChallengeId(id);
		this.RefreshButtonVisible(id);
		this.RefreshButtonRedDot(id);
		this.RefreshInActiveItemVisible(id);
		this.RefreshUnlockDescription(id);
		this.RefreshRankItemShowState(id);
		this.RefreshChangeIndexBtnVisible(this.ViewData);
		this.RefreshLimitItemShowState(this.ViewData);
		this.RefreshRewardProgressText(this.ViewData);
		this.RefreshGoalLayout();
		this.RefreshInsNameText(id);
		this.RefreshSceneNiagaraByCurrentChallenge(id);
		this.RefreshMaxProgressByChallengeId(id);
	}

	// Token: 0x0600C630 RID: 50736 RVA: 0x00345D94 File Offset: 0x00343F94
	private void RefreshInsNameText(int challengeId)
	{
		AbyssInst? config = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetConfig();
		if (config != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.Value.Title, Array.Empty<object>());
		}
	}

	// Token: 0x0600C631 RID: 50737 RVA: 0x00345DE8 File Offset: 0x00343FE8
	private void RefreshSceneNiagaraByCurrentChallenge(int challengeId)
	{
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("shenyuan").Value, ECollectActorType.UI);
		if (actorWithTag != null && actorWithTag.IsValid())
		{
			if (challengeId == 0)
			{
				return;
			}
			FColor fcolor = FColor.FromHex(ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(challengeId).Value.AbyssColor);
			FLinearColor flinearColor = FLinearColor.FromSRGBColor(fcolor);
			UNiagaraComponent uniagaraComponent = actorWithTag.GetComponentByClass(UNiagaraComponent.StaticClass()) as UNiagaraComponent;
			if (uniagaraComponent == null)
			{
				return;
			}
			uniagaraComponent.SetNiagaraVariableLinearColor("Color", flinearColor);
		}
	}

	// Token: 0x0600C632 RID: 50738 RVA: 0x00345E74 File Offset: 0x00344074
	private void RefreshRankItemShowState(int challengeId)
	{
		bool rankOpen = ModelBase<DangoAbyssModel>.Instance.GetRankOpen();
		AbyssButtonItem friendRankBtnItem = this.FriendRankBtnItem;
		if (friendRankBtnItem == null)
		{
			return;
		}
		friendRankBtnItem.SetActive(rankOpen);
	}

	// Token: 0x0600C633 RID: 50739 RVA: 0x00345EA0 File Offset: 0x003440A0
	[NullableContext(1)]
	private void RefreshLimitItemShowState(DangoAbyssInsSelectViewData data)
	{
		DangoAbyssActivityData activityData = data.ActivityData;
		bool flag = activityData.CheckInLimitTime();
		base.GetItem(5).SetUIActive(flag);
		if (flag)
		{
			string remainTimeText = activityData.GetRemainTimeText();
			AbyssButtonItem limitRewardBtnItem = this.LimitRewardBtnItem;
			if (limitRewardBtnItem == null)
			{
				return;
			}
			limitRewardBtnItem.SetNumText(remainTimeText);
		}
	}

	// Token: 0x0600C634 RID: 50740 RVA: 0x00345EE4 File Offset: 0x003440E4
	[NullableContext(1)]
	private void RefreshRewardProgressText(DangoAbyssInsSelectViewData data)
	{
		string rewardFinishProgressText = data.ActivityData.GetRewardFinishProgressText();
		AbyssButtonItem activityRewardBtnItem = this.ActivityRewardBtnItem;
		if (activityRewardBtnItem == null)
		{
			return;
		}
		activityRewardBtnItem.SetNumText(rewardFinishProgressText);
	}

	// Token: 0x0600C635 RID: 50741 RVA: 0x00345F10 File Offset: 0x00344110
	[NullableContext(1)]
	private void RefreshChangeIndexBtnVisible(DangoAbyssInsSelectViewData data)
	{
		bool uiactive = data.AbyssDataList.Length > 1;
		if (this.CurrentSelectedIndex == 0)
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(false);
		}
		else
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(uiactive);
		}
		if (this.CurrentSelectedIndex == data.AbyssDataList.Length - 1)
		{
			base.GetButton(3).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetButton(3).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x0600C636 RID: 50742 RVA: 0x00345FB0 File Offset: 0x003441B0
	private void RefreshTitleByChallengeId(int challengeId)
	{
		AbyssInst? config = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetConfig();
		if (config != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), config.Value.Title, Array.Empty<object>());
		}
	}

	// Token: 0x0600C637 RID: 50743 RVA: 0x00346004 File Offset: 0x00344204
	private void RefreshSubTitleByChallengeId(int challengeId)
	{
		AbyssInst? config = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetConfig();
		if (config != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), config.Value.SubTitle, Array.Empty<object>());
		}
	}

	// Token: 0x0600C638 RID: 50744 RVA: 0x00346058 File Offset: 0x00344258
	private void RefreshDescByChallengeId(int challengeId)
	{
		AbyssInst? config = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetConfig();
		if (config != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), config.Value.Desc, Array.Empty<object>());
		}
	}

	// Token: 0x0600C639 RID: 50745 RVA: 0x003460AC File Offset: 0x003442AC
	private void RefreshDangoRewardByChallengeId(int challengeId)
	{
		AbyssInst? config = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetConfig();
		if (config != null)
		{
			this.DangoRewardLayout.RefreshByData(config.Value.UnlockLittleRole().ToList<int>(), null, false);
			base.GetItem(28).SetUIActive(config.Value.UnlockLittleRole().Length != 0);
		}
	}

	// Token: 0x0600C63A RID: 50746 RVA: 0x0034611C File Offset: 0x0034431C
	private void RefreshMaxProgressByChallengeId(int challengeId)
	{
		bool challengeButtonCanShow = this.GetChallengeButtonCanShow(challengeId);
		base.GetItem(29).SetUIActive(challengeButtonCanShow);
		if (challengeButtonCanShow)
		{
			int abyssMaxProgress = ModelBase<DangoAbyssModel>.Instance.GetAbyssMaxProgress(challengeId);
			base.GetText(30).SetText(StringUtils.Format("{0}%", new string[]
			{
				abyssMaxProgress.ToString("F0")
			}), true);
		}
	}

	// Token: 0x0600C63B RID: 50747 RVA: 0x0034617C File Offset: 0x0034437C
	private void RefreshRewardItemLayout(int challengeId)
	{
		TItem[] reward = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetReward();
		this.ItemLayout.RefreshByData(reward.ToList<TItem>(), null, false);
	}

	// Token: 0x0600C63C RID: 50748 RVA: 0x003461B4 File Offset: 0x003443B4
	private void RefreshConsumeInfoByChallengeId(int challengeId)
	{
		bool flag = !ModelBase<DangoAbyssModel>.Instance.GetAbyssUnLockState(challengeId);
		base.GetItem(24).SetUIActive(flag);
		AbyssInst? config = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetConfig();
		if (config != null && flag)
		{
			Dictionary<int, int> dictionary = config.Value.ConsumeItem();
			if (dictionary.Count > 0)
			{
				int num = dictionary.Keys.ToList<int>()[0];
				int num2 = dictionary[num];
				base.SetTextureByPath(ConfigBase<ItemConfig>.Instance.GetConfig(num).Value.Icon, base.GetTexture(14), null, null);
				base.GetText(16).SetText(num2.ToString(), true);
			}
		}
	}

	// Token: 0x0600C63D RID: 50749 RVA: 0x00346288 File Offset: 0x00344488
	private bool GetChallengeButtonCanShow(int challengeId)
	{
		bool canChallenge = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetCanChallenge();
		bool abyssPreChallengeFinishState = ModelBase<DangoAbyssModel>.Instance.GetAbyssPreChallengeFinishState(challengeId);
		bool abyssConditionFinishState = ModelBase<DangoAbyssModel>.Instance.GetAbyssConditionFinishState(challengeId);
		bool abyssTimeLimitState = ModelBase<DangoAbyssModel>.Instance.GetAbyssTimeLimitState(challengeId);
		return canChallenge && abyssPreChallengeFinishState && abyssConditionFinishState && abyssTimeLimitState;
	}

	// Token: 0x0600C63E RID: 50750 RVA: 0x003462D8 File Offset: 0x003444D8
	private void RefreshButtonVisible(int challengeId)
	{
		bool challengeButtonCanShow = this.GetChallengeButtonCanShow(challengeId);
		int instId = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetConfig().Value.InstId;
		InstOnlineType onlineType = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instId).Value.OnlineType;
		if (ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<OnlineModel>.Instance.GetIsMyTeam())
		{
			this.ConfirmBtn1.SetActive(false);
			this.ConfirmBtn2.SetActive(false);
			return;
		}
		bool flag = onlineType != InstOnlineType.Single && (onlineType != InstOnlineType.Multi || true);
		this.ConfirmBtn1.SetActive(flag && challengeButtonCanShow);
		this.ConfirmBtn2.SetActive(challengeButtonCanShow);
		if (onlineType == InstOnlineType.Mixture && ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ButtonItem confirmBtn = this.ConfirmBtn2;
			if (confirmBtn != null)
			{
				confirmBtn.SetLocalTextNew("AbyssMPChallenge", Array.Empty<object>());
			}
		}
		else
		{
			ButtonItem confirmBtn2 = this.ConfirmBtn2;
			if (confirmBtn2 != null)
			{
				confirmBtn2.SetLocalTextNew("AbyssSoloChallenge", Array.Empty<object>());
			}
		}
		bool p = flag && challengeButtonCanShow;
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnAbyssTeamBtnVisibleRefresh, p);
	}

	// Token: 0x0600C63F RID: 50751 RVA: 0x003463F9 File Offset: 0x003445F9
	private void RefreshButtonRedDot(int challengeId)
	{
		ButtonItem confirmBtn = this.ConfirmBtn1;
		if (confirmBtn != null)
		{
			confirmBtn.SetRedDotVisible(false);
		}
		ButtonItem confirmBtn2 = this.ConfirmBtn2;
		if (confirmBtn2 == null)
		{
			return;
		}
		confirmBtn2.SetRedDotVisible(false);
	}

	// Token: 0x0600C640 RID: 50752 RVA: 0x00346420 File Offset: 0x00344620
	private void RefreshInActiveItemVisible(int challengeId)
	{
		bool canChallenge = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetCanChallenge();
		bool abyssPreChallengeFinishState = ModelBase<DangoAbyssModel>.Instance.GetAbyssPreChallengeFinishState(challengeId);
		bool abyssConditionFinishState = ModelBase<DangoAbyssModel>.Instance.GetAbyssConditionFinishState(challengeId);
		bool abyssTimeLimitState = ModelBase<DangoAbyssModel>.Instance.GetAbyssTimeLimitState(challengeId);
		FunctionalPanelConditionLock panelLock = this.PanelLock;
		if (panelLock == null)
		{
			return;
		}
		panelLock.SetActive(!canChallenge || !abyssTimeLimitState || !abyssPreChallengeFinishState || !abyssConditionFinishState);
	}

	// Token: 0x0600C641 RID: 50753 RVA: 0x00346488 File Offset: 0x00344688
	private void RefreshUnlockDescription(int challengeId)
	{
		if (ModelBase<DangoAbyssModel>.Instance.GetAbyssPreChallengeFinishState(challengeId))
		{
			if (!ModelBase<DangoAbyssModel>.Instance.GetAbyssConditionFinishState(challengeId))
			{
				AbyssInst? config = this.ViewData.ActivityData.GetAbyssChallengeDataById(challengeId).GetConfig();
				if (config != null)
				{
					string unLockDesc = config.Value.UnLockDesc;
					if (unLockDesc != "")
					{
						FunctionalPanelConditionLock panelLock = this.PanelLock;
						if (panelLock == null)
						{
							return;
						}
						panelLock.SetTextByTextId(unLockDesc, Array.Empty<string>());
						return;
					}
				}
			}
			if (!ModelBase<DangoAbyssModel>.Instance.GetAbyssTimeLimitState(challengeId))
			{
				string abyssUnlockTimeText = ModelBase<DangoAbyssModel>.Instance.GetAbyssUnlockTimeText(challengeId);
				string textByText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("AbyssUnlockTime", null), new string[]
				{
					abyssUnlockTimeText
				});
				FunctionalPanelConditionLock panelLock2 = this.PanelLock;
				if (panelLock2 == null)
				{
					return;
				}
				panelLock2.SetTextByText(textByText);
			}
			return;
		}
		FunctionalPanelConditionLock panelLock3 = this.PanelLock;
		if (panelLock3 == null)
		{
			return;
		}
		panelLock3.SetTextByTextId("AbyssNeedPreChallengeFinish", Array.Empty<string>());
	}

	// Token: 0x0600C642 RID: 50754 RVA: 0x00346568 File Offset: 0x00344768
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

	// Token: 0x0600C643 RID: 50755 RVA: 0x00346674 File Offset: 0x00344874
	private void OnAbyssUnlockChallengeStateUpdate()
	{
		this.RefreshView();
	}

	// Token: 0x0600C644 RID: 50756 RVA: 0x0034667C File Offset: 0x0034487C
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

	// Token: 0x0600C645 RID: 50757 RVA: 0x003466DC File Offset: 0x003448DC
	private void SetMatchingItemActive(bool state)
	{
		base.GetItem(19).SetUIActive(state);
		base.GetItem(25).SetUIActive(!state);
	}

	// Token: 0x0600C646 RID: 50758 RVA: 0x003466FD File Offset: 0x003448FD
	private void BeginMatching()
	{
		this.MatchingCountDownItem.SetMatchingTime(0);
		this.MatchingCountDownItem.StartTimer();
	}

	// Token: 0x0600C647 RID: 50759 RVA: 0x00346718 File Offset: 0x00344918
	private void RefreshGoalLayout()
	{
		List<global::Quest> questsByTypeAndSubType = ModelBase<QuestNewModel>.Instance.GetQuestsByTypeAndSubType(10, 1);
		List<GoalPanelData> list = new List<GoalPanelData>();
		foreach (global::Quest quest in questsByTypeAndSubType)
		{
			GoalPanelData goalPanelData = new GoalPanelData();
			string questName = ModelBase<QuestNewModel>.Instance.GetQuestName(quest.Id);
			goalPanelData.Title = questName;
			list.Add(goalPanelData);
		}
	}

	// Token: 0x0600C648 RID: 50760 RVA: 0x00346798 File Offset: 0x00344998
	protected override void OnBeforeDestroy()
	{
		CommonCurrencyItem currencyItem = this.CurrencyItem;
		if (currencyItem != null)
		{
			currencyItem.Destroy(null);
		}
		DangoWorldQuestItem dangoWorldQuestItem = this.DangoWorldQuestItem;
		if (dangoWorldQuestItem == null)
		{
			return;
		}
		dangoWorldQuestItem.Clear();
	}

	// Token: 0x04005EF9 RID: 24313
	[Nullable(1)]
	private const string ENTRANCELOOP = "DangoAbyssLoop2";

	// Token: 0x04005EFA RID: 24314
	private const int MATCHING_ITEM_OFFSET = -98;

	// Token: 0x04005EFB RID: 24315
	private InstanceDungeonMatchingCountDown MatchingCountDownItem;

	// Token: 0x04005EFC RID: 24316
	private CommonCurrencyItem CurrencyItem;

	// Token: 0x04005EFD RID: 24317
	private DangoAbyssInsSelectViewData ViewData;

	// Token: 0x04005EFE RID: 24318
	private int CurrentSelectedIndex;

	// Token: 0x04005EFF RID: 24319
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x04005F00 RID: 24320
	private AbyssButtonItem FriendRankBtnItem;

	// Token: 0x04005F01 RID: 24321
	private AbyssButtonItem LimitRewardBtnItem;

	// Token: 0x04005F02 RID: 24322
	private AbyssButtonItem ActivityRewardBtnItem;

	// Token: 0x04005F03 RID: 24323
	private ButtonItem ConfirmBtn1;

	// Token: 0x04005F04 RID: 24324
	private ButtonItem ConfirmBtn2;

	// Token: 0x04005F05 RID: 24325
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<DangoScrollItem, int> DangoRewardLayout;

	// Token: 0x04005F06 RID: 24326
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;

	// Token: 0x04005F07 RID: 24327
	private DangoWorldQuestItem DangoWorldQuestItem;

	// Token: 0x02007DB9 RID: 32185
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AD10 RID: 175376
		BackBtn,
		// Token: 0x0402AD11 RID: 175377
		InsNameText,
		// Token: 0x0402AD12 RID: 175378
		BtnBack,
		// Token: 0x0402AD13 RID: 175379
		BtnNext,
		// Token: 0x0402AD14 RID: 175380
		FriendRankBtnItem,
		// Token: 0x0402AD15 RID: 175381
		LimitRewardBtnItem,
		// Token: 0x0402AD16 RID: 175382
		ActivityRewardBtnItem,
		// Token: 0x0402AD17 RID: 175383
		TitleText,
		// Token: 0x0402AD18 RID: 175384
		SubTitleText,
		// Token: 0x0402AD19 RID: 175385
		DescText,
		// Token: 0x0402AD1A RID: 175386
		UnlockDangoLayout,
		// Token: 0x0402AD1B RID: 175387
		DangoItem,
		// Token: 0x0402AD1C RID: 175388
		RewardItemLayout,
		// Token: 0x0402AD1D RID: 175389
		RewardItem,
		// Token: 0x0402AD1E RID: 175390
		ConsumeItemTexture,
		// Token: 0x0402AD1F RID: 175391
		ConsumeItemMask,
		// Token: 0x0402AD20 RID: 175392
		ConsumeItemText,
		// Token: 0x0402AD21 RID: 175393
		ConfirmBtn1,
		// Token: 0x0402AD22 RID: 175394
		ConfirmBtn2,
		// Token: 0x0402AD23 RID: 175395
		MatchingTextItem,
		// Token: 0x0402AD24 RID: 175396
		InActiveItem,
		// Token: 0x0402AD25 RID: 175397
		TopItem,
		// Token: 0x0402AD26 RID: 175398
		CostItem,
		// Token: 0x0402AD27 RID: 175399
		ConsumeItem,
		// Token: 0x0402AD28 RID: 175400
		ConsumeCostItem,
		// Token: 0x0402AD29 RID: 175401
		DownButtonItem,
		// Token: 0x0402AD2A RID: 175402
		GoalScroller,
		// Token: 0x0402AD2B RID: 175403
		GoalItem,
		// Token: 0x0402AD2C RID: 175404
		DangoRootItem,
		// Token: 0x0402AD2D RID: 175405
		MaxProgressItem,
		// Token: 0x0402AD2E RID: 175406
		MaxProgressText
	}
}
