using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069B0 RID: 27056
	public class CoopTimeMapTaskSubConditionData : CoopSubConditionDataBase
	{
		// Token: 0x06043178 RID: 274808 RVA: 0x0113B758 File Offset: 0x01139958
		public CoopTimeMapTaskSubConditionData(int id, ECoopSubConditionType taskType) : base(id, taskType)
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(id);
			if (coopTaskConfigById == null)
			{
				return;
			}
			this.Title = (coopTaskConfigById.Value.TaskTitle5 ?? "");
		}

		// Token: 0x06043179 RID: 274809 RVA: 0x0113B7A4 File Offset: 0x011399A4
		public override bool IsTaskDone()
		{
			if (this.UnlockTime == 0L)
			{
				return false;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return (double)this.UnlockTime <= serverTime;
		}

		// Token: 0x0604317A RID: 274810 RVA: 0x0113B7D3 File Offset: 0x011399D3
		[NullableContext(1)]
		public override void RefreshData(CoopTaskCompleteInfo data)
		{
			this.UnlockTime = data.UnLockTime;
		}

		// Token: 0x04025643 RID: 153155
		public long UnlockTime;
	}
}
