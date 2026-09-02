using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054AD RID: 21677
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class PhantomArenaRootViewBase<[Nullable(0)] TViewModel> : UiViewBase, IPhantomArenaRootViewBase where TViewModel : IPhantomArenaTabViewModelBase
	{
		// Token: 0x06037310 RID: 226064 RVA: 0x00E02C53 File Offset: 0x00E00E53
		public PhantomArenaRootViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037311 RID: 226065 RVA: 0x00E02C72 File Offset: 0x00E00E72
		protected override void OnBeforeCreate()
		{
			this.OnRegisterViewData();
			this.OnRegisterDefaultChildView();
		}

		// Token: 0x06037312 RID: 226066
		protected abstract void OnRegisterDefaultChildView();

		// Token: 0x06037313 RID: 226067
		protected abstract void OnRegisterContentItem();

		// Token: 0x06037314 RID: 226068
		protected abstract void OnRegisterViewData();

		// Token: 0x06037315 RID: 226069 RVA: 0x00E02C80 File Offset: 0x00E00E80
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaRootViewBase<TViewModel>.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037316 RID: 226070 RVA: 0x00E02CC4 File Offset: 0x00E00EC4
		protected override UniTask OnShowAsyncImplementImplement()
		{
			PhantomArenaRootViewBase<TViewModel>.<OnShowAsyncImplementImplement>d__12 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<OnShowAsyncImplementImplement>d__12>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06037317 RID: 226071 RVA: 0x00E02D08 File Offset: 0x00E00F08
		protected override UniTask OnHideAsyncImplementImplement()
		{
			PhantomArenaRootViewBase<TViewModel>.<OnHideAsyncImplementImplement>d__13 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<OnHideAsyncImplementImplement>d__13>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06037318 RID: 226072 RVA: 0x00E02D4C File Offset: 0x00E00F4C
		protected override UniTask OnDestroyAsyncImplementImplement()
		{
			PhantomArenaRootViewBase<TViewModel>.<OnDestroyAsyncImplementImplement>d__14 <OnDestroyAsyncImplementImplement>d__;
			<OnDestroyAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnDestroyAsyncImplementImplement>d__.<>4__this = this;
			<OnDestroyAsyncImplementImplement>d__.<>1__state = -1;
			<OnDestroyAsyncImplementImplement>d__.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<OnDestroyAsyncImplementImplement>d__14>(ref <OnDestroyAsyncImplementImplement>d__);
			return <OnDestroyAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06037319 RID: 226073 RVA: 0x00E02D90 File Offset: 0x00E00F90
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<PhantomArenaChildViewBase> CreateChildViewAsync(EPhantomArenaChildViewName viewName)
		{
			PhantomArenaRootViewBase<TViewModel>.<CreateChildViewAsync>d__15 <CreateChildViewAsync>d__;
			<CreateChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhantomArenaChildViewBase>.Create();
			<CreateChildViewAsync>d__.<>4__this = this;
			<CreateChildViewAsync>d__.viewName = viewName;
			<CreateChildViewAsync>d__.<>1__state = -1;
			<CreateChildViewAsync>d__.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<CreateChildViewAsync>d__15>(ref <CreateChildViewAsync>d__);
			return <CreateChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603731A RID: 226074 RVA: 0x00E02DDC File Offset: 0x00E00FDC
		public void OpenChildView(EPhantomArenaChildViewName viewName)
		{
			PhantomArenaRootViewBase<TViewModel>.<>c__DisplayClass16_0 CS$<>8__locals1 = new PhantomArenaRootViewBase<TViewModel>.<>c__DisplayClass16_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.viewName = viewName;
			UiAsyncTask task = new UiAsyncTask("PhantomArenaRootViewBase", delegate()
			{
				PhantomArenaRootViewBase<TViewModel>.<>c__DisplayClass16_0.<<OpenChildView>b__0>d <<OpenChildView>b__0>d;
				<<OpenChildView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OpenChildView>b__0>d.<>4__this = CS$<>8__locals1;
				<<OpenChildView>b__0>d.<>1__state = -1;
				<<OpenChildView>b__0>d.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<>c__DisplayClass16_0.<<OpenChildView>b__0>d>(ref <<OpenChildView>b__0>d);
				return <<OpenChildView>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603731B RID: 226075 RVA: 0x00E02E20 File Offset: 0x00E01020
		public UniTask OpenChildViewAsync(EPhantomArenaChildViewName viewName)
		{
			PhantomArenaRootViewBase<TViewModel>.<OpenChildViewAsync>d__17 <OpenChildViewAsync>d__;
			<OpenChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenChildViewAsync>d__.<>4__this = this;
			<OpenChildViewAsync>d__.viewName = viewName;
			<OpenChildViewAsync>d__.<>1__state = -1;
			<OpenChildViewAsync>d__.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<OpenChildViewAsync>d__17>(ref <OpenChildViewAsync>d__);
			return <OpenChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603731C RID: 226076 RVA: 0x00E02E6C File Offset: 0x00E0106C
		public void CloseCurChildView()
		{
			UiAsyncTask task = new UiAsyncTask("PhantomArenaRootViewBase", delegate()
			{
				PhantomArenaRootViewBase<TViewModel>.<<CloseCurChildView>b__18_0>d <<CloseCurChildView>b__18_0>d;
				<<CloseCurChildView>b__18_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<CloseCurChildView>b__18_0>d.<>4__this = this;
				<<CloseCurChildView>b__18_0>d.<>1__state = -1;
				<<CloseCurChildView>b__18_0>d.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<<CloseCurChildView>b__18_0>d>(ref <<CloseCurChildView>b__18_0>d);
				return <<CloseCurChildView>b__18_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603731D RID: 226077 RVA: 0x00E02E9C File Offset: 0x00E0109C
		[NullableContext(0)]
		public UniTask<bool> CloseCurChildViewAsync()
		{
			PhantomArenaRootViewBase<TViewModel>.<CloseCurChildViewAsync>d__19 <CloseCurChildViewAsync>d__;
			<CloseCurChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseCurChildViewAsync>d__.<>4__this = this;
			<CloseCurChildViewAsync>d__.<>1__state = -1;
			<CloseCurChildViewAsync>d__.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<CloseCurChildViewAsync>d__19>(ref <CloseCurChildViewAsync>d__);
			return <CloseCurChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603731E RID: 226078 RVA: 0x00E02EE0 File Offset: 0x00E010E0
		public void CloseChildView(PhantomArenaChildViewBase childView)
		{
			PhantomArenaRootViewBase<TViewModel>.<>c__DisplayClass20_0 CS$<>8__locals1 = new PhantomArenaRootViewBase<TViewModel>.<>c__DisplayClass20_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.childView = childView;
			UiAsyncTask task = new UiAsyncTask("PhantomArenaRootViewBase", delegate()
			{
				PhantomArenaRootViewBase<TViewModel>.<>c__DisplayClass20_0.<<CloseChildView>b__0>d <<CloseChildView>b__0>d;
				<<CloseChildView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<CloseChildView>b__0>d.<>4__this = CS$<>8__locals1;
				<<CloseChildView>b__0>d.<>1__state = -1;
				<<CloseChildView>b__0>d.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<>c__DisplayClass20_0.<<CloseChildView>b__0>d>(ref <<CloseChildView>b__0>d);
				return <<CloseChildView>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603731F RID: 226079 RVA: 0x00E02F24 File Offset: 0x00E01124
		[NullableContext(0)]
		public UniTask<bool> CloseChildViewAsync([Nullable(1)] PhantomArenaChildViewBase childView)
		{
			PhantomArenaRootViewBase<TViewModel>.<CloseChildViewAsync>d__21 <CloseChildViewAsync>d__;
			<CloseChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseChildViewAsync>d__.<>4__this = this;
			<CloseChildViewAsync>d__.childView = childView;
			<CloseChildViewAsync>d__.<>1__state = -1;
			<CloseChildViewAsync>d__.<>t__builder.Start<PhantomArenaRootViewBase<TViewModel>.<CloseChildViewAsync>d__21>(ref <CloseChildViewAsync>d__);
			return <CloseChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037320 RID: 226080 RVA: 0x00E02F6F File Offset: 0x00E0116F
		protected PhantomArenaChildViewBase GetCurChildView()
		{
			return this.ChildViewStack.Peek();
		}

		// Token: 0x06037321 RID: 226081 RVA: 0x00E02F7C File Offset: 0x00E0117C
		public void Back()
		{
			if (this.ChildViewStack.Size > 1)
			{
				this.CloseCurChildView();
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x0401FC13 RID: 130067
		public TViewModel ViewModel;

		// Token: 0x0401FC14 RID: 130068
		public int ActivityId;

		// Token: 0x0401FC15 RID: 130069
		[Nullable(2)]
		protected UUIItem ContentItem;

		// Token: 0x0401FC16 RID: 130070
		protected EPhantomArenaChildViewName? DefaultChildViewName;

		// Token: 0x0401FC17 RID: 130071
		private readonly Stack<PhantomArenaChildViewBase> ChildViewStack = new Stack<PhantomArenaChildViewBase>();

		// Token: 0x0401FC18 RID: 130072
		protected UiMask ViewMask = new UiMask();
	}
}
