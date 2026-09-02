using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BFB RID: 3067
public class FloatCurve : CurveBase
{
	// Token: 0x060032B7 RID: 12983 RVA: 0x0002461B File Offset: 0x0002281B
	[NullableContext(1)]
	public FloatCurve(UCurveFloat floatCurve) : base(Array.Empty<float>())
	{
		this.CurveFloat = floatCurve;
	}

	// Token: 0x060032B8 RID: 12984 RVA: 0x0002462F File Offset: 0x0002282F
	public override float GetCurrentValueInternal(float key)
	{
		return this.CurveFloat.GetFloatValue(key);
	}

	// Token: 0x060032B9 RID: 12985 RVA: 0x0002463D File Offset: 0x0002283D
	public float GetCurrentValueByTime(float time)
	{
		return this.CurveFloat.GetFloatValue(time);
	}

	// Token: 0x04000581 RID: 1409
	[Nullable(2)]
	private readonly UCurveFloat CurveFloat;
}
