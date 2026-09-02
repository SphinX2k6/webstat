using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BF3 RID: 3059
public class RichCurveKeyHandle
{
	// Token: 0x06003299 RID: 12953 RVA: 0x0002380C File Offset: 0x00021A0C
	public RichCurveKeyHandle()
	{
	}

	// Token: 0x0600329A RID: 12954 RVA: 0x00023814 File Offset: 0x00021A14
	[NullableContext(2)]
	public RichCurveKeyHandle(RichCurveKeyHandle richCurveKey = null)
	{
		if (richCurveKey == null)
		{
			return;
		}
		this.ArriveTangent = richCurveKey.ArriveTangent;
		this.ArriveTangentWeight = richCurveKey.ArriveTangentWeight;
		this.InterpMode = richCurveKey.InterpMode;
		this.LeaveTangent = richCurveKey.LeaveTangent;
		this.LeaveTangentWeight = richCurveKey.LeaveTangentWeight;
		this.TangentMode = richCurveKey.TangentMode;
		this.TangentWeightMode = richCurveKey.TangentWeightMode;
		this.Time = richCurveKey.Time;
		this.Value = richCurveKey.Value;
	}

	// Token: 0x0600329B RID: 12955 RVA: 0x00023898 File Offset: 0x00021A98
	public RichCurveKeyHandle(FRichCurveKey? richCurveKey = null)
	{
		if (richCurveKey == null)
		{
			return;
		}
		FRichCurveKey value = richCurveKey.Value;
		this.ArriveTangent = value.ArriveTangent;
		this.ArriveTangentWeight = value.ArriveTangentWeight;
		this.InterpMode = value.InterpMode;
		this.LeaveTangent = value.LeaveTangent;
		this.LeaveTangentWeight = value.LeaveTangentWeight;
		this.TangentMode = value.TangentMode;
		this.TangentWeightMode = value.TangentWeightMode;
		this.Time = value.Time;
		this.Value = value.Value;
	}

	// Token: 0x0600329C RID: 12956 RVA: 0x00023938 File Offset: 0x00021B38
	public FRichCurveKey ToUeRichCurveKey()
	{
		return new FRichCurveKey(this.InterpMode, this.TangentMode, this.TangentWeightMode, this.Time, this.Value, this.ArriveTangent, this.ArriveTangentWeight, this.LeaveTangent, this.LeaveTangentWeight);
	}

	// Token: 0x0400055C RID: 1372
	public float ArriveTangent;

	// Token: 0x0400055D RID: 1373
	public float ArriveTangentWeight;

	// Token: 0x0400055E RID: 1374
	public ERichCurveInterpMode InterpMode;

	// Token: 0x0400055F RID: 1375
	public float LeaveTangent;

	// Token: 0x04000560 RID: 1376
	public float LeaveTangentWeight;

	// Token: 0x04000561 RID: 1377
	public ERichCurveTangentMode TangentMode;

	// Token: 0x04000562 RID: 1378
	public ERichCurveTangentWeightMode TangentWeightMode;

	// Token: 0x04000563 RID: 1379
	public float Time;

	// Token: 0x04000564 RID: 1380
	public float Value;
}
