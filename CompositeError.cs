using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020034DC RID: 13532
[NullableContext(1)]
[Nullable(0)]
public class CompositeError : Exception
{
	// Token: 0x0601C954 RID: 117076 RVA: 0x00891624 File Offset: 0x0088F824
	public CompositeError(List<Exception> errors, [Nullable(2)] string message = null)
	{
		string message2 = message;
		if (message == null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CompositeError (包含 ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(errors.Count);
			defaultInterpolatedStringHandler.AppendLiteral(" 个错误)");
			message2 = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		base..ctor(message2);
		this.Errors = errors;
		string text = "";
		for (int i = 0; i < errors.Count; i++)
		{
			Exception ex = errors[i];
			string str = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[错误 ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
			defaultInterpolatedStringHandler.AppendLiteral("] ");
			defaultInterpolatedStringHandler.AppendFormatted(ex.StackTrace ?? ex.Message);
			defaultInterpolatedStringHandler.AppendLiteral("\n\n");
			text = str + defaultInterpolatedStringHandler.ToStringAndClear();
		}
		this.Data["FullStackTrace"] = this.StackTrace + " " + text;
	}

	// Token: 0x0400E638 RID: 58936
	public readonly List<Exception> Errors = new List<Exception>();
}
