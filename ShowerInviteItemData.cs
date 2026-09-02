using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A0B RID: 10763
[NullableContext(1)]
[Nullable(0)]
public class ShowerInviteItemData : IShowerInviteItemData
{
	// Token: 0x17001C01 RID: 7169
	// (get) Token: 0x060157A4 RID: 87972 RVA: 0x005F42E8 File Offset: 0x005F24E8
	// (set) Token: 0x060157A5 RID: 87973 RVA: 0x005F42F0 File Offset: 0x005F24F0
	public RoleInstance RoleInstance { get; set; }

	// Token: 0x17001C02 RID: 7170
	// (get) Token: 0x060157A6 RID: 87974 RVA: 0x005F42F9 File Offset: 0x005F24F9
	// (set) Token: 0x060157A7 RID: 87975 RVA: 0x005F4301 File Offset: 0x005F2501
	public bool IsInFormation { get; set; }
}
