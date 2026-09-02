using System;

// Token: 0x02000BFC RID: 3068
public class LinearCurve : CurveBase
{
	// Token: 0x060032BA RID: 12986 RVA: 0x0002464B File Offset: 0x0002284B
	public override float GetCurrentValueInternal(float key)
	{
		return key;
	}

	// Token: 0x060032BB RID: 12987 RVA: 0x0002464E File Offset: 0x0002284E
	public LinearCurve() : base(Array.Empty<float>())
	{
	}
}
