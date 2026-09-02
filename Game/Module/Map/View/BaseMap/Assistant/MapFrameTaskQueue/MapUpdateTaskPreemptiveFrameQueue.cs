using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Misc.PreemptiveFrameQueue;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapFrameTaskQueue
{
	// Token: 0x0200580B RID: 22539
	[NullableContext(1)]
	[Nullable(0)]
	public class MapUpdateTaskPreemptiveFrameQueue : SimplePreemptiveFrameQueue
	{
		// Token: 0x06039568 RID: 234856 RVA: 0x00E8DEC3 File Offset: 0x00E8C0C3
		public MapUpdateTaskPreemptiveFrameQueue(int perFrameTaskLimit, int executeFrameInterval = 0) : base(perFrameTaskLimit, executeFrameInterval)
		{
		}

		// Token: 0x06039569 RID: 234857 RVA: 0x00E8DED8 File Offset: 0x00E8C0D8
		public override void AddTask(IPreemptiveFrameTask task)
		{
			IMapMarkPreemptiveFrameTask mapMarkPreemptiveFrameTask = task as IMapMarkPreemptiveFrameTask;
			if (mapMarkPreemptiveFrameTask == null)
			{
				return;
			}
			if (this.MarkTaskMap.ContainsKey(mapMarkPreemptiveFrameTask.MarkId))
			{
				return;
			}
			this.MarkTaskMap[mapMarkPreemptiveFrameTask.MarkId] = mapMarkPreemptiveFrameTask;
			base.AddTask(mapMarkPreemptiveFrameTask);
		}

		// Token: 0x0603956A RID: 234858 RVA: 0x00E8DF20 File Offset: 0x00E8C120
		protected override void OnTaskComplete(IPreemptiveFrameTask task)
		{
			IMapMarkPreemptiveFrameTask mapMarkPreemptiveFrameTask = task as IMapMarkPreemptiveFrameTask;
			if (mapMarkPreemptiveFrameTask != null)
			{
				this.MarkTaskMap.Remove(mapMarkPreemptiveFrameTask.MarkId);
			}
		}

		// Token: 0x0603956B RID: 234859 RVA: 0x00E8DF49 File Offset: 0x00E8C149
		public override void Dispose()
		{
			base.Dispose();
			this.MarkTaskMap.Clear();
		}

		// Token: 0x04020975 RID: 133493
		private readonly Dictionary<int, IMapMarkPreemptiveFrameTask> MarkTaskMap = new Dictionary<int, IMapMarkPreemptiveFrameTask>();
	}
}
