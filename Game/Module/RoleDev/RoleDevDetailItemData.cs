using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005039 RID: 20537
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevDetailItemData : IRoleDevDetailItemData
	{
		// Token: 0x17008AEF RID: 35567
		// (get) Token: 0x06034E1E RID: 216606 RVA: 0x00D466B5 File Offset: 0x00D448B5
		// (set) Token: 0x06034E1F RID: 216607 RVA: 0x00D466BD File Offset: 0x00D448BD
		public int RoleId { get; set; }

		// Token: 0x17008AF0 RID: 35568
		// (get) Token: 0x06034E20 RID: 216608 RVA: 0x00D466C6 File Offset: 0x00D448C6
		// (set) Token: 0x06034E21 RID: 216609 RVA: 0x00D466CE File Offset: 0x00D448CE
		public ERoleDevMainPage MainPage { get; set; }

		// Token: 0x17008AF1 RID: 35569
		// (get) Token: 0x06034E22 RID: 216610 RVA: 0x00D466D7 File Offset: 0x00D448D7
		// (set) Token: 0x06034E23 RID: 216611 RVA: 0x00D466DF File Offset: 0x00D448DF
		public ERoleDevSubPageButton ButtonType { get; set; }

		// Token: 0x17008AF2 RID: 35570
		// (get) Token: 0x06034E24 RID: 216612 RVA: 0x00D466E8 File Offset: 0x00D448E8
		// (set) Token: 0x06034E25 RID: 216613 RVA: 0x00D466F0 File Offset: 0x00D448F0
		public string Title { get; set; }

		// Token: 0x17008AF3 RID: 35571
		// (get) Token: 0x06034E26 RID: 216614 RVA: 0x00D466F9 File Offset: 0x00D448F9
		// (set) Token: 0x06034E27 RID: 216615 RVA: 0x00D46701 File Offset: 0x00D44901
		public int ItemGroupId { get; set; }

		// Token: 0x17008AF4 RID: 35572
		// (get) Token: 0x06034E28 RID: 216616 RVA: 0x00D4670A File Offset: 0x00D4490A
		// (set) Token: 0x06034E29 RID: 216617 RVA: 0x00D46712 File Offset: 0x00D44912
		public List<IItemMaterial> ItemGroup { get; set; }
	}
}
