using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054A5 RID: 21669
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaChildViewBase : UiPanelBase, GuideDefine.ICustomTabViewForGuide
	{
		// Token: 0x17008E1C RID: 36380
		// (get) Token: 0x06037272 RID: 225906 RVA: 0x00E01C51 File Offset: 0x00DFFE51
		// (set) Token: 0x06037273 RID: 225907 RVA: 0x00E01C59 File Offset: 0x00DFFE59
		public EPhantomArenaChildViewName? ViewName { get; set; }

		// Token: 0x17008E1D RID: 36381
		// (get) Token: 0x06037274 RID: 225908 RVA: 0x00E01C62 File Offset: 0x00DFFE62
		// (set) Token: 0x06037275 RID: 225909 RVA: 0x00E01C6A File Offset: 0x00DFFE6A
		public int ActivityId { get; set; }

		// Token: 0x06037276 RID: 225910 RVA: 0x00E01C73 File Offset: 0x00DFFE73
		protected virtual void OnAddEventListener()
		{
		}

		// Token: 0x06037277 RID: 225911 RVA: 0x00E01C75 File Offset: 0x00DFFE75
		protected virtual UniTask OnPlayingStartSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06037278 RID: 225912 RVA: 0x00E01C7C File Offset: 0x00DFFE7C
		protected virtual UniTask OnPlayingShowSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06037279 RID: 225913 RVA: 0x00E01C83 File Offset: 0x00DFFE83
		protected virtual UniTask OnPlayingHideSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603727A RID: 225914 RVA: 0x00E01C8A File Offset: 0x00DFFE8A
		protected virtual UniTask OnPlayingCloseSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603727B RID: 225915 RVA: 0x00E01C91 File Offset: 0x00DFFE91
		protected virtual void OnRemoveEventListener()
		{
		}

		// Token: 0x0603727C RID: 225916 RVA: 0x00E01C93 File Offset: 0x00DFFE93
		protected override void OnStartImplement()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.FirstShow = true;
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnPhantomArenaChildViewOpen, this.GetViewName());
		}

		// Token: 0x0603727D RID: 225917 RVA: 0x00E01CC3 File Offset: 0x00DFFEC3
		protected override void OnBeforeShowImplement()
		{
			this.OnAddEventListener();
		}

		// Token: 0x0603727E RID: 225918 RVA: 0x00E01CCC File Offset: 0x00DFFECC
		protected override UniTask OnShowAsyncImplementImplement()
		{
			PhantomArenaChildViewBase.<OnShowAsyncImplementImplement>d__20 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<PhantomArenaChildViewBase.<OnShowAsyncImplementImplement>d__20>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603727F RID: 225919 RVA: 0x00E01D10 File Offset: 0x00DFFF10
		protected override UniTask OnHideAsyncImplementImplement()
		{
			PhantomArenaChildViewBase.<OnHideAsyncImplementImplement>d__21 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<PhantomArenaChildViewBase.<OnHideAsyncImplementImplement>d__21>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06037280 RID: 225920 RVA: 0x00E01D53 File Offset: 0x00DFFF53
		protected override void OnAfterHideImplement()
		{
			this.OnRemoveEventListener();
		}

		// Token: 0x06037281 RID: 225921 RVA: 0x00E01D5B File Offset: 0x00DFFF5B
		public void OpenChildView(EPhantomArenaChildViewName viewName)
		{
			this.RootView.OpenChildView(viewName);
		}

		// Token: 0x06037282 RID: 225922 RVA: 0x00E01D6C File Offset: 0x00DFFF6C
		public UniTask OpenChildViewAsync(EPhantomArenaChildViewName viewName)
		{
			PhantomArenaChildViewBase.<OpenChildViewAsync>d__24 <OpenChildViewAsync>d__;
			<OpenChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenChildViewAsync>d__.<>4__this = this;
			<OpenChildViewAsync>d__.viewName = viewName;
			<OpenChildViewAsync>d__.<>1__state = -1;
			<OpenChildViewAsync>d__.<>t__builder.Start<PhantomArenaChildViewBase.<OpenChildViewAsync>d__24>(ref <OpenChildViewAsync>d__);
			return <OpenChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037283 RID: 225923 RVA: 0x00E01DB8 File Offset: 0x00DFFFB8
		[NullableContext(0)]
		public override UniTask<bool> CloseMeAsync()
		{
			PhantomArenaChildViewBase.<CloseMeAsync>d__25 <CloseMeAsync>d__;
			<CloseMeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseMeAsync>d__.<>4__this = this;
			<CloseMeAsync>d__.<>1__state = -1;
			<CloseMeAsync>d__.<>t__builder.Start<PhantomArenaChildViewBase.<CloseMeAsync>d__25>(ref <CloseMeAsync>d__);
			return <CloseMeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037284 RID: 225924 RVA: 0x00E01DFB File Offset: 0x00DFFFFB
		public void CloseMe()
		{
			this.RootView.CloseCurChildView();
		}

		// Token: 0x06037285 RID: 225925 RVA: 0x00E01E08 File Offset: 0x00E00008
		public string GetViewName()
		{
			EPhantomArenaChildViewName? ephantomArenaChildViewName;
			return ((this.ViewName != null) ? ephantomArenaChildViewName.GetValueOrDefault().ToString() : null) ?? "";
		}

		// Token: 0x06037286 RID: 225926 RVA: 0x00E01E46 File Offset: 0x00E00046
		public void BackToLastView()
		{
			this.RootView.Back();
		}

		// Token: 0x0401FBE2 RID: 130018
		public IPhantomArenaRootViewBase RootView;

		// Token: 0x0401FBE3 RID: 130019
		public IPhantomArenaTabViewModelBase ViewModel;

		// Token: 0x0401FBE6 RID: 130022
		protected UiSequencePlayer SequencePlayer;

		// Token: 0x0401FBE7 RID: 130023
		private bool FirstShow = true;
	}
}
