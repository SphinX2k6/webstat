using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049D4 RID: 18900
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class UiViewContainer
	{
		// Token: 0x06031728 RID: 202536 RVA: 0x00C4D784 File Offset: 0x00C4B984
		protected UniTask OpenViewImplementAsync(UiViewBase view)
		{
			UiViewContainer.<OpenViewImplementAsync>d__1 <OpenViewImplementAsync>d__;
			<OpenViewImplementAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenViewImplementAsync>d__.<>4__this = this;
			<OpenViewImplementAsync>d__.view = view;
			<OpenViewImplementAsync>d__.<>1__state = -1;
			<OpenViewImplementAsync>d__.<>t__builder.Start<UiViewContainer.<OpenViewImplementAsync>d__1>(ref <OpenViewImplementAsync>d__);
			return <OpenViewImplementAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031729 RID: 202537 RVA: 0x00C4D7D0 File Offset: 0x00C4B9D0
		[NullableContext(0)]
		protected UniTask<bool> CloseViewImplementAsync([Nullable(1)] UiViewBase view)
		{
			UiViewContainer.<CloseViewImplementAsync>d__2 <CloseViewImplementAsync>d__;
			<CloseViewImplementAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CloseViewImplementAsync>d__.view = view;
			<CloseViewImplementAsync>d__.<>1__state = -1;
			<CloseViewImplementAsync>d__.<>t__builder.Start<UiViewContainer.<CloseViewImplementAsync>d__2>(ref <CloseViewImplementAsync>d__);
			return <CloseViewImplementAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603172A RID: 202538 RVA: 0x00C4D813 File Offset: 0x00C4BA13
		protected bool IsIgnoreOpenViewMask(UiViewBase view)
		{
			return (Singleton<UiConfig>.Instance.TryGetViewInfo(view.ViewInfo.Name).Type & (ELayerType.Float | ELayerType.Guide)) > (ELayerType)0;
		}

		// Token: 0x0603172B RID: 202539 RVA: 0x00C4D838 File Offset: 0x00C4BA38
		protected void OnContainerOpenView(UiViewBase view)
		{
			UiPopViewData uiPopViewData = view.OpenParam as UiPopViewData;
			if (uiPopViewData != null && !uiPopViewData.NotAddChildToTopStackView)
			{
				UiViewBase uiViewBase = Singleton<UiModel>.Instance.NormalStack.Peek();
				if (uiViewBase != null)
				{
					uiViewBase.AddChild(view);
				}
			}
		}

		// Token: 0x0603172C RID: 202540 RVA: 0x00C4D878 File Offset: 0x00C4BA78
		protected unsafe void TryCatchViewDestroyCompatible(UiViewBase view)
		{
			try
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiViewContainer;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[Clear] 尝试执行销毁的界面";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", view.GetType().Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComponentId", view.ComponentId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				view.ClearAsync();
			}
			catch (Exception ex)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiViewContainer;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "界面同步关闭异常,业务变量可能未初始化完成,需要关注";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603172D RID: 202541
		[NullableContext(0)]
		public abstract UniTask<bool> OpenViewAsync([Nullable(1)] UiViewBase view);

		// Token: 0x0603172E RID: 202542
		public abstract UniTask PreOpenViewAsync(UiViewBase view);

		// Token: 0x0603172F RID: 202543
		public abstract UniTask OpenViewAfterPreOpenedAsync(UiViewBase view);

		// Token: 0x06031730 RID: 202544
		public abstract UniTask CloseViewAsync(UiViewBase view);

		// Token: 0x06031731 RID: 202545
		public abstract void ClearContainer(bool isSeamlessTravel);

		// Token: 0x06031732 RID: 202546 RVA: 0x00C4D93C File Offset: 0x00C4BB3C
		public virtual UniTask BeforeClearContainerAsync(bool isSeamlessTravel)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0401C608 RID: 116232
		protected UiMask OpenViewMask = new UiMask();
	}
}
