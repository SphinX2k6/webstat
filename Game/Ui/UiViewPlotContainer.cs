using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049D6 RID: 18902
	[NullableContext(1)]
	[Nullable(0)]
	public class UiViewPlotContainer : UiViewContainer
	{
		// Token: 0x0603173D RID: 202557 RVA: 0x00C4DC3C File Offset: 0x00C4BE3C
		private void PushView(UiViewBase view)
		{
			this.Stack.Push(view);
		}

		// Token: 0x0603173E RID: 202558 RVA: 0x00C4DC4C File Offset: 0x00C4BE4C
		[NullableContext(2)]
		private UiViewBase PopView()
		{
			UiViewBase uiViewBase = this.Stack.Pop();
			if (uiViewBase == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.PlotContainer, ELogAuthor.XXJ, "PlotContainer_PopView 出栈失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return uiViewBase;
		}

		// Token: 0x0603173F RID: 202559 RVA: 0x00C4DC8C File Offset: 0x00C4BE8C
		private bool DeleteView(UiViewBase view)
		{
			bool flag = this.Stack.Delete(view);
			if (!flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PlotContainer;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "PlotContainer_DeleteView删除界面不在栈内";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", view.ViewInfo.Name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return flag;
		}

		// Token: 0x06031740 RID: 202560 RVA: 0x00C4DCE1 File Offset: 0x00C4BEE1
		public UiViewPlotContainer(global::Stack<UiViewBase> stack)
		{
			this.Stack = stack;
		}

		// Token: 0x17008424 RID: 33828
		// (get) Token: 0x06031741 RID: 202561 RVA: 0x00C4DCFB File Offset: 0x00C4BEFB
		private bool IsLock
		{
			get
			{
				return this.Operating;
			}
		}

		// Token: 0x06031742 RID: 202562 RVA: 0x00C4DD03 File Offset: 0x00C4BF03
		private void Lock()
		{
			this.Operating = true;
			this.LockOperationPromise = new CustomPromise();
		}

		// Token: 0x06031743 RID: 202563 RVA: 0x00C4DD17 File Offset: 0x00C4BF17
		private void Unlock(bool needHandlePending = true)
		{
			this.Operating = false;
			CustomPromise lockOperationPromise = this.LockOperationPromise;
			if (lockOperationPromise != null)
			{
				lockOperationPromise.SetResult();
			}
			this.LockOperationPromise = null;
			if (needHandlePending)
			{
				this.ProcessViewPending();
			}
		}

		// Token: 0x06031744 RID: 202564 RVA: 0x00C4DD44 File Offset: 0x00C4BF44
		private unsafe UiViewPending AddPendingView(UiViewBase view, EViewPendingType type)
		{
			UiViewPending uiViewPending = new UiViewPending(view, type, null);
			if (this.ViewPendingList.Count > 0)
			{
				UiViewPending uiViewPending2 = this.ViewPendingList[this.ViewPendingList.Count - 1];
				if (uiViewPending2.Equal(uiViewPending))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PlotContainer;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "界面缓存操做重复";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", view.ViewInfo.Name);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					CustomPromise<bool> executePromise = uiViewPending.ExecutePromise;
					if (executePromise != null)
					{
						executePromise.SetResult(true);
					}
					return uiViewPending;
				}
				if (uiViewPending2.IsPairWith(uiViewPending))
				{
					this.ViewPendingList.RemoveAt(this.ViewPendingList.Count - 1);
					Singleton<UiManager>.Instance.RemoveView(view.GetViewId());
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.PlotContainer;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "界面缓存操作成对, 自动移除上一个";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ViewName", view.ViewInfo.Name);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					CustomPromise<bool> executePromise2 = uiViewPending.ExecutePromise;
					if (executePromise2 != null)
					{
						executePromise2.SetResult(true);
					}
					return uiViewPending;
				}
			}
			this.ViewPendingList.Add(uiViewPending);
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.PlotContainer;
			ELogAuthor author3 = ELogAuthor.XXJ;
			string message3 = "缓存界面操作";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("界面", view.ViewInfo.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("操作类型", type);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return uiViewPending;
		}

		// Token: 0x06031745 RID: 202565 RVA: 0x00C4DED4 File Offset: 0x00C4C0D4
		private UniTask ProcessViewPending()
		{
			UiViewPlotContainer.<ProcessViewPending>d__13 <ProcessViewPending>d__;
			<ProcessViewPending>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessViewPending>d__.<>4__this = this;
			<ProcessViewPending>d__.<>1__state = -1;
			<ProcessViewPending>d__.<>t__builder.Start<UiViewPlotContainer.<ProcessViewPending>d__13>(ref <ProcessViewPending>d__);
			return <ProcessViewPending>d__.<>t__builder.Task;
		}

		// Token: 0x06031746 RID: 202566 RVA: 0x00C4DF18 File Offset: 0x00C4C118
		private UniTask OpenStackViewAsync(UiViewBase view, [Nullable(2)] UiViewBase lastView)
		{
			UiViewPlotContainer.<OpenStackViewAsync>d__14 <OpenStackViewAsync>d__;
			<OpenStackViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenStackViewAsync>d__.view = view;
			<OpenStackViewAsync>d__.lastView = lastView;
			<OpenStackViewAsync>d__.<>1__state = -1;
			<OpenStackViewAsync>d__.<>t__builder.Start<UiViewPlotContainer.<OpenStackViewAsync>d__14>(ref <OpenStackViewAsync>d__);
			return <OpenStackViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031747 RID: 202567 RVA: 0x00C4DF64 File Offset: 0x00C4C164
		private UniTask CloseViewInternal(UiViewBase view, [Nullable(2)] UiViewBase nextView)
		{
			UiViewPlotContainer.<CloseViewInternal>d__15 <CloseViewInternal>d__;
			<CloseViewInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseViewInternal>d__.<>4__this = this;
			<CloseViewInternal>d__.view = view;
			<CloseViewInternal>d__.nextView = nextView;
			<CloseViewInternal>d__.<>1__state = -1;
			<CloseViewInternal>d__.<>t__builder.Start<UiViewPlotContainer.<CloseViewInternal>d__15>(ref <CloseViewInternal>d__);
			return <CloseViewInternal>d__.<>t__builder.Task;
		}

		// Token: 0x06031748 RID: 202568 RVA: 0x00C4DFB8 File Offset: 0x00C4C1B8
		[NullableContext(0)]
		public override UniTask<bool> OpenViewAsync([Nullable(1)] UiViewBase view)
		{
			UiViewPlotContainer.<OpenViewAsync>d__16 <OpenViewAsync>d__;
			<OpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenViewAsync>d__.<>4__this = this;
			<OpenViewAsync>d__.view = view;
			<OpenViewAsync>d__.<>1__state = -1;
			<OpenViewAsync>d__.<>t__builder.Start<UiViewPlotContainer.<OpenViewAsync>d__16>(ref <OpenViewAsync>d__);
			return <OpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031749 RID: 202569 RVA: 0x00C4E004 File Offset: 0x00C4C204
		public override UniTask PreOpenViewAsync(UiViewBase view)
		{
			UiViewPlotContainer.<PreOpenViewAsync>d__17 <PreOpenViewAsync>d__;
			<PreOpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreOpenViewAsync>d__.view = view;
			<PreOpenViewAsync>d__.<>1__state = -1;
			<PreOpenViewAsync>d__.<>t__builder.Start<UiViewPlotContainer.<PreOpenViewAsync>d__17>(ref <PreOpenViewAsync>d__);
			return <PreOpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603174A RID: 202570 RVA: 0x00C4E048 File Offset: 0x00C4C248
		public override UniTask OpenViewAfterPreOpenedAsync(UiViewBase view)
		{
			UiViewPlotContainer.<OpenViewAfterPreOpenedAsync>d__18 <OpenViewAfterPreOpenedAsync>d__;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenViewAfterPreOpenedAsync>d__.view = view;
			<OpenViewAfterPreOpenedAsync>d__.<>1__state = -1;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder.Start<UiViewPlotContainer.<OpenViewAfterPreOpenedAsync>d__18>(ref <OpenViewAfterPreOpenedAsync>d__);
			return <OpenViewAfterPreOpenedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603174B RID: 202571 RVA: 0x00C4E08C File Offset: 0x00C4C28C
		public override UniTask CloseViewAsync(UiViewBase view)
		{
			UiViewPlotContainer.<CloseViewAsync>d__19 <CloseViewAsync>d__;
			<CloseViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseViewAsync>d__.<>4__this = this;
			<CloseViewAsync>d__.view = view;
			<CloseViewAsync>d__.<>1__state = -1;
			<CloseViewAsync>d__.<>t__builder.Start<UiViewPlotContainer.<CloseViewAsync>d__19>(ref <CloseViewAsync>d__);
			return <CloseViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603174C RID: 202572 RVA: 0x00C4E0D8 File Offset: 0x00C4C2D8
		public unsafe override void ClearContainer(bool isSeamlessTravel)
		{
			List<UiViewBase> list = new List<UiViewBase>();
			for (int i = this.ViewPendingList.Count - 1; i >= 0; i--)
			{
				UiViewBase view = this.ViewPendingList[i].View;
				view.IsExistInLeaveLevel = true;
				if (!view.ViewInfo.IsPermanent)
				{
					CustomPromise<bool> openPromise = view.OpenPromise;
					if (openPromise != null)
					{
						openPromise.SetResult(false);
					}
					Singleton<UiManager>.Instance.RemoveView(view.GetViewId());
					this.ViewPendingList.RemoveAt(this.ViewPendingList.Count - 1);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PlotContainer;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "[Clear] 清理缓存的界面数据";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", view.GetType().Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComponentId", view.ComponentId);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			list.Clear();
			foreach (UiViewBase uiViewBase in this.Stack)
			{
				uiViewBase.IsExistInLeaveLevel = true;
				if (!uiViewBase.ViewInfo.IsPermanent && (!isSeamlessTravel || !Singleton<UiModel>.Instance.SeamlessStackWhileList.Contains(uiViewBase.ViewInfo.Name)))
				{
					base.TryCatchViewDestroyCompatible(uiViewBase);
					list.Add(uiViewBase);
				}
			}
			foreach (UiViewBase view2 in list)
			{
				this.DeleteView(view2);
			}
			Singleton<Log>.Instance.Info(ELogModule.PlotContainer, ELogAuthor.XXJ, "ClearContainer 清栈", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0401C60B RID: 116235
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly global::Stack<UiViewBase> Stack;

		// Token: 0x0401C60C RID: 116236
		[Nullable(2)]
		private CustomPromise LockOperationPromise;

		// Token: 0x0401C60D RID: 116237
		private bool Operating;

		// Token: 0x0401C60E RID: 116238
		private readonly List<UiViewPending> ViewPendingList = new List<UiViewPending>();
	}
}
