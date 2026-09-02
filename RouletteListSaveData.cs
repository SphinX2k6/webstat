using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200291A RID: 10522
[NullableContext(1)]
[Nullable(0)]
public class RouletteListSaveData : IRouletteListSaveData
{
	// Token: 0x17001B6D RID: 7021
	// (get) Token: 0x06014E02 RID: 85506 RVA: 0x005C7916 File Offset: 0x005C5B16
	// (set) Token: 0x06014E03 RID: 85507 RVA: 0x005C791E File Offset: 0x005C5B1E
	public ERouletteType RouletteType { get; set; }

	// Token: 0x17001B6E RID: 7022
	// (get) Token: 0x06014E04 RID: 85508 RVA: 0x005C7927 File Offset: 0x005C5B27
	// (set) Token: 0x06014E05 RID: 85509 RVA: 0x005C792F File Offset: 0x005C5B2F
	public List<int> RouletteIdList { get; set; }

	// Token: 0x17001B6F RID: 7023
	// (get) Token: 0x06014E06 RID: 85510 RVA: 0x005C7938 File Offset: 0x005C5B38
	// (set) Token: 0x06014E07 RID: 85511 RVA: 0x005C7940 File Offset: 0x005C5B40
	public int ExtraItemId { get; set; }

	// Token: 0x17001B70 RID: 7024
	// (get) Token: 0x06014E08 RID: 85512 RVA: 0x005C7949 File Offset: 0x005C5B49
	// (set) Token: 0x06014E09 RID: 85513 RVA: 0x005C7951 File Offset: 0x005C5B51
	public int EquipExploreSkillId { get; set; }
}
