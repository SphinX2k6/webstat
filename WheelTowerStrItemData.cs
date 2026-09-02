using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020016A5 RID: 5797
[NullableContext(1)]
[Nullable(0)]
internal class WheelTowerStrItemData
{
	// Token: 0x17000D88 RID: 3464
	// (get) Token: 0x0600A167 RID: 41319 RVA: 0x002A6A88 File Offset: 0x002A4C88
	// (set) Token: 0x0600A168 RID: 41320 RVA: 0x002A6A90 File Offset: 0x002A4C90
	public string RoleName { get; set; } = string.Empty;

	// Token: 0x17000D89 RID: 3465
	// (get) Token: 0x0600A169 RID: 41321 RVA: 0x002A6A99 File Offset: 0x002A4C99
	// (set) Token: 0x0600A16A RID: 41322 RVA: 0x002A6AA1 File Offset: 0x002A4CA1
	public List<string> DescList { get; set; } = new List<string>();
}
