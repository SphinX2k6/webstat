using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BFE RID: 3070
public class PowerCurve2 : CurveBase
{
	// Token: 0x060032BE RID: 12990 RVA: 0x0002470C File Offset: 0x0002290C
	[NullableContext(1)]
	public PowerCurve2(params float[] @params) : base(Array.Empty<float>())
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

	// Token: 0x060032BF RID: 12991 RVA: 0x00024770 File Offset: 0x00022970
	public override float GetCurrentValueInternal(float key)
	{
		float value = 2f * key - 1f;
		return (float)(1.0 - (double)Math.Sign(value) * Math.Pow((double)Math.Abs(value), (double)this.N));
	}

	// Token: 0x04000583 RID: 1411
	private readonly float N;
}
