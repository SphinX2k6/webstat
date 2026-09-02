using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069AC RID: 27052
	public class CoopMapTaskSubConditionData2 : CoopSubConditionDataBase
	{
		// Token: 0x06043166 RID: 274790 RVA: 0x0113B340 File Offset: 0x01139540
		public CoopMapTaskSubConditionData2(int id, ECoopSubConditionType taskType) : base(id, taskType)
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(id);
			if (coopTaskConfigById == null)
			{
				return;
			}
			this.Title = (coopTaskConfigById.Value.TaskTitle4 ?? "");
		}

		// Token: 0x06043167 RID: 274791 RVA: 0x0113B389 File Offset: 0x01139589
		public override bool IsShowJumpBtn()
		{
			return true;
		}

		// Token: 0x06043168 RID: 274792 RVA: 0x0113B38C File Offset: 0x0113958C
		public override bool IsTaskDone()
		{
			return this.IsTask4Done;
		}

		// Token: 0x06043169 RID: 274793 RVA: 0x0113B394 File Offset: 0x01139594
		[NullableContext(1)]
		public override void RefreshData(CoopTaskCompleteInfo data)
		{
			this.IsTask4Done = data.LevelPlay2Done;
		}

		// Token: 0x0604316A RID: 274794 RVA: 0x0113B3A4 File Offset: 0x011395A4
		public override void OnJumpClick()
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(this.Id);
			if (coopTaskConfigById != null && coopTaskConfigById.Value.LevelId2 != 0 && coopTaskConfigById.Value.TraceMarkId4 != 0)
			{
				base.JumpMapMark(coopTaskConfigById.Value.LevelId2, coopTaskConfigById.Value.TraceMarkId4);
			}
		}

		// Token: 0x0402563B RID: 153147
		public bool IsTask4Done;
	}
}
