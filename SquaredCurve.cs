using System;
using System.Runtime.CompilerServices;

// Token: 0x02000C06 RID: 3078
public class SquaredCurve : CurveBase
{
	// Token: 0x0600330B RID: 13067 RVA: 0x0002769C File Offset: 0x0002589C
	[NullableContext(1)]
	public SquaredCurve(params float[] @params) : base(Array.Empty<float>())
	{
		if (@params[0] < 0f || @params[0] > 2f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Core;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "二阶曲线配置的Slope不合法，必须大于等于0小于等于2。自动修复为1";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("StartSlope", @params[0]);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.A = 0f;
			this.B = 1f;
			return;
		}
		this.A = 1f - @params[0];
		this.B = @params[0];
	}

	// Token: 0x0600330C RID: 13068 RVA: 0x0002772E File Offset: 0x0002592E
	public override float GetCurrentValueInternal(float key)
	{
		return (this.A * key + this.B) * key;
	}

	// Token: 0x040005B3 RID: 1459
	private readonly float A;

	// Token: 0x040005B4 RID: 1460
	private readonly float B = 1f;
}
