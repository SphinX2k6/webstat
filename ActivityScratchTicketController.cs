using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001592 RID: 5522
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityScratchTicketController : ActivityControllerBase<ActivityScratchTicketController>
{
	// Token: 0x06009B77 RID: 39799 RVA: 0x0028B78A File Offset: 0x0028998A
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009B78 RID: 39800 RVA: 0x0028B78C File Offset: 0x0028998C
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ScratchoffTicketMain";
	}

	// Token: 0x06009B79 RID: 39801 RVA: 0x0028B793 File Offset: 0x00289993
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ScratchTicketActivityView();
	}

	// Token: 0x06009B7A RID: 39802 RVA: 0x0028B79C File Offset: 0x0028999C
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		ScratchTicketData scratchTicketData = new ScratchTicketData();
		ModelBase<ActivityScratchTicketModel>.Instance.SetScratchTicketData(scratchTicketData);
		return scratchTicketData;
	}

	// Token: 0x06009B7B RID: 39803 RVA: 0x0028B7BB File Offset: 0x002899BB
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009B7C RID: 39804 RVA: 0x0028B7C0 File Offset: 0x002899C0
	[NullableContext(0)]
	public static UniTask<bool> OpenScratchTicketMainView()
	{
		ActivityScratchTicketController.<OpenScratchTicketMainView>d__5 <OpenScratchTicketMainView>d__;
		<OpenScratchTicketMainView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenScratchTicketMainView>d__.<>1__state = -1;
		<OpenScratchTicketMainView>d__.<>t__builder.Start<ActivityScratchTicketController.<OpenScratchTicketMainView>d__5>(ref <OpenScratchTicketMainView>d__);
		return <OpenScratchTicketMainView>d__.<>t__builder.Task;
	}

	// Token: 0x06009B7D RID: 39805 RVA: 0x0028B7FB File Offset: 0x002899FB
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ScratchCardCountInfoNotify>(ENotifyMessageId.ScratchCardCountInfoNotify, new Action<ScratchCardCountInfoNotify, Net.CallbackStatus>(this.OnScratchCardCountInfoNotify));
	}

	// Token: 0x06009B7E RID: 39806 RVA: 0x0028B819 File Offset: 0x00289A19
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ScratchCardCountInfoNotify);
	}

	// Token: 0x06009B7F RID: 39807 RVA: 0x0028B82B File Offset: 0x00289A2B
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06009B80 RID: 39808 RVA: 0x0028B849 File Offset: 0x00289A49
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06009B81 RID: 39809 RVA: 0x0028B867 File Offset: 0x00289A67
	private void OnScratchCardCountInfoNotify(ScratchCardCountInfoNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<ActivityScratchTicketModel>.Instance.OnScratchCardCountInfoNotify(message);
	}

	// Token: 0x06009B82 RID: 39810 RVA: 0x0028B874 File Offset: 0x00289A74
	public void SendScratchCardRewardRequest(int roundId, int index, Action<EScratchTicketRewardType, int, List<ScratchTicketRoundResult>, List<RewardItemData>> callback)
	{
		ScratchCardRewardRequest scratchCardRewardRequest = ScratchCardRewardRequest.Create();
		scratchCardRewardRequest.RoundId = roundId;
		scratchCardRewardRequest.Index = index;
		Singleton<Net>.Instance.Call<ScratchCardRewardResponse>(ERequestMessageId.ScratchCardRewardRequest, scratchCardRewardRequest, delegate(ScratchCardRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Error != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, 22669, null, true, true);
				return;
			}
			ModelBase<ActivityScratchTicketModel>.Instance.OnScratchCardRewardResponse(index, roundId, response, callback);
		}, 0);
	}

	// Token: 0x06009B83 RID: 39811 RVA: 0x0028B8D8 File Offset: 0x00289AD8
	[NullableContext(0)]
	public UniTask<bool> SendScratchCardActivityInfoRequest()
	{
		ActivityScratchTicketController.<SendScratchCardActivityInfoRequest>d__12 <SendScratchCardActivityInfoRequest>d__;
		<SendScratchCardActivityInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SendScratchCardActivityInfoRequest>d__.<>1__state = -1;
		<SendScratchCardActivityInfoRequest>d__.<>t__builder.Start<ActivityScratchTicketController.<SendScratchCardActivityInfoRequest>d__12>(ref <SendScratchCardActivityInfoRequest>d__);
		return <SendScratchCardActivityInfoRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06009B84 RID: 39812 RVA: 0x0028B914 File Offset: 0x00289B14
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		ScratchTicketData scratchTicketData = ModelBase<ActivityScratchTicketModel>.Instance.GetScratchTicketData();
		if (scratchTicketData == null)
		{
			return;
		}
		if (configId != scratchTicketData.GetCostItemId())
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, scratchTicketData.Id);
	}

	// Token: 0x06009B85 RID: 39813 RVA: 0x0028B950 File Offset: 0x00289B50
	public void ShowScratchTicketRewardTip(List<RewardItemData> rewardItemDataList)
	{
		if (rewardItemDataList.Count < 1)
		{
			return;
		}
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(rewardItemDataList[0].ConfigId);
		if (itemConfigData == null)
		{
			return;
		}
		string text = itemConfigData.IconSmall + "/";
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.Name, null);
		QualityInfo? itemQualityConfig = ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(itemConfigData.QualityId);
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ScratchCardRewardTips", new object[]
		{
			text,
			itemQualityConfig.Value.TextColor,
			localTextNew,
			rewardItemDataList[0].Count.ToString()
		});
	}
}
