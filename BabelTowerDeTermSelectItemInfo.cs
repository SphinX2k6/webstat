using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011EF RID: 4591
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerDeTermSelectItemInfo : IBabelTowerDeTermSelectItemInfo
{
	// Token: 0x17000A53 RID: 2643
	// (get) Token: 0x0600797E RID: 31102 RVA: 0x001FCE8C File Offset: 0x001FB08C
	// (set) Token: 0x0600797F RID: 31103 RVA: 0x001FCE94 File Offset: 0x001FB094
	public bool IsNecessary { get; set; }

	// Token: 0x17000A54 RID: 2644
	// (get) Token: 0x06007980 RID: 31104 RVA: 0x001FCE9D File Offset: 0x001FB09D
	// (set) Token: 0x06007981 RID: 31105 RVA: 0x001FCEA5 File Offset: 0x001FB0A5
	public List<int> AllDeTerm { get; set; }

	// Token: 0x17000A55 RID: 2645
	// (get) Token: 0x06007982 RID: 31106 RVA: 0x001FCEAE File Offset: 0x001FB0AE
	// (set) Token: 0x06007983 RID: 31107 RVA: 0x001FCEB6 File Offset: 0x001FB0B6
	public List<int> DailyDeTerm { get; set; }

	// Token: 0x17000A56 RID: 2646
	// (get) Token: 0x06007984 RID: 31108 RVA: 0x001FCEBF File Offset: 0x001FB0BF
	// (set) Token: 0x06007985 RID: 31109 RVA: 0x001FCEC7 File Offset: 0x001FB0C7
	public Action<int> OnChangeSelectDeTerm { get; set; }
}
