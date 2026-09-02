using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063A5 RID: 25509
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeQuestData
	{
		// Token: 0x060400DB RID: 262363 RVA: 0x0106B0EF File Offset: 0x010692EF
		public void Reset()
		{
			this.ActivityId = 0;
			this.TaskById.Clear();
		}

		// Token: 0x060400DC RID: 262364 RVA: 0x0106B103 File Offset: 0x01069303
		public void PhraseEx(int activityId, RoverRogueActivityData roverData)
		{
			this.ActivityId = activityId;
			this.TaskById.Clear();
			this.UpdateTasks(roverData.ConditionTasks);
		}

		// Token: 0x060400DD RID: 262365 RVA: 0x0106B124 File Offset: 0x01069324
		public void UpdateTasks(IReadOnlyList<ConditionTask> tasks)
		{
			foreach (ConditionTask conditionTask in tasks)
			{
				this.TaskById[conditionTask.Id] = conditionTask;
			}
		}

		// Token: 0x060400DE RID: 262366 RVA: 0x0106B178 File Offset: 0x01069378
		[NullableContext(2)]
		public ConditionTask GetTask(int taskId)
		{
			ConditionTask result;
			if (!this.TaskById.TryGetValue(taskId, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060400DF RID: 262367 RVA: 0x0106B198 File Offset: 0x01069398
		public List<int> GetAllTakeableTaskIds()
		{
			List<int> list = new List<int>();
			foreach (ConditionTask conditionTask in this.TaskById.Values)
			{
				if (conditionTask.Status == ConditionTaskState.ConditionTaskFinish)
				{
					list.Add(conditionTask.Id);
				}
			}
			return list;
		}

		// Token: 0x060400E0 RID: 262368 RVA: 0x0106B208 File Offset: 0x01069408
		public void MarkTaken(int taskId)
		{
			ConditionTask conditionTask;
			if (this.TaskById.TryGetValue(taskId, out conditionTask))
			{
				conditionTask.Status = ConditionTaskState.ConditionTaskTaken;
			}
		}

		// Token: 0x060400E1 RID: 262369 RVA: 0x0106B22C File Offset: 0x0106942C
		public List<int> GetSortedTaskIdList()
		{
			List<int> list = this.TaskById.Keys.ToList<int>();
			list.Sort(delegate(int a, int b)
			{
				int statusSortWeight = this.GetStatusSortWeight(a);
				int statusSortWeight2 = this.GetStatusSortWeight(b);
				if (statusSortWeight != statusSortWeight2)
				{
					return statusSortWeight - statusSortWeight2;
				}
				return a - b;
			});
			return list;
		}

		// Token: 0x060400E2 RID: 262370 RVA: 0x0106B250 File Offset: 0x01069450
		public int GetTakenCount()
		{
			int num = 0;
			using (Dictionary<int, ConditionTask>.ValueCollection.Enumerator enumerator = this.TaskById.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == ConditionTaskState.ConditionTaskTaken)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060400E3 RID: 262371 RVA: 0x0106B2B0 File Offset: 0x010694B0
		public int GetTotalCount()
		{
			return this.TaskById.Count;
		}

		// Token: 0x060400E4 RID: 262372 RVA: 0x0106B2C0 File Offset: 0x010694C0
		public bool IsAllTaken()
		{
			if (this.TaskById.Count <= 0)
			{
				return false;
			}
			using (Dictionary<int, ConditionTask>.ValueCollection.Enumerator enumerator = this.TaskById.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status != ConditionTaskState.ConditionTaskTaken)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060400E5 RID: 262373 RVA: 0x0106B330 File Offset: 0x01069530
		public bool HasRedDot()
		{
			using (Dictionary<int, ConditionTask>.ValueCollection.Enumerator enumerator = this.TaskById.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == ConditionTaskState.ConditionTaskFinish)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060400E6 RID: 262374 RVA: 0x0106B390 File Offset: 0x01069590
		private int GetStatusSortWeight(int taskId)
		{
			ConditionTask conditionTask;
			ConditionTaskState? conditionTaskState = this.TaskById.TryGetValue(taskId, out conditionTask) ? new ConditionTaskState?(conditionTask.Status) : null;
			if (conditionTaskState.GetValueOrDefault() == ConditionTaskState.ConditionTaskFinish)
			{
				return 0;
			}
			if (conditionTaskState.GetValueOrDefault() == ConditionTaskState.ConditionTaskTaken)
			{
				return 2;
			}
			return 1;
		}

		// Token: 0x04023F68 RID: 147304
		public int ActivityId;

		// Token: 0x04023F69 RID: 147305
		private readonly Dictionary<int, ConditionTask> TaskById = new Dictionary<int, ConditionTask>();
	}
}
