using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Common.Component
{
	// Token: 0x02004881 RID: 18561
	[NullableContext(1)]
	[Nullable(0)]
	public class AiRacingPerceptionData
	{
		// Token: 0x0401BBC3 RID: 113603
		public Vector PlayerLocation = Vector.Create();

		// Token: 0x0401BBC4 RID: 113604
		public Vector SelfLocation = Vector.Create();

		// Token: 0x0401BBC5 RID: 113605
		public float DistanceBetween;

		// Token: 0x0401BBC6 RID: 113606
		public FSplineMoveDynamicSpeedData? SelfSplineMoveData;

		// Token: 0x0401BBC7 RID: 113607
		public Vector PlayerVelocity = Vector.Create();

		// Token: 0x0401BBC8 RID: 113608
		public float PlayerAbsSpeed;

		// Token: 0x0401BBC9 RID: 113609
		public Vector SelfEstimationVelocity = Vector.Create();

		// Token: 0x0401BBCA RID: 113610
		public float SelfAbsSpeed;

		// Token: 0x0401BBCB RID: 113611
		public float DeltaAbsSpeed;

		// Token: 0x0401BBCC RID: 113612
		public float SelfKeepMovingTime;
	}
}
