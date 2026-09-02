using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005038 RID: 20536
	[NullableContext(1)]
	public interface IRoleDevDetailItemData
	{
		// Token: 0x17008AE9 RID: 35561
		// (get) Token: 0x06034E12 RID: 216594
		// (set) Token: 0x06034E13 RID: 216595
		int RoleId { get; set; }

		// Token: 0x17008AEA RID: 35562
		// (get) Token: 0x06034E14 RID: 216596
		// (set) Token: 0x06034E15 RID: 216597
		ERoleDevMainPage MainPage { get; set; }

		// Token: 0x17008AEB RID: 35563
		// (get) Token: 0x06034E16 RID: 216598
		// (set) Token: 0x06034E17 RID: 216599
		ERoleDevSubPageButton ButtonType { get; set; }

		// Token: 0x17008AEC RID: 35564
		// (get) Token: 0x06034E18 RID: 216600
		// (set) Token: 0x06034E19 RID: 216601
		string Title { get; set; }

		// Token: 0x17008AED RID: 35565
		// (get) Token: 0x06034E1A RID: 216602
		// (set) Token: 0x06034E1B RID: 216603
		int ItemGroupId { get; set; }

		// Token: 0x17008AEE RID: 35566
		// (get) Token: 0x06034E1C RID: 216604
		// (set) Token: 0x06034E1D RID: 216605
		List<IItemMaterial> ItemGroup { get; set; }
	}
}
