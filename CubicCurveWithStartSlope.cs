using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BF7 RID: 3063
public class CubicCurveWithStartSlope : CurveBase
{
	// Token: 0x060032A9 RID: 12969 RVA: 0x0002406C File Offset: 0x0002226C
	[NullableContext(1)]
	public CubicCurveWithStartSlope(params float[] @params) : base(Array.Empty<float>())
	{
		if (@params[0] <= 0f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Core;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "三阶曲线配置的Slope不合法，必须大于0。自动修复为1";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("StartSlope", @params[0]);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.A = 0f;
			this.B = 0f;
			this.C = 1f;
			return;
		}
		this.A = @params[0] + 1f / @params[0] - 2f;
		this.B = 3f - 2f * @params[0] - 1f / @params[0];
		this.C = @params[0];
	}

	// Token: 0x060032AA RID: 12970 RVA: 0x00024128 File Offset: 0x00022328
	public override float GetCurrentValueInternal(float key)
	{
		return ((this.A * key + this.B) * key + this.C) * key;
	}

	// Token: 0x04000574 RID: 1396
	private readonly float A;

	// Token: 0x04000575 RID: 1397
	private readonly float B;

	// Token: 0x04000576 RID: 1398
	private readonly float C = 1f;
}
