using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C78 RID: 19576
	[NullableContext(1)]
	[Nullable(0)]
	public class LoopScrollView<TProxy, [Nullable(2)] TData> : IGridPreserver where TProxy : class, IGridProxy<TData>
	{
		// Token: 0x1700878F RID: 34703
		// (get) Token: 0x0603301E RID: 208926 RVA: 0x00CC6777 File Offset: 0x00CC4977
		private int DisplayGridNum
		{
			get
			{
				if (this.IsEmpty)
				{
					return 0;
				}
				return this.EndGridIndex - this.StartGridIndex + 1;
			}
		}

		// Token: 0x17008790 RID: 34704
		// (get) Token: 0x0603301F RID: 208927 RVA: 0x00CC6792 File Offset: 0x00CC4992
		// (set) Token: 0x06033020 RID: 208928 RVA: 0x00CC679A File Offset: 0x00CC499A
		public int StartGridIndex
		{
			get
			{
				return this.PrivateStartGridIndex;
			}
			set
			{
				this.PrivateStartGridIndex = value;
			}
		}

		// Token: 0x17008791 RID: 34705
		// (get) Token: 0x06033021 RID: 208929 RVA: 0x00CC67A3 File Offset: 0x00CC49A3
		// (set) Token: 0x06033022 RID: 208930 RVA: 0x00CC67AB File Offset: 0x00CC49AB
		public int EndGridIndex
		{
			get
			{
				return this.PrivateEndGridIndex;
			}
			set
			{
				this.PrivateEndGridIndex = value;
			}
		}

		// Token: 0x17008792 RID: 34706
		// (get) Token: 0x06033023 RID: 208931 RVA: 0x00CC67B4 File Offset: 0x00CC49B4
		private bool IsEmpty
		{
			get
			{
				return this.EndGridIndex == -1 && this.StartGridIndex == -1;
			}
		}

		// Token: 0x17008793 RID: 34707
		// (get) Token: 0x06033024 RID: 208932 RVA: 0x00CC67CA File Offset: 0x00CC49CA
		public bool DataInited
		{
			get
			{
				return this.DataInitedInternal;
			}
		}

		// Token: 0x17008794 RID: 34708
		// (get) Token: 0x06033025 RID: 208933 RVA: 0x00CC67D2 File Offset: 0x00CC49D2
		private bool IsLock
		{
			get
			{
				return this.Operating;
			}
		}

		// Token: 0x06033026 RID: 208934 RVA: 0x00CC67DA File Offset: 0x00CC49DA
		private void Lock()
		{
			this.Operating = true;
		}

		// Token: 0x06033027 RID: 208935 RVA: 0x00CC67E4 File Offset: 0x00CC49E4
		private void Unlock()
		{
			this.Operating = false;
			if (this.OperationQueue.Size > 0)
			{
				OperationParam<TData> operationParam = this.OperationQueue.Pop();
				this.RefreshByData(operationParam.Data, operationParam.KeepContentPosition, operationParam.CallBack, operationParam.PlayGridAnim);
			}
		}

		// Token: 0x06033028 RID: 208936 RVA: 0x00CC6830 File Offset: 0x00CC4A30
		public LoopScrollView(UUILoopScrollViewComponent scrollView, [Nullable(2)] AUIBaseActor gridActor, Func<TProxy> gridProxyCreateFunction, bool isAsync = false)
		{
			if (gridActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LoopScrollView, ELogAuthor.TL, "设置格子模板错误，grid为空!", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			gridActor.GetUIItem().SetUIActive(false);
			scrollView.SetTickableWhenPaused(true);
			AUIBaseActor auibaseActor = scrollView.GetOwner() as AUIBaseActor;
			if (auibaseActor != null)
			{
				auibaseActor.OnPreDestroyed.Add(new Action<AActor>(this.OnDestroy));
			}
			if (isAsync)
			{
				scrollView.OnGridCreate.Bind(new Action<int, AUIBaseActor>(this.OnGridCreateAsync));
			}
			else
			{
				scrollView.OnGridCreate.Bind(new Action<int, AUIBaseActor>(this.OnGridCreate));
			}
			scrollView.OnGridsUpdate.Bind(new Action<int, int>(this.OnGridsUpdate));
			this.TargetScroll = scrollView;
			this.TemplateGridActor = gridActor;
			this.Delegate = new ScrollViewDelegate<TProxy, TData>(gridProxyCreateFunction);
			this.GridsController = new InTurnGridAppearAnimation(this);
			this.GridsController.RegisterAnimController();
		}

		// Token: 0x06033029 RID: 208937 RVA: 0x00CC6945 File Offset: 0x00CC4B45
		public int GetDisplayGridNum()
		{
			return this.DisplayGridNum;
		}

		// Token: 0x0603302A RID: 208938 RVA: 0x00CC694D File Offset: 0x00CC4B4D
		public int GetPreservedGridNum()
		{
			UUILoopScrollViewComponent targetScroll = this.TargetScroll;
			if (targetScroll == null)
			{
				return 0;
			}
			return targetScroll.GridArray.Num();
		}

		// Token: 0x0603302B RID: 208939 RVA: 0x00CC6965 File Offset: 0x00CC4B65
		public int GetDisplayGridStartIndex()
		{
			return this.StartGridIndex;
		}

		// Token: 0x0603302C RID: 208940 RVA: 0x00CC696D File Offset: 0x00CC4B6D
		public int GetDisplayGridEndIndex()
		{
			return this.EndGridIndex;
		}

		// Token: 0x0603302D RID: 208941 RVA: 0x00CC6975 File Offset: 0x00CC4B75
		public float GetGridAnimationInterval()
		{
			return this.TargetScroll.GetGridAnimationInterval();
		}

		// Token: 0x0603302E RID: 208942 RVA: 0x00CC6982 File Offset: 0x00CC4B82
		public float GetGridAnimationStartTime()
		{
			return this.TargetScroll.GetGridAnimationStartTime();
		}

		// Token: 0x0603302F RID: 208943 RVA: 0x00CC698F File Offset: 0x00CC4B8F
		public void NotifyAnimationStart()
		{
			this.TargetScroll.SetInAnimation(true);
		}

		// Token: 0x06033030 RID: 208944 RVA: 0x00CC699D File Offset: 0x00CC4B9D
		public void NotifyAnimationEnd()
		{
			this.TargetScroll.SetInAnimation(false);
			Action animFinishDelegate = this.AnimFinishDelegate;
			if (animFinishDelegate == null)
			{
				return;
			}
			animFinishDelegate();
		}

		// Token: 0x06033031 RID: 208945 RVA: 0x00CC69BB File Offset: 0x00CC4BBB
		public void SetAnimFinishDelegate(Action @delegate)
		{
			this.AnimFinishDelegate = @delegate;
		}

		// Token: 0x06033032 RID: 208946 RVA: 0x00CC69C4 File Offset: 0x00CC4BC4
		[NullableContext(2)]
		public UUIItem GetGrid(int gridIndex)
		{
			AUIBaseActor grid = this.TargetScroll.GetGrid(gridIndex);
			if (grid == null)
			{
				return null;
			}
			return grid.GetUIItem();
		}

		// Token: 0x06033033 RID: 208947 RVA: 0x00CC69E0 File Offset: 0x00CC4BE0
		[NullableContext(2)]
		public UUIItem GetGridByDisplayIndex(int displayIndex)
		{
			if (this.TargetScroll.GridArray.Num() <= 0)
			{
				return null;
			}
			TWeakObjectPtr<AUIBaseActor> tweakObjectPtr = this.TargetScroll.GridArray[displayIndex];
			if (tweakObjectPtr.Get() == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ScrollViewGrid;
				ELogAuthor author = ELogAuthor.WY;
				string message = "Grid is NULL!";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DisplayIndex", displayIndex);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return tweakObjectPtr.Get().GetUIItem();
		}

		// Token: 0x06033034 RID: 208948 RVA: 0x00CC6A58 File Offset: 0x00CC4C58
		[NullableContext(2)]
		public TProxy UnsafeGetGridProxy(int gridIndex, bool logError = false)
		{
			int gridDisplayIndex = this.GetGridDisplayIndex(gridIndex, true);
			if (gridDisplayIndex == -1)
			{
				return default(TProxy);
			}
			if (this.GridsController != null && !this.GridsController.IsGridControlValid())
			{
				if (logError)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.ScrollViewGrid;
					ELogAuthor author = ELogAuthor.WY;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
					defaultInterpolatedStringHandler.AppendLiteral("动画还在播放时非法获取格子, gridIndex: ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(gridIndex);
					instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return default(TProxy);
			}
			return this.Delegate.GetGridProxy(gridDisplayIndex);
		}

		// Token: 0x06033035 RID: 208949 RVA: 0x00CC6AE6 File Offset: 0x00CC4CE6
		public void ReloadGrids(int length)
		{
			if (length == this.Delegate.GetDataLength())
			{
				return;
			}
			this.UpdateDataInternal(length, false);
		}

		// Token: 0x06033036 RID: 208950 RVA: 0x00CC6AFF File Offset: 0x00CC4CFF
		[Obsolete("请使用RefreshByData或 RefreshByDataAsync")]
		public void ReloadProxyData(Func<int, TData> dataProxyFunction, int dataLength, bool cacheData = true, bool keepContentPosition = false)
		{
			this.Delegate.ClearSelectInfo();
			this.Delegate.SetDataProxy(dataProxyFunction, dataLength, cacheData);
			this.UpdateDataInternal(dataLength, keepContentPosition);
		}

		// Token: 0x06033037 RID: 208951 RVA: 0x00CC6B24 File Offset: 0x00CC4D24
		[Obsolete("请使用RefreshByData或 RefreshByDataAsync")]
		public void ReloadData(IReadOnlyList<TData> data, bool keepContentPosition = false)
		{
			if (data.Count != this.Delegate.GetDataLength())
			{
				this.Delegate.ClearSelectInfo();
				this.Delegate.SetData(data);
				this.UpdateDataInternal(data.Count, keepContentPosition);
				return;
			}
			this.UpdateData(data);
			GridAppearAnimationBase gridsController = this.GridsController;
			if (gridsController == null)
			{
				return;
			}
			gridsController.PlayGridAnim(this.DisplayGridNum, true);
		}

		// Token: 0x06033038 RID: 208952 RVA: 0x00CC6B88 File Offset: 0x00CC4D88
		public void UpdateData(IReadOnlyList<TData> data)
		{
			if (data.Count != this.Delegate.GetDataLength())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ScrollViewGrid;
				ELogAuthor author = ELogAuthor.WY;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 2);
				defaultInterpolatedStringHandler.AppendLiteral("UpdateData要求新的数据长度必须跟旧的数据长度相等. 新长度: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
				defaultInterpolatedStringHandler.AppendLiteral(", 旧长度：");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Delegate.GetDataLength());
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.Delegate.SetData(data);
			this.RefreshAllGridProxies();
		}

		// Token: 0x06033039 RID: 208953 RVA: 0x00CC6C1C File Offset: 0x00CC4E1C
		public void RefreshAllGridProxies()
		{
			if (this.IsEmpty)
			{
				return;
			}
			for (int i = this.StartGridIndex; i <= this.EndGridIndex; i++)
			{
				this.RefreshGridProxy(i);
			}
		}

		// Token: 0x0603303A RID: 208954 RVA: 0x00CC6C50 File Offset: 0x00CC4E50
		public void RefreshGridProxy(int gridIndex)
		{
			if (gridIndex >= this.StartGridIndex && gridIndex <= this.EndGridIndex)
			{
				int gridDisplayIndex = this.GetGridDisplayIndex(gridIndex, false);
				this.Delegate.RefreshGridProxy(gridIndex, gridDisplayIndex);
			}
		}

		// Token: 0x0603303B RID: 208955 RVA: 0x00CC6C88 File Offset: 0x00CC4E88
		public void ClearGridProxies()
		{
			this.Delegate.ClearData();
			if (this.EndGridIndex < 0)
			{
				return;
			}
			for (int i = this.StartGridIndex; i <= this.EndGridIndex; i++)
			{
				this.Delegate.ClearGridProxy(i, this.GetGridDisplayIndex(i, false));
			}
		}

		// Token: 0x0603303C RID: 208956 RVA: 0x00CC6CD4 File Offset: 0x00CC4ED4
		public void ClearSelectInfo()
		{
			this.Delegate.ClearSelectInfo();
		}

		// Token: 0x0603303D RID: 208957 RVA: 0x00CC6CE1 File Offset: 0x00CC4EE1
		public TData TryGetCachedData(int gridIndex)
		{
			return this.Delegate.TryGetCachedData(gridIndex);
		}

		// Token: 0x0603303E RID: 208958 RVA: 0x00CC6CEF File Offset: 0x00CC4EEF
		public void SelectGridProxy(int gridIndex, bool fireEvent = false)
		{
			this.Delegate.SelectGridProxy(gridIndex, this.GetGridDisplayIndex(gridIndex, false), fireEvent);
		}

		// Token: 0x0603303F RID: 208959 RVA: 0x00CC6D06 File Offset: 0x00CC4F06
		public void DeselectCurrentGridProxy(bool fireEvent = false)
		{
			this.Delegate.DeselectCurrentGridProxy(fireEvent);
		}

		// Token: 0x06033040 RID: 208960 RVA: 0x00CC6D14 File Offset: 0x00CC4F14
		public int GetSelectedGridIndex()
		{
			return this.Delegate.GetSelectedGridIndex();
		}

		// Token: 0x06033041 RID: 208961 RVA: 0x00CC6D21 File Offset: 0x00CC4F21
		public void BindLateUpdate(Action<float> callBack)
		{
			this.TargetScroll.OnLateUpdate.Bind(callBack);
		}

		// Token: 0x06033042 RID: 208962 RVA: 0x00CC6D34 File Offset: 0x00CC4F34
		public void UnBindLateUpdate()
		{
			this.TargetScroll.OnLateUpdate.Unbind();
		}

		// Token: 0x06033043 RID: 208963 RVA: 0x00CC6D48 File Offset: 0x00CC4F48
		private void UpdateDataInternal(int gridNum, bool keepContentPosition)
		{
			if (this.TargetScroll == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LoopScrollView, ELogAuthor.TL, "更新数据错误，UUILoopScrollViewComponent组件为空!", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			AUIBaseActor templateGridActor = this.TemplateGridActor;
			if (templateGridActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LoopScrollView, ELogAuthor.TL, "更新数据错误，TemplateGrid为空!", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.StartGridIndex = -1;
			this.EndGridIndex = -1;
			this.GridNum = gridNum;
			this.TargetScroll.RefreshByData(templateGridActor, gridNum, keepContentPosition);
			this.DataInitedInternal = true;
			if (this.GridsController != null)
			{
				this.GridsController.PlayGridAnim(this.DisplayGridNum, true);
			}
		}

		// Token: 0x06033044 RID: 208964 RVA: 0x00CC6DE8 File Offset: 0x00CC4FE8
		public void RefreshByData(IReadOnlyList<TData> data, bool keepContentPosition = false, [Nullable(2)] Action callBack = null, bool playGridAnim = false)
		{
			if (this.IsLock)
			{
				OperationParam<TData> element = new OperationParam<TData>(data, keepContentPosition, callBack, playGridAnim);
				this.OperationQueue.Push(element);
				return;
			}
			this.Lock();
			this.RefreshByDataAsync(data, keepContentPosition, playGridAnim).ContinueWith(delegate()
			{
				Action callBack2 = callBack;
				if (callBack2 != null)
				{
					callBack2();
				}
				this.Unlock();
			});
		}

		// Token: 0x06033045 RID: 208965 RVA: 0x00CC6E50 File Offset: 0x00CC5050
		public UniTask RefreshByDataAsync(IReadOnlyList<TData> data, bool keepContentPosition = false, bool playGridAnim = false)
		{
			LoopScrollView<TProxy, TData>.<RefreshByDataAsync>d__58 <RefreshByDataAsync>d__;
			<RefreshByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshByDataAsync>d__.<>4__this = this;
			<RefreshByDataAsync>d__.data = data;
			<RefreshByDataAsync>d__.keepContentPosition = keepContentPosition;
			<RefreshByDataAsync>d__.playGridAnim = playGridAnim;
			<RefreshByDataAsync>d__.<>1__state = -1;
			<RefreshByDataAsync>d__.<>t__builder.Start<LoopScrollView<TProxy, TData>.<RefreshByDataAsync>d__58>(ref <RefreshByDataAsync>d__);
			return <RefreshByDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033046 RID: 208966 RVA: 0x00CC6EAC File Offset: 0x00CC50AC
		private UniTask UpdateDataInternalAsync(int gridNum, bool keepContentPosition)
		{
			LoopScrollView<TProxy, TData>.<UpdateDataInternalAsync>d__60 <UpdateDataInternalAsync>d__;
			<UpdateDataInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateDataInternalAsync>d__.<>4__this = this;
			<UpdateDataInternalAsync>d__.gridNum = gridNum;
			<UpdateDataInternalAsync>d__.keepContentPosition = keepContentPosition;
			<UpdateDataInternalAsync>d__.<>1__state = -1;
			<UpdateDataInternalAsync>d__.<>t__builder.Start<LoopScrollView<TProxy, TData>.<UpdateDataInternalAsync>d__60>(ref <UpdateDataInternalAsync>d__);
			return <UpdateDataInternalAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033047 RID: 208967 RVA: 0x00CC6F00 File Offset: 0x00CC5100
		public bool IsGridDisplaying(int gridIndex)
		{
			int gridDisplayIndex = this.GetGridDisplayIndex(gridIndex, false);
			return gridDisplayIndex >= 0 && gridDisplayIndex < this.DisplayGridNum;
		}

		// Token: 0x06033048 RID: 208968 RVA: 0x00CC6F25 File Offset: 0x00CC5125
		public void ScrollToGridIndex(int gridIndex, bool playGridAnim = true)
		{
			this.TargetScroll.ScrollToGridIndex(gridIndex, false);
			if (playGridAnim)
			{
				this.ResetGridController();
			}
		}

		// Token: 0x06033049 RID: 208969 RVA: 0x00CC6F3D File Offset: 0x00CC513D
		public void ScrollToGridIndexLate(int gridIndex, bool playGridAnim = true)
		{
			this.TargetScroll.ScrollToGridIndexLater(gridIndex, false);
			if (playGridAnim)
			{
				this.ResetGridController();
			}
		}

		// Token: 0x0603304A RID: 208970 RVA: 0x00CC6F55 File Offset: 0x00CC5155
		public void ScrollToGridIndexWithTween(int gridIndex, bool playGridAnim = true)
		{
			this.TargetScroll.ScrollToGridIndex(gridIndex, true);
			if (playGridAnim)
			{
				this.ResetGridController();
			}
		}

		// Token: 0x0603304B RID: 208971 RVA: 0x00CC6F6D File Offset: 0x00CC516D
		[NullableContext(2)]
		private void OnGridCreate(int displayIndex, AUIBaseActor actor)
		{
			this.Delegate.CreateGridProxy(displayIndex, actor);
		}

		// Token: 0x0603304C RID: 208972 RVA: 0x00CC6F80 File Offset: 0x00CC5180
		[NullableContext(2)]
		private void OnGridCreateAsync(int displayIndex, AUIBaseActor actor)
		{
			UniTask<TProxy> promise = this.Delegate.CreateGridProxyAsync(displayIndex, actor, true);
			if (this.IsInRefreshAsync)
			{
				this.TempGridCreatePromiseList.Add(promise);
				return;
			}
			this.TempGridCreatePromiseList.Add(promise);
			promise.ContinueWith(delegate(TProxy _)
			{
				this.TempGridCreatePromiseList.Remove(promise);
				return UniTask.CompletedTask;
			}).Forget();
		}

		// Token: 0x0603304D RID: 208973 RVA: 0x00CC6FF8 File Offset: 0x00CC51F8
		private void OnGridsUpdate(int startGridIndex, int endGridIndex)
		{
			if (this.TempGridCreatePromiseList.Count > 0)
			{
				return;
			}
			if (this.StartGridIndex == startGridIndex && this.EndGridIndex == endGridIndex)
			{
				return;
			}
			int startGridIndex2 = this.StartGridIndex;
			int endGridIndex2 = this.EndGridIndex;
			int displayGridNum = this.DisplayGridNum;
			int num = endGridIndex - startGridIndex + 1;
			for (int i = startGridIndex2; i <= endGridIndex2; i++)
			{
				if (i >= 0 && i < this.GridNum && displayGridNum != 0 && num != 0)
				{
					int num2 = i % displayGridNum;
					int num3 = i % num;
					if (i < startGridIndex || i > endGridIndex || i > endGridIndex2 || num2 != num3)
					{
						this.Delegate.ClearGridProxy(i, this.GetGridDisplayIndex(i, false));
					}
				}
			}
			this.StartGridIndex = startGridIndex;
			this.EndGridIndex = endGridIndex;
			for (int j = startGridIndex; j <= endGridIndex; j++)
			{
				if (j >= 0 && j < this.GridNum)
				{
					if (displayGridNum == 0 || num == 0)
					{
						this.OnGridUpdate(j);
					}
					else
					{
						int num4 = j % displayGridNum;
						int num5 = j % num;
						if (startGridIndex2 < 0 || j < startGridIndex2 || j > endGridIndex2 || num4 != num5)
						{
							this.OnGridUpdate(j);
						}
					}
				}
			}
		}

		// Token: 0x0603304E RID: 208974 RVA: 0x00CC710C File Offset: 0x00CC530C
		private void OnGridUpdate(int gridIndex)
		{
			int gridDisplayIndex = this.GetGridDisplayIndex(gridIndex, false);
			this.Delegate.OnGridsUpdate(gridIndex, gridDisplayIndex, this.StartGridIndex, this.EndGridIndex);
		}

		// Token: 0x0603304F RID: 208975 RVA: 0x00CC713C File Offset: 0x00CC533C
		private unsafe int GetGridDisplayIndex(int gridIndex, bool logError = false)
		{
			if (this.StartGridIndex < 0 || this.DisplayGridNum <= 0)
			{
				if (logError)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.LoopScrollView;
					ELogAuthor author = ELogAuthor.TL;
					string message = "GetGridDisplayIndex: 未初始化";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.StartGridIndex", this.StartGridIndex);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.DisplayGridNum", this.DisplayGridNum);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				return -1;
			}
			if (gridIndex < this.StartGridIndex || gridIndex >= this.StartGridIndex + this.DisplayGridNum)
			{
				if (logError)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.LoopScrollView;
					ELogAuthor author2 = ELogAuthor.TL;
					string message2 = "GetGridDisplayIndex: 未处于展示中";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("gridIndex", gridIndex);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("this.StartGridIndex", this.StartGridIndex);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("this.StartGridIndex + this.DisplayGridNum", this.StartGridIndex + this.DisplayGridNum);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
				return -1;
			}
			return gridIndex % this.DisplayGridNum;
		}

		// Token: 0x06033050 RID: 208976 RVA: 0x00CC7280 File Offset: 0x00CC5480
		private void OnDestroy(AActor actor)
		{
			(this.TargetScroll.GetOwner() as AUIBaseActor).OnPreDestroyed.Remove(new Action<AActor>(this.OnDestroy));
			this.TargetScroll.OnDestroyCallBack.Unbind();
			this.TargetScroll.OnGridsUpdate.Unbind();
			this.TargetScroll.OnGridCreate.Unbind();
			GridAppearAnimationBase gridsController = this.GridsController;
			if (gridsController != null)
			{
				gridsController.Clear();
			}
			this.Delegate.Destroy();
		}

		// Token: 0x06033051 RID: 208977 RVA: 0x00CC72FF File Offset: 0x00CC54FF
		public void BindOnScrollValueChanged(Action<FVector2D> callback)
		{
			this.TargetScroll.OnScrollValueChange.Bind(callback);
		}

		// Token: 0x06033052 RID: 208978 RVA: 0x00CC7314 File Offset: 0x00CC5514
		[return: Nullable(2)]
		public UUIItem GetGridAndScrollToByJudge(object targetData, Func<object, TData, bool> judge, bool playGridAnim = true)
		{
			if (!this.DataInited)
			{
				return null;
			}
			int num = 0;
			bool flag = false;
			foreach (TData arg in this.Delegate.GetDatas())
			{
				if (judge(targetData, arg))
				{
					flag = true;
					break;
				}
				num++;
			}
			if (!flag)
			{
				num = 0;
			}
			this.ScrollToGridIndex(num, playGridAnim);
			return this.GetGrid(num);
		}

		// Token: 0x06033053 RID: 208979 RVA: 0x00CC7394 File Offset: 0x00CC5594
		public void ScrollToNextLine(bool bReversed = true)
		{
			this.TargetScroll.ScrollToNextLine(bReversed);
		}

		// Token: 0x06033054 RID: 208980 RVA: 0x00CC73A2 File Offset: 0x00CC55A2
		public void SetTargetRootComponentActive(bool value)
		{
			this.TargetScroll.GetRootComponent().SetUIActive(value);
		}

		// Token: 0x06033055 RID: 208981 RVA: 0x00CC73B5 File Offset: 0x00CC55B5
		public void ResetGridController()
		{
			if (this.GridsController != null)
			{
				this.GridsController.PlayGridAnim(this.DisplayGridNum, true);
			}
		}

		// Token: 0x06033056 RID: 208982 RVA: 0x00CC73D4 File Offset: 0x00CC55D4
		public void ScrollToDisplayingIndex(int displayIndex)
		{
			UUIItem gridByDisplayIndex = this.GetGridByDisplayIndex(displayIndex);
			if (gridByDisplayIndex != null)
			{
				this.TargetScroll.ScrollTo(gridByDisplayIndex, false);
			}
		}

		// Token: 0x06033057 RID: 208983 RVA: 0x00CC73F9 File Offset: 0x00CC55F9
		public UUIInturnAnimController GetUiAnimController()
		{
			UUILoopScrollViewComponent targetScroll = this.TargetScroll;
			AUIBaseActor auibaseActor = (targetScroll != null) ? targetScroll.GetContent() : null;
			return ((auibaseActor != null) ? auibaseActor.GetComponentByClass(UUIInturnAnimController.StaticClass()) : null) as UUIInturnAnimController;
		}

		// Token: 0x06033058 RID: 208984 RVA: 0x00CC7428 File Offset: 0x00CC5628
		public int GetDisplayGridEndIndexPurely()
		{
			if (this.LineCount == -1)
			{
				UUILoopScrollViewComponent targetScroll = this.TargetScroll;
				float? num;
				if (targetScroll == null)
				{
					num = null;
				}
				else
				{
					AUIBaseActor viewport = targetScroll.GetViewport();
					if (viewport == null)
					{
						num = null;
					}
					else
					{
						UUIItem uiitem = viewport.GetUIItem();
						num = ((uiitem != null) ? new float?(uiitem.GetHeight()) : null);
					}
				}
				float? num2 = num;
				float valueOrDefault = num2.GetValueOrDefault();
				UUILoopScrollViewComponent targetScroll2 = this.TargetScroll;
				float num3 = (targetScroll2 != null) ? targetScroll2.PaddingVertical : 0f;
				UUILoopScrollViewComponent targetScroll3 = this.TargetScroll;
				float num4 = (targetScroll3 != null) ? targetScroll3.SpacingVertical : 0f;
				float num5 = 0f;
				UUILoopScrollViewComponent targetScroll4 = this.TargetScroll;
				bool flag;
				if (targetScroll4 == null)
				{
					flag = false;
				}
				else
				{
					TWeakObjectPtr<AUIBaseActor> templateGrid = targetScroll4.TemplateGrid;
					flag = true;
				}
				if (flag)
				{
					UUIItem uiitem2 = this.TargetScroll.TemplateGrid.Get().GetUIItem();
					num5 = ((uiitem2 != null) ? uiitem2.GetHeight() : 0f);
				}
				if (num5 + num4 != 0f)
				{
					this.LineCount = (int)Math.Ceiling((double)((valueOrDefault - 2f * num3 + num4) / (num5 + num4)));
				}
			}
			return this.StartGridIndex + this.LineCount - 1;
		}

		// Token: 0x0401DAB7 RID: 121527
		public const bool IS_DEBUG = false;

		// Token: 0x0401DAB8 RID: 121528
		[Nullable(2)]
		private readonly UUILoopScrollViewComponent TargetScroll;

		// Token: 0x0401DAB9 RID: 121529
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private readonly ScrollViewDelegate<TProxy, TData> Delegate;

		// Token: 0x0401DABA RID: 121530
		[Nullable(2)]
		private readonly GridAppearAnimationBase GridsController;

		// Token: 0x0401DABB RID: 121531
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		private readonly List<UniTask<TProxy>> TempGridCreatePromiseList = new List<UniTask<TProxy>>();

		// Token: 0x0401DABC RID: 121532
		private int GridNum;

		// Token: 0x0401DABD RID: 121533
		private int PrivateStartGridIndex = -1;

		// Token: 0x0401DABE RID: 121534
		private int PrivateEndGridIndex = -1;

		// Token: 0x0401DABF RID: 121535
		[Nullable(2)]
		private readonly AUIBaseActor TemplateGridActor;

		// Token: 0x0401DAC0 RID: 121536
		private bool DataInitedInternal;

		// Token: 0x0401DAC1 RID: 121537
		private bool Operating;

		// Token: 0x0401DAC2 RID: 121538
		private readonly Queue<OperationParam<TData>> OperationQueue = new Queue<OperationParam<TData>>(4);

		// Token: 0x0401DAC3 RID: 121539
		private Action AnimFinishDelegate;

		// Token: 0x0401DAC4 RID: 121540
		private bool IsInRefreshAsync;

		// Token: 0x0401DAC5 RID: 121541
		private int LineCount = -1;
	}
}
