using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Spring25;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020015BC RID: 5564
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivitySpring25Controller : ActivityControllerBase<ActivitySpring25Controller>
{
	// Token: 0x06009CCA RID: 40138 RVA: 0x0029108A File Offset: 0x0028F28A
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009CCB RID: 40139 RVA: 0x0029108C File Offset: 0x0028F28C
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_SpringAGuide";
	}

	// Token: 0x06009CCC RID: 40140 RVA: 0x00291093 File Offset: 0x0028F293
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySpring25SubView();
	}

	// Token: 0x06009CCD RID: 40141 RVA: 0x0029109A File Offset: 0x0028F29A
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return ModelBase<Spring25Model>.Instance.ActivityData;
	}

	// Token: 0x06009CCE RID: 40142 RVA: 0x002910A8 File Offset: 0x0028F2A8
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.Spring25MainView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.Spring25InfoView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.Spring25DialogueView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.Spring25EnvelopeView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.Spring25LetterListView);
	}

	// Token: 0x06009CCF RID: 40143 RVA: 0x0029110A File Offset: 0x0028F30A
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCloseRewardView, new Action(this.HandleOnCloseRewardView));
	}

	// Token: 0x06009CD0 RID: 40144 RVA: 0x00291128 File Offset: 0x0028F328
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseRewardView, new Action(this.HandleOnCloseRewardView));
	}

	// Token: 0x06009CD1 RID: 40145 RVA: 0x00291148 File Offset: 0x0028F348
	[NullableContext(0)]
	public UniTask<bool> RequestSpringSignDrawRoleRequest()
	{
		ActivitySpring25Controller.<RequestSpringSignDrawRoleRequest>d__8 <RequestSpringSignDrawRoleRequest>d__;
		<RequestSpringSignDrawRoleRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestSpringSignDrawRoleRequest>d__.<>1__state = -1;
		<RequestSpringSignDrawRoleRequest>d__.<>t__builder.Start<ActivitySpring25Controller.<RequestSpringSignDrawRoleRequest>d__8>(ref <RequestSpringSignDrawRoleRequest>d__);
		return <RequestSpringSignDrawRoleRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06009CD2 RID: 40146 RVA: 0x00291184 File Offset: 0x0028F384
	public UniTask RequestSpringSignDrawRewardRequest(int id)
	{
		ActivitySpring25Controller.<RequestSpringSignDrawRewardRequest>d__9 <RequestSpringSignDrawRewardRequest>d__;
		<RequestSpringSignDrawRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestSpringSignDrawRewardRequest>d__.id = id;
		<RequestSpringSignDrawRewardRequest>d__.<>1__state = -1;
		<RequestSpringSignDrawRewardRequest>d__.<>t__builder.Start<ActivitySpring25Controller.<RequestSpringSignDrawRewardRequest>d__9>(ref <RequestSpringSignDrawRewardRequest>d__);
		return <RequestSpringSignDrawRewardRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06009CD3 RID: 40147 RVA: 0x002911C8 File Offset: 0x0028F3C8
	private UniTask RequestSpringSignSkinRewardRequest()
	{
		ActivitySpring25Controller.<RequestSpringSignSkinRewardRequest>d__10 <RequestSpringSignSkinRewardRequest>d__;
		<RequestSpringSignSkinRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestSpringSignSkinRewardRequest>d__.<>1__state = -1;
		<RequestSpringSignSkinRewardRequest>d__.<>t__builder.Start<ActivitySpring25Controller.<RequestSpringSignSkinRewardRequest>d__10>(ref <RequestSpringSignSkinRewardRequest>d__);
		return <RequestSpringSignSkinRewardRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06009CD4 RID: 40148 RVA: 0x00291204 File Offset: 0x0028F404
	private UniTask RequestSpringSignPhotoRewardRequest()
	{
		ActivitySpring25Controller.<RequestSpringSignPhotoRewardRequest>d__11 <RequestSpringSignPhotoRewardRequest>d__;
		<RequestSpringSignPhotoRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestSpringSignPhotoRewardRequest>d__.<>1__state = -1;
		<RequestSpringSignPhotoRewardRequest>d__.<>t__builder.Start<ActivitySpring25Controller.<RequestSpringSignPhotoRewardRequest>d__11>(ref <RequestSpringSignPhotoRewardRequest>d__);
		return <RequestSpringSignPhotoRewardRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06009CD5 RID: 40149 RVA: 0x0029123F File Offset: 0x0028F43F
	public void HandleConfirmClickInActivitySubView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.Spring25MainView, ModelBase<Spring25Model>.Instance.BuildMainViewData(false), null);
	}

	// Token: 0x06009CD6 RID: 40150 RVA: 0x0029125C File Offset: 0x0028F45C
	public UniTask HandleInviteClickInMainView()
	{
		ActivitySpring25Controller.<HandleInviteClickInMainView>d__13 <HandleInviteClickInMainView>d__;
		<HandleInviteClickInMainView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HandleInviteClickInMainView>d__.<>4__this = this;
		<HandleInviteClickInMainView>d__.<>1__state = -1;
		<HandleInviteClickInMainView>d__.<>t__builder.Start<ActivitySpring25Controller.<HandleInviteClickInMainView>d__13>(ref <HandleInviteClickInMainView>d__);
		return <HandleInviteClickInMainView>d__.<>t__builder.Task;
	}

	// Token: 0x06009CD7 RID: 40151 RVA: 0x0029129F File Offset: 0x0028F49F
	public void HandleGiftClickInMainView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.Spring25InfoView, ModelBase<Spring25Model>.Instance.BuildInfoViewData(), null);
	}

	// Token: 0x06009CD8 RID: 40152 RVA: 0x002912BC File Offset: 0x0028F4BC
	public void HandleLetterClickInMainView()
	{
		if (ModelBase<Spring25Model>.Instance.IsLetterListViewAvailable)
		{
			ModelBase<Spring25Model>.Instance.InitLetterSignIdForLetterListView();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.Spring25LetterListView, ModelBase<Spring25Model>.Instance.BuildLetterListViewData(), null);
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SpringMessage_1", Array.Empty<object>());
	}

	// Token: 0x06009CD9 RID: 40153 RVA: 0x0029130E File Offset: 0x0028F50E
	public void HandleResetCurrentSignId()
	{
		ModelBase<Spring25Model>.Instance.ResetCurrentSignId();
	}

	// Token: 0x06009CDA RID: 40154 RVA: 0x0029131C File Offset: 0x0028F51C
	public void HandleOpenOpeningDialogViewInMainView()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.Spring25FirstEnter, false);
		Spring25DialogueViewData param = ModelBase<Spring25Model>.Instance.BuildStartDialogueViewData();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.Spring25DialogueView, param, null);
	}

	// Token: 0x06009CDB RID: 40155 RVA: 0x0029134E File Offset: 0x0028F54E
	public void HandleLetterClickInLetterListView(int signId)
	{
		ModelBase<Spring25Model>.Instance.TrySetCurrentLetterSignId(signId);
	}

	// Token: 0x06009CDC RID: 40156 RVA: 0x0029135C File Offset: 0x0028F55C
	public void HandleHelpClick()
	{
		int helpId = ModelBase<Spring25Model>.Instance.HelpId;
		ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
	}

	// Token: 0x06009CDD RID: 40157 RVA: 0x0029137F File Offset: 0x0028F57F
	public void HandleConfirmClickInDialogueView()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.Spring25DialogueView, null);
		if (ModelBase<Spring25Model>.Instance.NeedOpenEnvelopeView)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.Spring25EnvelopeView, ModelBase<Spring25Model>.Instance.BuildEnvelopeViewData(), null);
		}
	}

	// Token: 0x06009CDE RID: 40158 RVA: 0x002913B8 File Offset: 0x0028F5B8
	public unsafe void HandleOpenSkinPreview()
	{
		RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(81011102);
		if (roleSkinData == null)
		{
			return;
		}
		SkinController instance = ControllerBase<SkinController>.Instance;
		int num = 1;
		List<RoleSkinData> list = new List<RoleSkinData>(num);
		CollectionsMarshal.SetCount<RoleSkinData>(list, num);
		Span<RoleSkinData> span = CollectionsMarshal.AsSpan<RoleSkinData>(list);
		int index = 0;
		*span[index] = roleSkinData;
		instance.OpenBuyRoleSkinPreviewDetailViewByRoleSkinData(list);
	}

	// Token: 0x06009CDF RID: 40159 RVA: 0x00291405 File Offset: 0x0028F605
	public void HandleRequestRewardSkin()
	{
		if (ModelBase<Spring25Model>.Instance.IsSkinRewarded)
		{
			return;
		}
		this.RequestSpringSignSkinRewardRequest();
	}

	// Token: 0x06009CE0 RID: 40160 RVA: 0x0029141C File Offset: 0x0028F61C
	public void HandleWhenUnlockAnimEnd()
	{
		Spring25DialogueViewData spring25DialogueViewData = ModelBase<Spring25Model>.Instance.BuildDialogueViewData();
		if (spring25DialogueViewData != null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.Spring25DialogueView, spring25DialogueViewData, null);
		}
	}

	// Token: 0x06009CE1 RID: 40161 RVA: 0x00291448 File Offset: 0x0028F648
	public UniTask HandleTryOpenShareViewAsync()
	{
		ActivitySpring25Controller.<HandleTryOpenShareViewAsync>d__24 <HandleTryOpenShareViewAsync>d__;
		<HandleTryOpenShareViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HandleTryOpenShareViewAsync>d__.<>4__this = this;
		<HandleTryOpenShareViewAsync>d__.<>1__state = -1;
		<HandleTryOpenShareViewAsync>d__.<>t__builder.Start<ActivitySpring25Controller.<HandleTryOpenShareViewAsync>d__24>(ref <HandleTryOpenShareViewAsync>d__);
		return <HandleTryOpenShareViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009CE2 RID: 40162 RVA: 0x0029148B File Offset: 0x0028F68B
	private void HandleOnCloseRewardView()
	{
		CustomPromise waitForRewardClosePromise = this.WaitForRewardClosePromise;
		if (waitForRewardClosePromise == null)
		{
			return;
		}
		waitForRewardClosePromise.SetResult();
	}

	// Token: 0x0400480D RID: 18445
	[Nullable(2)]
	private CustomPromise WaitForRewardClosePromise;
}
