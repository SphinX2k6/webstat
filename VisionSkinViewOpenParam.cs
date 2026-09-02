using System;
using System.Runtime.CompilerServices;

// Token: 0x02002548 RID: 9544
[NullableContext(2)]
[Nullable(0)]
public class VisionSkinViewOpenParam : IVisionSkinViewOpenParam
{
	// Token: 0x17001783 RID: 6019
	// (get) Token: 0x06012923 RID: 76067 RVA: 0x0051D8F8 File Offset: 0x0051BAF8
	// (set) Token: 0x06012924 RID: 76068 RVA: 0x0051D900 File Offset: 0x0051BB00
	public int? UniqueId { get; set; }

	// Token: 0x17001784 RID: 6020
	// (get) Token: 0x06012925 RID: 76069 RVA: 0x0051D909 File Offset: 0x0051BB09
	// (set) Token: 0x06012926 RID: 76070 RVA: 0x0051D911 File Offset: 0x0051BB11
	public int[] ShowItemIdList { get; set; }
}
