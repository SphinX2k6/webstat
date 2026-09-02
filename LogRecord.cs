using System;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;

// Token: 0x02000048 RID: 72
[NullableContext(2)]
[Nullable(0)]
[LogJsonSerializable]
public class LogRecord : ILogRecord
{
	// Token: 0x06000131 RID: 305 RVA: 0x000084DC File Offset: 0x000066DC
	public LogRecord(string p4v, string br, int playerId, int id, ELogLevel level, ELogModule module, string category, [Nullable(1)] string author, [Nullable(1)] string msg, string context, string stack)
	{
		this.P4V = p4v;
		this.Br = br;
		this.PlayerId = playerId;
		this.Id = id;
		this.Level = level.ToEnumString();
		this.Module = module.ToEnumString();
		this.Category = category;
		this.Author = author;
		this.Msg = msg;
		this.Context = context;
		this.Stack = stack;
	}

	// Token: 0x04000128 RID: 296
	public readonly int Sp = (KuroApplication.IsBuildShipping() > false) ? 1 : 0;

	// Token: 0x04000129 RID: 297
	public readonly int? Ed = KuroApplication.IsWithEditor() ? new int?(1) : null;

	// Token: 0x0400012A RID: 298
	[LogJsonRaw]
	public readonly string Context;

	// Token: 0x0400012B RID: 299
	public string P4V;

	// Token: 0x0400012C RID: 300
	public string Br;

	// Token: 0x0400012D RID: 301
	public readonly int PlayerId;

	// Token: 0x0400012E RID: 302
	public readonly int Id;

	// Token: 0x0400012F RID: 303
	[Nullable(1)]
	public readonly string Level;

	// Token: 0x04000130 RID: 304
	[Nullable(1)]
	public readonly string Module;

	// Token: 0x04000131 RID: 305
	public readonly string Category;

	// Token: 0x04000132 RID: 306
	[Nullable(1)]
	public readonly string Author;

	// Token: 0x04000133 RID: 307
	[Nullable(1)]
	public readonly string Msg;

	// Token: 0x04000134 RID: 308
	public readonly string Stack;
}
