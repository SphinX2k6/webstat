using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A5D RID: 6749
[NullableContext(1)]
[Nullable(0)]
public class CommonTabTitleData
{
	// Token: 0x0600C0E7 RID: 49383 RVA: 0x0032DD42 File Offset: 0x0032BF42
	public CommonTabTitleData(string textId, params object[] args)
	{
		this.TextId = textId;
		this.Args = args;
	}

	// Token: 0x17000FD7 RID: 4055
	// (get) Token: 0x0600C0E8 RID: 49384 RVA: 0x0032DD58 File Offset: 0x0032BF58
	public string TextId { get; }

	// Token: 0x17000FD8 RID: 4056
	// (get) Token: 0x0600C0E9 RID: 49385 RVA: 0x0032DD60 File Offset: 0x0032BF60
	public object[] Args { get; }
}
