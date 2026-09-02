using System;
using System.Runtime.CompilerServices;

// Token: 0x0200111D RID: 4381
[NullableContext(1)]
public interface IGuessJokerTipsData
{
	// Token: 0x1700094E RID: 2382
	// (get) Token: 0x06007233 RID: 29235
	// (set) Token: 0x06007234 RID: 29236
	string TextId { get; set; }

	// Token: 0x1700094F RID: 2383
	// (get) Token: 0x06007235 RID: 29237
	// (set) Token: 0x06007236 RID: 29238
	[Nullable(new byte[]
	{
		2,
		1
	})]
	string[] TextParam { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
