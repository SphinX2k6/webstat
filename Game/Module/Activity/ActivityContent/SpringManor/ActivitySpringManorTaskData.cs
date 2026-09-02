using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x020062FE RID: 25342
	public class ActivitySpringManorTaskData
	{
		// Token: 0x0603FB83 RID: 260995 RVA: 0x010561F0 File Offset: 0x010543F0
		[NullableContext(1)]
		public void Refresh(ConditionTask taskData)
		{
			this.Status = TaskStateResolver.ConditionState[taskData.Status];
			this.Current = taskData.Current;
			this.Target = taskData.Target;
			if (this.Id != taskData.Id)
			{
				SpringFestivalReward? springFestivalReward;
				this.Sort = ((ConfigBase<SpringManorConfig>.Instance.GetRewardTaskConfigById(taskData.Id) != null) ? springFestivalReward.GetValueOrDefault().Sort : 1);
			}
			this.Id = taskData.Id;
		}

		// Token: 0x04023C1D RID: 146461
		public int Id;

		// Token: 0x04023C1E RID: 146462
		public EActivityTaskState Status = EActivityTaskState.Active;

		// Token: 0x04023C1F RID: 146463
		public int Current;

		// Token: 0x04023C20 RID: 146464
		public int Target;

		// Token: 0x04023C21 RID: 146465
		public int Sort;
	}
}
