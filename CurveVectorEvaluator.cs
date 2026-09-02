using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E26 RID: 3622
public class CurveVectorEvaluator : IVectorParamEvaluator
{
	// Token: 0x060055A7 RID: 21927 RVA: 0x000E1929 File Offset: 0x000DFB29
	[NullableContext(1)]
	public CurveVectorEvaluator(UCurveVector curve)
	{
	}

	// Token: 0x060055A8 RID: 21928 RVA: 0x000E1938 File Offset: 0x000DFB38
	public FVector GetValue(float t)
	{
		return this.<curve>P.GetVectorValue(t);
	}

	// Token: 0x04001AEE RID: 6894
	[Nullable(1)]
	[CompilerGenerated]
	private UCurveVector <curve>P = curve;
}
