using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049D8 RID: 18904
	[NullableContext(1)]
	[Nullable(0)]
	public class UiViewStackContainer : UiViewContainer
	{
		// Token: 0x06031753 RID: 202579 RVA: 0x00C4E4BB File Offset: 0x00C4C6BB
		public UiViewStackContainer(global::Stack<UiViewBase> stack)
		{
			this.Stack = stack;
		}

		// Token: 0x17008425 RID: 33829
		// (get) Token: 0x06031754 RID: 202580 RVA: 0x00C4E4F7 File Offset: 0x00C4C6F7
		private bool IsLock
		{
			get
			{
				return this.Operating;
			}
		}

		// Token: 0x06031755 RID: 202581 RVA: 0x00C4E4FF File Offset: 0x00C4C6FF
		private void Lock(string lockReason = "")
		{
			this.Operating = true;
			this.LockOperationPromise = new CustomPromise();
		}

		// Token: 0x06031756 RID: 202582 RVA: 0x00C4E513 File Offset: 0x00C4C713
		private void Unlock(string unlockReason = "", bool needHandlePending = true)
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

		// Token: 0x06031757 RID: 202583 RVA: 0x00C4E540 File Offset: 0x00C4C740
		private void PushView(UiViewBase view)
		{
			this.Stack.Push(view);
			EUiViewName name = view.ViewInfo.Name;
			HashSet<UiViewBase> hashSet;
			if (!this.NameToViewSetMap.TryGetValue(name, out hashSet))
			{
				hashSet = new HashSet<UiViewBase>();
				this.NameToViewSetMap[name] = hashSet;
			}
			hashSet.Add(view);
		}

		// Token: 0x06031758 RID: 202584 RVA: 0x00C4E590 File Offset: 0x00C4C790
		private void PopView()
		{
			UiViewBase uiViewBase = this.Stack.Pop();
			if (uiViewBase == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.StackContainer, ELogAuthor.TL, "StackContainer_PopView 出栈失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EUiViewName name = uiViewBase.ViewInfo.Name;
			HashSet<UiViewBase> hashSet;
			if (this.NameToViewSetMap.TryGetValue(name, out hashSet))
			{
				hashSet.Remove(uiViewBase);
				if (hashSet.Count <= 0)
				{
					this.NameToViewSetMap.Remove(name);
				}
			}
		}

		// Token: 0x06031759 RID: 202585 RVA: 0x00C4E608 File Offset: 0x00C4C808
		private bool DeleteView(UiViewBase view)
		{
			EUiViewName name = view.ViewInfo.Name;
			HashSet<UiViewBase> hashSet;
			if (this.NameToViewSetMap.TryGetValue(name, out hashSet))
			{
				hashSet.Remove(view);
				if (hashSet.Count <= 0)
				{
					this.NameToViewSetMap.Remove(name);
				}
			}
			bool flag = this.Stack.Delete(view);
			if (!flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.StackContainer;
				ELogAuthor author = ELogAuthor.TL;
				string message = "StackContainer_DeleteView删除界面不在栈内";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", view.ViewInfo.Name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return flag;
		}

		// Token: 0x0603175A RID: 202586 RVA: 0x00C4E698 File Offset: 0x00C4C898
		private UniTask ProcessViewPending()
		{
			UiViewStackContainer.<ProcessViewPending>d__13 <ProcessViewPending>d__;
			<ProcessViewPending>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessViewPending>d__.<>4__this = this;
			<ProcessViewPending>d__.<>1__state = -1;
			<ProcessViewPending>d__.<>t__builder.Start<UiViewStackContainer.<ProcessViewPending>d__13>(ref <ProcessViewPending>d__);
			return <ProcessViewPending>d__.<>t__builder.Task;
		}

		// Token: 0x0603175B RID: 202587 RVA: 0x00C4E6DC File Offset: 0x00C4C8DC
		[NullableContext(0)]
		public override UniTask<bool> OpenViewAsync([Nullable(1)] UiViewBase view)
		{
			UiViewStackContainer.<OpenViewAsync>d__14 <OpenViewAsync>d__;
			<OpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenViewAsync>d__.<>4__this = this;
			<OpenViewAsync>d__.view = view;
			<OpenViewAsync>d__.<>1__state = -1;
			<OpenViewAsync>d__.<>t__builder.Start<UiViewStackContainer.<OpenViewAsync>d__14>(ref <OpenViewAsync>d__);
			return <OpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603175C RID: 202588 RVA: 0x00C4E728 File Offset: 0x00C4C928
		public override UniTask PreOpenViewAsync(UiViewBase view)
		{
			UiViewStackContainer.<PreOpenViewAsync>d__15 <PreOpenViewAsync>d__;
			<PreOpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreOpenViewAsync>d__.view = view;
			<PreOpenViewAsync>d__.<>1__state = -1;
			<PreOpenViewAsync>d__.<>t__builder.Start<UiViewStackContainer.<PreOpenViewAsync>d__15>(ref <PreOpenViewAsync>d__);
			return <PreOpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603175D RID: 202589 RVA: 0x00C4E76C File Offset: 0x00C4C96C
		public override UniTask OpenViewAfterPreOpenedAsync(UiViewBase view)
		{
			UiViewStackContainer.<OpenViewAfterPreOpenedAsync>d__16 <OpenViewAfterPreOpenedAsync>d__;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenViewAfterPreOpenedAsync>d__.<>4__this = this;
			<OpenViewAfterPreOpenedAsync>d__.view = view;
			<OpenViewAfterPreOpenedAsync>d__.<>1__state = -1;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder.Start<UiViewStackContainer.<OpenViewAfterPreOpenedAsync>d__16>(ref <OpenViewAfterPreOpenedAsync>d__);
			return <OpenViewAfterPreOpenedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603175E RID: 202590 RVA: 0x00C4E7B8 File Offset: 0x00C4C9B8
		private UniTask OpenStackViewAsync(UiViewBase view, [Nullable(2)] UiViewBase lastView)
		{
			UiViewStackContainer.<OpenStackViewAsync>d__17 <OpenStackViewAsync>d__;
			<OpenStackViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenStackViewAsync>d__.<>4__this = this;
			<OpenStackViewAsync>d__.view = view;
			<OpenStackViewAsync>d__.lastView = lastView;
			<OpenStackViewAsync>d__.<>1__state = -1;
			<OpenStackViewAsync>d__.<>t__builder.Start<UiViewStackContainer.<OpenStackViewAsync>d__17>(ref <OpenStackViewAsync>d__);
			return <OpenStackViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603175F RID: 202591 RVA: 0x00C4E80C File Offset: 0x00C4CA0C
		public override UniTask CloseViewAsync(UiViewBase view)
		{
			UiViewStackContainer.<CloseViewAsync>d__18 <CloseViewAsync>d__;
			<CloseViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseViewAsync>d__.<>4__this = this;
			<CloseViewAsync>d__.view = view;
			<CloseViewAsync>d__.<>1__state = -1;
			<CloseViewAsync>d__.<>t__builder.Start<UiViewStackContainer.<CloseViewAsync>d__18>(ref <CloseViewAsync>d__);
			return <CloseViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031760 RID: 202592 RVA: 0x00C4E858 File Offset: 0x00C4CA58
		public UniTask CloseAndOpenNewAsync(UiViewBase closeView, UiViewBase view)
		{
			UiViewStackContainer.<CloseAndOpenNewAsync>d__19 <CloseAndOpenNewAsync>d__;
			<CloseAndOpenNewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseAndOpenNewAsync>d__.<>4__this = this;
			<CloseAndOpenNewAsync>d__.closeView = closeView;
			<CloseAndOpenNewAsync>d__.view = view;
			<CloseAndOpenNewAsync>d__.<>1__state = -1;
			<CloseAndOpenNewAsync>d__.<>t__builder.Start<UiViewStackContainer.<CloseAndOpenNewAsync>d__19>(ref <CloseAndOpenNewAsync>d__);
			return <CloseAndOpenNewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031761 RID: 202593 RVA: 0x00C4E8AC File Offset: 0x00C4CAAC
		public UniTask ResetToViewAsync(UiViewBase targetView)
		{
			UiViewStackContainer.<ResetToViewAsync>d__20 <ResetToViewAsync>d__;
			<ResetToViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetToViewAsync>d__.<>4__this = this;
			<ResetToViewAsync>d__.targetView = targetView;
			<ResetToViewAsync>d__.<>1__state = -1;
			<ResetToViewAsync>d__.<>t__builder.Start<UiViewStackContainer.<ResetToViewAsync>d__20>(ref <ResetToViewAsync>d__);
			return <ResetToViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031762 RID: 202594 RVA: 0x00C4E8F8 File Offset: 0x00C4CAF8
		private UniTask CloseViewInternal(UiViewBase view, [Nullable(2)] UiViewBase nextView, bool isCloseAndOpen = false)
		{
			UiViewStackContainer.<CloseViewInternal>d__21 <CloseViewInternal>d__;
			<CloseViewInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseViewInternal>d__.<>4__this = this;
			<CloseViewInternal>d__.view = view;
			<CloseViewInternal>d__.nextView = nextView;
			<CloseViewInternal>d__.isCloseAndOpen = isCloseAndOpen;
			<CloseViewInternal>d__.<>1__state = -1;
			<CloseViewInternal>d__.<>t__builder.Start<UiViewStackContainer.<CloseViewInternal>d__21>(ref <CloseViewInternal>d__);
			return <CloseViewInternal>d__.<>t__builder.Task;
		}

		// Token: 0x06031763 RID: 202595 RVA: 0x00C4E954 File Offset: 0x00C4CB54
		public UniTask CloseHistoryRingViewAsync(EUiViewName viewName)
		{
			UiViewStackContainer.<CloseHistoryRingViewAsync>d__22 <CloseHistoryRingViewAsync>d__;
			<CloseHistoryRingViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseHistoryRingViewAsync>d__.<>4__this = this;
			<CloseHistoryRingViewAsync>d__.viewName = viewName;
			<CloseHistoryRingViewAsync>d__.<>1__state = -1;
			<CloseHistoryRingViewAsync>d__.<>t__builder.Start<UiViewStackContainer.<CloseHistoryRingViewAsync>d__22>(ref <CloseHistoryRingViewAsync>d__);
			return <CloseHistoryRingViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031764 RID: 202596 RVA: 0x00C4E9A0 File Offset: 0x00C4CBA0
		private void PushCameraHandle(UiViewBase view, bool bBlend = true)
		{
			IUiCameraBehavior uiCameraBehavior = view as IUiCameraBehavior;
			if (uiCameraBehavior != null)
			{
				uiCameraBehavior.PushCameraHandle(view.ViewInfo.Name, view.GetViewId(), bBlend);
				return;
			}
			ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle(view.ViewInfo.Name, new int?(view.GetViewId()), bBlend);
		}

		// Token: 0x06031765 RID: 202597 RVA: 0x00C4E9F4 File Offset: 0x00C4CBF4
		private void PopCameraHandle(UiViewBase view, UiViewInfo stackTopInfo, bool popOrDelete = true)
		{
			IUiCameraBehavior uiCameraBehavior = view as IUiCameraBehavior;
			if (uiCameraBehavior != null)
			{
				uiCameraBehavior.PopCameraHandle(view.ViewInfo.Name, stackTopInfo, view.GetViewId(), popOrDelete);
				return;
			}
			ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle(view.ViewInfo.Name, stackTopInfo, view.GetViewId(), popOrDelete);
		}

		// Token: 0x06031766 RID: 202598 RVA: 0x00C4EA42 File Offset: 0x00C4CC42
		private bool CheckContainerHasSameView(EUiViewName viewName)
		{
			return this.NameToViewSetMap.ContainsKey(viewName);
		}

		// Token: 0x06031767 RID: 202599 RVA: 0x00C4EA50 File Offset: 0x00C4CC50
		public override void ClearContainer(bool isSeamlessTravel)
		{
			List<UiViewBase> list = new List<UiViewBase>();
			foreach (UiViewBase uiViewBase in this.Stack)
			{
				uiViewBase.IsExistInLeaveLevel = true;
				if (!uiViewBase.ViewInfo.IsPermanent && (!isSeamlessTravel || !Singleton<UiModel>.Instance.SeamlessStackWhileList.Contains(uiViewBase.ViewInfo.Name)))
				{
					base.TryCatchViewDestroyCompatible(uiViewBase);
					list.Add(uiViewBase);
				}
			}
			foreach (UiViewBase view in list)
			{
				this.DeleteView(view);
			}
			Singleton<Log>.Instance.Info(ELogModule.StackContainer, ELogAuthor.TL, "ClearContainer 清栈", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06031768 RID: 202600 RVA: 0x00C4EB40 File Offset: 0x00C4CD40
		public override UniTask BeforeClearContainerAsync(bool isSeamlessTravel)
		{
			UiViewStackContainer.<BeforeClearContainerAsync>d__27 <BeforeClearContainerAsync>d__;
			<BeforeClearContainerAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<BeforeClearContainerAsync>d__.<>4__this = this;
			<BeforeClearContainerAsync>d__.isSeamlessTravel = isSeamlessTravel;
			<BeforeClearContainerAsync>d__.<>1__state = -1;
			<BeforeClearContainerAsync>d__.<>t__builder.Start<UiViewStackContainer.<BeforeClearContainerAsync>d__27>(ref <BeforeClearContainerAsync>d__);
			return <BeforeClearContainerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031769 RID: 202601 RVA: 0x00C4EB8C File Offset: 0x00C4CD8C
		public UniTask HideViewByPlot()
		{
			UiViewStackContainer.<HideViewByPlot>d__28 <HideViewByPlot>d__;
			<HideViewByPlot>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HideViewByPlot>d__.<>4__this = this;
			<HideViewByPlot>d__.<>1__state = -1;
			<HideViewByPlot>d__.<>t__builder.Start<UiViewStackContainer.<HideViewByPlot>d__28>(ref <HideViewByPlot>d__);
			return <HideViewByPlot>d__.<>t__builder.Task;
		}

		// Token: 0x0603176A RID: 202602 RVA: 0x00C4EBD0 File Offset: 0x00C4CDD0
		public UniTask ShowViewByPlot(Func<UniTask> destroyOtherView = null)
		{
			UiViewStackContainer.<ShowViewByPlot>d__29 <ShowViewByPlot>d__;
			<ShowViewByPlot>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowViewByPlot>d__.<>4__this = this;
			<ShowViewByPlot>d__.destroyOtherView = destroyOtherView;
			<ShowViewByPlot>d__.<>1__state = -1;
			<ShowViewByPlot>d__.<>t__builder.Start<UiViewStackContainer.<ShowViewByPlot>d__29>(ref <ShowViewByPlot>d__);
			return <ShowViewByPlot>d__.<>t__builder.Task;
		}

		// Token: 0x0603176B RID: 202603 RVA: 0x00C4EC1C File Offset: 0x00C4CE1C
		public UniTask WaitSwitchToPlotPending()
		{
			UiViewStackContainer.<WaitSwitchToPlotPending>d__30 <WaitSwitchToPlotPending>d__;
			<WaitSwitchToPlotPending>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitSwitchToPlotPending>d__.<>4__this = this;
			<WaitSwitchToPlotPending>d__.<>1__state = -1;
			<WaitSwitchToPlotPending>d__.<>t__builder.Start<UiViewStackContainer.<WaitSwitchToPlotPending>d__30>(ref <WaitSwitchToPlotPending>d__);
			return <WaitSwitchToPlotPending>d__.<>t__builder.Task;
		}

		// Token: 0x0603176C RID: 202604 RVA: 0x00C4EC5F File Offset: 0x00C4CE5F
		public void TryUnlock()
		{
			if (this.Operating)
			{
				this.Unlock("TryUnlock", true);
			}
		}

		// Token: 0x0603176D RID: 202605 RVA: 0x00C4EC78 File Offset: 0x00C4CE78
		private unsafe UiViewPending AddPendingView(UiViewBase view, EViewPendingType type, [Nullable(2)] UiViewBase nextView = null)
		{
			UiViewPending uiViewPending = new UiViewPending(view, type, nextView);
			if (this.ViewPendingList.Count > 0)
			{
				List<UiViewPending> viewPendingList = this.ViewPendingList;
				UiViewPending uiViewPending2 = viewPendingList[viewPendingList.Count - 1];
				if (uiViewPending2.Equal(uiViewPending))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.StackContainer;
					ELogAuthor author = ELogAuthor.TL;
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
					ELogModule module2 = ELogModule.StackContainer;
					ELogAuthor author2 = ELogAuthor.TL;
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
			ELogModule module3 = ELogModule.StackContainer;
			ELogAuthor author3 = ELogAuthor.TL;
			string message3 = "缓存界面操作";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("界面", view.ViewInfo.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("操作类型", type);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return uiViewPending;
		}

		// Token: 0x0603176E RID: 202606 RVA: 0x00C4EE04 File Offset: 0x00C4D004
		private void DeleteDoublyLinkData(DoublyLinkedNode<UiViewBase> node)
		{
			if (node == null)
			{
				return;
			}
			this.DoublyLinked.Remove(node);
			this.DoublyLinkNodeMap.Remove(node.Element);
			if (this.DoublyLinkNodeMap.Count == 0)
			{
				Singleton<UiModel>.Instance.InNormalQueue = false;
				Singleton<EventSystem>.Instance.Emit(EEventName.ExitNormalQueueState);
			}
		}

		// Token: 0x0603176F RID: 202607 RVA: 0x00C4EE5C File Offset: 0x00C4D05C
		private void AddDoubleLinkData(UiViewBase view)
		{
			DoublyLinkedNode<UiViewBase> doublyLinkedNode = this.DoublyLinked.Find((DoublyLinkedNode<UiViewBase> node) => node.Element == null || view.ViewInfo.SortIndex < node.Element.ViewInfo.SortIndex);
			DoublyLinkedNode<UiViewBase> value;
			if (doublyLinkedNode.Pre != null)
			{
				value = this.DoublyLinked.Insert(view, doublyLinkedNode.Pre);
			}
			else
			{
				value = this.DoublyLinked.AddTail(view);
			}
			this.DoublyLinkNodeMap[view] = value;
			Singleton<UiModel>.Instance.InNormalQueue = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.StackContainer;
			ELogAuthor author = ELogAuthor.TL;
			string message = "缓存界面进入等待队列";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", view.ViewInfo.Name);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06031770 RID: 202608 RVA: 0x00C4EF1F File Offset: 0x00C4D11F
		public bool IsViewPendingListEmpty()
		{
			return this.ViewPendingList.Count == 0;
		}

		// Token: 0x06031771 RID: 202609 RVA: 0x00C4EF30 File Offset: 0x00C4D130
		private bool CheckMainViewAtBottom(UiViewBase view)
		{
			return view.ViewInfo.GetContainerLayerType() != ELayerType.Normal || this.Stack.Size >= 1 || (view.ViewInfo.Name == Singleton<UiModel>.Instance.MainViewName || Singleton<UiModel>.Instance.NormalStackBottomWhiteSet.Contains(view.ViewInfo.Name));
		}

		// Token: 0x0401C610 RID: 116240
		private readonly global::Stack<UiViewBase> Stack;

		// Token: 0x0401C611 RID: 116241
		private readonly Dictionary<EUiViewName, HashSet<UiViewBase>> NameToViewSetMap = new Dictionary<EUiViewName, HashSet<UiViewBase>>();

		// Token: 0x0401C612 RID: 116242
		private bool Operating;

		// Token: 0x0401C613 RID: 116243
		[Nullable(2)]
		private CustomPromise ResetToViewPromise;

		// Token: 0x0401C614 RID: 116244
		[Nullable(2)]
		private CustomPromise LockOperationPromise;

		// Token: 0x0401C615 RID: 116245
		private List<UiViewPending> ViewPendingList = new List<UiViewPending>();

		// Token: 0x0401C616 RID: 116246
		private readonly DoublyLinkedList<UiViewBase> DoublyLinked = new DoublyLinkedList<UiViewBase>(null);

		// Token: 0x0401C617 RID: 116247
		private readonly Dictionary<UiViewBase, DoublyLinkedNode<UiViewBase>> DoublyLinkNodeMap = new Dictionary<UiViewBase, DoublyLinkedNode<UiViewBase>>();
	}
}
