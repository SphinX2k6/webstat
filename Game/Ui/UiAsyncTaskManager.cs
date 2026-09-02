using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x0200499F RID: 18847
	public class UiAsyncTaskManager
	{
		// Token: 0x0603137B RID: 201595 RVA: 0x00C41A2C File Offset: 0x00C3FC2C
		public UniTask<bool> RunTask([Nullable(1)] UiAsyncTask task)
		{
			UiAsyncTaskManager.<RunTask>d__1 <RunTask>d__;
			<RunTask>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RunTask>d__.<>4__this = this;
			<RunTask>d__.task = task;
			<RunTask>d__.<>1__state = -1;
			<RunTask>d__.<>t__builder.Start<UiAsyncTaskManager.<RunTask>d__1>(ref <RunTask>d__);
			return <RunTask>d__.<>t__builder.Task;
		}

		// Token: 0x0603137C RID: 201596 RVA: 0x00C41A78 File Offset: 0x00C3FC78
		public void CancelAllTask()
		{
			if (this.TaskQueueMap == null || this.TaskQueueMap.Count == 0)
			{
				return;
			}
			foreach (UiAsyncTaskQueue uiAsyncTaskQueue in this.TaskQueueMap.Values)
			{
				uiAsyncTaskQueue.Cancel();
			}
			this.TaskQueueMap.Clear();
		}

		// Token: 0x0603137D RID: 201597 RVA: 0x00C41AF0 File Offset: 0x00C3FCF0
		[NullableContext(1)]
		public void CancelPendingByName(string name)
		{
			UiAsyncTaskQueue uiAsyncTaskQueue;
			if (this.TaskQueueMap.TryGetValue(name, out uiAsyncTaskQueue))
			{
				uiAsyncTaskQueue.CancelPending();
			}
		}

		// Token: 0x0603137E RID: 201598 RVA: 0x00C41B13 File Offset: 0x00C3FD13
		[NullableContext(2)]
		public void LogInfo(string key)
		{
		}

		// Token: 0x0401C51F RID: 115999
		[Nullable(1)]
		private Dictionary<string, UiAsyncTaskQueue> TaskQueueMap;
	}
}
