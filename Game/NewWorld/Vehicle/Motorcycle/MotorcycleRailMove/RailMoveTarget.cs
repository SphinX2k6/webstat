using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047C9 RID: 18377
	[NullableContext(1)]
	[Nullable(0)]
	public class RailMoveTarget
	{
		// Token: 0x0401B4E7 RID: 111847
		public Vector TargetLoc = Vector.Create();

		// Token: 0x0401B4E8 RID: 111848
		public Rotator TargetRot = Rotator.Create();

		// Token: 0x0401B4E9 RID: 111849
		public Vector TargetVel = Vector.Create();

		// Token: 0x0401B4EA RID: 111850
		[Nullable(2)]
		public SplineCurve TargetSpline;

		// Token: 0x0401B4EB RID: 111851
		public float TargetSplineInputKey;

		// Token: 0x0401B4EC RID: 111852
		public float TargetSplineDist;

		// Token: 0x0401B4ED RID: 111853
		public Vector TargetSplineDir = Vector.Create();

		// Token: 0x0401B4EE RID: 111854
		public Rotator TargetSplineRot = Rotator.Create();

		// Token: 0x0401B4EF RID: 111855
		public bool IsForward;
	}
}
