using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020014C5 RID: 5317
[NullableContext(1)]
public interface IPinballRoleSelectGridItemData
{
	// Token: 0x17000C88 RID: 3208
	// (get) Token: 0x060094B6 RID: 38070
	// (set) Token: 0x060094B7 RID: 38071
	PinballRoleDataBase RoleData { get; set; }

	// Token: 0x17000C89 RID: 3209
	// (get) Token: 0x060094B8 RID: 38072
	// (set) Token: 0x060094B9 RID: 38073
	IPinballItemDataRole ItemData { get; set; }

	// Token: 0x17000C8A RID: 3210
	// (get) Token: 0x060094BA RID: 38074
	// (set) Token: 0x060094BB RID: 38075
	List<int> ClassIdList { get; set; }

	// Token: 0x17000C8B RID: 3211
	// (get) Token: 0x060094BC RID: 38076
	// (set) Token: 0x060094BD RID: 38077
	bool IsSelected { get; set; }

	// Token: 0x17000C8C RID: 3212
	// (get) Token: 0x060094BE RID: 38078
	// (set) Token: 0x060094BF RID: 38079
	int FormationIndex { get; set; }
}
