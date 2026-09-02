using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011F5 RID: 4597
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerMutexGroupData : IBabelTowerMutexGroupData
{
	// Token: 0x17000A72 RID: 2674
	// (get) Token: 0x060079BF RID: 31167 RVA: 0x001FCFA3 File Offset: 0x001FB1A3
	// (set) Token: 0x060079C0 RID: 31168 RVA: 0x001FCFAB File Offset: 0x001FB1AB
	public int MutexId { get; set; }

	// Token: 0x17000A73 RID: 2675
	// (get) Token: 0x060079C1 RID: 31169 RVA: 0x001FCFB4 File Offset: 0x001FB1B4
	// (set) Token: 0x060079C2 RID: 31170 RVA: 0x001FCFBC File Offset: 0x001FB1BC
	public int GroupId { get; set; }

	// Token: 0x17000A74 RID: 2676
	// (get) Token: 0x060079C3 RID: 31171 RVA: 0x001FCFC5 File Offset: 0x001FB1C5
	// (set) Token: 0x060079C4 RID: 31172 RVA: 0x001FCFCD File Offset: 0x001FB1CD
	public List<int> DeTermList { get; set; }

	// Token: 0x17000A75 RID: 2677
	// (get) Token: 0x060079C5 RID: 31173 RVA: 0x001FCFD6 File Offset: 0x001FB1D6
	// (set) Token: 0x060079C6 RID: 31174 RVA: 0x001FCFDE File Offset: 0x001FB1DE
	public bool? IsNecessary { get; set; }

	// Token: 0x17000A76 RID: 2678
	// (get) Token: 0x060079C7 RID: 31175 RVA: 0x001FCFE7 File Offset: 0x001FB1E7
	// (set) Token: 0x060079C8 RID: 31176 RVA: 0x001FCFEF File Offset: 0x001FB1EF
	public int? CurrentDeTermId { get; set; }
}
