using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047CA RID: 18378
	[NullableContext(1)]
	[Nullable(0)]
	public class RailMoveContext
	{
		// Token: 0x0401B4F0 RID: 111856
		public Vector SourceLoc = Vector.Create();

		// Token: 0x0401B4F1 RID: 111857
		public Rotator SourceRot = Rotator.Create();

		// Token: 0x0401B4F2 RID: 111858
		public Vector SourceVel = Vector.Create();

		// Token: 0x0401B4F3 RID: 111859
		[Nullable(2)]
		public SplineCurve RailSpline;

		// Token: 0x0401B4F4 RID: 111860
		public bool IsForward;

		// Token: 0x0401B4F5 RID: 111861
		public RailMoveTarget RailMoveTarget = new RailMoveTarget();
	}
}
