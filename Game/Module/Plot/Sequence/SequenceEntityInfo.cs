using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence
{
	// Token: 0x02005386 RID: 21382
	[NullableContext(1)]
	[Nullable(0)]
	public class SequenceEntityInfo
	{
		// Token: 0x060368A2 RID: 223394 RVA: 0x00DC90D8 File Offset: 0x00DC72D8
		[NullableContext(2)]
		public SequenceEntityInfo(int moveCompDisableHandle = -1, int ueMoveCompDisableHandle = -1, EMovementMode cacheMovementMode = EMovementMode.MOVE_None, bool cacheMovementSync = false, Vector cacheLocation = null, Rotator cacheRotation = null, bool cacheAiEnable = false, bool cacheDisableHumanIk = false)
		{
			this.MoveCompDisableHandle = moveCompDisableHandle;
			this.UeMoveCompDisableHandle = ueMoveCompDisableHandle;
			this.CacheMovementMode = cacheMovementMode;
			this.CacheMovementSync = cacheMovementSync;
			this.CacheLocation = (cacheLocation ?? Vector.Create());
			this.CacheRotation = (cacheRotation ?? Rotator.Create());
			this.CacheAiEnable = cacheAiEnable;
			this.CacheDisableHumanIk = cacheDisableHumanIk;
		}

		// Token: 0x0401F66A RID: 128618
		public int MoveCompDisableHandle = -1;

		// Token: 0x0401F66B RID: 128619
		public int UeMoveCompDisableHandle = -1;

		// Token: 0x0401F66C RID: 128620
		public EMovementMode CacheMovementMode;

		// Token: 0x0401F66D RID: 128621
		public bool CacheMovementSync;

		// Token: 0x0401F66E RID: 128622
		public Vector CacheLocation = Vector.Create();

		// Token: 0x0401F66F RID: 128623
		public Rotator CacheRotation = Rotator.Create();

		// Token: 0x0401F670 RID: 128624
		public bool CacheAiEnable;

		// Token: 0x0401F671 RID: 128625
		public bool CacheDisableHumanIk;
	}
}
