using System;
using UnrealEngine;

// Token: 0x02000C04 RID: 3076
public class InterpCurvePointNumber : ICurvePoint<float>
{
	// Token: 0x060032CC RID: 13004 RVA: 0x00024A38 File Offset: 0x00022C38
	public InterpCurvePointNumber(global::EInterpCurveMode param)
	{
		this.InterpMode = param;
	}

	// Token: 0x060032CD RID: 13005 RVA: 0x00024A47 File Offset: 0x00022C47
	public InterpCurvePointNumber(UnrealEngine.EInterpCurveMode param)
	{
		this.InterpMode = SplineCurve.getTsInterpCurveMode(param);
	}

	// Token: 0x060032CE RID: 13006 RVA: 0x00024A5C File Offset: 0x00022C5C
	public void DeepCopy(FInterpCurvePointFloat param)
	{
		this.InVal = param.InVal;
		this.OutVal = param.OutVal;
		this.ArriveTangent = param.ArriveTangent;
		this.LeaveTangent = param.LeaveTangent;
		this.InterpMode = SplineCurve.getTsInterpCurveMode(param.InterpMode);
	}

	// Token: 0x060032CF RID: 13007 RVA: 0x00024AAF File Offset: 0x00022CAF
	public void Clear()
	{
		this.InVal = 0f;
		this.ArriveTangent = 0f;
		this.LeaveTangent = 0f;
		this.OutVal = 0f;
	}

	// Token: 0x04000593 RID: 1427
	public global::EInterpCurveMode InterpMode;
}
