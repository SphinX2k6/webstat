using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x020027EC RID: 10220
[NullableContext(1)]
public interface IRoleDevDetailItemData
{
	// Token: 0x170019C1 RID: 6593
	// (get) Token: 0x060142E0 RID: 82656
	// (set) Token: 0x060142E1 RID: 82657
	int RoleId { get; set; }

	// Token: 0x170019C2 RID: 6594
	// (get) Token: 0x060142E2 RID: 82658
	// (set) Token: 0x060142E3 RID: 82659
	ERoleDevMainPage MainPage { get; set; }

	// Token: 0x170019C3 RID: 6595
	// (get) Token: 0x060142E4 RID: 82660
	// (set) Token: 0x060142E5 RID: 82661
	ERoleDevSubPageButton ButtonType { get; set; }

	// Token: 0x170019C4 RID: 6596
	// (get) Token: 0x060142E6 RID: 82662
	// (set) Token: 0x060142E7 RID: 82663
	string Title { get; set; }

	// Token: 0x170019C5 RID: 6597
	// (get) Token: 0x060142E8 RID: 82664
	// (set) Token: 0x060142E9 RID: 82665
	int ItemGroupId { get; set; }

	// Token: 0x170019C6 RID: 6598
	// (get) Token: 0x060142EA RID: 82666
	// (set) Token: 0x060142EB RID: 82667
	List<global::IItemMaterial> ItemGroup { get; set; }
}
