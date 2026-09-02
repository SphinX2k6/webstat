using System;
using System.Runtime.CompilerServices;

// Token: 0x020014C4 RID: 5316
[NullableContext(2)]
public interface IPinballRoleViewOpenParam
{
	// Token: 0x17000C86 RID: 3206
	// (get) Token: 0x060094B2 RID: 38066
	// (set) Token: 0x060094B3 RID: 38067
	int? RoleId { get; set; }

	// Token: 0x17000C87 RID: 3207
	// (get) Token: 0x060094B4 RID: 38068
	// (set) Token: 0x060094B5 RID: 38069
	int[] FormationRoleIds { get; set; }
}
