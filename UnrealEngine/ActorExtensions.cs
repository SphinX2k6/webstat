using System;
using System.Runtime.CompilerServices;

namespace UnrealEngine
{
	// Token: 0x020043DB RID: 17371
	public static class ActorExtensions
	{
		// Token: 0x0602E280 RID: 189056 RVA: 0x00ADADEF File Offset: 0x00AD8FEF
		[NullableContext(1)]
		public static bool D_K2_SetActorTransform(this AActor actor, in FTransformDouble newTransform, bool bSweep, [Nullable(2)] FHitResult sweepHitResult, bool bTeleport)
		{
			return actor.D_K2_SetActorTransform(newTransform, bSweep, ref sweepHitResult, bTeleport);
		}
	}
}
