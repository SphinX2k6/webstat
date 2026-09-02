using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069AD RID: 27053
	public class CoopPreTaskSubConditionData : CoopSubConditionDataBase
	{
		// Token: 0x0604316B RID: 274795 RVA: 0x0113B414 File Offset: 0x01139614
		public CoopPreTaskSubConditionData(int id, ECoopSubConditionType taskType) : base(id, taskType)
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(id);
			if (coopTaskConfigById == null)
			{
				return;
			}
			this.CoopPreQuestId = coopTaskConfigById.Value.CoopPreQuest;
			this.Title = "Coop_Role_Condition_Task";
		}

		// Token: 0x0604316C RID: 274796 RVA: 0x0113B45F File Offset: 0x0113965F
		public override bool IsTaskDone()
		{
			return this.CoopPreQuestId != 0 && ModelBase<QuestNewModel>.Instance.CheckQuestFinished(this.CoopPreQuestId);
		}

		// Token: 0x0402563C RID: 153148
		public int CoopPreQuestId;
	}
}
