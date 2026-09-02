using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A0 RID: 18848
	public class UiAsyncTaskQueue
	{
		// Token: 0x06031380 RID: 201600 RVA: 0x00C41B1D File Offset: 0x00C3FD1D
		[NullableContext(1)]
		public void EnQueue(UiAsyncTask task)
		{
			if (this.TaskQueue == null)
			{
				this.TaskQueue = new Queue<UiAsyncTask>(4);
			}
			this.TaskQueue.Push(task);
		}

		// Token: 0x06031381 RID: 201601 RVA: 0x00C41B40 File Offset: 0x00C3FD40
		public UniTask ProcessQueue()
		{
			UiAsyncTaskQueue.<ProcessQueue>d__5 <ProcessQueue>d__;
			<ProcessQueue>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessQueue>d__.<>4__this = this;
			<ProcessQueue>d__.<>1__state = -1;
			<ProcessQueue>d__.<>t__builder.Start<UiAsyncTaskQueue.<ProcessQueue>d__5>(ref <ProcessQueue>d__);
			return <ProcessQueue>d__.<>t__builder.Task;
		}

		// Token: 0x06031382 RID: 201602 RVA: 0x00C41B84 File Offset: 0x00C3FD84
		public void Cancel()
		{
			this.Canceled = true;
			UiAsyncTask currentRunningTask = this.CurrentRunningTask;
			if (currentRunningTask != null)
			{
				currentRunningTask.Cancel();
			}
			if (this.TaskQueue == null)
			{
				return;
			}
			for (int i = 0; i < this.TaskQueue.Size; i++)
			{
				UiAsyncTask uiAsyncTask = this.TaskQueue.Get(i);
				if (uiAsyncTask != null)
				{
					uiAsyncTask.Cancel();
				}
			}
			this.TaskQueue.Clear();
		}

		// Token: 0x06031383 RID: 201603 RVA: 0x00C41BEC File Offset: 0x00C3FDEC
		public void CancelPending()
		{
			if (this.TaskQueue == null)
			{
				return;
			}
			for (int i = 0; i < this.TaskQueue.Size; i++)
			{
				UiAsyncTask uiAsyncTask = this.TaskQueue.Get(i);
				if (uiAsyncTask != null)
				{
					uiAsyncTask.Cancel();
				}
			}
			this.TaskQueue.Clear();
		}

		// Token: 0x0401C520 RID: 116000
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Queue<UiAsyncTask> TaskQueue;

		// Token: 0x0401C521 RID: 116001
		private bool IsProcessing;

		// Token: 0x0401C522 RID: 116002
		private bool Canceled;

		// Token: 0x0401C523 RID: 116003
		[Nullable(2)]
		private UiAsyncTask CurrentRunningTask;
	}
}
