using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Misc.PreemptiveFrameQueue;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapFrameTaskQueue
{
	// Token: 0x02005806 RID: 22534
	[NullableContext(1)]
	[Nullable(0)]
	public class MapMarkPreemptiveFrameQueue : SimplePreemptiveFrameQueue
	{
		// Token: 0x06039530 RID: 234800 RVA: 0x00E8DB4B File Offset: 0x00E8BD4B
		public MapMarkPreemptiveFrameQueue(int perFrameTaskLimit, int executeFrameInterval = 0) : base(perFrameTaskLimit, executeFrameInterval)
		{
		}

		// Token: 0x06039531 RID: 234801 RVA: 0x00E8DB60 File Offset: 0x00E8BD60
		public override void AddTask(IPreemptiveFrameTask task)
		{
			base.AddTask(task);
			IMapMarkPreemptiveFrameTask mapMarkPreemptiveFrameTask = (IMapMarkPreemptiveFrameTask)task;
			Dictionary<int, IMapMarkPreemptiveFrameTask> dictionary;
			if (!this.MarkTaskMap.TryGetValue(mapMarkPreemptiveFrameTask.MarkType, out dictionary))
			{
				dictionary = new Dictionary<int, IMapMarkPreemptiveFrameTask>();
				this.MarkTaskMap[mapMarkPreemptiveFrameTask.MarkType] = dictionary;
			}
			dictionary[mapMarkPreemptiveFrameTask.MarkId] = mapMarkPreemptiveFrameTask;
		}

		// Token: 0x06039532 RID: 234802 RVA: 0x00E8DBB8 File Offset: 0x00E8BDB8
		public void ForceExecuteTask(EMarkType markType, int markId)
		{
			IMapMarkPreemptiveFrameTask task = this.GetTask(markType, markId);
			if (task != null)
			{
				task.Execute();
				this.CancelMapTask(markType, markId);
			}
		}

		// Token: 0x06039533 RID: 234803 RVA: 0x00E8DBE4 File Offset: 0x00E8BDE4
		public void Flush()
		{
			this.EnableFlush = true;
			base.Process();
			this.EnableFlush = false;
		}

		// Token: 0x06039534 RID: 234804 RVA: 0x00E8DBFC File Offset: 0x00E8BDFC
		public void CancelMapTask(EMarkType markType, int markId)
		{
			IMapMarkPreemptiveFrameTask task = this.GetTask(markType, markId);
			if (task != null)
			{
				base.CancelTask(task);
				this.RemoveTaskCache(task);
			}
		}

		// Token: 0x06039535 RID: 234805 RVA: 0x00E8DC24 File Offset: 0x00E8BE24
		private void RemoveTaskCache(IMapMarkPreemptiveFrameTask task)
		{
			Dictionary<int, IMapMarkPreemptiveFrameTask> dictionary;
			if (this.MarkTaskMap.TryGetValue(task.MarkType, out dictionary))
			{
				dictionary.Remove(task.MarkId);
			}
		}

		// Token: 0x06039536 RID: 234806 RVA: 0x00E8DC53 File Offset: 0x00E8BE53
		public bool HasTask(EMarkType markType, int markId)
		{
			return this.GetTask(markType, markId) != null;
		}

		// Token: 0x06039537 RID: 234807 RVA: 0x00E8DC60 File Offset: 0x00E8BE60
		[NullableContext(2)]
		private IMapMarkPreemptiveFrameTask GetTask(EMarkType markType, int markId)
		{
			if (markType == EMarkType.None)
			{
				using (Dictionary<EMarkType, Dictionary<int, IMapMarkPreemptiveFrameTask>>.ValueCollection.Enumerator enumerator = this.MarkTaskMap.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IMapMarkPreemptiveFrameTask result;
						if (enumerator.Current.TryGetValue(markId, out result))
						{
							return result;
						}
					}
				}
				return null;
			}
			Dictionary<int, IMapMarkPreemptiveFrameTask> dictionary;
			if (this.MarkTaskMap.TryGetValue(markType, out dictionary))
			{
				IMapMarkPreemptiveFrameTask result2;
				dictionary.TryGetValue(markId, out result2);
				return result2;
			}
			return null;
		}

		// Token: 0x06039538 RID: 234808 RVA: 0x00E8DCE4 File Offset: 0x00E8BEE4
		public void CancelMapTaskByType(EMarkType markType)
		{
			Dictionary<int, IMapMarkPreemptiveFrameTask> dictionary;
			if (this.MarkTaskMap.TryGetValue(markType, out dictionary))
			{
				foreach (IMapMarkPreemptiveFrameTask task in dictionary.Values.ToList<IMapMarkPreemptiveFrameTask>())
				{
					base.CancelTask(task);
					this.RemoveTaskCache(task);
				}
			}
		}

		// Token: 0x06039539 RID: 234809 RVA: 0x00E8DD54 File Offset: 0x00E8BF54
		protected override void OnTaskComplete(IPreemptiveFrameTask task)
		{
			base.OnTaskComplete(task);
			IMapMarkPreemptiveFrameTask mapMarkPreemptiveFrameTask = (IMapMarkPreemptiveFrameTask)task;
			this.RemoveTaskCache(mapMarkPreemptiveFrameTask);
			Singleton<EventSystem>.Instance.Emit<EMarkType, int>(EEventName.OnMapMarkTaskComplete, mapMarkPreemptiveFrameTask.MarkType, mapMarkPreemptiveFrameTask.MarkId);
		}

		// Token: 0x04020963 RID: 133475
		private readonly Dictionary<EMarkType, Dictionary<int, IMapMarkPreemptiveFrameTask>> MarkTaskMap = new Dictionary<EMarkType, Dictionary<int, IMapMarkPreemptiveFrameTask>>();
	}
}
