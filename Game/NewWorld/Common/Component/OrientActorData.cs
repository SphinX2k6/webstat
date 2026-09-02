using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048CB RID: 18635
	[NullableContext(1)]
	[Nullable(0)]
	internal class OrientActorData
	{
		// Token: 0x060309DF RID: 199135 RVA: 0x00BF68ED File Offset: 0x00BF4AED
		public OrientActorData(AActor origin, BaseActorComponent target)
		{
			this.OriginActor = origin;
			this.TargetActor = target;
		}

		// Token: 0x0401BF02 RID: 114434
		public AActor OriginActor;

		// Token: 0x0401BF03 RID: 114435
		public BaseActorComponent TargetActor;
	}
}
