using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200493A RID: 18746
	[NullableContext(1)]
	[Nullable(0)]
	public class SplineRuntime
	{
		// Token: 0x0401C368 RID: 115560
		[Nullable(2)]
		public USplineComponent SourceSplineUe;

		// Token: 0x0401C369 RID: 115561
		public SplineCurve SourceSpline = new SplineCurve(10);

		// Token: 0x0401C36A RID: 115562
		public SplineCurve WallSpline = new SplineCurve(10);

		// Token: 0x0401C36B RID: 115563
		public float DistanceInSource;

		// Token: 0x0401C36C RID: 115564
		public float DistanceInWallSpline;
	}
}
