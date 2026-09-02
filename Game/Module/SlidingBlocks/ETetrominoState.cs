using System;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F05 RID: 20229
	public enum ETetrominoState
	{
		// Token: 0x0401E2AC RID: 123564
		Init,
		// Token: 0x0401E2AD RID: 123565
		Aiming,
		// Token: 0x0401E2AE RID: 123566
		WaitFallingEvent,
		// Token: 0x0401E2AF RID: 123567
		InitFallData,
		// Token: 0x0401E2B0 RID: 123568
		Falling,
		// Token: 0x0401E2B1 RID: 123569
		PlayLockEffect,
		// Token: 0x0401E2B2 RID: 123570
		Lock
	}
}
