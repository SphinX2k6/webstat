using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BF6 RID: 3062
public class CubicCurve : CurveBase
{
	// Token: 0x060032A7 RID: 12967 RVA: 0x00023FF8 File Offset: 0x000221F8
	[NullableContext(1)]
	public CubicCurve(params float[] @params) : base(Array.Empty<float>())
	{
		this.A = -2f * (1f - @params[0]);
		this.B = 3f * (1f - @params[0]);
		this.C = @params[0];
	}

	// Token: 0x060032A8 RID: 12968 RVA: 0x0002404E File Offset: 0x0002224E
	public override float GetCurrentValueInternal(float key)
	{
		return ((this.A * key + this.B) * key + this.C) * key;
	}

	// Token: 0x04000571 RID: 1393
	private readonly float A;

	// Token: 0x04000572 RID: 1394
	private readonly float B;

	// Token: 0x04000573 RID: 1395
	private readonly float C = 1f;
}
