using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065FB RID: 26107
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class PinballMainRootViewBase : UiViewBase
	{
		// Token: 0x06041390 RID: 267152 RVA: 0x010BAEFB File Offset: 0x010B90FB
		public PinballMainRootViewBase(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041391 RID: 267153 RVA: 0x010BAF1A File Offset: 0x010B911A
		protected override void OnBeforeCreate()
		{
			this.OnRegisterViewData();
			this.OnRegisterDefaultChildView();
		}

		// Token: 0x06041392 RID: 267154
		protected abstract void OnRegisterDefaultChildView();

		// Token: 0x06041393 RID: 267155
		protected abstract void OnRegisterContentItem();

		// Token: 0x06041394 RID: 267156
		protected abstract void OnRegisterViewData();

		// Token: 0x06041395 RID: 267157 RVA: 0x010BAF28 File Offset: 0x010B9128
		protected override UniTask OnBeforeStartAsync()
		{
			PinballMainRootViewBase.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballMainRootViewBase.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041396 RID: 267158 RVA: 0x010BAF6C File Offset: 0x010B916C
		protected override UniTask OnShowAsyncImplementImplement()
		{
			PinballMainRootViewBase.<OnShowAsyncImplementImplement>d__12 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<PinballMainRootViewBase.<OnShowAsyncImplementImplement>d__12>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06041397 RID: 267159 RVA: 0x010BAFB0 File Offset: 0x010B91B0
		protected override UniTask OnHideAsyncImplementImplement()
		{
			PinballMainRootViewBase.<OnHideAsyncImplementImplement>d__13 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<PinballMainRootViewBase.<OnHideAsyncImplementImplement>d__13>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06041398 RID: 267160 RVA: 0x010BAFF4 File Offset: 0x010B91F4
		protected override UniTask OnDestroyAsyncImplementImplement()
		{
			PinballMainRootViewBase.<OnDestroyAsyncImplementImplement>d__14 <OnDestroyAsyncImplementImplement>d__;
			<OnDestroyAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnDestroyAsyncImplementImplement>d__.<>4__this = this;
			<OnDestroyAsyncImplementImplement>d__.<>1__state = -1;
			<OnDestroyAsyncImplementImplement>d__.<>t__builder.Start<PinballMainRootViewBase.<OnDestroyAsyncImplementImplement>d__14>(ref <OnDestroyAsyncImplementImplement>d__);
			return <OnDestroyAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06041399 RID: 267161 RVA: 0x010BB038 File Offset: 0x010B9238
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<PinballMainChildViewBase> CreateChildViewAsync(string viewName)
		{
			PinballMainRootViewBase.<CreateChildViewAsync>d__15 <CreateChildViewAsync>d__;
			<CreateChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<PinballMainChildViewBase>.Create();
			<CreateChildViewAsync>d__.<>4__this = this;
			<CreateChildViewAsync>d__.viewName = viewName;
			<CreateChildViewAsync>d__.<>1__state = -1;
			<CreateChildViewAsync>d__.<>t__builder.Start<PinballMainRootViewBase.<CreateChildViewAsync>d__15>(ref <CreateChildViewAsync>d__);
			return <CreateChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604139A RID: 267162 RVA: 0x010BB084 File Offset: 0x010B9284
		public void OpenChildView(string viewName)
		{
			PinballMainRootViewBase.<>c__DisplayClass16_0 CS$<>8__locals1 = new PinballMainRootViewBase.<>c__DisplayClass16_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.viewName = viewName;
			UiAsyncTask task = new UiAsyncTask("PinballMainRootViewOpenChild", delegate()
			{
				PinballMainRootViewBase.<>c__DisplayClass16_0.<<OpenChildView>b__0>d <<OpenChildView>b__0>d;
				<<OpenChildView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OpenChildView>b__0>d.<>4__this = CS$<>8__locals1;
				<<OpenChildView>b__0>d.<>1__state = -1;
				<<OpenChildView>b__0>d.<>t__builder.Start<PinballMainRootViewBase.<>c__DisplayClass16_0.<<OpenChildView>b__0>d>(ref <<OpenChildView>b__0>d);
				return <<OpenChildView>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x0604139B RID: 267163 RVA: 0x010BB0CC File Offset: 0x010B92CC
		public UniTask OpenChildViewAsync(string viewName)
		{
			PinballMainRootViewBase.<OpenChildViewAsync>d__17 <OpenChildViewAsync>d__;
			<OpenChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenChildViewAsync>d__.<>4__this = this;
			<OpenChildViewAsync>d__.viewName = viewName;
			<OpenChildViewAsync>d__.<>1__state = -1;
			<OpenChildViewAsync>d__.<>t__builder.Start<PinballMainRootViewBase.<OpenChildViewAsync>d__17>(ref <OpenChildViewAsync>d__);
			return <OpenChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604139C RID: 267164 RVA: 0x010BB118 File Offset: 0x010B9318
		public void CloseCurChildView()
		{
			UiAsyncTask task = new UiAsyncTask("PinballMainRootViewCloseCurChild", delegate()
			{
				PinballMainRootViewBase.<<CloseCurChildView>b__18_0>d <<CloseCurChildView>b__18_0>d;
				<<CloseCurChildView>b__18_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<CloseCurChildView>b__18_0>d.<>4__this = this;
				<<CloseCurChildView>b__18_0>d.<>1__state = -1;
				<<CloseCurChildView>b__18_0>d.<>t__builder.Start<PinballMainRootViewBase.<<CloseCurChildView>b__18_0>d>(ref <<CloseCurChildView>b__18_0>d);
				return <<CloseCurChildView>b__18_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x0604139D RID: 267165 RVA: 0x010BB14C File Offset: 0x010B934C
		[NullableContext(0)]
		public UniTask<bool> CloseCurChildViewAsync()
		{
			PinballMainRootViewBase.<CloseCurChildViewAsync>d__19 <CloseCurChildViewAsync>d__;
			<CloseCurChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseCurChildViewAsync>d__.<>4__this = this;
			<CloseCurChildViewAsync>d__.<>1__state = -1;
			<CloseCurChildViewAsync>d__.<>t__builder.Start<PinballMainRootViewBase.<CloseCurChildViewAsync>d__19>(ref <CloseCurChildViewAsync>d__);
			return <CloseCurChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604139E RID: 267166 RVA: 0x010BB190 File Offset: 0x010B9390
		public void CloseChildView(PinballMainChildViewBase childView)
		{
			PinballMainRootViewBase.<>c__DisplayClass20_0 CS$<>8__locals1 = new PinballMainRootViewBase.<>c__DisplayClass20_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.childView = childView;
			UiAsyncTask task = new UiAsyncTask("PinballMainRootViewCloseChild", delegate()
			{
				PinballMainRootViewBase.<>c__DisplayClass20_0.<<CloseChildView>b__0>d <<CloseChildView>b__0>d;
				<<CloseChildView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<CloseChildView>b__0>d.<>4__this = CS$<>8__locals1;
				<<CloseChildView>b__0>d.<>1__state = -1;
				<<CloseChildView>b__0>d.<>t__builder.Start<PinballMainRootViewBase.<>c__DisplayClass20_0.<<CloseChildView>b__0>d>(ref <<CloseChildView>b__0>d);
				return <<CloseChildView>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x0604139F RID: 267167 RVA: 0x010BB1D8 File Offset: 0x010B93D8
		[NullableContext(0)]
		public UniTask<bool> CloseChildViewAsync([Nullable(1)] PinballMainChildViewBase childView)
		{
			PinballMainRootViewBase.<CloseChildViewAsync>d__21 <CloseChildViewAsync>d__;
			<CloseChildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseChildViewAsync>d__.<>4__this = this;
			<CloseChildViewAsync>d__.childView = childView;
			<CloseChildViewAsync>d__.<>1__state = -1;
			<CloseChildViewAsync>d__.<>t__builder.Start<PinballMainRootViewBase.<CloseChildViewAsync>d__21>(ref <CloseChildViewAsync>d__);
			return <CloseChildViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060413A0 RID: 267168 RVA: 0x010BB223 File Offset: 0x010B9423
		public int GetChildViewStackNum()
		{
			return this.ChildViewStack.Size;
		}

		// Token: 0x060413A1 RID: 267169 RVA: 0x010BB230 File Offset: 0x010B9430
		protected PinballMainChildViewBase GetCurChildView()
		{
			return this.ChildViewStack.Peek();
		}

		// Token: 0x060413A2 RID: 267170 RVA: 0x010BB240 File Offset: 0x010B9440
		public void Back()
		{
			if (this.ChildViewStack.Size > 1)
			{
				this.CloseCurChildView();
				return;
			}
			IPinballMainRootViewOpenParam pinballMainRootViewOpenParam = this.OpenParam as IPinballMainRootViewOpenParam;
			if (pinballMainRootViewOpenParam == null || !pinballMainRootViewOpenParam.IsFromInstanceDungeon.GetValueOrDefault())
			{
				base.CloseMe(null);
				return;
			}
			PinballController instance = ControllerBase<PinballController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.OpenConfirmBackWorld();
		}

		// Token: 0x060413A3 RID: 267171 RVA: 0x010BB29C File Offset: 0x010B949C
		public void PlaySequenceByName(string sequenceName)
		{
			this.UiViewSequence.StopSequenceByKey(sequenceName, false, false);
			this.UiViewSequence.PlaySequence(sequenceName, false, null);
		}

		// Token: 0x060413A4 RID: 267172 RVA: 0x010BB2D0 File Offset: 0x010B94D0
		public UniTask PlaySequenceByNameAsync(string sequenceName)
		{
			PinballMainRootViewBase.<PlaySequenceByNameAsync>d__26 <PlaySequenceByNameAsync>d__;
			<PlaySequenceByNameAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceByNameAsync>d__.<>4__this = this;
			<PlaySequenceByNameAsync>d__.sequenceName = sequenceName;
			<PlaySequenceByNameAsync>d__.<>1__state = -1;
			<PlaySequenceByNameAsync>d__.<>t__builder.Start<PinballMainRootViewBase.<PlaySequenceByNameAsync>d__26>(ref <PlaySequenceByNameAsync>d__);
			return <PlaySequenceByNameAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060413A5 RID: 267173 RVA: 0x010BB31B File Offset: 0x010B951B
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (this.ChildViewStack.Size == 0)
			{
				return null;
			}
			return this.GetCurChildView().GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0402482B RID: 149547
		[Nullable(2)]
		public object ViewModel;

		// Token: 0x0402482C RID: 149548
		public int ActivityId;

		// Token: 0x0402482D RID: 149549
		[Nullable(2)]
		protected UUIItem ContentItem;

		// Token: 0x0402482E RID: 149550
		[Nullable(2)]
		protected string DefaultChildViewName;

		// Token: 0x0402482F RID: 149551
		private readonly Stack<PinballMainChildViewBase> ChildViewStack = new Stack<PinballMainChildViewBase>();

		// Token: 0x04024830 RID: 149552
		protected UiMask ViewMask = new UiMask();
	}
}
