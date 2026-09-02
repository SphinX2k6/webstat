using System;

// Token: 0x02002962 RID: 10594
public class GetTeamItemOptions : IGetTeamItemOptions
{
	// Token: 0x17001BB0 RID: 7088
	// (get) Token: 0x060150DE RID: 86238 RVA: 0x005D303D File Offset: 0x005D123D
	// (set) Token: 0x060150DF RID: 86239 RVA: 0x005D3045 File Offset: 0x005D1245
	public ETeamParamType ParamType { get; set; }

	// Token: 0x17001BB1 RID: 7089
	// (get) Token: 0x060150E0 RID: 86240 RVA: 0x005D304E File Offset: 0x005D124E
	// (set) Token: 0x060150E1 RID: 86241 RVA: 0x005D3056 File Offset: 0x005D1256
	public bool? OnlyMyRole { get; set; }

	// Token: 0x17001BB2 RID: 7090
	// (get) Token: 0x060150E2 RID: 86242 RVA: 0x005D305F File Offset: 0x005D125F
	// (set) Token: 0x060150E3 RID: 86243 RVA: 0x005D3067 File Offset: 0x005D1267
	public bool? IsControl { get; set; }
}
