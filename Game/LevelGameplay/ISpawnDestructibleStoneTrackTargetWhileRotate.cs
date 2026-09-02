using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A27 RID: 27175
	[NullableContext(1)]
	[Nullable(0)]
	public class ISpawnDestructibleStoneTrackTargetWhileRotate : ILevelEventBlueprintToSpawnType
	{
		// Token: 0x04025818 RID: 153624
		public EBpTypeName? DestructibleStoneBlueprintType;

		// Token: 0x04025819 RID: 153625
		public EBpTypeName? TrackTargetWhileRotateBlueprintType;

		// Token: 0x0402581A RID: 153626
		public FTransformDouble StartTransform;

		// Token: 0x0402581B RID: 153627
		public APawn TargetToTrack;

		// Token: 0x0402581C RID: 153628
		public IFauxPhysicsRotateParam RotateParam;

		// Token: 0x0402581D RID: 153629
		public int DamageAmount;

		// Token: 0x0402581E RID: 153630
		[Nullable(2)]
		public Action Callback;
	}
}
