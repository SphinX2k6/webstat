using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.Misc.PreemptiveFrameQueue
{
	// Token: 0x0200580D RID: 22541
	[NullableContext(1)]
	[Nullable(0)]
	public class SimplePreemptiveFrameQueue
	{
		// Token: 0x1700921B RID: 37403
		// (get) Token: 0x06039578 RID: 234872 RVA: 0x00E8E066 File Offset: 0x00E8C266
		public int PerFrameTaskLimit { get; }

		// Token: 0x1700921C RID: 37404
		// (get) Token: 0x06039579 RID: 234873 RVA: 0x00E8E06E File Offset: 0x00E8C26E
		public int ExecuteFrameInterval { get; }

		// Token: 0x0603957A RID: 234874 RVA: 0x00E8E076 File Offset: 0x00E8C276
		public SimplePreemptiveFrameQueue(int perFrameTaskLimit, int executeFrameInterval = 0)
		{
			this.PerFrameTaskLimit = perFrameTaskLimit;
			this.ExecuteFrameInterval = executeFrameInterval;
			this.FrameCounter = this.ExecuteFrameInterval;
		}

		// Token: 0x0603957B RID: 234875 RVA: 0x00E8E0A4 File Offset: 0x00E8C2A4
		public virtual void AddTask(IPreemptiveFrameTask task)
		{
			int num = 0;
			while (num < this.Tasks.Count && this.Tasks[num].Priority < task.Priority)
			{
				num++;
			}
			this.Tasks.Insert(num, task);
			if (this.IsTaskComplete() && !this.OnExecutionInterval)
			{
				this.FrameCounter = this.ExecuteFrameInterval;
			}
		}

		// Token: 0x0603957C RID: 234876 RVA: 0x00E8E10C File Offset: 0x00E8C30C
		public void CancelTask(IPreemptiveFrameTask task)
		{
			int num = this.Tasks.IndexOf(task);
			if (num > -1)
			{
				TPreemptiveCancelMethod cancel = task.Cancel;
				if (cancel != null)
				{
					cancel();
				}
				this.Tasks.RemoveAt(num);
			}
		}

		// Token: 0x0603957D RID: 234877 RVA: 0x00E8E148 File Offset: 0x00E8C348
		public void Process()
		{
			if (this.OnExecutionInterval)
			{
				this.FrameCounter++;
				return;
			}
			if (this.FrameCounter >= this.ExecuteFrameInterval)
			{
				this.FrameCounter = 0;
			}
			if (this.IsTaskComplete())
			{
				this.FrameExecuteTaskCounter = 0;
				while (this.Tasks.Count > 0 && this.FrameExecuteTaskCounter < this.PerFrameTaskLimit)
				{
					this.CurrentTask = this.ShiftNextTask();
					if (this.CurrentTask != null)
					{
						this.CurrentTask.Execute();
						if (!this.EnableFlush)
						{
							this.FrameExecuteTaskCounter++;
						}
						if (!this.IsTaskComplete())
						{
							break;
						}
						this.OnTaskComplete(this.CurrentTask);
					}
				}
				if (this.Tasks.Count == 0)
				{
					this.CurrentTask = null;
				}
				if (this.FrameExecuteTaskCounter != 0)
				{
					this.OnLateExecuteTasksFrame();
				}
				return;
			}
			TPreemptiveExecuteMethod frameExecute = this.CurrentTask.FrameExecute;
			if (frameExecute == null)
			{
				return;
			}
			frameExecute();
		}

		// Token: 0x0603957E RID: 234878 RVA: 0x00E8E234 File Offset: 0x00E8C434
		[NullableContext(2)]
		protected virtual IPreemptiveFrameTask ShiftNextTask()
		{
			if (this.Tasks.Count > 0)
			{
				IPreemptiveFrameTask result = this.Tasks[0];
				this.Tasks.RemoveAt(0);
				return result;
			}
			return null;
		}

		// Token: 0x0603957F RID: 234879 RVA: 0x00E8E25E File Offset: 0x00E8C45E
		protected virtual void OnTaskComplete(IPreemptiveFrameTask task)
		{
		}

		// Token: 0x06039580 RID: 234880 RVA: 0x00E8E260 File Offset: 0x00E8C460
		protected virtual void OnLateExecuteTasksFrame()
		{
		}

		// Token: 0x06039581 RID: 234881 RVA: 0x00E8E262 File Offset: 0x00E8C462
		protected bool IsTaskComplete()
		{
			if (this.CurrentTask != null)
			{
				TPreemptiveIsCompleteMethod isComplete = this.CurrentTask.IsComplete;
				return isComplete == null || isComplete();
			}
			return true;
		}

		// Token: 0x1700921D RID: 37405
		// (get) Token: 0x06039582 RID: 234882 RVA: 0x00E8E284 File Offset: 0x00E8C484
		protected bool OnExecutionInterval
		{
			get
			{
				return this.FrameCounter < this.ExecuteFrameInterval;
			}
		}

		// Token: 0x06039583 RID: 234883 RVA: 0x00E8E294 File Offset: 0x00E8C494
		public virtual void Dispose()
		{
			IPreemptiveFrameTask currentTask = this.CurrentTask;
			if (currentTask != null)
			{
				TPreemptiveCancelMethod cancel = currentTask.Cancel;
				if (cancel != null)
				{
					cancel();
				}
			}
			this.CurrentTask = null;
			this.Tasks.Clear();
		}

		// Token: 0x04020977 RID: 133495
		protected readonly List<IPreemptiveFrameTask> Tasks = new List<IPreemptiveFrameTask>();

		// Token: 0x04020978 RID: 133496
		[Nullable(2)]
		private IPreemptiveFrameTask CurrentTask;

		// Token: 0x04020979 RID: 133497
		private int FrameExecuteTaskCounter;

		// Token: 0x0402097A RID: 133498
		protected bool EnableFlush;

		// Token: 0x0402097B RID: 133499
		private int FrameCounter;
	}
}
