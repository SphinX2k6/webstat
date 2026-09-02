using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200606B RID: 24683
	public class StepConditionIndexChangeProcess : TPendingProcess
	{
		// Token: 0x0603E3F6 RID: 254966 RVA: 0x00FE4075 File Offset: 0x00FE2275
		public StepConditionIndexChangeProcess(EMissionItemView viewId, int stepId, int? curConditionTextIndex)
		{
		}

		// Token: 0x17009AC8 RID: 39624
		// (get) Token: 0x0603E3F7 RID: 254967 RVA: 0x00FE4092 File Offset: 0x00FE2292
		public override EMissionProcessType ProcessType
		{
			get
			{
				return EMissionProcessType.StepConditionIndexChange;
			}
		}

		// Token: 0x17009AC9 RID: 39625
		// (get) Token: 0x0603E3F8 RID: 254968 RVA: 0x00FE4095 File Offset: 0x00FE2295
		public override bool IsSkipAnim
		{
			get
			{
				return false;
			}
		}

		// Token: 0x04022E48 RID: 142920
		public readonly EMissionItemView ViewId = viewId;

		// Token: 0x04022E49 RID: 142921
		public readonly int StepId = stepId;

		// Token: 0x04022E4A RID: 142922
		public readonly int? CurConditionTextIndex = curConditionTextIndex;
	}
}
