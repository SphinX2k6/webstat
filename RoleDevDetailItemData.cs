using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x020027ED RID: 10221
[NullableContext(1)]
[Nullable(0)]
public class RoleDevDetailItemData : global::IRoleDevDetailItemData
{
	// Token: 0x170019C7 RID: 6599
	// (get) Token: 0x060142EC RID: 82668 RVA: 0x005A0B36 File Offset: 0x0059ED36
	// (set) Token: 0x060142ED RID: 82669 RVA: 0x005A0B3E File Offset: 0x0059ED3E
	public int RoleId { get; set; }

	// Token: 0x170019C8 RID: 6600
	// (get) Token: 0x060142EE RID: 82670 RVA: 0x005A0B47 File Offset: 0x0059ED47
	// (set) Token: 0x060142EF RID: 82671 RVA: 0x005A0B4F File Offset: 0x0059ED4F
	public ERoleDevMainPage MainPage { get; set; }

	// Token: 0x170019C9 RID: 6601
	// (get) Token: 0x060142F0 RID: 82672 RVA: 0x005A0B58 File Offset: 0x0059ED58
	// (set) Token: 0x060142F1 RID: 82673 RVA: 0x005A0B60 File Offset: 0x0059ED60
	public ERoleDevSubPageButton ButtonType { get; set; }

	// Token: 0x170019CA RID: 6602
	// (get) Token: 0x060142F2 RID: 82674 RVA: 0x005A0B69 File Offset: 0x0059ED69
	// (set) Token: 0x060142F3 RID: 82675 RVA: 0x005A0B71 File Offset: 0x0059ED71
	public string Title { get; set; }

	// Token: 0x170019CB RID: 6603
	// (get) Token: 0x060142F4 RID: 82676 RVA: 0x005A0B7A File Offset: 0x0059ED7A
	// (set) Token: 0x060142F5 RID: 82677 RVA: 0x005A0B82 File Offset: 0x0059ED82
	public int ItemGroupId { get; set; }

	// Token: 0x170019CC RID: 6604
	// (get) Token: 0x060142F6 RID: 82678 RVA: 0x005A0B8B File Offset: 0x0059ED8B
	// (set) Token: 0x060142F7 RID: 82679 RVA: 0x005A0B93 File Offset: 0x0059ED93
	public List<global::IItemMaterial> ItemGroup { get; set; }
}
