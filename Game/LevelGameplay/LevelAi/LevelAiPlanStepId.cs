using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E12 RID: 28178
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiPlanStepId
	{
		// Token: 0x06044688 RID: 280200 RVA: 0x011C51E1 File Offset: 0x011C33E1
		public LevelAiPlanStepId(int levelIndex = -1, int stepIndex = -1)
		{
			this.LevelIndex = levelIndex;
			this.StepIndex = stepIndex;
		}

		// Token: 0x06044689 RID: 280201 RVA: 0x011C51F7 File Offset: 0x011C33F7
		public void Reset()
		{
			this.LevelIndex = -1;
			this.StepIndex = -1;
		}

		// Token: 0x0604468A RID: 280202 RVA: 0x011C5207 File Offset: 0x011C3407
		public void CopyFrom(LevelAiPlanStepId other)
		{
			this.LevelIndex = other.LevelIndex;
			this.StepIndex = other.StepIndex;
		}

		// Token: 0x0604468B RID: 280203 RVA: 0x011C5221 File Offset: 0x011C3421
		public bool Equal(LevelAiPlanStepId other)
		{
			return this.LevelIndex == other.LevelIndex && this.StepIndex == other.StepIndex;
		}

		// Token: 0x0604468C RID: 280204 RVA: 0x011C5241 File Offset: 0x011C3441
		public static bool Equal(LevelAiPlanStepId l, LevelAiPlanStepId r)
		{
			return l.LevelIndex == r.LevelIndex && l.StepIndex == r.StepIndex;
		}

		// Token: 0x04026129 RID: 155945
		[StaticVariableRuleIgnore]
		public static readonly LevelAiPlanStepId None = new LevelAiPlanStepId(-1, -1);

		// Token: 0x0402612A RID: 155946
		public int LevelIndex;

		// Token: 0x0402612B RID: 155947
		public int StepIndex;
	}
}
