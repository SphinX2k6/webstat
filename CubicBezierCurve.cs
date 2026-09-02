using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BF5 RID: 3061
public class CubicBezierCurve : CurveBase
{
	// Token: 0x060032A5 RID: 12965 RVA: 0x00023E80 File Offset: 0x00022080
	[NullableContext(1)]
	public CubicBezierCurve(params float[] parameters) : base(Array.Empty<float>())
	{
		float num = parameters[0];
		float num2 = parameters[1];
		float num3 = parameters[2];
		float num4 = parameters[3];
		this.Cx = 3f * num;
		this.Bx = 3f * (num3 - num) - this.Cx;
		this.Ax = 1f - this.Cx - this.Bx;
		this.Cy = 3f * num2;
		this.By = 3f * (num4 - num2) - this.Cy;
		this.Ay = 1f - this.Cy - this.By;
	}

	// Token: 0x060032A6 RID: 12966 RVA: 0x00023F38 File Offset: 0x00022138
	public override float GetCurrentValueInternal(float key)
	{
		if (key <= 0f)
		{
			return 0f;
		}
		if (key >= 1f)
		{
			return 1f;
		}
		float num = key;
		for (int i = 0; i < CubicBezierCurve.NEWTON_ITERATIONS; i++)
		{
			float num2 = ((this.Ax * num + this.Bx) * num + this.Cx) * num - key;
			if (Singleton<MathUtils>.Instance.IsNearlyZero((double)Math.Abs(num2), new double?(0.0001)))
			{
				break;
			}
			float num3 = (3f * this.Ax * num + 2f * this.Bx) * num + this.Cx;
			num -= num2 / num3;
		}
		return ((this.Ay * num + this.By) * num + this.Cy) * num;
	}

	// Token: 0x0400056A RID: 1386
	private static readonly int NEWTON_ITERATIONS = 6;

	// Token: 0x0400056B RID: 1387
	private readonly float Ax;

	// Token: 0x0400056C RID: 1388
	private readonly float Bx;

	// Token: 0x0400056D RID: 1389
	private readonly float Cx = 1f;

	// Token: 0x0400056E RID: 1390
	private readonly float Ay;

	// Token: 0x0400056F RID: 1391
	private readonly float By;

	// Token: 0x04000570 RID: 1392
	private readonly float Cy = 1f;
}
