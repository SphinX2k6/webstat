using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x020055FF RID: 22015
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCardTaskData
	{
		// Token: 0x17009023 RID: 36899
		// (get) Token: 0x060381AB RID: 229803 RVA: 0x00E35A31 File Offset: 0x00E33C31
		// (set) Token: 0x060381AC RID: 229804 RVA: 0x00E35A39 File Offset: 0x00E33C39
		public bool IsOwn { get; private set; }

		// Token: 0x060381AD RID: 229805 RVA: 0x00E35A42 File Offset: 0x00E33C42
		public PhantomArenaCardTaskData(bool isOwn)
		{
			this.IsOwn = isOwn;
		}

		// Token: 0x17009024 RID: 36900
		// (get) Token: 0x060381AE RID: 229806 RVA: 0x00E35A5C File Offset: 0x00E33C5C
		public bool IsAllFinish
		{
			get
			{
				return this.IsAllFinishInternal;
			}
		}

		// Token: 0x17009025 RID: 36901
		// (get) Token: 0x060381AF RID: 229807 RVA: 0x00E35A64 File Offset: 0x00E33C64
		public int AllTaskNum
		{
			get
			{
				return this.TaskInfoList.Count;
			}
		}

		// Token: 0x060381B0 RID: 229808 RVA: 0x00E35A74 File Offset: 0x00E33C74
		public void SetTaskData(PhantomBattleGamerFourCTaskInfo data)
		{
			this.TaskInfoList = new List<PhantomBattleFourTaskInfo>(data.PhantomBattleFourTaskInfos);
			this.IsAllFinishInternal = data.IsFinish;
			this.TaskCardConfigId = data.CardConfId;
			this.FinishTaskNum = 0;
			using (List<PhantomBattleFourTaskInfo>.Enumerator enumerator = this.TaskInfoList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsFinish)
					{
						this.FinishTaskNum++;
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.NotifyCardTaskData, this.IsOwn);
		}

		// Token: 0x060381B1 RID: 229809 RVA: 0x00E35B1C File Offset: 0x00E33D1C
		public int GetConditionDescCurrentProgress(int conditionId)
		{
			int result = 0;
			foreach (PhantomBattleFourTaskInfo phantomBattleFourTaskInfo in this.TaskInfoList)
			{
				if (phantomBattleFourTaskInfo.ConditionId == conditionId)
				{
					result = phantomBattleFourTaskInfo.CurProgress;
				}
			}
			return result;
		}

		// Token: 0x04020112 RID: 131346
		private List<PhantomBattleFourTaskInfo> TaskInfoList = new List<PhantomBattleFourTaskInfo>();

		// Token: 0x04020113 RID: 131347
		private bool IsAllFinishInternal;

		// Token: 0x04020114 RID: 131348
		public int FinishTaskNum;

		// Token: 0x04020115 RID: 131349
		public bool IsExecuteFourCostLogic;

		// Token: 0x04020116 RID: 131350
		public int TaskCardConfigId;
	}
}
