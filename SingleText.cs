using System;
using System.Runtime.CompilerServices;

// Token: 0x0200288C RID: 10380
[NullableContext(1)]
[Nullable(0)]
public class SingleText
{
	// Token: 0x17001AD1 RID: 6865
	// (get) Token: 0x060148CC RID: 84172 RVA: 0x005B2B81 File Offset: 0x005B0D81
	// (set) Token: 0x060148CD RID: 84173 RVA: 0x005B2B89 File Offset: 0x005B0D89
	public string TextId { get; set; }

	// Token: 0x17001AD2 RID: 6866
	// (get) Token: 0x060148CE RID: 84174 RVA: 0x005B2B92 File Offset: 0x005B0D92
	// (set) Token: 0x060148CF RID: 84175 RVA: 0x005B2B9A File Offset: 0x005B0D9A
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] Params { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
