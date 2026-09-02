using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D48 RID: 3400
[NullableContext(1)]
[Nullable(0)]
internal class FixOffsetParams
{
	// Token: 0x040013DE RID: 5086
	public readonly Vector DeltaPos = Vector.Create();

	// Token: 0x040013DF RID: 5087
	public float DeltaYaw;

	// Token: 0x040013E0 RID: 5088
	public float TotalDuration;

	// Token: 0x040013E1 RID: 5089
	public readonly CurveChannel ChX = new CurveChannel();

	// Token: 0x040013E2 RID: 5090
	public readonly CurveChannel ChY = new CurveChannel();

	// Token: 0x040013E3 RID: 5091
	public readonly CurveChannel ChZ = new CurveChannel();

	// Token: 0x040013E4 RID: 5092
	public readonly CurveChannel ChLook = new CurveChannel();

	// Token: 0x040013E5 RID: 5093
	public float AppliedX;

	// Token: 0x040013E6 RID: 5094
	public float AppliedY;

	// Token: 0x040013E7 RID: 5095
	public float AppliedZ;
}
