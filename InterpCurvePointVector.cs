using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C02 RID: 3074
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class InterpCurvePointVector : ICurvePoint<Vector>
{
	// Token: 0x060032C3 RID: 12995 RVA: 0x00024851 File Offset: 0x00022A51
	public InterpCurvePointVector(global::EInterpCurveMode param)
	{
		this.InterpMode = param;
	}

	// Token: 0x060032C4 RID: 12996 RVA: 0x00024860 File Offset: 0x00022A60
	public InterpCurvePointVector(UnrealEngine.EInterpCurveMode param)
	{
		this.InterpMode = SplineCurve.getTsInterpCurveMode(param);
	}

	// Token: 0x060032C5 RID: 12997 RVA: 0x00024874 File Offset: 0x00022A74
	public void DeepCopy(InterpCurvePointVector param)
	{
		this.InVal = param.InVal;
		this.OutVal.DeepCopy(param.OutVal);
		this.ArriveTangent.DeepCopy(param.ArriveTangent);
		this.LeaveTangent.DeepCopy(param.LeaveTangent);
		this.InterpMode = param.InterpMode;
	}

	// Token: 0x060032C6 RID: 12998 RVA: 0x000248CC File Offset: 0x00022ACC
	public void DeepCopy(FInterpCurvePointVector param)
	{
		this.InVal = param.InVal;
		Vector outVal = this.OutVal;
		FVectorDouble fvectorDouble = param.OutVal;
		outVal.DeepCopy(fvectorDouble);
		Vector arriveTangent = this.ArriveTangent;
		fvectorDouble = param.ArriveTangent;
		arriveTangent.DeepCopy(fvectorDouble);
		Vector leaveTangent = this.LeaveTangent;
		fvectorDouble = param.LeaveTangent;
		leaveTangent.DeepCopy(fvectorDouble);
		this.InterpMode = SplineCurve.getTsInterpCurveMode(param.InterpMode);
	}

	// Token: 0x060032C7 RID: 12999 RVA: 0x00024949 File Offset: 0x00022B49
	public void Clear()
	{
		this.InVal = 0f;
		this.ArriveTangent.Reset();
		this.LeaveTangent.Reset();
		this.OutVal.Reset();
	}

	// Token: 0x04000591 RID: 1425
	public global::EInterpCurveMode InterpMode;
}
