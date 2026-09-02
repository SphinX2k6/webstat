using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Map.Misc.PreemptiveFrameQueue;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapFrameTaskQueue
{
	// Token: 0x02005805 RID: 22533
	[NullableContext(1)]
	[Nullable(0)]
	public class MapGamePlayRequestPreemptiveFrameQueue : SimplePreemptiveFrameQueue
	{
		// Token: 0x0603952D RID: 234797 RVA: 0x00E8DA75 File Offset: 0x00E8BC75
		public MapGamePlayRequestPreemptiveFrameQueue(int perFrameTaskLimit, int executeFrameInterval = 0) : base(perFrameTaskLimit, executeFrameInterval)
		{
		}

		// Token: 0x0603952E RID: 234798 RVA: 0x00E8DA8C File Offset: 0x00E8BC8C
		protected override void OnTaskComplete(IPreemptiveFrameTask rawTask)
		{
			IMapGamePlayRequestPreemptiveFrameTask mapGamePlayRequestPreemptiveFrameTask = rawTask as IMapGamePlayRequestPreemptiveFrameTask;
			base.OnTaskComplete(mapGamePlayRequestPreemptiveFrameTask);
			InstLevelPlayStateReq instLevelPlayStateReq;
			if (!this.RequestMap.TryGetValue(mapGamePlayRequestPreemptiveFrameTask.InstId, out instLevelPlayStateReq))
			{
				instLevelPlayStateReq = new InstLevelPlayStateReq();
				instLevelPlayStateReq.InstId = mapGamePlayRequestPreemptiveFrameTask.InstId;
				this.RequestMap[mapGamePlayRequestPreemptiveFrameTask.InstId] = instLevelPlayStateReq;
			}
			int gamePlayId = mapGamePlayRequestPreemptiveFrameTask.GamePlayId;
			if (!instLevelPlayStateReq.LevelPlayIds.Contains(gamePlayId))
			{
				instLevelPlayStateReq.LevelPlayIds.Add(gamePlayId);
			}
		}

		// Token: 0x0603952F RID: 234799 RVA: 0x00E8DB04 File Offset: 0x00E8BD04
		protected override void OnLateExecuteTasksFrame()
		{
			if (this.RequestMap.Count > 0)
			{
				List<InstLevelPlayStateReq> requestList = this.RequestMap.Values.ToList<InstLevelPlayStateReq>();
				ControllerBase<LevelPlayReportController>.Instance.RequestLevelPlayStateListAsync(requestList).Forget();
				this.RequestMap.Clear();
			}
		}

		// Token: 0x04020962 RID: 133474
		private readonly Dictionary<int, InstLevelPlayStateReq> RequestMap = new Dictionary<int, InstLevelPlayStateReq>();
	}
}
