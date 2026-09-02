using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E83 RID: 11907
[NullableContext(2)]
[Nullable(0)]
public class TBuffAction
{
	// Token: 0x17002101 RID: 8449
	// (get) Token: 0x06018771 RID: 100209 RVA: 0x006DA38F File Offset: 0x006D858F
	// (set) Token: 0x06018772 RID: 100210 RVA: 0x006DA397 File Offset: 0x006D8597
	public EBuffActionType Type { get; set; }

	// Token: 0x17002102 RID: 8450
	// (get) Token: 0x06018773 RID: 100211 RVA: 0x006DA3A0 File Offset: 0x006D85A0
	// (set) Token: 0x06018774 RID: 100212 RVA: 0x006DA3A8 File Offset: 0x006D85A8
	public long[] Buffs { get; set; }

	// Token: 0x17002103 RID: 8451
	// (get) Token: 0x06018775 RID: 100213 RVA: 0x006DA3B1 File Offset: 0x006D85B1
	// (set) Token: 0x06018776 RID: 100214 RVA: 0x006DA3B9 File Offset: 0x006D85B9
	public int[] Tags { get; set; }

	// Token: 0x17002104 RID: 8452
	// (get) Token: 0x06018777 RID: 100215 RVA: 0x006DA3C2 File Offset: 0x006D85C2
	// (set) Token: 0x06018778 RID: 100216 RVA: 0x006DA3CA File Offset: 0x006D85CA
	public int[] CustomParams { get; set; }
}
