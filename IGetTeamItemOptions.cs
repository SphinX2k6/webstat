using System;

// Token: 0x02002961 RID: 10593
public interface IGetTeamItemOptions
{
	// Token: 0x17001BAD RID: 7085
	// (get) Token: 0x060150D8 RID: 86232
	// (set) Token: 0x060150D9 RID: 86233
	ETeamParamType ParamType { get; set; }

	// Token: 0x17001BAE RID: 7086
	// (get) Token: 0x060150DA RID: 86234
	// (set) Token: 0x060150DB RID: 86235
	bool? OnlyMyRole { get; set; }

	// Token: 0x17001BAF RID: 7087
	// (get) Token: 0x060150DC RID: 86236
	// (set) Token: 0x060150DD RID: 86237
	bool? IsControl { get; set; }
}
