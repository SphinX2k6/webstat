using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x0200137E RID: 4990
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityMapTravelController : ActivityControllerBase<ActivityMapTravelController>
{
	// Token: 0x060088E8 RID: 35048 RVA: 0x002412E2 File Offset: 0x0023F4E2
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<MapTravelInfoUpdateNotify>(ENotifyMessageId.MapTravelInfoUpdateNotify, new Action<MapTravelInfoUpdateNotify, Net.CallbackStatus>(this.OnMapTravelInfoUpdateNotify));
	}

	// Token: 0x060088E9 RID: 35049 RVA: 0x00241300 File Offset: 0x0023F500
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MapTravelInfoUpdateNotify);
	}

	// Token: 0x060088EA RID: 35050 RVA: 0x00241312 File Offset: 0x0023F512
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x060088EB RID: 35051 RVA: 0x0024134C File Offset: 0x0023F54C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x060088EC RID: 35052 RVA: 0x00241386 File Offset: 0x0023F586
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_TravelMapSubView";
	}

	// Token: 0x060088ED RID: 35053 RVA: 0x00241390 File Offset: 0x0023F590
	private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
	{
		ActivityMapTravelData mapTravelData = this.GetMapTravelData();
		if (mapTravelData == null)
		{
			return;
		}
		if (mapTravelData.PhantomQuestIds.Contains(questId))
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, mapTravelData.Id);
		}
	}

	// Token: 0x060088EE RID: 35054 RVA: 0x002413CC File Offset: 0x0023F5CC
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		ActivityMapTravelData mapTravelData = this.GetMapTravelData();
		if (mapTravelData == null)
		{
			return;
		}
		if (mapTravelData.GetActivityConfig().ExpItemId != configId)
		{
			return;
		}
		if (mapTravelData.CanTravelLevelUp())
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, mapTravelData.Id);
		}
		this.TryOpenLevelTipsView(mapTravelData);
	}

	// Token: 0x060088EF RID: 35055 RVA: 0x0024141B File Offset: 0x0023F61B
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060088F0 RID: 35056 RVA: 0x0024141D File Offset: 0x0023F61D
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewMapTravel();
	}

	// Token: 0x060088F1 RID: 35057 RVA: 0x00241424 File Offset: 0x0023F624
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityMapTravelData();
	}

	// Token: 0x060088F2 RID: 35058 RVA: 0x0024142B File Offset: 0x0023F62B
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060088F3 RID: 35059 RVA: 0x00241430 File Offset: 0x0023F630
	[NullableContext(2)]
	public ActivityMapTravelData GetMapTravelData()
	{
		List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(32);
		ActivityMapTravelData result = null;
		if (currentActivitiesByType.Count > 0)
		{
			result = (currentActivitiesByType[0] as ActivityMapTravelData);
		}
		return result;
	}

	// Token: 0x060088F4 RID: 35060 RVA: 0x00241464 File Offset: 0x0023F664
	private void OnMapTravelInfoUpdateNotify(MapTravelInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		ActivityMapTravelData mapTravelData = this.GetMapTravelData();
		if (mapTravelData == null)
		{
			return;
		}
		if (notify.ActivityTask != null)
		{
			mapTravelData.RefreshTravelTaskData(notify.ActivityTask);
		}
		if (notify.SoarLevel != null)
		{
			mapTravelData.RefreshSoarChallengePlayData(notify.SoarLevel);
			ModelBase<GeneralLogicTreeModel>.Instance.HistorySoarScore = notify.SoarLevel.HistorySoarScore;
		}
		if (notify.HasUnLockArea)
		{
			mapTravelData.UnlockAreaData(notify.UnLockArea);
		}
		if (notify.HasUnLockMonsterId)
		{
			mapTravelData.UnlockPhantom(notify.UnLockMonsterId);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, mapTravelData.Id);
	}

	// Token: 0x060088F5 RID: 35061 RVA: 0x002414F8 File Offset: 0x0023F6F8
	public void RequestMapTravelLevelUp(Action<bool> callback = null)
	{
		MapTravelLevelUpRequest message = MapTravelLevelUpRequest.Create();
		Singleton<Net>.Instance.Call<MapTravelLevelUpResponse>(ERequestMessageId.MapTravelLevelUpRequest, message, delegate(MapTravelLevelUpResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
				return;
			}
			else if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15345, null, true, true);
				Action<bool> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(false);
				return;
			}
			else
			{
				ActivityMapTravelData mapTravelData = this.GetMapTravelData();
				if (mapTravelData != null)
				{
					mapTravelData.TravelLevel++;
					Action<bool> callback4 = callback;
					if (callback4 != null)
					{
						callback4(true);
					}
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, mapTravelData.Id);
					this.TryOpenLevelTipsView(mapTravelData);
					return;
				}
				Action<bool> callback5 = callback;
				if (callback5 == null)
				{
					return;
				}
				callback5(false);
				return;
			}
		}, 0);
	}

	// Token: 0x060088F6 RID: 35062 RVA: 0x0024153C File Offset: 0x0023F73C
	public void RequestMultiMapTravelTaskReward(List<int> ids)
	{
		MulMapTravelTaskRewardRequest mulMapTravelTaskRewardRequest = MulMapTravelTaskRewardRequest.Create();
		mulMapTravelTaskRewardRequest.TaskId.AddRange(ids);
		Singleton<Net>.Instance.Call<MulMapTravelTaskRewardResponse>(ERequestMessageId.MulMapTravelTaskRewardRequest, mulMapTravelTaskRewardRequest, delegate(MulMapTravelTaskRewardResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26948, null, true, true);
				return;
			}
			ActivityMapTravelData mapTravelData = this.GetMapTravelData();
			if (mapTravelData == null)
			{
				return;
			}
			foreach (int travelTaskDataDone in ids)
			{
				mapTravelData.SetTravelTaskDataDone(travelTaskDataDone);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, mapTravelData.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.MapTravelTaskRefresh);
		}, 0);
	}

	// Token: 0x060088F7 RID: 35063 RVA: 0x00241594 File Offset: 0x0023F794
	public void RequestTakeTaskFinalReward()
	{
		MapTravelFullRewardRequest message = MapTravelFullRewardRequest.Create();
		Singleton<Net>.Instance.Call<MapTravelFullRewardResponse>(ERequestMessageId.MapTravelFullRewardRequest, message, delegate(MapTravelFullRewardResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23774, null, true, true);
				return;
			}
			ActivityMapTravelData mapTravelData = this.GetMapTravelData();
			if (mapTravelData == null)
			{
				return;
			}
			mapTravelData.TaskFinalRewardData.IsReceived = true;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, mapTravelData.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.MapTravelTaskRefresh);
		}, 0);
	}

	// Token: 0x060088F8 RID: 35064 RVA: 0x002415C4 File Offset: 0x0023F7C4
	public void RequestMultiTakeSoarChallengeReward(List<int> rewardIds)
	{
		MulMapTravelSoarRewardRequest mulMapTravelSoarRewardRequest = MulMapTravelSoarRewardRequest.Create();
		mulMapTravelSoarRewardRequest.TaskIds.AddRange(rewardIds);
		Singleton<Net>.Instance.Call<MulMapTravelSoarRewardResponse>(ERequestMessageId.MulMapTravelSoarRewardRequest, mulMapTravelSoarRewardRequest, delegate(MulMapTravelSoarRewardResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18686, null, true, true);
				return;
			}
			ActivityMapTravelData mapTravelData = this.GetMapTravelData();
			if (mapTravelData == null)
			{
				return;
			}
			foreach (int soarChallengeRewardDone in rewardIds)
			{
				mapTravelData.SetSoarChallengeRewardDone(soarChallengeRewardDone);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, mapTravelData.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.MapTravelSoarRefresh);
		}, 0);
	}

	// Token: 0x060088F9 RID: 35065 RVA: 0x00241619 File Offset: 0x0023F819
	private void TryOpenLevelTipsView(ActivityMapTravelData data)
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TravelLevelTipsView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TravelLevelTipsView, data, null);
		}
	}

	// Token: 0x060088FA RID: 35066 RVA: 0x0024163D File Offset: 0x0023F83D
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipMapTravelView, null, null);
	}

	// Token: 0x060088FB RID: 35067 RVA: 0x00241650 File Offset: 0x0023F850
	public void OpenSoarStrengthView(float changeValue)
	{
		float baseMax = ControllerBase<FormationAttributeController>.Instance.GetBaseMax(EFormationAttributeId.SoarStrength);
		FormationProperty? config = ConfigFormationPropertyById.GetConfig(10, true);
		AttributeInfo item = new AttributeInfo
		{
			Name = config.Value.Name,
			IconPath = config.Value.Icon,
			ShowArrow = new bool?(true),
			PreText = Math.Floor((double)(baseMax - changeValue) / 100.0).ToString(),
			CurText = Math.Floor((double)baseMax / 100.0).ToString()
		};
		LevelUpSuccessAttributeData data = new LevelUpSuccessAttributeData
		{
			Title = "Flying_EnergyUp",
			StrengthUpgradeData = new StrengthUpgradeData
			{
				AttributeId = EFormationAttributeId.SoarStrength,
				SingleStrengthValue = ConfigCommonParamById.GetIntConfig("FlySingleStrengthValue").Value,
				MaxSingleStrengthItemCount = ConfigCommonParamById.GetIntConfig("FlyMaxSingleStrengthItemCount").Value,
				MaxStrength = (int)baseMax
			},
			AttributeInfo = new List<IAttributeInfo>
			{
				item
			}
		};
		ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessAttributeView(data, null);
	}
}
