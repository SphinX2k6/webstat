using System;
using System.Runtime.CompilerServices;

// Token: 0x0200344B RID: 13387
[NullableContext(1)]
[Nullable(0)]
public class CombatScriptUnit
{
	// Token: 0x0601C14C RID: 115020 RVA: 0x00860BAA File Offset: 0x0085EDAA
	public CombatScriptUnit(string cmd, string body, string viewName, string introduction)
	{
		this.Cmd = cmd;
		this.Body = body;
		this.ViewName = viewName;
		this.Introduction = introduction;
	}

	// Token: 0x0601C14D RID: 115021 RVA: 0x00860BD0 File Offset: 0x0085EDD0
	public override string ToString()
	{
		return string.Concat(new string[]
		{
			"-------------------------------------------------------------------------\n        -指令名称： ",
			this.ViewName,
			"\n        -指令介绍： ",
			this.Introduction,
			"\n        -指令详情： ",
			this.Cmd,
			"\n        -指令具体内容： ",
			this.Body,
			"\n"
		});
	}

	// Token: 0x0400E2D0 RID: 58064
	public string Cmd;

	// Token: 0x0400E2D1 RID: 58065
	public string Body;

	// Token: 0x0400E2D2 RID: 58066
	public string ViewName;

	// Token: 0x0400E2D3 RID: 58067
	public string Introduction;
}
