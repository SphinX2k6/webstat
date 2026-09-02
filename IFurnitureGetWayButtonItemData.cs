using System;
using System.Runtime.CompilerServices;

// Token: 0x0200108B RID: 4235
[NullableContext(2)]
public interface IFurnitureGetWayButtonItemData
{
	// Token: 0x170008EA RID: 2282
	// (get) Token: 0x06006E76 RID: 28278
	// (set) Token: 0x06006E77 RID: 28279
	string NameTextId { get; set; }

	// Token: 0x170008EB RID: 2283
	// (get) Token: 0x06006E78 RID: 28280
	// (set) Token: 0x06006E79 RID: 28281
	[Nullable(new byte[]
	{
		2,
		1
	})]
	string[] NameTextParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170008EC RID: 2284
	// (get) Token: 0x06006E7A RID: 28282
	// (set) Token: 0x06006E7B RID: 28283
	Action JumpFunction { get; set; }
}
