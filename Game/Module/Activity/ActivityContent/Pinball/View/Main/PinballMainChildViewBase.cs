using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065F8 RID: 26104
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballMainChildViewBase : UiPanelBase, GuideDefine.ICustomTabViewForGuide
	{
		// Token: 0x06041366 RID: 267110 RVA: 0x010BA8D9 File Offset: 0x010B8AD9
		protected virtual void OnAddEventListener()
		{
		}

		// Token: 0x06041367 RID: 267111 RVA: 0x010BA8DB File Offset: 0x010B8ADB
		protected virtual UniTask OnPlayingStartSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06041368 RID: 267112 RVA: 0x010BA8E2 File Offset: 0x010B8AE2
		protected virtual UniTask OnPlayingShowSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06041369 RID: 267113 RVA: 0x010BA8E9 File Offset: 0x010B8AE9
		protected virtual UniTask OnPlayingHideSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0604136A RID: 267114 RVA: 0x010BA8F0 File Offset: 0x010B8AF0
		protected virtual UniTask OnPlayingCloseSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0604136B RID: 267115 RVA: 0x010BA8F7 File Offset: 0x010B8AF7
		protected virtual void OnRemoveEventListener()
		{
		}

		// Token: 0x0604136C RID: 267116 RVA: 0x010BA8F9 File Offset: 0x010B8AF9
		protected override void OnStartImplement()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.FirstShow = true;
		}

		// Token: 0x0604136D RID: 267117 RVA: 0x010BA913 File Offset: 0x010B8B13
		protected override void OnBeforeShowImplement()
		{
			this.OnAddEventListener();
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, this.ViewName);
		}

		// Token: 0x0604136E RID: 267118 RVA: 0x010BA934 File Offset: 0x010B8B34
		protected override UniTask OnShowAsyncImplementImplement()
		{
			PinballMainChildViewBase.<OnShowAsyncImplementImplement>d__14 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<PinballMainChildViewBase.<OnShowAsyncImplementImplement>d__14>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0604136F RID: 267119 RVA: 0x010BA978 File Offset: 0x010B8B78
		protected override UniTask OnHideAsyncImplementImplement()
		{
			PinballMainChildViewBase.<OnHideAsyncImplementImplement>d__15 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<PinballMainChildViewBase.<OnHideAsyncImplementImplement>d__15>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06041370 RID: 267120 RVA: 0x010BA9BB File Offset: 0x010B8BBB
		protected override void OnAfterHideImplement()
		{
			this.OnRemoveEventListener();
		}

		// Token: 0x06041371 RID: 267121 RVA: 0x010BA9C3 File Offset: 0x010B8BC3
		public void OpenChildView(string viewName)
		{
			this.RootView.OpenChildView(viewName);
		}

		// Token: 0x06041372 RID: 267122 RVA: 0x010BA9D4 File Offset: 0x010B8BD4
		public UniTask OpenChildViewAsync(string viewName)
		{
			PinballMainChildViewBase.<OpenChildViewAsync>d__18 <OpenChildViewAsync>d__;
			<OpenChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenChildViewAsync>d__.<>4__this = this;
			<OpenChildViewAsync>d__.viewName = viewName;
			<OpenChildViewAsync>d__.<>1__state = -1;
			<OpenChildViewAsync>d__.<>t__builder.Start<PinballMainChildViewBase.<OpenChildViewAsync>d__18>(ref <OpenChildViewAsync>d__);
			return <OpenChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041373 RID: 267123 RVA: 0x010BAA20 File Offset: 0x010B8C20
		[NullableContext(0)]
		public override UniTask<bool> CloseMeAsync()
		{
			PinballMainChildViewBase.<CloseMeAsync>d__19 <CloseMeAsync>d__;
			<CloseMeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseMeAsync>d__.<>4__this = this;
			<CloseMeAsync>d__.<>1__state = -1;
			<CloseMeAsync>d__.<>t__builder.Start<PinballMainChildViewBase.<CloseMeAsync>d__19>(ref <CloseMeAsync>d__);
			return <CloseMeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041374 RID: 267124 RVA: 0x010BAA63 File Offset: 0x010B8C63
		public void CloseMe()
		{
			this.RootView.CloseCurChildView();
		}

		// Token: 0x06041375 RID: 267125 RVA: 0x010BAA70 File Offset: 0x010B8C70
		public string GetViewName()
		{
			return this.ViewName ?? "";
		}

		// Token: 0x06041376 RID: 267126 RVA: 0x010BAA81 File Offset: 0x010B8C81
		public void BackToLastView()
		{
			this.RootView.Back();
		}

		// Token: 0x06041377 RID: 267127 RVA: 0x010BAA8E File Offset: 0x010B8C8E
		public void PlayRootSequence(string sequenceName)
		{
			this.RootView.PlaySequenceByName(sequenceName);
		}

		// Token: 0x06041378 RID: 267128 RVA: 0x010BAA9C File Offset: 0x010B8C9C
		public UniTask PlayRootSequenceAsync(string sequenceName)
		{
			PinballMainChildViewBase.<PlayRootSequenceAsync>d__24 <PlayRootSequenceAsync>d__;
			<PlayRootSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayRootSequenceAsync>d__.<>4__this = this;
			<PlayRootSequenceAsync>d__.sequenceName = sequenceName;
			<PlayRootSequenceAsync>d__.<>1__state = -1;
			<PlayRootSequenceAsync>d__.<>t__builder.Start<PinballMainChildViewBase.<PlayRootSequenceAsync>d__24>(ref <PlayRootSequenceAsync>d__);
			return <PlayRootSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04024824 RID: 149540
		[Nullable(2)]
		public PinballMainRootViewBase RootView;

		// Token: 0x04024825 RID: 149541
		[Nullable(2)]
		public object ViewModel;

		// Token: 0x04024826 RID: 149542
		[Nullable(2)]
		public string ViewName;

		// Token: 0x04024827 RID: 149543
		public int ActivityId;

		// Token: 0x04024828 RID: 149544
		[Nullable(2)]
		protected UiSequencePlayer SequencePlayer;

		// Token: 0x04024829 RID: 149545
		private bool FirstShow;
	}
}
