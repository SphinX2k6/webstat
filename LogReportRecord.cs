using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Typing;

// Token: 0x02000049 RID: 73
[NullableContext(2)]
[Nullable(0)]
[LogJsonSerializable]
public class LogReportRecord : ILogRecord
{
	// Token: 0x06000132 RID: 306 RVA: 0x0000857C File Offset: 0x0000677C
	public LogReportRecord(int playerId, int num, [Nullable(1)] StringBuilder detail, string p4v = null, string br = null)
	{
		this.PlayerId = playerId;
		this.Num = num;
		this.Detail = detail;
		this.P4V = p4v;
		this.Br = br;
	}

	// Token: 0x04000135 RID: 309
	public readonly int Sp = (KuroApplication.IsBuildShipping() > false) ? 1 : 0;

	// Token: 0x04000136 RID: 310
	public readonly int? Ed = KuroApplication.IsWithEditor() ? new int?(1) : null;

	// Token: 0x04000137 RID: 311
	public readonly int PlayerId;

	// Token: 0x04000138 RID: 312
	public readonly int Num;

	// Token: 0x04000139 RID: 313
	[Nullable(1)]
	public readonly StringBuilder Detail;

	// Token: 0x0400013A RID: 314
	public string P4V;

	// Token: 0x0400013B RID: 315
	public string Br;
}
