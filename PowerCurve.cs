using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BFD RID: 3069
public class PowerCurve : CurveBase
{
	// Token: 0x060032BC RID: 12988 RVA: 0x0002465C File Offset: 0x0002285C
	[NullableContext(1)]
	public PowerCurve(params float[] @params) : base(Array.Empty<float>())
	{
		if (@params[0] < 0f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Core;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "幂函数N值不合法，自动修复为0";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("StartSlope", @params[0]);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.N = 0f;
			return;
		}
		this.N = @params[0];
	}

	// Token: 0x060032BD RID: 12989 RVA: 0x000246C0 File Offset: 0x000228C0
	public override float GetCurrentValueInternal(float key)
	{
		float value = 2f * key - 1f;
		return (float)((double)Math.Sign(value) * Math.Pow((double)Math.Abs(value), (double)this.N) * 0.5 + 0.5);
	}

	// Token: 0x04000582 RID: 1410
	private readonly float N;
}
