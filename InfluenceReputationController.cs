using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x02001FD8 RID: 8152
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class InfluenceReputationController : UiControllerBase<InfluenceReputationController>
{
	// Token: 0x0600F61B RID: 63003 RVA: 0x0043654E File Offset: 0x0043474E
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.RequestInfluenceInfo));
	}

	// Token: 0x0600F61C RID: 63004 RVA: 0x0043656C File Offset: 0x0043476C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.RequestInfluenceInfo));
	}

	// Token: 0x0600F61D RID: 63005 RVA: 0x0043658A File Offset: 0x0043478A
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<InfluenceInfoUpdateNotify>(ENotifyMessageId.InfluenceInfoUpdateNotify, new Action<InfluenceInfoUpdateNotify, Net.CallbackStatus>(this.NotifyInfluenceInfoUpdate));
	}

	// Token: 0x0600F61E RID: 63006 RVA: 0x004365A8 File Offset: 0x004347A8
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfluenceInfoUpdateNotify);
	}

	// Token: 0x0600F61F RID: 63007 RVA: 0x004365BC File Offset: 0x004347BC
	private void NotifyInfluenceInfoUpdate(InfluenceInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<OneInfluenceInfo> influenceInfos = message.InfluenceInfos;
		ModelBase<InfluenceReputationModel>.Instance.SetInfluenceInfoList(influenceInfos.ToArray<OneInfluenceInfo>());
	}

	// Token: 0x0600F620 RID: 63008 RVA: 0x004365E0 File Offset: 0x004347E0
	public void RequestInfluenceInfo()
	{
		InfluenceInfoRequest message = InfluenceInfoRequest.Create();
		Singleton<Net>.Instance.Call<InfluenceInfoResponse>(ERequestMessageId.InfluenceInfoRequest, message, delegate(InfluenceInfoResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			RepeatedField<OneInfluenceInfo> influenceInfos = response.InfluenceInfos;
			ModelBase<InfluenceReputationModel>.Instance.SetInfluenceInfoList(influenceInfos.ToArray<OneInfluenceInfo>());
		}, 0);
	}

	// Token: 0x0600F621 RID: 63009 RVA: 0x00436624 File Offset: 0x00434824
	public void RequestInfluenceReward(int influenceId)
	{
		InfluenceRewardRequest influenceRewardRequest = InfluenceRewardRequest.Create();
		influenceRewardRequest.InfluenceId = influenceId;
		Singleton<Net>.Instance.Call<InfluenceRewardResponse>(ERequestMessageId.InfluenceRewardRequest, influenceRewardRequest, delegate(InfluenceRewardResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response.Code != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 27807, null, true, true);
				return;
			}
			if (ModelBase<InfluenceReputationModel>.Instance.UpdateInfluenceRewardIndex(response.InfluenceId, response.RewardIndex))
			{
				this.ShowReward(response.RewardItems);
				Singleton<EventSystem>.Instance.Emit(EEventName.ReceiveReputationReward);
			}
		}, 0);
	}

	// Token: 0x0600F622 RID: 63010 RVA: 0x0043665C File Offset: 0x0043485C
	private void ShowReward(IDictionary<int, int> itemList)
	{
		List<RewardItemData> list = new List<RewardItemData>();
		foreach (KeyValuePair<int, int> keyValuePair in itemList)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			RewardItemData item = new RewardItemData(key, value, null, EDropItemType.Normal);
			list.Add(item);
		}
		ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1009, list, null);
	}

	// Token: 0x0600F623 RID: 63011 RVA: 0x004366E0 File Offset: 0x004348E0
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.InfluenceReputationView, new Func<EUiViewName, object, bool>(this.CanOpenView), "InfluenceReputationController.CanOpenView");
	}

	// Token: 0x0600F624 RID: 63012 RVA: 0x00436702 File Offset: 0x00434902
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.InfluenceReputationView, new Func<EUiViewName, object, bool>(this.CanOpenView));
	}

	// Token: 0x0600F625 RID: 63013 RVA: 0x0043671F File Offset: 0x0043491F
	private bool CanOpenView(EUiViewName viewName, object param)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10029);
	}
}
