using System;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052D8 RID: 21208
	public class QuickHackSkillConditionResult
	{
		// Token: 0x060362C7 RID: 221895 RVA: 0x00DA50A1 File Offset: 0x00DA32A1
		public QuickHackSkillConditionResult(bool isSuccess, EQuickHackSkillCondition? failConditionType)
		{
		}

		// Token: 0x0401F20E RID: 127502
		public readonly bool IsSuccess = isSuccess;

		// Token: 0x0401F20F RID: 127503
		public readonly EQuickHackSkillCondition? FailConditionType = failConditionType;
	}
}
