using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063CD RID: 25549
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeActionSubViewManager
	{
		// Token: 0x06040255 RID: 262741 RVA: 0x0107026C File Offset: 0x0106E46C
		public void RegisterHost(UUIItem hostViewItem)
		{
			this.HostParentItem = hostViewItem;
			this.IsHostReadyInternal = true;
			foreach (UiAsyncTask task in this.PendingTasks)
			{
				this.TaskManager.RunTask(task);
			}
			this.PendingTasks.Clear();
			this.PendingTaskMap.Clear();
		}

		// Token: 0x06040256 RID: 262742 RVA: 0x010702EC File Offset: 0x0106E4EC
		public void UnregisterHost()
		{
			this.FinishAllSubView();
			this.OnAllSubViewsFinished = null;
			this.IsHostReadyInternal = false;
			this.HostParentItem = null;
			this.ActionTopPanel = null;
		}

		// Token: 0x06040257 RID: 262743 RVA: 0x01070310 File Offset: 0x0106E510
		public void RegisterTopPanel(RoverlikeBattleTopPanel panel)
		{
			this.ActionTopPanel = panel;
		}

		// Token: 0x06040258 RID: 262744 RVA: 0x01070319 File Offset: 0x0106E519
		[NullableContext(2)]
		public RoverlikeBattleTopPanel GetActionTopPanel()
		{
			return this.ActionTopPanel;
		}

		// Token: 0x06040259 RID: 262745 RVA: 0x01070324 File Offset: 0x0106E524
		[NullableContext(2)]
		public int AddSubView(ERoverActionSubViewType type, object openParam = null)
		{
			RoverlikeActionSubViewManager.<>c__DisplayClass15_0 CS$<>8__locals1 = new RoverlikeActionSubViewManager.<>c__DisplayClass15_0();
			CS$<>8__locals1.<>4__this = this;
			if (this.IsDisposed)
			{
				return -1;
			}
			RoverlikeActionSubViewManager.<>c__DisplayClass15_0 CS$<>8__locals2 = CS$<>8__locals1;
			int nextIncId = this.NextIncId;
			this.NextIncId = nextIncId + 1;
			CS$<>8__locals2.incId = nextIncId;
			CS$<>8__locals1.subView = RoverlikeActionSubViewFactory.CreateSubView(type);
			if (CS$<>8__locals1.subView == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Roverlike;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[俯视角肉鸽] 未注册的子界面类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return -1;
			}
			CS$<>8__locals1.subView.IncId = CS$<>8__locals1.incId;
			CS$<>8__locals1.subView.OpenParam = openParam;
			this.SubViewStack.Add(CS$<>8__locals1.subView);
			this.SubViewMap[CS$<>8__locals1.incId] = CS$<>8__locals1.subView;
			RoverlikeActionStack actionStack = this.GetActionStack();
			if (actionStack != null)
			{
				actionStack.Push(CS$<>8__locals1.subView);
			}
			UiAsyncTask uiAsyncTask = new UiAsyncTask("RoverlikeActionSubView.Create", delegate()
			{
				RoverlikeActionSubViewManager.<>c__DisplayClass15_0.<<AddSubView>b__0>d <<AddSubView>b__0>d;
				<<AddSubView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<AddSubView>b__0>d.<>4__this = CS$<>8__locals1;
				<<AddSubView>b__0>d.<>1__state = -1;
				<<AddSubView>b__0>d.<>t__builder.Start<RoverlikeActionSubViewManager.<>c__DisplayClass15_0.<<AddSubView>b__0>d>(ref <<AddSubView>b__0>d);
				return <<AddSubView>b__0>d.<>t__builder.Task;
			}, null);
			if (this.IsHostReadyInternal)
			{
				this.TaskManager.RunTask(uiAsyncTask);
			}
			else
			{
				this.PendingTasks.Add(uiAsyncTask);
				this.PendingTaskMap[CS$<>8__locals1.incId] = uiAsyncTask;
			}
			return CS$<>8__locals1.incId;
		}

		// Token: 0x0604025A RID: 262746 RVA: 0x01070454 File Offset: 0x0106E654
		public void FinishSubView(int incId)
		{
			RoverlikeActionSubViewManager.<>c__DisplayClass16_0 CS$<>8__locals1 = new RoverlikeActionSubViewManager.<>c__DisplayClass16_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.incId = incId;
			if (this.IsDisposed)
			{
				return;
			}
			if (!this.SubViewMap.TryGetValue(CS$<>8__locals1.incId, out CS$<>8__locals1.subView) || CS$<>8__locals1.subView.Finished)
			{
				return;
			}
			if (CS$<>8__locals1.subView.State == ERoverlikeActionSubViewState.Wait)
			{
				this.FinishWaitingSubView(CS$<>8__locals1.subView);
				this.CheckAllFinished();
				return;
			}
			UiAsyncTask task = new UiAsyncTask("RoverlikeActionSubView.Finish", delegate()
			{
				RoverlikeActionSubViewManager.<>c__DisplayClass16_0.<<FinishSubView>b__0>d <<FinishSubView>b__0>d;
				<<FinishSubView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<FinishSubView>b__0>d.<>4__this = CS$<>8__locals1;
				<<FinishSubView>b__0>d.<>1__state = -1;
				<<FinishSubView>b__0>d.<>t__builder.Start<RoverlikeActionSubViewManager.<>c__DisplayClass16_0.<<FinishSubView>b__0>d>(ref <<FinishSubView>b__0>d);
				return <<FinishSubView>b__0>d.<>t__builder.Task;
			}, null);
			this.TaskManager.RunTask(task);
		}

		// Token: 0x0604025B RID: 262747 RVA: 0x010704EC File Offset: 0x0106E6EC
		public unsafe void FinishAllSubView()
		{
			if (this.IsDisposed)
			{
				return;
			}
			for (int i = this.SubViewStack.Count - 1; i >= 0; i--)
			{
				RoverlikeActionSubViewBase roverlikeActionSubViewBase = this.SubViewStack[i];
				if (!roverlikeActionSubViewBase.Finished)
				{
					if (roverlikeActionSubViewBase.State == ERoverlikeActionSubViewState.Wait)
					{
						this.FinishWaitingSubView(roverlikeActionSubViewBase);
					}
					else
					{
						roverlikeActionSubViewBase.SetState(ERoverlikeActionSubViewState.Finished);
						RoverlikeActionStack actionStack = this.GetActionStack();
						if (actionStack != null)
						{
							actionStack.Pop(roverlikeActionSubViewBase);
						}
						this.RemoveFromStack(roverlikeActionSubViewBase);
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Roverlike;
						ELogAuthor author = ELogAuthor.YYZ;
						string message = "[俯视角肉鸽] 完成行为子界面";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IncId", roverlikeActionSubViewBase.IncId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", roverlikeActionSubViewBase.SubViewType.ToEnumString());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StackSize", this.SubViewStack.Count);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					}
				}
			}
		}

		// Token: 0x0604025C RID: 262748 RVA: 0x010705FD File Offset: 0x0106E7FD
		[NullableContext(2)]
		public RoverlikeActionSubViewBase GetCurrentSubView()
		{
			if (this.SubViewStack.Count == 0)
			{
				return null;
			}
			return this.SubViewStack[this.SubViewStack.Count - 1];
		}

		// Token: 0x0604025D RID: 262749 RVA: 0x01070628 File Offset: 0x0106E828
		[NullableContext(2)]
		public RoverlikeActionSubViewBase GetSubViewByIncId(int incId)
		{
			RoverlikeActionSubViewBase result;
			this.SubViewMap.TryGetValue(incId, out result);
			return result;
		}

		// Token: 0x0604025E RID: 262750 RVA: 0x01070645 File Offset: 0x0106E845
		public bool HasSubViews()
		{
			return this.SubViewStack.Count > 0;
		}

		// Token: 0x17009DB1 RID: 40369
		// (get) Token: 0x0604025F RID: 262751 RVA: 0x01070655 File Offset: 0x0106E855
		public bool HostReady
		{
			get
			{
				return this.IsHostReadyInternal;
			}
		}

		// Token: 0x06040260 RID: 262752 RVA: 0x01070660 File Offset: 0x0106E860
		public void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			this.IsDisposed = true;
			this.TaskManager.CancelAllTask();
			this.PendingTasks.Clear();
			this.PendingTaskMap.Clear();
			this.SubViewStack.Clear();
			this.SubViewMap.Clear();
			this.HostParentItem = null;
			this.IsHostReadyInternal = false;
			this.ActionTopPanel = null;
			this.OnAllSubViewsFinished = null;
		}

		// Token: 0x06040261 RID: 262753 RVA: 0x010706D0 File Offset: 0x0106E8D0
		[NullableContext(2)]
		private RoverlikeActionSubViewBase GetTopActiveSubView()
		{
			for (int i = this.SubViewStack.Count - 1; i >= 0; i--)
			{
				if (!this.SubViewStack[i].Finished)
				{
					return this.SubViewStack[i];
				}
			}
			return null;
		}

		// Token: 0x06040262 RID: 262754 RVA: 0x01070716 File Offset: 0x0106E916
		private void CheckAllFinished()
		{
			if (this.SubViewStack.Count > 0)
			{
				return;
			}
			Action onAllSubViewsFinished = this.OnAllSubViewsFinished;
			if (onAllSubViewsFinished != null)
			{
				onAllSubViewsFinished();
			}
			this.UnregisterHost();
		}

		// Token: 0x06040263 RID: 262755 RVA: 0x01070740 File Offset: 0x0106E940
		private unsafe void FinishWaitingSubView(RoverlikeActionSubViewBase subView)
		{
			int incId = subView.IncId;
			UiAsyncTask uiAsyncTask;
			if (this.PendingTaskMap.TryGetValue(incId, out uiAsyncTask))
			{
				int num = -1;
				for (int i = 0; i < this.PendingTasks.Count; i++)
				{
					if (this.PendingTasks[i] == uiAsyncTask)
					{
						num = i;
						break;
					}
				}
				if (num != -1)
				{
					this.PendingTasks.RemoveAt(num);
				}
				this.PendingTaskMap.Remove(incId);
			}
			subView.SetState(ERoverlikeActionSubViewState.Finished);
			RoverlikeActionStack actionStack = this.GetActionStack();
			if (actionStack != null)
			{
				actionStack.Pop(subView);
			}
			this.RemoveFromStack(subView);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Roverlike;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[俯视角肉鸽] 取消未创建的子界面";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IncId", incId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", subView.SubViewType.ToEnumString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StackSize", this.SubViewStack.Count);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x06040264 RID: 262756 RVA: 0x01070860 File Offset: 0x0106EA60
		private void RemoveFromStack(RoverlikeActionSubViewBase subView)
		{
			int num = -1;
			for (int i = 0; i < this.SubViewStack.Count; i++)
			{
				if (this.SubViewStack[i] == subView)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				this.SubViewStack.RemoveAt(num);
			}
			this.SubViewMap.Remove(subView.IncId);
		}

		// Token: 0x06040265 RID: 262757 RVA: 0x010708BA File Offset: 0x0106EABA
		[NullableContext(2)]
		private RoverlikeActionStack GetActionStack()
		{
			RoverlikeModel instance = ModelBase<RoverlikeModel>.Instance;
			if (instance == null)
			{
				return null;
			}
			return instance.ActionStack;
		}

		// Token: 0x04023FE4 RID: 147428
		private readonly List<RoverlikeActionSubViewBase> SubViewStack = new List<RoverlikeActionSubViewBase>();

		// Token: 0x04023FE5 RID: 147429
		private readonly Dictionary<int, RoverlikeActionSubViewBase> SubViewMap = new Dictionary<int, RoverlikeActionSubViewBase>();

		// Token: 0x04023FE6 RID: 147430
		private readonly UiAsyncTaskManager TaskManager = new UiAsyncTaskManager();

		// Token: 0x04023FE7 RID: 147431
		private readonly List<UiAsyncTask> PendingTasks = new List<UiAsyncTask>();

		// Token: 0x04023FE8 RID: 147432
		private readonly Dictionary<int, UiAsyncTask> PendingTaskMap = new Dictionary<int, UiAsyncTask>();

		// Token: 0x04023FE9 RID: 147433
		private int NextIncId = 1;

		// Token: 0x04023FEA RID: 147434
		public bool IsDisposed;

		// Token: 0x04023FEB RID: 147435
		[Nullable(2)]
		private UUIItem HostParentItem;

		// Token: 0x04023FEC RID: 147436
		private bool IsHostReadyInternal;

		// Token: 0x04023FED RID: 147437
		[Nullable(2)]
		private RoverlikeBattleTopPanel ActionTopPanel;

		// Token: 0x04023FEE RID: 147438
		[Nullable(2)]
		public Action OnAllSubViewsFinished;
	}
}
