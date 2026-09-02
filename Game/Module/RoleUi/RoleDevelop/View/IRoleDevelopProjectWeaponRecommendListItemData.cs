using System;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050C6 RID: 20678
	public interface IRoleDevelopProjectWeaponRecommendListItemData
	{
		// Token: 0x17008C17 RID: 35863
		// (get) Token: 0x06035472 RID: 218226
		// (set) Token: 0x06035473 RID: 218227
		int DevelopRoleId { get; set; }

		// Token: 0x17008C18 RID: 35864
		// (get) Token: 0x06035474 RID: 218228
		// (set) Token: 0x06035475 RID: 218229
		int RecommendWeaponId { get; set; }

		// Token: 0x17008C19 RID: 35865
		// (get) Token: 0x06035476 RID: 218230
		// (set) Token: 0x06035477 RID: 218231
		int? LogRoleId { get; set; }

		// Token: 0x17008C1A RID: 35866
		// (get) Token: 0x06035478 RID: 218232
		// (set) Token: 0x06035479 RID: 218233
		ERoleDevelopCategoryType? LogMainPage { get; set; }

		// Token: 0x17008C1B RID: 35867
		// (get) Token: 0x0603547A RID: 218234
		// (set) Token: 0x0603547B RID: 218235
		ERoleDevelopLogSubPage? LogSubPage { get; set; }
	}
}
