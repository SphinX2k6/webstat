using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoDevelop
{
	// Token: 0x0200671D RID: 26397
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityMotorDevelopData : ActivityBaseData
	{
		// Token: 0x06041DB1 RID: 269745 RVA: 0x010E55D8 File Offset: 0x010E37D8
		protected override void PhraseEx(ActivityData data)
		{
			MotorDevelopActivityData motorDevelopActivityData = data.MotorDevelopActivityData;
			RepeatedField<ConditionTask> repeatedField = (motorDevelopActivityData != null) ? motorDevelopActivityData.Task : null;
			if (repeatedField == null)
			{
				return;
			}
			this.InitMotorDevelopTask(repeatedField);
		}

		// Token: 0x06041DB2 RID: 269746 RVA: 0x010E5604 File Offset: 0x010E3804
		public void InitMotorDevelopTask(IReadOnlyList<ConditionTask> tasks)
		{
			this.TaskMap.Clear();
			foreach (ConditionTask conditionTask in tasks)
			{
				this.TaskMap[conditionTask.Id] = conditionTask;
			}
		}

		// Token: 0x06041DB3 RID: 269747 RVA: 0x010E5664 File Offset: 0x010E3864
		public void UpdateMotorDevelopTask(IReadOnlyList<ConditionTask> tasks)
		{
			foreach (ConditionTask conditionTask in tasks)
			{
				this.TaskMap[conditionTask.Id] = conditionTask;
			}
		}

		// Token: 0x06041DB4 RID: 269748 RVA: 0x010E56B8 File Offset: 0x010E38B8
		public List<ConditionTask> GetMotorDevelopTaskList()
		{
			return new List<ConditionTask>(this.TaskMap.Values);
		}

		// Token: 0x06041DB5 RID: 269749 RVA: 0x010E56CA File Offset: 0x010E38CA
		public void SetActivityFirstUnlockUnReadFlag(int flagId)
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SaveActivityData(base.Id, 2, 0, 0, flagId);
		}

		// Token: 0x06041DB6 RID: 269750 RVA: 0x010E56E5 File Offset: 0x010E38E5
		public void CheckAndCloseFirstUnlockReadFlag()
		{
			if (base.IsUnLock())
			{
				this.SetActivityFirstUnlockUnReadFlag(0);
			}
		}

		// Token: 0x06041DB7 RID: 269751 RVA: 0x010E56F8 File Offset: 0x010E38F8
		public override bool GetExDataRedPointShowState()
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			int? num = (instance != null) ? new int?(instance.GetActivityCacheData(base.Id, 0, 1, 0, 0)) : null;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					return true;
				}
			}
			ActivityModel instance2 = ModelBase<ActivityModel>.Instance;
			int? num4 = (instance2 != null) ? new int?(instance2.GetActivityCacheData(base.Id, 0, 2, 0, 0)) : null;
			if (num4 != null)
			{
				int? num2 = num4;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					return true;
				}
			}
			using (List<ConditionTask>.Enumerator enumerator = new List<ConditionTask>(this.TaskMap.Values).GetEnumerator())
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

		// Token: 0x06041DB8 RID: 269752 RVA: 0x010E57F8 File Offset: 0x010E39F8
		protected override bool GetExDataFinishShowState()
		{
			using (List<ConditionTask>.Enumerator enumerator = new List<ConditionTask>(this.TaskMap.Values).GetEnumerator())
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

		// Token: 0x04024BFA RID: 150522
		private const int FIRSTOPEN = 1;

		// Token: 0x04024BFB RID: 150523
		private const int FIRSTUNLOCK = 2;

		// Token: 0x04024BFC RID: 150524
		private readonly Dictionary<int, ConditionTask> TaskMap = new Dictionary<int, ConditionTask>();
	}
}
