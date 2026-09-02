using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D37 RID: 11575
[NullableContext(2)]
[Nullable(0)]
public class WeeklyRogueRolePosInfo : IWeeklyRogueRolePosInfo
{
	// Token: 0x17001EC0 RID: 7872
	// (get) Token: 0x060175BB RID: 95675 RVA: 0x00679EA1 File Offset: 0x006780A1
	// (set) Token: 0x060175BC RID: 95676 RVA: 0x00679EA9 File Offset: 0x006780A9
	public RoleDataBase Data { get; set; }

	// Token: 0x17001EC1 RID: 7873
	// (get) Token: 0x060175BD RID: 95677 RVA: 0x00679EB2 File Offset: 0x006780B2
	// (set) Token: 0x060175BE RID: 95678 RVA: 0x00679EBA File Offset: 0x006780BA
	public bool? IsRecommend { get; set; }
}
