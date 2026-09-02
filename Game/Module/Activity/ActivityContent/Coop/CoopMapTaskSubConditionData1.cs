using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069AB RID: 27051
	public class CoopMapTaskSubConditionData1 : CoopSubConditionDataBase
	{
		// Token: 0x06043161 RID: 274785 RVA: 0x0113B26C File Offset: 0x0113946C
		public CoopMapTaskSubConditionData1(int id, ECoopSubConditionType taskType) : base(id, taskType)
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(id);
			if (coopTaskConfigById == null)
			{
				return;
			}
			this.Title = (coopTaskConfigById.Value.TaskTitle3 ?? "");
		}

		// Token: 0x06043162 RID: 274786 RVA: 0x0113B2B5 File Offset: 0x011394B5
		public override bool IsShowJumpBtn()
		{
			return true;
		}

		// Token: 0x06043163 RID: 274787 RVA: 0x0113B2B8 File Offset: 0x011394B8
		public override bool IsTaskDone()
		{
			return this.IsTask3Done;
		}

		// Token: 0x06043164 RID: 274788 RVA: 0x0113B2C0 File Offset: 0x011394C0
		[NullableContext(1)]
		public override void RefreshData(CoopTaskCompleteInfo data)
		{
			this.IsTask3Done = data.LevelPlay1Done;
		}

		// Token: 0x06043165 RID: 274789 RVA: 0x0113B2D0 File Offset: 0x011394D0
		public override void OnJumpClick()
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(this.Id);
			if (coopTaskConfigById != null && coopTaskConfigById.Value.LevelId1 != 0 && coopTaskConfigById.Value.TraceMarkId3 != 0)
			{
				base.JumpMapMark(coopTaskConfigById.Value.LevelId1, coopTaskConfigById.Value.TraceMarkId3);
			}
		}

		// Token: 0x0402563A RID: 153146
		public bool IsTask3Done;
	}
}
