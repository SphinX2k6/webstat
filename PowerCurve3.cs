using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BFF RID: 3071
public class PowerCurve3 : CurveBase
{
	// Token: 0x060032C0 RID: 12992 RVA: 0x000247B4 File Offset: 0x000229B4
	[NullableContext(1)]
	public PowerCurve3(params float[] @params) : base(Array.Empty<float>())
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

	// Token: 0x060032C1 RID: 12993 RVA: 0x00024817 File Offset: 0x00022A17
	public override float GetCurrentValueInternal(float key)
	{
		return (float)Math.Pow((double)key, (double)this.N);
	}

	// Token: 0x04000584 RID: 1412
	private readonly float N;
}
