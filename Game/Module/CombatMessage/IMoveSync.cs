using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.CombatMessage
{
	// Token: 0x02005E93 RID: 24211
	[NullableContext(1)]
	public interface IMoveSync
	{
		// Token: 0x1700997D RID: 39293
		// (get) Token: 0x0603CE16 RID: 249366
		Entity Entity { get; }

		// Token: 0x1700997E RID: 39294
		// (get) Token: 0x0603CE17 RID: 249367
		List<MoveReplaySample> PendingMoveInfos { get; }

		// Token: 0x0603CE18 RID: 249368
		[NullableContext(2)]
		MovingEntityData CollectPendingMoveInfos();
	}
}
