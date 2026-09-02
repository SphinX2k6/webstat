using System;
using System.Runtime.CompilerServices;

// Token: 0x020030BE RID: 12478
[NullableContext(1)]
[Nullable(0)]
public class RotateBoneItem
{
	// Token: 0x06019B73 RID: 105331 RVA: 0x0077BC4E File Offset: 0x00779E4E
	public void Set(float startAlpha, float endAlpha, CurveBase curve = null)
	{
		this.StartAlpha = startAlpha;
		this.EndAlpha = endAlpha;
		this.Curve = (curve ?? CurveUtils.DefaultCubic);
	}

	// Token: 0x06019B74 RID: 105332 RVA: 0x0077BC6E File Offset: 0x00779E6E
	public float GetBoneAlpha(float time)
	{
		return Singleton<MathUtils>.Instance.Lerp(this.StartAlpha, this.EndAlpha, this.Curve.GetCurrentValue(time));
	}

	// Token: 0x0400CCD6 RID: 52438
	private float StartAlpha;

	// Token: 0x0400CCD7 RID: 52439
	private float EndAlpha = 1f;

	// Token: 0x0400CCD8 RID: 52440
	private CurveBase Curve = CurveUtils.DefaultCubic;
}
