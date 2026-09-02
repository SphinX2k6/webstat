using System;

namespace CSharpScript.Game.LevelFlow
{
	// Token: 0x02006F73 RID: 28531
	public enum ELevelFlowNodeState
	{
		// Token: 0x04026859 RID: 157785
		Idle,
		// Token: 0x0402685A RID: 157786
		WaitingCondition,
		// Token: 0x0402685B RID: 157787
		RunningAction,
		// Token: 0x0402685C RID: 157788
		Success,
		// Token: 0x0402685D RID: 157789
		Failure
	}
}
