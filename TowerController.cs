using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002BD8 RID: 11224
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class TowerController : ControllerBase<TowerController>
{
	// Token: 0x0601666E RID: 91758 RVA: 0x00638533 File Offset: 0x00636733
	protected override bool OnInit()
	{
		this.OnAddEvents();
		this.OnRegisterNetEvent();
		return true;
	}

	// Token: 0x0601666F RID: 91759 RVA: 0x00638542 File Offset: 0x00636742
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		this.OnUnRegisterNetEvent();
		return true;
	}

	// Token: 0x06016670 RID: 91760 RVA: 0x00638551 File Offset: 0x00636751
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDone));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
	}

	// Token: 0x06016671 RID: 91761 RVA: 0x0063858B File Offset: 0x0063678B
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
	}

	// Token: 0x06016672 RID: 91762 RVA: 0x006385C8 File Offset: 0x006367C8
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<TowerInfoUpdateNotify>(ENotifyMessageId.TowerInfoUpdateNotify, new Action<TowerInfoUpdateNotify, Net.CallbackStatus>(this.TowerInfoUpdateNotify));
		Singleton<Net>.Instance.Register<TowerDifficultyUpdateNotify>(ENotifyMessageId.TowerDifficultyUpdateNotify, new Action<TowerDifficultyUpdateNotify, Net.CallbackStatus>(this.TowerDifficultyUpdateNotify));
		Singleton<Net>.Instance.Register<TowerFloorUpdateNotify>(ENotifyMessageId.TowerFloorUpdateNotify, new Action<TowerFloorUpdateNotify, Net.CallbackStatus>(this.TowerFloorUpdateNotify));
		Singleton<Net>.Instance.Register<TowerEndNotify>(ENotifyMessageId.TowerEndNotify, new Action<TowerEndNotify, Net.CallbackStatus>(this.TowerEndNotify));
	}

	// Token: 0x06016673 RID: 91763 RVA: 0x00638648 File Offset: 0x00636848
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerDifficultyUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerFloorUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerEndNotify);
	}

	// Token: 0x06016674 RID: 91764 RVA: 0x00638695 File Offset: 0x00636895
	private void OnFunctionOpenUpdate(EFunctionType functionType, bool isOpen)
	{
		if (functionType != EFunctionType.NewTower)
		{
			return;
		}
		if (!isOpen)
		{
			return;
		}
		this.TowerRequest();
	}

	// Token: 0x06016675 RID: 91765 RVA: 0x006386AC File Offset: 0x006368AC
	private void WorldDone()
	{
		ModelBase<TowerModel>.Instance.IsWaitTowerStart = false;
		ModelBase<TowerModel>.Instance.IsWaitTowerSettlement = false;
		this.TowerRequest();
		if (ModelBase<TowerModel>.Instance.NeedOpenConfirmView)
		{
			TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(ModelBase<TowerModel>.Instance.NeedOpenConfirmViewTowerId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerFloorView, towerInfo.Value.AreaNum, null);
		}
		if (ModelBase<TowerModel>.Instance.CheckInTower())
		{
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("TowerGuide");
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				ControllerBase<TowerController>.Instance.OpenTowerGuide();
				Singleton<EventSystem>.Instance.Emit(EEventName.OnShowTowerGuideButton);
			}, (float)ModelBase<TowerModel>.Instance.TowerGuideDelayTime, null, null, true, 1f);
		}
	}

	// Token: 0x06016676 RID: 91766 RVA: 0x00638774 File Offset: 0x00636974
	[NullableContext(0)]
	public UniTask<bool> RefreshTower(int timeoutMs = 0)
	{
		TowerController.<RefreshTower>d__10 <RefreshTower>d__;
		<RefreshTower>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RefreshTower>d__.timeoutMs = timeoutMs;
		<RefreshTower>d__.<>1__state = -1;
		<RefreshTower>d__.<>t__builder.Start<TowerController.<RefreshTower>d__10>(ref <RefreshTower>d__);
		return <RefreshTower>d__.<>t__builder.Task;
	}

	// Token: 0x06016677 RID: 91767 RVA: 0x006387B8 File Offset: 0x006369B8
	public UniTask TowerStartRequest(int towerConfigId, List<int> formation, bool checkCost = true)
	{
		TowerController.<TowerStartRequest>d__11 <TowerStartRequest>d__;
		<TowerStartRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TowerStartRequest>d__.towerConfigId = towerConfigId;
		<TowerStartRequest>d__.formation = formation;
		<TowerStartRequest>d__.checkCost = checkCost;
		<TowerStartRequest>d__.<>1__state = -1;
		<TowerStartRequest>d__.<>t__builder.Start<TowerController.<TowerStartRequest>d__11>(ref <TowerStartRequest>d__);
		return <TowerStartRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06016678 RID: 91768 RVA: 0x0063880C File Offset: 0x00636A0C
	public void TowerResetRequest(int towerConfigId)
	{
		TowerResetRequest towerResetRequest = Aki.Protocol.TowerResetRequest.Create();
		towerResetRequest.TowerConfigId = towerConfigId;
		Singleton<Net>.Instance.Call<TowerResetResponse>(ERequestMessageId.TowerResetRequest, towerResetRequest, delegate(TowerResetResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnTowerRefresh);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ResetConfirm", Array.Empty<object>());
				return;
			}
			if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.ErrTowerSeasonUpdate)
			{
				ControllerBase<TowerController>.Instance.OpenSeasonUpdateConfirm();
				return;
			}
			if (response != null)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27635, null, true, true);
			}
		}, 0);
	}

	// Token: 0x06016679 RID: 91769 RVA: 0x00638858 File Offset: 0x00636A58
	public void TowerRewardRequest(int difficulty, int rewardIndex, List<int> rewardIndexList)
	{
		TowerRewardRequest towerRewardRequest = Aki.Protocol.TowerRewardRequest.Create();
		towerRewardRequest.Difficulty = difficulty;
		towerRewardRequest.RewardIndex = rewardIndex;
		towerRewardRequest.RewardIndexList.AddRange(rewardIndexList);
		Singleton<Net>.Instance.Call<TowerRewardResponse>(ERequestMessageId.TowerRewardRequest, towerRewardRequest, delegate(TowerRewardResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnTowerRewardReceived);
				Singleton<EventSystem>.Instance.Emit(EEventName.RedDotTowerReward);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotTowerRewardByDifficulties, difficulty);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotTowerRewardByDifficulties, 5);
				return;
			}
			if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.ErrTowerSeasonUpdate)
			{
				ControllerBase<TowerController>.Instance.OpenSeasonUpdateConfirm();
				return;
			}
			if (response != null)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17270, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0601667A RID: 91770 RVA: 0x006388B4 File Offset: 0x00636AB4
	public UniTask TowerFormationRecommendRequest(int towerConfigId)
	{
		TowerController.<TowerFormationRecommendRequest>d__14 <TowerFormationRecommendRequest>d__;
		<TowerFormationRecommendRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TowerFormationRecommendRequest>d__.towerConfigId = towerConfigId;
		<TowerFormationRecommendRequest>d__.<>1__state = -1;
		<TowerFormationRecommendRequest>d__.<>t__builder.Start<TowerController.<TowerFormationRecommendRequest>d__14>(ref <TowerFormationRecommendRequest>d__);
		return <TowerFormationRecommendRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0601667B RID: 91771 RVA: 0x006388F8 File Offset: 0x00636AF8
	public void TowerApplyFloorDataRequest(bool apply)
	{
		TowerApplyFloorDataRequest towerApplyFloorDataRequest = Aki.Protocol.TowerApplyFloorDataRequest.Create();
		towerApplyFloorDataRequest.Apply = apply;
		Singleton<Net>.Instance.Call<TowerApplyFloorDataResponse>(ERequestMessageId.TowerApplyFloorDataRequest, towerApplyFloorDataRequest, delegate(TowerApplyFloorDataResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnTowerRefresh);
				return;
			}
			if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.ErrTowerSeasonUpdate)
			{
				ControllerBase<TowerController>.Instance.OpenSeasonUpdateConfirm();
				return;
			}
			if (response != null)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25038, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0601667C RID: 91772 RVA: 0x00638942 File Offset: 0x00636B42
	private void TowerInfoUpdateNotify(TowerInfoUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
	{
		if (data.TowerInfo != null)
		{
			ModelBase<TowerModel>.Instance.RefreshTowerInfo(data.TowerInfo);
		}
	}

	// Token: 0x0601667D RID: 91773 RVA: 0x0063895C File Offset: 0x00636B5C
	private void TowerFloorUpdateNotify(TowerFloorUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<TowerModel>.Instance.RefreshTowerInfoByFloor(data.TowerFloors);
	}

	// Token: 0x0601667E RID: 91774 RVA: 0x0063896E File Offset: 0x00636B6E
	private void TowerDifficultyUpdateNotify(TowerDifficultyUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<TowerModel>.Instance.RefreshTowerInfoByDifficulty(data.TowerDifficulties);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, 100300002);
	}

	// Token: 0x0601667F RID: 91775 RVA: 0x00638998 File Offset: 0x00636B98
	private void TowerEndNotify(TowerEndNotify data, [Nullable(2)] Net.CallbackStatus _)
	{
		if (data.NeedUpdateSeason && !ModelBase<TowerModel>.Instance.GetIsInOnceTower())
		{
			ControllerBase<TowerController>.Instance.OpenSeasonUpdateConfirm();
			return;
		}
		if (ModelBase<TowerModel>.Instance.IsWaitTowerStart)
		{
			return;
		}
		ModelBase<TowerModel>.Instance.IsWaitTowerSettlement = true;
		ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
		if (data.Success)
		{
			TowerFloorPb currentFloorData = data.CurrentFloorData;
			if (currentFloorData != null)
			{
				ModelBase<TowerModel>.Instance.CurrentNotConfirmedFloor = new TowerFloorInfo(currentFloorData.TowerConfigId, currentFloorData.Star, currentFloorData.Formation.ToList<TowerRolePb>(), currentFloorData.StarIndex.ToList<int>(), currentFloorData.IsQuickPass);
			}
		}
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("TowerGuide");
		ControllerBase<TowerController>.Instance.ClearAllHatredInTower();
		ControllerBase<TowerController>.Instance.OpenTowerSettlementView(data.Success);
	}

	// Token: 0x06016680 RID: 91776 RVA: 0x00638A58 File Offset: 0x00636C58
	private void TowerRequest()
	{
		TowerRequest message = Aki.Protocol.TowerRequest.Create();
		Singleton<Net>.Instance.Call<TowerResponse>(ERequestMessageId.TowerRequest, message, delegate(TowerResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.TowerInfo != null)
			{
				ModelBase<TowerModel>.Instance.RefreshTowerInfo(response.TowerInfo);
				ModelBase<WorldMapModel>.Instance.UpdateActivityListItemData(true);
			}
		}, 0);
	}

	// Token: 0x06016681 RID: 91777 RVA: 0x00638A9C File Offset: 0x00636C9C
	public unsafe void OpenTowerSettlementView(bool isSuccess)
	{
		TowerController.<>c__DisplayClass21_0 CS$<>8__locals1 = new TowerController.<>c__DisplayClass21_0();
		CS$<>8__locals1.isSuccess = isSuccess;
		CS$<>8__locals1.towerManager = ModelBase<TowerModel>.Instance;
		int currentTowerId = CS$<>8__locals1.towerManager.CurrentTowerId;
		bool haveChallengeFloorAndFormation = CS$<>8__locals1.towerManager.GetHaveChallengeFloorAndFormation(currentTowerId);
		CS$<>8__locals1.buttonList = new List<IRewardExploreConfirmButton>();
		CS$<>8__locals1.nextTowerFloor = ConfigBase<TowerClimbConfig>.Instance.GetNextFloorInArea(currentTowerId);
		List<IRewardExploreConfirmButton> buttonList = CS$<>8__locals1.buttonList;
		RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
		rewardExploreConfirmButtonData.ButtonTextId = "Text_BackToTower_Text";
		rewardExploreConfirmButtonData.DescriptionTextId = null;
		rewardExploreConfirmButtonData.IsTimeDownCloseView = false;
		rewardExploreConfirmButtonData.IsClickedCloseView = true;
		rewardExploreConfirmButtonData.OnClickedCallback = delegate(int _)
		{
			ControllerBase<TowerController>.Instance.BackToTowerView(null);
		};
		buttonList.Add(rewardExploreConfirmButtonData);
		CS$<>8__locals1.toggle = null;
		if (CS$<>8__locals1.isSuccess && haveChallengeFloorAndFormation)
		{
			CS$<>8__locals1.buttonList.RemoveAt(CS$<>8__locals1.buttonList.Count - 1);
			CS$<>8__locals1.buttonList.Add(new RewardExploreConfirmButtonData
			{
				ButtonTextId = "Text_ButtonTextConfirmResult_Text",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = delegate(int _)
				{
					ControllerBase<TowerController>.Instance.ConfirmResult(false, CS$<>8__locals1.isSuccess);
				}
			});
		}
		else if (CS$<>8__locals1.isSuccess && CS$<>8__locals1.nextTowerFloor != 0 && !haveChallengeFloorAndFormation)
		{
			TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(CS$<>8__locals1.nextTowerFloor);
			string towerAreaName = ConfigBase<TowerClimbConfig>.Instance.GetTowerAreaName(CS$<>8__locals1.nextTowerFloor);
			if (towerInfo != null && towerAreaName != null)
			{
				List<IRewardExploreConfirmButton> buttonList2 = CS$<>8__locals1.buttonList;
				RewardExploreConfirmButtonData rewardExploreConfirmButtonData2 = new RewardExploreConfirmButtonData();
				rewardExploreConfirmButtonData2.ButtonTextId = "Text_ButtonTextContinue_Text";
				rewardExploreConfirmButtonData2.DescriptionTextId = "Text_ButtonTextGoOnTower_Text";
				int num = 2;
				List<object> list = new List<object>(num);
				CollectionsMarshal.SetCount<object>(list, num);
				Span<object> span = CollectionsMarshal.AsSpan<object>(list);
				int i = 0;
				*span[i] = towerAreaName;
				i++;
				*span[i] = towerInfo.Value.Floor;
				rewardExploreConfirmButtonData2.DescriptionArgs = list;
				rewardExploreConfirmButtonData2.IsTimeDownCloseView = false;
				rewardExploreConfirmButtonData2.IsClickedCloseView = true;
				rewardExploreConfirmButtonData2.OnClickedCallback = delegate(int _)
				{
					ControllerBase<TowerController>.Instance.OpenTowerFormation(new int?(CS$<>8__locals1.nextTowerFloor));
				};
				buttonList2.Add(rewardExploreConfirmButtonData2);
			}
		}
		else if (!CS$<>8__locals1.isSuccess || CS$<>8__locals1.nextTowerFloor == 0)
		{
			CS$<>8__locals1.towerManager.NeedChangeFormation = false;
			List<IRewardExploreConfirmButton> buttonList3 = CS$<>8__locals1.buttonList;
			RewardExploreConfirmButtonData rewardExploreConfirmButtonData3 = new RewardExploreConfirmButtonData();
			rewardExploreConfirmButtonData3.ButtonTextId = "Text_ButtonTextChallengeOneMore_Text";
			rewardExploreConfirmButtonData3.DescriptionTextId = null;
			rewardExploreConfirmButtonData3.IsTimeDownCloseView = false;
			rewardExploreConfirmButtonData3.IsClickedCloseView = true;
			rewardExploreConfirmButtonData3.OnClickedCallback = delegate(int _)
			{
				if (ModelBase<TowerModel>.Instance.NeedChangeFormation)
				{
					ControllerBase<TowerController>.Instance.OpenTowerFormation(null);
					return;
				}
				ControllerBase<TowerController>.Instance.ReChallengeTower();
			};
			buttonList3.Add(rewardExploreConfirmButtonData3);
			CS$<>8__locals1.toggle = new RewardExploreToggleData
			{
				DescriptionTextId = "Text_ChangeFormation_Text",
				OnToggleClick = delegate(EToggleState state)
				{
					CS$<>8__locals1.towerManager.NeedChangeFormation = (state == EToggleState.ETT_Checked);
				}
			};
		}
		if (CS$<>8__locals1.isSuccess)
		{
			List<IRewardExploreTargetReached> targetReached = new List<IRewardExploreTargetReached>();
			IReadOnlyList<int> floorTarget = ConfigBase<TowerClimbConfig>.Instance.GetFloorTarget(currentTowerId);
			if (floorTarget != null && ModelBase<TowerModel>.Instance.CurrentNotConfirmedFloor != null)
			{
				List<int> starIndex = ModelBase<TowerModel>.Instance.CurrentNotConfirmedFloor.StarIndex;
				for (int j = 0; j < 3; j++)
				{
					if (j < floorTarget.Count)
					{
						TowerTarget? targetConfig = ConfigBase<TowerClimbConfig>.Instance.GetTargetConfig(floorTarget[j]);
						if (targetConfig != null)
						{
							List<string> list2 = new List<string>();
							if (targetConfig.Value.Params() != null)
							{
								foreach (int num2 in targetConfig.Value.Params())
								{
									list2.Add(num2.ToString());
								}
							}
							bool isReached = starIndex.Contains(j);
							RewardExploreTargetReachedData item = new RewardExploreTargetReachedData
							{
								Target = list2.ToList<string>(),
								DescriptionTextId = targetConfig.Value.DesText,
								IsReached = isReached
							};
							targetReached.Add(item);
						}
					}
				}
			}
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				ControllerBase<ItemRewardController>.Instance.OpenExploreRewardView(3008, CS$<>8__locals1.isSuccess, null, null, null, CS$<>8__locals1.buttonList, targetReached, CS$<>8__locals1.toggle, null, null, null, null, null, null, null, null, null);
			}, (float)ModelBase<TowerModel>.Instance.TowerSettlementDelayTime, null, null, true, 1f);
			return;
		}
		List<IRewardExploreBar> barList = new List<IRewardExploreBar>();
		IReadOnlyList<TrainingData> trainingDataList = ModelBase<TrainingDegreeModel>.Instance.GetTrainingDataList();
		if (trainingDataList == null)
		{
			return;
		}
		foreach (TrainingData trainingData in trainingDataList)
		{
			RewardExploreBar item2 = new RewardExploreBar
			{
				TrainingData = trainingData
			};
			barList.Add(item2);
		}
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardView(3009, CS$<>8__locals1.isSuccess, null, null, barList, CS$<>8__locals1.buttonList, null, CS$<>8__locals1.toggle, null, null, null, null, null, null, null, null, null);
		}, (float)ModelBase<TowerModel>.Instance.TowerSettlementDelayTime, null, null, true, 1f);
	}

	// Token: 0x06016682 RID: 91778 RVA: 0x00638F60 File Offset: 0x00637160
	private void CloseTowerView()
	{
		Singleton<UiManager>.Instance.ResetToBattleView(delegate(bool _)
		{
			if (ModelBase<TowerModel>.Instance.CheckInTower())
			{
				ControllerBase<TowerController>.Instance.LeaveTower().Forget();
			}
		});
	}

	// Token: 0x06016683 RID: 91779 RVA: 0x00638F8C File Offset: 0x0063718C
	public UniTask LeaveTower()
	{
		TowerController.<LeaveTower>d__23 <LeaveTower>d__;
		<LeaveTower>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LeaveTower>d__.<>1__state = -1;
		<LeaveTower>d__.<>t__builder.Start<TowerController.<LeaveTower>d__23>(ref <LeaveTower>d__);
		return <LeaveTower>d__.<>t__builder.Task;
	}

	// Token: 0x06016684 RID: 91780 RVA: 0x00638FC8 File Offset: 0x006371C8
	private void OpenTowerFormation(int? nextFloor = null)
	{
		ModelBase<TowerModel>.Instance.OpenTowerFormationView(nextFloor ?? ModelBase<TowerModel>.Instance.CurrentTowerId);
	}

	// Token: 0x06016685 RID: 91781 RVA: 0x00638FFD File Offset: 0x006371FD
	public void ReChallengeTower()
	{
		ModelBase<TowerModel>.Instance.IsWaitTowerStart = true;
		ControllerBase<TowerController>.Instance.TowerStartRequest(ModelBase<TowerModel>.Instance.CurrentTowerId, ModelBase<TowerModel>.Instance.CurrentTowerFormation, false);
	}

	// Token: 0x06016686 RID: 91782 RVA: 0x0063902C File Offset: 0x0063722C
	private void ConfirmResult(bool isFormLeave, bool isSuccess)
	{
		if (isSuccess)
		{
			ModelBase<TowerModel>.Instance.SaveNeedOpenConfirmView();
		}
		if (isFormLeave)
		{
			return;
		}
		TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(ModelBase<TowerModel>.Instance.NeedOpenConfirmViewTowerId);
		if (towerInfo != null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerFloorView, towerInfo.Value.AreaNum, null);
		}
	}

	// Token: 0x06016687 RID: 91783 RVA: 0x0063908C File Offset: 0x0063728C
	[NullableContext(2)]
	public void BackToTowerView(Action callBack = null)
	{
		ControllerBase<TowerController>.Instance.OpenTowerView(true).ContinueWith(delegate(bool _)
		{
			Action callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2();
		});
	}

	// Token: 0x06016688 RID: 91784 RVA: 0x006390C4 File Offset: 0x006372C4
	[NullableContext(0)]
	public UniTask<bool> OpenTowerView(bool openCurrentFloor = false)
	{
		TowerController.<OpenTowerView>d__28 <OpenTowerView>d__;
		<OpenTowerView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenTowerView>d__.openCurrentFloor = openCurrentFloor;
		<OpenTowerView>d__.<>1__state = -1;
		<OpenTowerView>d__.<>t__builder.Start<TowerController.<OpenTowerView>d__28>(ref <OpenTowerView>d__);
		return <OpenTowerView>d__.<>t__builder.Task;
	}

	// Token: 0x06016689 RID: 91785 RVA: 0x00639108 File Offset: 0x00637308
	[NullableContext(0)]
	private UniTask<bool> OpenTowerViewInternal(bool openCurrentFloor = false)
	{
		TowerController.<OpenTowerViewInternal>d__29 <OpenTowerViewInternal>d__;
		<OpenTowerViewInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenTowerViewInternal>d__.openCurrentFloor = openCurrentFloor;
		<OpenTowerViewInternal>d__.<>1__state = -1;
		<OpenTowerViewInternal>d__.<>t__builder.Start<TowerController.<OpenTowerViewInternal>d__29>(ref <OpenTowerViewInternal>d__);
		return <OpenTowerViewInternal>d__.<>t__builder.Task;
	}

	// Token: 0x0601668A RID: 91786 RVA: 0x0063914C File Offset: 0x0063734C
	public void OpenSeasonUpdateConfirm()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CycleTowerSeasonRefresh);
		Action value = delegate()
		{
			ControllerBase<TowerController>.Instance.CloseTowerView();
		};
		confirmBoxDataNew.FunctionMap.Add(1, value);
		confirmBoxDataNew.FunctionMap.Add(2, value);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0601668B RID: 91787 RVA: 0x006391A7 File Offset: 0x006373A7
	public void OpenTowerGuide()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerGuideView, null, null);
	}

	// Token: 0x0601668C RID: 91788 RVA: 0x006391BC File Offset: 0x006373BC
	public void ClearAllHatredInTower()
	{
		foreach (int id in ModelBase<FormationDataModel>.Instance.PlayerAggroSet)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(id);
			if (entity != null)
			{
				CharacterAiComponent characterAiComponent = entity.CheckGetComponent<CharacterAiComponent>();
				if (characterAiComponent != null)
				{
					AiController aiController = characterAiComponent.AiController;
					if (aiController != null)
					{
						AiHateList aiHateList = aiController.AiHateList;
						if (aiHateList != null)
						{
							aiHateList.ClearHatred(0);
						}
					}
				}
			}
		}
	}

	// Token: 0x0400AD57 RID: 44375
	private const int TOWER_SUCCESS_NO_REWARD = 3008;

	// Token: 0x0400AD58 RID: 44376
	private const int TOWER_FAIL = 3009;
}
