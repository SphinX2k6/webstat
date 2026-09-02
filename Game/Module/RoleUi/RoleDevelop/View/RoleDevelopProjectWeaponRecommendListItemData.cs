using System;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050C7 RID: 20679
	public class RoleDevelopProjectWeaponRecommendListItemData : IRoleDevelopProjectWeaponRecommendListItemData
	{
		// Token: 0x17008C1C RID: 35868
		// (get) Token: 0x0603547C RID: 218236 RVA: 0x00D5D330 File Offset: 0x00D5B530
		// (set) Token: 0x0603547D RID: 218237 RVA: 0x00D5D338 File Offset: 0x00D5B538
		public int DevelopRoleId { get; set; }

		// Token: 0x17008C1D RID: 35869
		// (get) Token: 0x0603547E RID: 218238 RVA: 0x00D5D341 File Offset: 0x00D5B541
		// (set) Token: 0x0603547F RID: 218239 RVA: 0x00D5D349 File Offset: 0x00D5B549
		public int RecommendWeaponId { get; set; }

		// Token: 0x17008C1E RID: 35870
		// (get) Token: 0x06035480 RID: 218240 RVA: 0x00D5D352 File Offset: 0x00D5B552
		// (set) Token: 0x06035481 RID: 218241 RVA: 0x00D5D35A File Offset: 0x00D5B55A
		public int? LogRoleId { get; set; }

		// Token: 0x17008C1F RID: 35871
		// (get) Token: 0x06035482 RID: 218242 RVA: 0x00D5D363 File Offset: 0x00D5B563
		// (set) Token: 0x06035483 RID: 218243 RVA: 0x00D5D36B File Offset: 0x00D5B56B
		public ERoleDevelopCategoryType? LogMainPage { get; set; }

		// Token: 0x17008C20 RID: 35872
		// (get) Token: 0x06035484 RID: 218244 RVA: 0x00D5D374 File Offset: 0x00D5B574
		// (set) Token: 0x06035485 RID: 218245 RVA: 0x00D5D37C File Offset: 0x00D5B57C
		public ERoleDevelopLogSubPage? LogSubPage { get; set; }
	}
}
