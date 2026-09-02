using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011E7 RID: 4583
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerLevelInfo : IBabelTowerLevelInfo
{
	// Token: 0x17000A31 RID: 2609
	// (get) Token: 0x06007936 RID: 31030 RVA: 0x001FCD3A File Offset: 0x001FAF3A
	// (set) Token: 0x06007937 RID: 31031 RVA: 0x001FCD42 File Offset: 0x001FAF42
	public int BabelTowerLevelId { get; set; }

	// Token: 0x17000A32 RID: 2610
	// (get) Token: 0x06007938 RID: 31032 RVA: 0x001FCD4B File Offset: 0x001FAF4B
	// (set) Token: 0x06007939 RID: 31033 RVA: 0x001FCD53 File Offset: 0x001FAF53
	public int InstanceId { get; set; }

	// Token: 0x17000A33 RID: 2611
	// (get) Token: 0x0600793A RID: 31034 RVA: 0x001FCD5C File Offset: 0x001FAF5C
	// (set) Token: 0x0600793B RID: 31035 RVA: 0x001FCD64 File Offset: 0x001FAF64
	public List<int> RoleList { get; set; }

	// Token: 0x17000A34 RID: 2612
	// (get) Token: 0x0600793C RID: 31036 RVA: 0x001FCD6D File Offset: 0x001FAF6D
	// (set) Token: 0x0600793D RID: 31037 RVA: 0x001FCD75 File Offset: 0x001FAF75
	public List<int> BuffList { get; set; }

	// Token: 0x17000A35 RID: 2613
	// (get) Token: 0x0600793E RID: 31038 RVA: 0x001FCD7E File Offset: 0x001FAF7E
	// (set) Token: 0x0600793F RID: 31039 RVA: 0x001FCD86 File Offset: 0x001FAF86
	public int BuffCount { get; set; }

	// Token: 0x17000A36 RID: 2614
	// (get) Token: 0x06007940 RID: 31040 RVA: 0x001FCD8F File Offset: 0x001FAF8F
	// (set) Token: 0x06007941 RID: 31041 RVA: 0x001FCD97 File Offset: 0x001FAF97
	public int StarNumber { get; set; }
}
