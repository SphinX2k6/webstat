using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E23 RID: 3619
[NullableContext(1)]
[Nullable(0)]
public class CurveFloatEvaluator : IModifyParamEvaluator
{
	// Token: 0x060055A2 RID: 21922 RVA: 0x000E18A9 File Offset: 0x000DFAA9
	public CurveFloatEvaluator(UCurveVector curve, string axis)
	{
	}

	// Token: 0x060055A3 RID: 21923 RVA: 0x000E18C0 File Offset: 0x000DFAC0
	public float GetValue(float t)
	{
		FVector vectorValue = this.<curve>P.GetVectorValue(t);
		if (this.<axis>P == "X")
		{
			return vectorValue.X;
		}
		if (!(this.<axis>P == "Y"))
		{
			return vectorValue.Z;
		}
		return vectorValue.Y;
	}

	// Token: 0x04001AEB RID: 6891
	[CompilerGenerated]
	private UCurveVector <curve>P = curve;

	// Token: 0x04001AEC RID: 6892
	[CompilerGenerated]
	private string <axis>P = axis;
}
