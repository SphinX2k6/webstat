using System;
using System.Runtime.CompilerServices;

// Token: 0x0200111E RID: 4382
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerTipsData : IGuessJokerTipsData
{
	// Token: 0x17000950 RID: 2384
	// (get) Token: 0x06007237 RID: 29239 RVA: 0x001DD1DF File Offset: 0x001DB3DF
	// (set) Token: 0x06007238 RID: 29240 RVA: 0x001DD1E7 File Offset: 0x001DB3E7
	public string TextId { get; set; } = "";

	// Token: 0x17000951 RID: 2385
	// (get) Token: 0x06007239 RID: 29241 RVA: 0x001DD1F0 File Offset: 0x001DB3F0
	// (set) Token: 0x0600723A RID: 29242 RVA: 0x001DD1F8 File Offset: 0x001DB3F8
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] TextParam { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
