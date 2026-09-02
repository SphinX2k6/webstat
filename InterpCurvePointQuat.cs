using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C03 RID: 3075
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class InterpCurvePointQuat : ICurvePoint<Quat>
{
	// Token: 0x060032C8 RID: 13000 RVA: 0x00024977 File Offset: 0x00022B77
	public InterpCurvePointQuat(global::EInterpCurveMode param)
	{
		this.InterpMode = param;
	}

	// Token: 0x060032C9 RID: 13001 RVA: 0x0002498D File Offset: 0x00022B8D
	public InterpCurvePointQuat(UnrealEngine.EInterpCurveMode param)
	{
		this.InterpMode = SplineCurve.getTsInterpCurveMode(param);
	}

	// Token: 0x060032CA RID: 13002 RVA: 0x000249A8 File Offset: 0x00022BA8
	public void DeepCopy(FInterpCurvePointQuat param)
	{
		this.InVal = param.InVal;
		this.OutVal.DeepCopy(param.OutVal);
		this.ArriveTangent.DeepCopy(param.ArriveTangent);
		this.LeaveTangent.DeepCopy(param.LeaveTangent);
		this.InterpMode = SplineCurve.getTsInterpCurveMode(param.InterpMode);
	}

	// Token: 0x060032CB RID: 13003 RVA: 0x00024A0A File Offset: 0x00022C0A
	public void Clear()
	{
		this.InVal = 0f;
		this.ArriveTangent.Reset();
		this.LeaveTangent.Reset();
		this.OutVal.Reset();
	}

	// Token: 0x04000592 RID: 1426
	public global::EInterpCurveMode InterpMode = global::EInterpCurveMode.CurveAuto;
}
