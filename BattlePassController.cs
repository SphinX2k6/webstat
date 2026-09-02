using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002376 RID: 9078
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BattlePassController : UiControllerBase<BattlePassController>
{
	// Token: 0x060115FA RID: 71162 RVA: 0x004C94C0 File Offset: 0x004C76C0
	protected override bool OnInit()
	{
		Singleton<InputManager>.Instance.RegisterOpenViewFunc(EUiViewName.BattlePassMainView, new Action(this.RegisterOpenView));
		Singleton<InputManager>.Instance.RegisterCloseViewFunc(EUiViewName.BattlePassMainView, new Action(this.RegisterCloseView));
		return true;
	}

	// Token: 0x060115FB RID: 71163 RVA: 0x004C94F9 File Offset: 0x004C76F9
	protected override bool OnClear()
	{
		this.StopBattlePassTimer();
		return true;
	}

	// Token: 0x060115FC RID: 71164 RVA: 0x004C9502 File Offset: 0x004C7702
	private void RegisterOpenView()
	{
		this.OpenBattlePassView();
	}

	// Token: 0x060115FD RID: 71165 RVA: 0x004C950A File Offset: 0x004C770A
	private void RegisterCloseView()
	{
		this.CloseView();
	}

	// Token: 0x060115FE RID: 71166 RVA: 0x004C9514 File Offset: 0x004C7714
	public void RequestBattlePassDataForTask()
	{
		BattlePassRequest message = BattlePassRequest.Create();
		Singleton<Net>.Instance.Call<BattlePassResponse>(ERequestMessageId.BattlePassRequest, message, new Action<BattlePassResponse, Net.CallbackStatus>(this.<RequestBattlePassDataForTask>g__Response|5_0), 0);
	}

	// Token: 0x060115FF RID: 71167 RVA: 0x004C9544 File Offset: 0x004C7744
	public void OpenBattlePassView()
	{
		if (ModelBase<BattlePassModel>.Instance.IsRequiringViewData || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattlePassMainView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattlePassFirstOpenView))
		{
			return;
		}
		this.DoOpenBattlePassView().ContinueWith(delegate()
		{
			ModelBase<BattlePassModel>.Instance.IsRequiringViewData = false;
		}).Forget();
	}

	// Token: 0x06011600 RID: 71168 RVA: 0x004C95B0 File Offset: 0x004C77B0
	private UniTask DoOpenBattlePassView()
	{
		BattlePassController.<DoOpenBattlePassView>d__7 <DoOpenBattlePassView>d__;
		<DoOpenBattlePassView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DoOpenBattlePassView>d__.<>1__state = -1;
		<DoOpenBattlePassView>d__.<>t__builder.Start<BattlePassController.<DoOpenBattlePassView>d__7>(ref <DoOpenBattlePassView>d__);
		return <DoOpenBattlePassView>d__.<>t__builder.Task;
	}

	// Token: 0x06011601 RID: 71169 RVA: 0x004C95EC File Offset: 0x004C77EC
	public void SetBattlePassEnter()
	{
		BattlePassEnterPush message = BattlePassEnterPush.Create();
		Singleton<Net>.Instance.Send(EPushMessageId.BattlePassEnterPush, message);
		ModelBase<BattlePassModel>.Instance.HadEnter = true;
	}

	// Token: 0x06011602 RID: 71170 RVA: 0x004C961C File Offset: 0x004C781C
	public void RequestTakeBattlePassReward(BattlePassType battlePassType, int level, int itemId, int gridIndex)
	{
		BattlePassController.<>c__DisplayClass9_0 CS$<>8__locals1 = new BattlePassController.<>c__DisplayClass9_0();
		CS$<>8__locals1.battlePassType = battlePassType;
		CS$<>8__locals1.level = level;
		CS$<>8__locals1.itemId = itemId;
		CS$<>8__locals1.gridIndex = gridIndex;
		BattlePassTakeRewardRequest battlePassTakeRewardRequest = BattlePassTakeRewardRequest.Create();
		battlePassTakeRewardRequest.Type = CS$<>8__locals1.battlePassType;
		battlePassTakeRewardRequest.Level = CS$<>8__locals1.level;
		battlePassTakeRewardRequest.ItemId = CS$<>8__locals1.itemId;
		Singleton<Net>.Instance.Call<BattlePassTakeRewardResponse>(ERequestMessageId.BattlePassTakeRewardRequest, battlePassTakeRewardRequest, new Action<BattlePassTakeRewardResponse, Net.CallbackStatus>(CS$<>8__locals1.<RequestTakeBattlePassReward>g__ResponseAction|0), 0);
		BattlePassModel instance = ModelBase<BattlePassModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.TryAssignRemindLevel(new int?(CS$<>8__locals1.level));
	}

	// Token: 0x06011603 RID: 71171 RVA: 0x004C96B0 File Offset: 0x004C78B0
	public void RequestTakeAllRewardResponse()
	{
		BattlePassTakeAllRewardRequest message = BattlePassTakeAllRewardRequest.Create();
		Singleton<Net>.Instance.Call<BattlePassTakeAllRewardResponse>(ERequestMessageId.BattlePassTakeAllRewardRequest, message, new Action<BattlePassTakeAllRewardResponse, Net.CallbackStatus>(BattlePassController.<RequestTakeAllRewardResponse>g__ResponseAction|10_0), 0);
		BattlePassModel instance = ModelBase<BattlePassModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.TryAssignRemindLevel(null);
	}

	// Token: 0x06011604 RID: 71172 RVA: 0x004C96F8 File Offset: 0x004C78F8
	public void RequestBattlePassTask()
	{
		BattlePassTaskRequest message = BattlePassTaskRequest.Create();
		Singleton<Net>.Instance.Call<BattlePassTaskResponse>(ERequestMessageId.BattlePassTaskRequest, message, new Action<BattlePassTaskResponse, Net.CallbackStatus>(BattlePassController.<RequestBattlePassTask>g__ResponseAction|11_0), 0);
	}

	// Token: 0x06011605 RID: 71173 RVA: 0x004C9728 File Offset: 0x004C7928
	public void TryRequestTaskList(List<int> taskIdList)
	{
		ModelBase<BattlePassModel>.Instance.TryRequestTaskList(taskIdList);
	}

	// Token: 0x06011606 RID: 71174 RVA: 0x004C9738 File Offset: 0x004C7938
	public void RequestBattlePassTaskTake(List<int> taskIdList)
	{
		BattlePassTaskTakeRequest battlePassTaskTakeRequest = BattlePassTaskTakeRequest.Create();
		battlePassTaskTakeRequest.Ids.AddRange(taskIdList);
		Singleton<Net>.Instance.Call<BattlePassTaskTakeResponse>(ERequestMessageId.BattlePassTaskTakeRequest, battlePassTaskTakeRequest, new Action<BattlePassTaskTakeResponse, Net.CallbackStatus>(BattlePassController.<RequestBattlePassTaskTake>g__ResponseAction|13_0), 0);
	}

	// Token: 0x06011607 RID: 71175 RVA: 0x004C9774 File Offset: 0x004C7974
	public void RequestBuyBattlePassLevel(int level)
	{
		BattlePassLevelUpRequest battlePassLevelUpRequest = BattlePassLevelUpRequest.Create();
		battlePassLevelUpRequest.Level = level;
		Singleton<Net>.Instance.Call<BattlePassLevelUpResponse>(ERequestMessageId.BattlePassLevelUpRequest, battlePassLevelUpRequest, delegate(BattlePassLevelUpResponse response, Net.CallbackStatus _)
		{
		}, 0);
	}

	// Token: 0x06011608 RID: 71176 RVA: 0x004C97C0 File Offset: 0x004C79C0
	private void OnReceiveBattlePassTaskUpdateNotify(BattlePassTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		foreach (PbBattlePassTask task in notify.Tasks)
		{
			ModelBase<BattlePassModel>.Instance.AddTaskDataFromProtocol(task);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.UpdateBattlePassTaskEvent);
	}

	// Token: 0x06011609 RID: 71177 RVA: 0x004C9824 File Offset: 0x004C7A24
	private void OnReceiveBattlePassExpUpdateNotify(BattlePassExpUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<BattlePassModel>.Instance.UpdateExpDataFromBattlePassExpUpdateNotify(notify.Level, notify.Exp, notify.WeeklyTotalExp);
	}

	// Token: 0x0601160A RID: 71178 RVA: 0x004C9844 File Offset: 0x004C7A44
	private void OnReceiveBattlePassPaidNotify(BattlePassPaidNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (!ModelBase<BattlePassModel>.Instance.GetInTimeRange())
		{
			return;
		}
		BattlePassPayStatus payType = ModelBase<BattlePassModel>.Instance.PayType;
		ModelBase<BattlePassModel>.Instance.PayType = notify.PayStatus;
		EBattlePassUnlockType ebattlePassUnlockType = (notify.PayStatus == BattlePassPayStatus.Paid) ? EBattlePassUnlockType.Primary : EBattlePassUnlockType.Upgrade;
		if (payType == BattlePassPayStatus.NoPaid && payType != notify.PayStatus)
		{
			ModelBase<BattlePassModel>.Instance.UpdateRewardDataFormFreeToPay();
			ebattlePassUnlockType = ((ebattlePassUnlockType == EBattlePassUnlockType.Upgrade) ? EBattlePassUnlockType.High : ebattlePassUnlockType);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.ReceiveBattlePassDataEvent);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnReceiveBattlePassPaid);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BattlePassUnlockView, ebattlePassUnlockType, null);
	}

	// Token: 0x0601160B RID: 71179 RVA: 0x004C98DC File Offset: 0x004C7ADC
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<BattlePassTaskUpdateNotify>(ENotifyMessageId.BattlePassTaskUpdateNotify, new Action<BattlePassTaskUpdateNotify, Net.CallbackStatus>(this.OnReceiveBattlePassTaskUpdateNotify));
		Singleton<Net>.Instance.Register<BattlePassExpUpdateNotify>(ENotifyMessageId.BattlePassExpUpdateNotify, new Action<BattlePassExpUpdateNotify, Net.CallbackStatus>(this.OnReceiveBattlePassExpUpdateNotify));
		Singleton<Net>.Instance.Register<BattlePassPaidNotify>(ENotifyMessageId.BattlePassPaidNotify, new Action<BattlePassPaidNotify, Net.CallbackStatus>(this.OnReceiveBattlePassPaidNotify));
	}

	// Token: 0x0601160C RID: 71180 RVA: 0x004C993D File Offset: 0x004C7B3D
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BattlePassTaskUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BattlePassExpUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BattlePassPaidNotify);
	}

	// Token: 0x0601160D RID: 71181 RVA: 0x004C996F File Offset: 0x004C7B6F
	private void OnFunctionUnlock(EFunctionType functionType, bool isOpen)
	{
		if (functionType == EFunctionType.BattlePass && isOpen)
		{
			this.RequestBattlePassDataForTask();
		}
	}

	// Token: 0x0601160E RID: 71182 RVA: 0x004C9983 File Offset: 0x004C7B83
	private void OnEnterGameSuccess()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10040))
		{
			return;
		}
		this.RequestBattlePassDataForTask();
	}

	// Token: 0x0601160F RID: 71183 RVA: 0x004C999D File Offset: 0x004C7B9D
	private void OnDayCross()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10040) || !ModelBase<BattlePassModel>.Instance.GetInTimeRange())
		{
			return;
		}
		this.RequestBattlePassTask();
	}

	// Token: 0x06011610 RID: 71184 RVA: 0x004C99C3 File Offset: 0x004C7BC3
	private void StartBattlePassTimer()
	{
		if (this.BattlePassTimer != null)
		{
			return;
		}
		this.BattlePassTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			if (Singleton<TimeUtil>.Instance.GetServerTime() >= (double)ModelBase<BattlePassModel>.Instance.GetBattlePassEndTime())
			{
				ModelBase<BattlePassModel>.Instance.SetInTimeRange(false);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.ReceiveBattlePassTaskEvent, false);
				Singleton<EventSystem>.Instance.Emit(EEventName.ReceiveBattlePassDataEvent);
				Singleton<EventSystem>.Instance.Emit(EEventName.BattlePassHadEnterUpdate);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnBattlePassExpireEvent);
				this.StopBattlePassTimer();
			}
		}, 500f, 1f, null, null, true);
	}

	// Token: 0x06011611 RID: 71185 RVA: 0x004C99F8 File Offset: 0x004C7BF8
	public void ShowTimePassConfirm()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BattlePassExpireTip);
		confirmBoxDataNew.SetCloseFunction(delegate
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06011612 RID: 71186 RVA: 0x004C9A41 File Offset: 0x004C7C41
	private void StopBattlePassTimer()
	{
		if (this.BattlePassTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.BattlePassTimer);
			this.BattlePassTimer = null;
		}
	}

	// Token: 0x06011613 RID: 71187 RVA: 0x004C9A64 File Offset: 0x004C7C64
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnEnterGameSuccess));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionUnlock));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.OnDayCross));
	}

	// Token: 0x06011614 RID: 71188 RVA: 0x004C9AC8 File Offset: 0x004C7CC8
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnEnterGameSuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionUnlock));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.OnDayCross));
	}

	// Token: 0x06011615 RID: 71189 RVA: 0x004C9B2C File Offset: 0x004C7D2C
	public bool TryShowUpLevelView(bool firstBuy)
	{
		if (ModelBase<BattlePassModel>.Instance.IncreasedLevelToShow <= 0 || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattlePassUnlockView))
		{
			return false;
		}
		BattlePassUpLevelViewData param = new BattlePassUpLevelViewData
		{
			IncreasedLevel = ModelBase<BattlePassModel>.Instance.IncreasedLevelToShow,
			FirstUnlockPass = firstBuy
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BattlePassUpLevelView, param, null);
		return true;
	}

	// Token: 0x06011616 RID: 71190 RVA: 0x004C9B88 File Offset: 0x004C7D88
	public void PopHighUnlockReward()
	{
		int value = ConfigCommonParamById.GetIntConfig("PrimaryBattlePassGiftPack").Value;
		List<RewardItemData> list = new List<RewardItemData>();
		foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(value).Value.Content())
		{
			list.Add(new RewardItemData(keyValuePair.Key, keyValuePair.Value, null, EDropItemType.Normal));
		}
		ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1009, list, delegate
		{
			this.TryShowUpLevelView(true);
		});
	}

	// Token: 0x06011617 RID: 71191 RVA: 0x004C9C44 File Offset: 0x004C7E44
	public void PayPrimaryBattlePass()
	{
		if (FeatureRestrictionTemplate.TemplateForPioneerClient.Check())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BetaDisableCharge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		int primaryBattlePassGoodsId = ModelBase<BattlePassModel>.Instance.GetPrimaryBattlePassGoodsId();
		PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(primaryBattlePassGoodsId);
		if (payShopGoodsById == null || !payShopGoodsById.InSellTime())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("BattlePassShopNotInTime", Array.Empty<object>());
			return;
		}
		if (this.PayInWarningTime(primaryBattlePassGoodsId))
		{
			return;
		}
		ControllerBase<PayGiftController>.Instance.SdkPay(payShopGoodsById.GetGoodsData().Id);
	}

	// Token: 0x06011618 RID: 71192 RVA: 0x004C9CCC File Offset: 0x004C7ECC
	public void PayHighBattlePass()
	{
		if (FeatureRestrictionTemplate.TemplateForPioneerClient.Check())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BetaDisableCharge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		BattlePassPayStatus payType = ModelBase<BattlePassModel>.Instance.PayType;
		if (payType != BattlePassPayStatus.NoPaid)
		{
			if (payType == BattlePassPayStatus.Paid)
			{
				int supplyBattlePassGoodsId = ModelBase<BattlePassModel>.Instance.GetSupplyBattlePassGoodsId();
				PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(supplyBattlePassGoodsId);
				if (payShopGoodsById == null || !payShopGoodsById.InSellTime())
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("BattlePassShopNotInTime", Array.Empty<object>());
					return;
				}
				ControllerBase<PayGiftController>.Instance.SdkPay(supplyBattlePassGoodsId);
			}
			return;
		}
		int highBattlePassGoodsId = ModelBase<BattlePassModel>.Instance.GetHighBattlePassGoodsId();
		PayShopGoods payShopGoodsById2 = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(highBattlePassGoodsId);
		if (payShopGoodsById2 == null || !payShopGoodsById2.InSellTime())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("BattlePassShopNotInTime", Array.Empty<object>());
			return;
		}
		if (this.PayInWarningTime(highBattlePassGoodsId))
		{
			return;
		}
		ControllerBase<PayGiftController>.Instance.SdkPay(highBattlePassGoodsId);
	}

	// Token: 0x06011619 RID: 71193 RVA: 0x004C9DA4 File Offset: 0x004C7FA4
	private bool PayInWarningTime(int id)
	{
		BattlePassController.<>c__DisplayClass32_0 CS$<>8__locals1 = new BattlePassController.<>c__DisplayClass32_0();
		CS$<>8__locals1.id = id;
		if (ModelBase<BattlePassModel>.Instance.InBattlePassInWarningTime())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BattlePassTimeWarning);
			confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<PayInWarningTime>g__ConfirmCallback|0));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return true;
		}
		return false;
	}

	// Token: 0x0601161A RID: 71194 RVA: 0x004C9DFC File Offset: 0x004C7FFC
	public void CloseView()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattlePassFirstOpenView))
		{
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.BattlePassMainView, null);
	}

	// Token: 0x0601161B RID: 71195 RVA: 0x004C9E20 File Offset: 0x004C8020
	public RewardData<IBattlePassExtraRewardInfo> BuildExtraRewardData(List<RewardItemData> rewardItemDataList)
	{
		RewardItemData[] extraRewardItems = ModelBase<BattlePassModel>.Instance.GetExtraRewardItems();
		BattlePassExtraRewardInfo battlePassExtraRewardInfo = new BattlePassExtraRewardInfo();
		battlePassExtraRewardInfo.Type = ERewardInfoType.BattlePassExtra;
		battlePassExtraRewardInfo.ViewName = EUiViewName.BattlePassExtraRewardView;
		battlePassExtraRewardInfo.CommonItems = rewardItemDataList;
		battlePassExtraRewardInfo.ExtraItems = extraRewardItems.ToList<RewardItemData>();
		battlePassExtraRewardInfo.LeftAction = delegate()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.NotifyBattlePassToBuyEvent);
		};
		battlePassExtraRewardInfo.RightAction = delegate()
		{
		};
		return new RewardData<IBattlePassExtraRewardInfo>(battlePassExtraRewardInfo, null);
	}

	// Token: 0x0601161C RID: 71196 RVA: 0x004C9EB4 File Offset: 0x004C80B4
	public bool IsNeedExtraRewardView()
	{
		BattlePassModel instance = ModelBase<BattlePassModel>.Instance;
		return instance != null && instance.RemindLevel != null;
	}

	// Token: 0x0601161E RID: 71198 RVA: 0x004C9EE4 File Offset: 0x004C80E4
	[CompilerGenerated]
	private void <RequestBattlePassDataForTask>g__Response|5_0(BattlePassResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
		{
			ModelBase<BattlePassModel>.Instance.SetDataFromBattlePassResponse(response);
			if (ModelBase<BattlePassModel>.Instance.GetInTimeRange())
			{
				this.RequestBattlePassTask();
			}
			this.StartBattlePassTimer();
			return;
		}
		ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19513, null, true, true);
	}

	// Token: 0x0601161F RID: 71199 RVA: 0x004C9F39 File Offset: 0x004C8139
	[CompilerGenerated]
	internal static void <RequestTakeAllRewardResponse>g__ResponseAction|10_0(BattlePassTakeAllRewardResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
		{
			ModelBase<BattlePassModel>.Instance.UpdateRewardDataFromBattlePassTakeAllRewardResponse(response);
			return;
		}
		ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23199, null, true, true);
	}

	// Token: 0x06011620 RID: 71200 RVA: 0x004C9F6C File Offset: 0x004C816C
	[CompilerGenerated]
	internal static void <RequestBattlePassTask>g__ResponseAction|11_0(BattlePassTaskResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
		{
			ModelBase<BattlePassModel>.Instance.BattlePassTaskMap.Clear();
			foreach (PbBattlePassTask task in response.Tasks)
			{
				ModelBase<BattlePassModel>.Instance.AddTaskDataFromProtocol(task);
			}
			bool p = ModelBase<BattlePassModel>.Instance.GetWeekEndTime() != response.WeekEnd;
			ModelBase<BattlePassModel>.Instance.SetWeekEndTime(response.WeekEnd);
			ModelBase<BattlePassModel>.Instance.SetDayEndTime(response.DayEnd);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.ReceiveBattlePassTaskEvent, p);
			return;
		}
		ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19631, null, true, true);
	}

	// Token: 0x06011621 RID: 71201 RVA: 0x004CA03C File Offset: 0x004C823C
	[CompilerGenerated]
	internal static void <RequestBattlePassTaskTake>g__ResponseAction|13_0(BattlePassTaskTakeResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
		{
			ModelBase<BattlePassModel>.Instance.UpdateTaskDataFromBattlePassTaskTakeResponse(response.Ids.ToArray<int>());
			return;
		}
		ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25644, null, true, true);
	}

	// Token: 0x04008886 RID: 34950
	[Nullable(2)]
	private TimerHandle BattlePassTimer;
}
