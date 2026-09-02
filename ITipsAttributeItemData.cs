using System;
using System.Runtime.CompilerServices;

// Token: 0x02001983 RID: 6531
[NullableContext(1)]
public interface ITipsAttributeItemData
{
	// Token: 0x17000F3F RID: 3903
	// (get) Token: 0x0600BBC2 RID: 48066
	// (set) Token: 0x0600BBC3 RID: 48067
	int Id { get; set; }

	// Token: 0x17000F40 RID: 3904
	// (get) Token: 0x0600BBC4 RID: 48068
	// (set) Token: 0x0600BBC5 RID: 48069
	bool IsMainAttribute { get; set; }

	// Token: 0x17000F41 RID: 3905
	// (get) Token: 0x0600BBC6 RID: 48070
	// (set) Token: 0x0600BBC7 RID: 48071
	string Name { get; set; }

	// Token: 0x17000F42 RID: 3906
	// (get) Token: 0x0600BBC8 RID: 48072
	// (set) Token: 0x0600BBC9 RID: 48073
	string IconPath { get; set; }

	// Token: 0x17000F43 RID: 3907
	// (get) Token: 0x0600BBCA RID: 48074
	// (set) Token: 0x0600BBCB RID: 48075
	double Value { get; set; }

	// Token: 0x17000F44 RID: 3908
	// (get) Token: 0x0600BBCC RID: 48076
	// (set) Token: 0x0600BBCD RID: 48077
	bool IsRatio { get; set; }
}
