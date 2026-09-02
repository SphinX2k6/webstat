using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200133B RID: 4923
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityInviteNewbieController : ActivityControllerBase<ActivityInviteNewbieController>
{
	// Token: 0x06008679 RID: 34425 RVA: 0x0023701B File Offset: 0x0023521B
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600867A RID: 34426 RVA: 0x0023701D File Offset: 0x0023521D
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ReferralCampaignMain";
	}

	// Token: 0x0600867B RID: 34427 RVA: 0x00237024 File Offset: 0x00235224
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new InviteNewbieSubView();
	}

	// Token: 0x0600867C RID: 34428 RVA: 0x0023702B File Offset: 0x0023522B
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return ModelBase<InviteNewbieModel>.Instance.ActivityData;
	}

	// Token: 0x0600867D RID: 34429 RVA: 0x00237037 File Offset: 0x00235237
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600867E RID: 34430 RVA: 0x0023703A File Offset: 0x0023523A
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<H5CircumFluenceActivityDataNotify>(ENotifyMessageId.H5CircumFluenceActivityDataNotify, new Action<H5CircumFluenceActivityDataNotify, Net.CallbackStatus>(this.HandleActivityDataNotify));
	}

	// Token: 0x0600867F RID: 34431 RVA: 0x00237058 File Offset: 0x00235258
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.H5CircumFluenceActivityDataNotify);
	}

	// Token: 0x06008680 RID: 34432 RVA: 0x0023706A File Offset: 0x0023526A
	private void HandleActivityDataNotify(H5CircumFluenceActivityDataNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<InviteNewbieModel>.Instance.SyncActivityNotify(notify);
	}

	// Token: 0x06008681 RID: 34433 RVA: 0x00237077 File Offset: 0x00235277
	public void HandleOnRewardClick(InviteNewbieProtocolContext activityData)
	{
		if (activityData != null)
		{
			activityData.SetCurrentLoginClickState(true);
		}
		this.OpenUrl();
	}

	// Token: 0x06008682 RID: 34434 RVA: 0x00237089 File Offset: 0x00235289
	public void HandleOnEnterClick(InviteNewbieProtocolContext activityData)
	{
		if (activityData != null)
		{
			activityData.SetCurrentLoginClickState(true);
		}
		this.OpenUrl();
	}

	// Token: 0x06008683 RID: 34435 RVA: 0x0023709B File Offset: 0x0023529B
	public void HandleOnCopyInviteCodeClick()
	{
		string inviteCode = ModelBase<InviteNewbieModel>.Instance.InviteCode;
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Activity_104600001_CopyTips", Array.Empty<object>());
		ULGUIBPLibrary.ClipBoardCopy(inviteCode);
	}

	// Token: 0x06008684 RID: 34436 RVA: 0x002370C0 File Offset: 0x002352C0
	private void RequestSaveReadState()
	{
		H5CircumFluenceActivityReadRequest message = H5CircumFluenceActivityReadRequest.Create();
		Singleton<Net>.Instance.Call<H5CircumFluenceActivityReadResponse>(ERequestMessageId.H5CircumFluenceActivityReadRequest, message, delegate(H5CircumFluenceActivityReadResponse response, Net.CallbackStatus _)
		{
		}, 0);
	}

	// Token: 0x06008685 RID: 34437 RVA: 0x00237104 File Offset: 0x00235304
	private void OpenUrl()
	{
		string rootUrl = ModelBase<InviteNewbieModel>.Instance.RootUrl;
		if (StringUtils.IsEmpty(rootUrl))
		{
			Singleton<Log>.Instance.Info(ELogModule.InviteNewbie, ELogAuthor.WZ, "无法获取根链接", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		string text = Singleton<PublicUtil>.Instance.GetExternalUrl(rootUrl, PublicUtil.EExternalUrlReason.InviteNewbie);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.InviteNewbie;
		ELogAuthor author = ELogAuthor.WZ;
		string message = "打开外部链接";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", text);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (text != null)
		{
			ModelBase<InviteNewbieModel>.Instance.SaveClickState();
			this.RequestSaveReadState();
			Singleton<EventSystem>.Instance.Emit(EEventName.InviteNewbieEntered);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ModelBase<InviteNewbieModel>.Instance.CurrentActivityId);
			if (ModelBase<InviteNewbieModel>.Instance.IsInternalBrowser)
			{
				if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
				{
					text = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(text, true);
					ControllerBase<KuroSdkController>.Instance.OpenWebView("", text, true, true, true, "Default");
					return;
				}
				text = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(text, false);
				ControllerBase<KuroSdkController>.Instance.OpenExternalUrl(text);
				return;
			}
			else
			{
				text = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(text, false);
				ControllerBase<KuroSdkController>.Instance.OpenExternalUrl(text);
			}
		}
	}
}
