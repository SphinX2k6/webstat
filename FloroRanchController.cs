using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BF8 RID: 7160
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FloroRanchController : ActivityControllerBase<FloroRanchController>
{
	// Token: 0x0600D04E RID: 53326 RVA: 0x003751CC File Offset: 0x003733CC
	protected override void OnOpenView(ActivityBaseData data)
	{
		throw new NotImplementedException();
	}

	// Token: 0x0600D04F RID: 53327 RVA: 0x003751D3 File Offset: 0x003733D3
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityPastureGuide";
	}

	// Token: 0x0600D050 RID: 53328 RVA: 0x003751DA File Offset: 0x003733DA
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new FloroRanchActivityView();
	}

	// Token: 0x0600D051 RID: 53329 RVA: 0x003751E4 File Offset: 0x003733E4
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		global::FloroRanchActivityData floroRanchActivityData = new global::FloroRanchActivityData();
		EFloroRanchActivityDataType activityDataType = ModelBase<FloroRanchModel>.Instance.GetActivityDataType(data.Id);
		ModelBase<FloroRanchModel>.Instance.SetActivityData(activityDataType, floroRanchActivityData);
		return floroRanchActivityData;
	}

	// Token: 0x0600D052 RID: 53330 RVA: 0x00375215 File Offset: 0x00373415
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600D053 RID: 53331 RVA: 0x00375218 File Offset: 0x00373418
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchUnlockTipView, null, null);
	}

	// Token: 0x0600D054 RID: 53332 RVA: 0x0037522C File Offset: 0x0037342C
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<FloroRanchUpdatePlayerInfoNotify>(ENotifyMessageId.FloroRanchUpdatePlayerInfoNotify, new Action<FloroRanchUpdatePlayerInfoNotify, Net.CallbackStatus>(this.OnFloroRanchUpdatePlayerInfoNotify));
		Singleton<Net>.Instance.Register<FloroRanchPlayGmInfoUpdateNotify>(ENotifyMessageId.FloroRanchPlayGmInfoUpdateNotify, new Action<FloroRanchPlayGmInfoUpdateNotify, Net.CallbackStatus>(this.OnFloroRanchPlayGmInfoUpdateNotify));
		Singleton<Net>.Instance.Register<FloroRanchPlayWeeklyEndNotify>(ENotifyMessageId.FloroRanchPlayWeeklyEndNotify, new Action<FloroRanchPlayWeeklyEndNotify, Net.CallbackStatus>(this.OnFloroRanchPlayWeeklyEndNotify));
	}

	// Token: 0x0600D055 RID: 53333 RVA: 0x0037528D File Offset: 0x0037348D
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FloroRanchUpdatePlayerInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FloroRanchPlayGmInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FloroRanchPlayWeeklyEndNotify);
	}

	// Token: 0x0600D056 RID: 53334 RVA: 0x003752BF File Offset: 0x003734BF
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x0600D057 RID: 53335 RVA: 0x003752DD File Offset: 0x003734DD
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x0600D058 RID: 53336 RVA: 0x003752FC File Offset: 0x003734FC
	private void OnFloroRanchUpdatePlayerInfoNotify(FloroRanchUpdatePlayerInfoNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		EFloroRanchActivityDataType activityDataType = ModelBase<FloroRanchModel>.Instance.GetActivityDataType(message.ActivityId);
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(activityDataType, true);
		if (activityData == null)
		{
			return;
		}
		switch (message.FloroCfgType)
		{
		case FloroConfigType.FloroCard:
			activityData.UpdateFloroRanchCardData(message.UnlockCard);
			return;
		case FloroConfigType.FloroRace:
			activityData.UpdateFloroRanchRaceData(message.RaceUnLockInfo);
			return;
		case FloroConfigType.FloroTask:
			activityData.UpdateFloroRanchTaskData(message.ConditionTask, true);
			return;
		case FloroConfigType.FloroSkill:
			activityData.UpdateFloroRanchSkillData(message.UnlockSkill);
			return;
		case FloroConfigType.FloroToy:
			activityData.UpdateFloroRanchToyData(message.UnlockToy);
			return;
		case FloroConfigType.FloroIns:
			activityData.UpdateFloroRanchDungeonUnLock(message.InsLockInfo);
			return;
		case FloroConfigType.FloroSubIns:
			activityData.UpdateFloroRanchSubDungeon(message.FloroSubInsInfo, true);
			return;
		case FloroConfigType.SubInsHistory:
			activityData.UpdateFloroRanchSubDungeonHistoryData(message.SubInfHistory);
			Singleton<EventSystem>.Instance.Emit(EEventName.FloroRanchSubInsHistoryUpdate);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600D059 RID: 53337 RVA: 0x003753D4 File Offset: 0x003735D4
	[NullableContext(2)]
	public unsafe void SendFloroRanchStartPlayRequest(int activityId, int subInstanceId, int[] races = null, int? skillId = null, Action<FloroRanchStartPlayResponse> callback = null)
	{
		FloroRanchStartPlayRequest floroRanchStartPlayRequest = FloroRanchStartPlayRequest.Create();
		floroRanchStartPlayRequest.ActivityId = activityId;
		floroRanchStartPlayRequest.SubInsId = subInstanceId;
		if (races != null && skillId != null)
		{
			floroRanchStartPlayRequest.Races.AddRange(races);
			floroRanchStartPlayRequest.SkillId = skillId.Value;
		}
		Singleton<Net>.Instance.Call<FloroRanchStartPlayResponse>(ERequestMessageId.FloroRanchStartPlayRequest, floroRanchStartPlayRequest, delegate(FloroRanchStartPlayResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Action<FloroRanchStartPlayResponse> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(null);
				return;
			}
			else
			{
				if (response.ErrorCode == ErrorCode.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.FloroRanchGamePlay;
					ELogAuthor author = ELogAuthor.LRC;
					string message = "弗洛洛牧场 游戏开始";
					<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SubInsId", response.PlayInfo.SubInsId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SkillId", response.PlayInfo.Role.SKillData.SkillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Races", string.Join<int>(",", response.PlayInfo.Races));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Stage", response.PlayInfo.Stage);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Day", response.PlayInfo.Day);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
					ModelBase<FloroRanchGamePlayModel>.Instance.InitGame(activityId, new List<int>(response.PlayInfo.Races), response.PlayInfo.Role.SKillData.SkillId, response.PlayInfo.IsOver);
					EFloroRanchActivityDataType activityDataType = ModelBase<FloroRanchModel>.Instance.GetActivityDataType(activityId);
					global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(activityDataType, true);
					ModelBase<FloroRanchGamePlayModel>.Instance.SetCurrentActivityData(activityData);
					ModelBase<FloroRanchGamePlayModel>.Instance.EnterGame(response);
					Action<FloroRanchStartPlayResponse> callback3 = callback;
					if (callback3 != null)
					{
						callback3(response);
					}
					activityData.SetUnFinishedSubDungeonId(subInstanceId);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20499, null, true, true);
				Action<FloroRanchStartPlayResponse> callback4 = callback;
				if (callback4 == null)
				{
					return;
				}
				callback4(null);
				return;
			}
		}, 0);
	}

	// Token: 0x0600D05A RID: 53338 RVA: 0x00375460 File Offset: 0x00373660
	public void SendFloroRanchPlayNextDayRequest(int activityId, int subInstanceId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchPlayNextDayResponse> callback)
	{
		FloroRanchPlayNextDayRequest floroRanchPlayNextDayRequest = FloroRanchPlayNextDayRequest.Create();
		floroRanchPlayNextDayRequest.ActivityId = activityId;
		floroRanchPlayNextDayRequest.SubInsId = subInstanceId;
		Singleton<Net>.Instance.Call<FloroRanchPlayNextDayResponse>(ERequestMessageId.FloroRanchPlayNextDayRequest, floroRanchPlayNextDayRequest, delegate(FloroRanchPlayNextDayResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29245, null, true, true);
				callback(null);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<FloroRanchPlayTask>>(EEventName.OnFloroRanchNextDayTaskRefresh, response.Task);
			callback(response);
		}, 0);
	}

	// Token: 0x0600D05B RID: 53339 RVA: 0x003754AC File Offset: 0x003736AC
	public void FloroRanchPlayGachaRequest(int activityId, int subInstanceId, int cardId, int incId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchPlayGachaResponse> callback)
	{
		FloroRanchPlayGachaRequest floroRanchPlayGachaRequest = Aki.Protocol.FloroRanchPlayGachaRequest.Create();
		floroRanchPlayGachaRequest.ActivityId = activityId;
		floroRanchPlayGachaRequest.SubInsId = subInstanceId;
		floroRanchPlayGachaRequest.CardId = cardId;
		floroRanchPlayGachaRequest.IncId = incId;
		Singleton<Net>.Instance.Call<FloroRanchPlayGachaResponse>(ERequestMessageId.FloroRanchPlayGachaRequest, floroRanchPlayGachaRequest, delegate(FloroRanchPlayGachaResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18362, null, true, true);
				callback(null);
				return;
			}
			FloroRanchEntityActionSystem.AddEntities(new List<FloroRanchPlayUnit>(response.GachaResult)).ContinueWith(delegate()
			{
				callback(response);
			});
		}, 0);
	}

	// Token: 0x0600D05C RID: 53340 RVA: 0x00375508 File Offset: 0x00373708
	public void FloroRanchPlayRefreshGachaRequest(int activityId, int subInstanceId, int incId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchPlayGachaRefreshResponse> callback)
	{
		FloroRanchPlayGachaRefreshRequest floroRanchPlayGachaRefreshRequest = FloroRanchPlayGachaRefreshRequest.Create();
		floroRanchPlayGachaRefreshRequest.ActivityId = activityId;
		floroRanchPlayGachaRefreshRequest.SubInsId = subInstanceId;
		floroRanchPlayGachaRefreshRequest.IncId = incId;
		Singleton<Net>.Instance.Call<FloroRanchPlayGachaRefreshResponse>(ERequestMessageId.FloroRanchPlayGachaRefreshRequest, floroRanchPlayGachaRefreshRequest, delegate(FloroRanchPlayGachaRefreshResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28626, null, true, true);
				callback(null);
				return;
			}
			ModelBase<FloroRanchGamePlayModel>.Instance.OnCurrencyChange((int)Singleton<MathUtils>.Instance.LongToBigInt(response.CurCoin), (int)Singleton<MathUtils>.Instance.LongToBigInt(response.CurDiamond));
			callback(response);
		}, 0);
	}

	// Token: 0x0600D05D RID: 53341 RVA: 0x0037555C File Offset: 0x0037375C
	public void SendFloroRanchPlayShopBuyRequest(int activityId, int subInstanceId, int taskIncId, int id, int type, int goodIncId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchPlayShopBuyResponse> callback)
	{
		FloroRanchPlayShopBuyRequest floroRanchPlayShopBuyRequest = FloroRanchPlayShopBuyRequest.Create();
		floroRanchPlayShopBuyRequest.ActivityId = activityId;
		floroRanchPlayShopBuyRequest.SubInsId = subInstanceId;
		floroRanchPlayShopBuyRequest.BuyId = id;
		floroRanchPlayShopBuyRequest.Type = (FloroRanchShopItemType)type;
		floroRanchPlayShopBuyRequest.IncId = taskIncId;
		floroRanchPlayShopBuyRequest.ItemIncId = goodIncId;
		Singleton<Net>.Instance.Call<FloroRanchPlayShopBuyResponse>(ERequestMessageId.FloroRanchPlayShopBuyRequest, floroRanchPlayShopBuyRequest, delegate(FloroRanchPlayShopBuyResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16304, null, true, true);
				callback(null);
				return;
			}
			ModelBase<FloroRanchGamePlayModel>.Instance.OnShopItemPurchased(response);
			callback(response);
		}, 0);
	}

	// Token: 0x0600D05E RID: 53342 RVA: 0x003755C8 File Offset: 0x003737C8
	public void SendFloroRanchPlayRefreshShopRequest(int activityId, int subInstanceId, int incId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchPlayRefreshShopResponse> callback)
	{
		FloroRanchPlayRefreshShopRequest floroRanchPlayRefreshShopRequest = FloroRanchPlayRefreshShopRequest.Create();
		floroRanchPlayRefreshShopRequest.ActivityId = activityId;
		floroRanchPlayRefreshShopRequest.SubInsId = subInstanceId;
		floroRanchPlayRefreshShopRequest.IncId = incId;
		Singleton<Net>.Instance.Call<FloroRanchPlayRefreshShopResponse>(ERequestMessageId.FloroRanchPlayRefreshShopRequest, floroRanchPlayRefreshShopRequest, delegate(FloroRanchPlayRefreshShopResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17209, null, true, true);
				callback(null);
				return;
			}
			ModelBase<FloroRanchGamePlayModel>.Instance.OnCurrencyChange((int)Singleton<MathUtils>.Instance.LongToBigInt(response.CurCoin), (int)Singleton<MathUtils>.Instance.LongToBigInt(response.CurDiamond));
			callback(response);
		}, 0);
	}

	// Token: 0x0600D05F RID: 53343 RVA: 0x0037561C File Offset: 0x0037381C
	public void SendFloroRanchPlaySelectCardGroupRequest(int activityId, int subInstanceId, int[] cardIdList, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchPlaySelectCardGroupResponse> callback)
	{
		FloroRanchPlaySelectCardGroupRequest floroRanchPlaySelectCardGroupRequest = FloroRanchPlaySelectCardGroupRequest.Create();
		floroRanchPlaySelectCardGroupRequest.ActivityId = activityId;
		floroRanchPlaySelectCardGroupRequest.SubInsId = subInstanceId;
		floroRanchPlaySelectCardGroupRequest.CardId.AddRange(cardIdList);
		Singleton<Net>.Instance.Call<FloroRanchPlaySelectCardGroupResponse>(ERequestMessageId.FloroRanchPlaySelectCardGroupRequest, floroRanchPlaySelectCardGroupRequest, delegate(FloroRanchPlaySelectCardGroupResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22034, null, true, true);
				callback(null);
				return;
			}
			FloroRanchEntityActionSystem.AddEntities(new List<FloroRanchPlayUnit>(response.NewPhantoms)).ContinueWith(delegate()
			{
				callback(response);
			});
		}, 0);
	}

	// Token: 0x0600D060 RID: 53344 RVA: 0x00375674 File Offset: 0x00373874
	public void SendFloroRanchExecuteSkillPlayRequest(int activityId, int subInstanceId, Action<bool> callback)
	{
		FloroRanchExecuteSkillPlayRequest floroRanchExecuteSkillPlayRequest = FloroRanchExecuteSkillPlayRequest.Create();
		floroRanchExecuteSkillPlayRequest.ActivityId = activityId;
		floroRanchExecuteSkillPlayRequest.SubInsId = subInstanceId;
		Singleton<Net>.Instance.Call<FloroRanchExecuteSkillPlayResponse>(ERequestMessageId.FloroRanchExecuteSkillPlayRequest, floroRanchExecuteSkillPlayRequest, delegate(FloroRanchExecuteSkillPlayResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(false);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22564, null, true, true);
				callback(false);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<FloroRanchPlayTask>>(EEventName.OnFloroRanchNextDayTaskRefresh, response.Task);
			callback(true);
		}, 0);
	}

	// Token: 0x0600D061 RID: 53345 RVA: 0x003756C0 File Offset: 0x003738C0
	public void SendFloroRanchEventChoiceRequest(int activityId, int subInstanceId, int eventIncId, int choiceId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchEventChoiceResponse> callback)
	{
		FloroRanchEventChoiceRequest floroRanchEventChoiceRequest = FloroRanchEventChoiceRequest.Create();
		floroRanchEventChoiceRequest.ActivityId = activityId;
		floroRanchEventChoiceRequest.SubInsId = subInstanceId;
		floroRanchEventChoiceRequest.IncId = eventIncId;
		floroRanchEventChoiceRequest.Choice = choiceId;
		Singleton<Net>.Instance.Call<FloroRanchEventChoiceResponse>(ERequestMessageId.FloroRanchEventChoiceRequest, floroRanchEventChoiceRequest, delegate(FloroRanchEventChoiceResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27265, null, true, true);
				callback(null);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<FloroRanchPlayTask>>(EEventName.OnFloroRanchNextDayTaskRefresh, response.Task);
			callback(response);
		}, 0);
	}

	// Token: 0x0600D062 RID: 53346 RVA: 0x0037571C File Offset: 0x0037391C
	public void SendFloroRanchPlayTributeRequest(int activityId, int subInstanceId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchPlayTributeResponse> callback)
	{
		FloroRanchPlayTributeRequest floroRanchPlayTributeRequest = FloroRanchPlayTributeRequest.Create();
		floroRanchPlayTributeRequest.ActivityId = activityId;
		floroRanchPlayTributeRequest.SubInsId = subInstanceId;
		Singleton<Net>.Instance.Call<FloroRanchPlayTributeResponse>(ERequestMessageId.FloroRanchPlayTributeRequest, floroRanchPlayTributeRequest, delegate(FloroRanchPlayTributeResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15114, null, true, true);
				callback(null);
				return;
			}
			ModelBase<FloroRanchGamePlayModel>.Instance.OnTributeResult(response);
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<FloroRanchPlayTask>>(EEventName.OnFloroRanchNextDayTaskRefresh, response.Task);
			callback(response);
		}, 0);
	}

	// Token: 0x0600D063 RID: 53347 RVA: 0x00375768 File Offset: 0x00373968
	[NullableContext(2)]
	public void SendFloroRanchPlayUnlimitedModeRequest(int activityId, int subInstanceId, Action<FloroRanchPlayUnlimitedModeResponse> callback = null)
	{
		FloroRanchPlayUnlimitedModeRequest floroRanchPlayUnlimitedModeRequest = FloroRanchPlayUnlimitedModeRequest.Create();
		floroRanchPlayUnlimitedModeRequest.ActivityId = activityId;
		floroRanchPlayUnlimitedModeRequest.SubInsId = subInstanceId;
		Singleton<Net>.Instance.Call<FloroRanchPlayUnlimitedModeResponse>(ERequestMessageId.FloroRanchPlayUnlimitedModeRequest, floroRanchPlayUnlimitedModeRequest, delegate(FloroRanchPlayUnlimitedModeResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Action<FloroRanchPlayUnlimitedModeResponse> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(null);
				return;
			}
			else if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20820, null, true, true);
				Action<FloroRanchPlayUnlimitedModeResponse> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(null);
				return;
			}
			else
			{
				Singleton<EventSystem>.Instance.Emit<IReadOnlyList<FloroRanchPlayTask>>(EEventName.OnFloroRanchInsertTask, response.Task);
				ModelBase<FloroRanchGamePlayModel>.Instance.IsEndlessMode = true;
				ModelBase<FloroRanchGamePlayModel>.Instance.CurStage = response.CurStage;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnFloroRanchStageInfoRefresh);
				Action<FloroRanchPlayUnlimitedModeResponse> callback4 = callback;
				if (callback4 == null)
				{
					return;
				}
				callback4(response);
				return;
			}
		}, 0);
	}

	// Token: 0x0600D064 RID: 53348 RVA: 0x003757B4 File Offset: 0x003739B4
	public void SendFloroRanchPlayRemoveUnitRequest(int activityId, int subInstanceId, int entityId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchPlayRemoveUnitResponse> callback)
	{
		FloroRanchPlayRemoveUnitRequest floroRanchPlayRemoveUnitRequest = FloroRanchPlayRemoveUnitRequest.Create();
		floroRanchPlayRemoveUnitRequest.ActivityId = activityId;
		floroRanchPlayRemoveUnitRequest.SubInsId = subInstanceId;
		floroRanchPlayRemoveUnitRequest.UnitIncId = entityId;
		Singleton<Net>.Instance.Call<FloroRanchPlayRemoveUnitResponse>(ERequestMessageId.FloroRanchPlayRemoveUnitRequest, floroRanchPlayRemoveUnitRequest, delegate(FloroRanchPlayRemoveUnitResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26709, null, true, true);
				callback(null);
				return;
			}
			FloroRanchEntityActionSystem.RemoveEntity(entityId).ContinueWith(delegate()
			{
				ModelBase<FloroRanchGamePlayModel>.Instance.OnCurrencyChange((int)Singleton<MathUtils>.Instance.LongToBigInt(response.CurCoin), (int)Singleton<MathUtils>.Instance.LongToBigInt(response.CurDiamond));
				Singleton<EventSystem>.Instance.Emit<IReadOnlyList<FloroRanchPlayTask>>(EEventName.OnFloroRanchInsertTask, response.Task);
				callback(response);
			});
		}, 0);
	}

	// Token: 0x0600D065 RID: 53349 RVA: 0x00375814 File Offset: 0x00373A14
	public void SendFloroRanchSettleDataRequest(int activityId, int subInstanceId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchSettleDataResponse> callback)
	{
		FloroRanchSettleDataRequest floroRanchSettleDataRequest = FloroRanchSettleDataRequest.Create();
		floroRanchSettleDataRequest.ActivityId = activityId;
		floroRanchSettleDataRequest.SubInsId = subInstanceId;
		Singleton<Net>.Instance.Call<FloroRanchSettleDataResponse>(ERequestMessageId.FloroRanchSettleDataRequest, floroRanchSettleDataRequest, delegate(FloroRanchSettleDataResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18074, null, true, true);
				callback(null);
				return;
			}
			callback(response);
		}, 0);
	}

	// Token: 0x0600D066 RID: 53350 RVA: 0x00375860 File Offset: 0x00373A60
	public unsafe void SendFloroRanchSettleRequest(int activityId, int subInstanceId, bool isSettle, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchSettleResponse> callback)
	{
		FloroRanchSettleRequest floroRanchSettleRequest = FloroRanchSettleRequest.Create();
		floroRanchSettleRequest.ActivityId = activityId;
		floroRanchSettleRequest.SubInsId = subInstanceId;
		floroRanchSettleRequest.Settle = isSettle;
		Singleton<Net>.Instance.Call<FloroRanchSettleResponse>(ERequestMessageId.FloroRanchSettleRequest, floroRanchSettleRequest, delegate(FloroRanchSettleResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25000, null, true, true);
				callback(null);
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanch;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "副本结算";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isWin", response.Win);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("subInstanceId", subInstanceId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			callback(response);
			global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
			if (response.Win && currentActivityData != null)
			{
				currentActivityData.UpdateFloroRanchSubDungeonPass(subInstanceId);
			}
			if (currentActivityData != null)
			{
				currentActivityData.ClearUnFinishedSubDungeonId();
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.FloroRanchSettlement);
			ModelBase<FloroRanchGamePlayModel>.Instance.GameEnd();
		}, 0);
	}

	// Token: 0x0600D067 RID: 53351 RVA: 0x003758C0 File Offset: 0x00373AC0
	public void SendFloroRanchAbandonArchiveRequest(int activityId, int subInstanceId, [Nullable(new byte[]
	{
		1,
		2
	})] Action<FloroRanchSettleResponse> callback)
	{
		FloroRanchSettleRequest floroRanchSettleRequest = FloroRanchSettleRequest.Create();
		floroRanchSettleRequest.ActivityId = activityId;
		floroRanchSettleRequest.SubInsId = subInstanceId;
		floroRanchSettleRequest.Settle = true;
		Singleton<Net>.Instance.Call<FloroRanchSettleResponse>(ERequestMessageId.FloroRanchSettleRequest, floroRanchSettleRequest, delegate(FloroRanchSettleResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				callback(null);
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25000, null, true, true);
				callback(null);
				return;
			}
			EFloroRanchActivityDataType activityDataType = ModelBase<FloroRanchModel>.Instance.GetActivityDataType(activityId);
			global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(activityDataType, true);
			if (activityData != null)
			{
				activityData.ClearUnFinishedSubDungeonId();
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.FloroRanchSettlement);
			callback(response);
		}, 0);
	}

	// Token: 0x0600D068 RID: 53352 RVA: 0x00375920 File Offset: 0x00373B20
	public UniTask SendFloroRanchReStartRequest(int activityId, int subInstanceId, int[] races, int skillId)
	{
		FloroRanchController.<SendFloroRanchReStartRequest>d__26 <SendFloroRanchReStartRequest>d__;
		<SendFloroRanchReStartRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SendFloroRanchReStartRequest>d__.<>4__this = this;
		<SendFloroRanchReStartRequest>d__.activityId = activityId;
		<SendFloroRanchReStartRequest>d__.subInstanceId = subInstanceId;
		<SendFloroRanchReStartRequest>d__.races = races;
		<SendFloroRanchReStartRequest>d__.skillId = skillId;
		<SendFloroRanchReStartRequest>d__.<>1__state = -1;
		<SendFloroRanchReStartRequest>d__.<>t__builder.Start<FloroRanchController.<SendFloroRanchReStartRequest>d__26>(ref <SendFloroRanchReStartRequest>d__);
		return <SendFloroRanchReStartRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600D069 RID: 53353 RVA: 0x00375984 File Offset: 0x00373B84
	[NullableContext(2)]
	public void SendFloroRanchCloseTaskRequest(int activityId, int subInstanceId, int taskId, Action<FloroRanchCloseTaskResponse> callback = null)
	{
		FloroRanchCloseTaskRequest floroRanchCloseTaskRequest = FloroRanchCloseTaskRequest.Create();
		floroRanchCloseTaskRequest.ActivityId = activityId;
		floroRanchCloseTaskRequest.SubInsId = subInstanceId;
		floroRanchCloseTaskRequest.TaskIncId = taskId;
		Singleton<Net>.Instance.Call<FloroRanchCloseTaskResponse>(ERequestMessageId.FloroRanchCloseTaskRequest, floroRanchCloseTaskRequest, delegate(FloroRanchCloseTaskResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Action<FloroRanchCloseTaskResponse> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(null);
				return;
			}
			else if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22264, null, true, true);
				Action<FloroRanchCloseTaskResponse> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(null);
				return;
			}
			else
			{
				Action<FloroRanchCloseTaskResponse> callback4 = callback;
				if (callback4 == null)
				{
					return;
				}
				callback4(response);
				return;
			}
		}, 0);
	}

	// Token: 0x0600D06A RID: 53354 RVA: 0x003759D8 File Offset: 0x00373BD8
	public void SendFloroRanchOutRequest(int activityId, int subInstanceId)
	{
		FloroRanchOutRequest floroRanchOutRequest = FloroRanchOutRequest.Create();
		floroRanchOutRequest.ActivityId = activityId;
		floroRanchOutRequest.SubInsId = subInstanceId;
		Singleton<Net>.Instance.Call<FloroRanchOutResponse>(ERequestMessageId.FloroRanchOutRequest, floroRanchOutRequest, delegate(FloroRanchOutResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15009, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0600D06B RID: 53355 RVA: 0x00375A29 File Offset: 0x00373C29
	private void OnFloroRanchPlayGmInfoUpdateNotify(FloroRanchPlayGmInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
	}

	// Token: 0x0600D06C RID: 53356 RVA: 0x00375A2C File Offset: 0x00373C2C
	private void OnFloroRanchPlayWeeklyEndNotify(FloroRanchPlayWeeklyEndNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (ModelBase<FloroRanchGamePlayModel>.Instance.IsInGamePlay)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FloroRanchWeeklyEnd);
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				ModelBase<FloroRanchGamePlayModel>.Instance.ExitGame(false);
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FloroRanchWeeklyMainView, null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FloroRanchWeeklyMainView))
		{
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.FloroRanchWeeklyEnd);
			confirmBoxDataNew2.FunctionMap[1] = delegate()
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FloroRanchWeeklyMainView, null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
		}
	}

	// Token: 0x0600D06D RID: 53357 RVA: 0x00375ADC File Offset: 0x00373CDC
	public void RequestTaskReward(int[] taskIds)
	{
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		FloroRanchRewardTaskRequest floroRanchRewardTaskRequest = new FloroRanchRewardTaskRequest();
		floroRanchRewardTaskRequest.TaskIds.AddRange(taskIds);
		floroRanchRewardTaskRequest.ActivityId = activityData.Id;
		Singleton<Net>.Instance.Call<FloroRanchRewardTaskResponse>(ERequestMessageId.FloroRanchRewardTaskRequest, floroRanchRewardTaskRequest, delegate(FloroRanchRewardTaskResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17649, null, true, true);
				return;
			}
			activityData.UpdateTaskRewardStatus(new List<int>(taskIds));
		}, 0);
	}

	// Token: 0x0600D06E RID: 53358 RVA: 0x00375B50 File Offset: 0x00373D50
	public void RequestMilestoneReward(int[] rewardIds)
	{
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		FloroRanchRewardMilestoneRequest floroRanchRewardMilestoneRequest = FloroRanchRewardMilestoneRequest.Create();
		floroRanchRewardMilestoneRequest.ActivityId = activityData.Id;
		floroRanchRewardMilestoneRequest.MilestoneIds.AddRange(rewardIds);
		Singleton<Net>.Instance.Call<FloroRanchRewardMilestoneResponse>(ERequestMessageId.FloroRanchRewardMilestoneRequest, floroRanchRewardMilestoneRequest, delegate(FloroRanchRewardMilestoneResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18496, null, true, true);
			}
			activityData.UpdateFloroRanchMilestoneDataList(new List<int>(rewardIds));
		}, 0);
	}

	// Token: 0x0600D06F RID: 53359 RVA: 0x00375BC4 File Offset: 0x00373DC4
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, false);
		if (activityData == null)
		{
			return;
		}
		if (activityData.GetFloroRanchParamConfig().MilestoneItemId == configId)
		{
			activityData.UpdateFloroRanchMilestoneItemCount();
		}
		if (activityData.GetFloroRanchParamConfig().TechPointItem == configId)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.FloroRanchDataRedDot);
		}
	}

	// Token: 0x0600D070 RID: 53360 RVA: 0x00375C1C File Offset: 0x00373E1C
	public void RequestUnlockTechPoint(int technologyId, Action<FloroRanchUnlockTechPointResponse> callback)
	{
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		FloroRanchUnlockTechPointRequest floroRanchUnlockTechPointRequest = FloroRanchUnlockTechPointRequest.Create();
		floroRanchUnlockTechPointRequest.ActivityId = activityData.Id;
		floroRanchUnlockTechPointRequest.TechPoint = technologyId;
		Singleton<Net>.Instance.Call<FloroRanchUnlockTechPointResponse>(ERequestMessageId.FloroRanchUnlockTechPointRequest, floroRanchUnlockTechPointRequest, delegate(FloroRanchUnlockTechPointResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17845, null, true, true);
				return;
			}
			activityData.UpdateFloroRanchTechnologyData(technologyId);
			callback(response);
		}, 0);
	}

	// Token: 0x0600D071 RID: 53361 RVA: 0x00375C90 File Offset: 0x00373E90
	public void RequestComicRead()
	{
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		if (activityData.GetIsReadComic())
		{
			return;
		}
		FloroRanchAnimationRequest floroRanchAnimationRequest = new FloroRanchAnimationRequest();
		floroRanchAnimationRequest.ActivityId = activityData.Id;
		Singleton<Net>.Instance.Call<FloroRanchAnimationResponse>(ERequestMessageId.FloroRanchAnimationRequest, floroRanchAnimationRequest, delegate(FloroRanchAnimationResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17037, null, true, true);
				return;
			}
			activityData.ReadComic();
		}, 0);
	}

	// Token: 0x0600D072 RID: 53362 RVA: 0x00375CF8 File Offset: 0x00373EF8
	public void RequestSubDungeonRead(int subDungeonId)
	{
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		FloroRanchFirstEnterRequest floroRanchFirstEnterRequest = new FloroRanchFirstEnterRequest();
		floroRanchFirstEnterRequest.ActivityId = activityData.Id;
		floroRanchFirstEnterRequest.SubInsId = subDungeonId;
		Singleton<Net>.Instance.Call<FloroRanchFirstEnterResponse>(ERequestMessageId.FloroRanchFirstEnterRequest, floroRanchFirstEnterRequest, delegate(FloroRanchFirstEnterResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29430, null, true, true);
				return;
			}
			activityData.UpdateFloroRanchSubDungeonRedDot(new List<int>
			{
				subDungeonId
			});
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
		}, 0);
	}
}
