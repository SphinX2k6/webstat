using System;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AC3 RID: 27331
	public enum ESplineMoveState
	{
		// Token: 0x04025C4B RID: 154699
		None,
		// Token: 0x04025C4C RID: 154700
		Start,
		// Token: 0x04025C4D RID: 154701
		Prepare,
		// Token: 0x04025C4E RID: 154702
		MoveToStartPoint,
		// Token: 0x04025C4F RID: 154703
		SplineMove,
		// Token: 0x04025C50 RID: 154704
		WaitEnd,
		// Token: 0x04025C51 RID: 154705
		End
	}
}
