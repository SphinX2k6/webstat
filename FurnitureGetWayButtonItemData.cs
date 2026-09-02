using System;
using System.Runtime.CompilerServices;

// Token: 0x0200108C RID: 4236
[NullableContext(2)]
[Nullable(0)]
public class FurnitureGetWayButtonItemData : IFurnitureGetWayButtonItemData
{
	// Token: 0x170008ED RID: 2285
	// (get) Token: 0x06006E7C RID: 28284 RVA: 0x001CC695 File Offset: 0x001CA895
	// (set) Token: 0x06006E7D RID: 28285 RVA: 0x001CC69D File Offset: 0x001CA89D
	public string NameTextId { get; set; }

	// Token: 0x170008EE RID: 2286
	// (get) Token: 0x06006E7E RID: 28286 RVA: 0x001CC6A6 File Offset: 0x001CA8A6
	// (set) Token: 0x06006E7F RID: 28287 RVA: 0x001CC6AE File Offset: 0x001CA8AE
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] NameTextParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170008EF RID: 2287
	// (get) Token: 0x06006E80 RID: 28288 RVA: 0x001CC6B7 File Offset: 0x001CA8B7
	// (set) Token: 0x06006E81 RID: 28289 RVA: 0x001CC6BF File Offset: 0x001CA8BF
	public Action JumpFunction { get; set; }
}
