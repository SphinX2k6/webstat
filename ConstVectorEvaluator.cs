using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E25 RID: 3621
public class ConstVectorEvaluator : IVectorParamEvaluator
{
	// Token: 0x060055A5 RID: 21925 RVA: 0x000E1912 File Offset: 0x000DFB12
	public ConstVectorEvaluator(FVector vec)
	{
	}

	// Token: 0x060055A6 RID: 21926 RVA: 0x000E1921 File Offset: 0x000DFB21
	public FVector GetValue(float t)
	{
		return this.<vec>P;
	}

	// Token: 0x04001AED RID: 6893
	[CompilerGenerated]
	private FVector <vec>P = vec;
}
