using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005040 RID: 20544
	[NullableContext(1)]
	public interface IRoleDevRoleViewItemData
	{
		// Token: 0x17008B05 RID: 35589
		// (get) Token: 0x06034E4E RID: 216654
		// (set) Token: 0x06034E4F RID: 216655
		int RoleId { get; set; }

		// Token: 0x17008B06 RID: 35590
		// (get) Token: 0x06034E50 RID: 216656
		// (set) Token: 0x06034E51 RID: 216657
		int RoleLevel { get; set; }

		// Token: 0x17008B07 RID: 35591
		// (get) Token: 0x06034E52 RID: 216658
		// (set) Token: 0x06034E53 RID: 216659
		bool RoleLevelIsMax { get; set; }

		// Token: 0x17008B08 RID: 35592
		// (get) Token: 0x06034E54 RID: 216660
		// (set) Token: 0x06034E55 RID: 216661
		int BreachLevel { get; set; }

		// Token: 0x17008B09 RID: 35593
		// (get) Token: 0x06034E56 RID: 216662
		// (set) Token: 0x06034E57 RID: 216663
		int RoleGoalUpgradeLevel { get; set; }

		// Token: 0x17008B0A RID: 35594
		// (get) Token: 0x06034E58 RID: 216664
		// (set) Token: 0x06034E59 RID: 216665
		int RoleGoalBreakLevel { get; set; }

		// Token: 0x17008B0B RID: 35595
		// (get) Token: 0x06034E5A RID: 216666
		// (set) Token: 0x06034E5B RID: 216667
		string RoleName { get; set; }

		// Token: 0x17008B0C RID: 35596
		// (get) Token: 0x06034E5C RID: 216668
		// (set) Token: 0x06034E5D RID: 216669
		int GachaId { get; set; }

		// Token: 0x17008B0D RID: 35597
		// (get) Token: 0x06034E5E RID: 216670
		// (set) Token: 0x06034E5F RID: 216671
		bool IsForecast { get; set; }

		// Token: 0x17008B0E RID: 35598
		// (get) Token: 0x06034E60 RID: 216672
		// (set) Token: 0x06034E61 RID: 216673
		bool IsCall { get; set; }

		// Token: 0x17008B0F RID: 35599
		// (get) Token: 0x06034E62 RID: 216674
		// (set) Token: 0x06034E63 RID: 216675
		bool IsCanUpgrade { get; set; }

		// Token: 0x17008B10 RID: 35600
		// (get) Token: 0x06034E64 RID: 216676
		// (set) Token: 0x06034E65 RID: 216677
		bool IsCanBreach { get; set; }

		// Token: 0x17008B11 RID: 35601
		// (get) Token: 0x06034E66 RID: 216678
		// (set) Token: 0x06034E67 RID: 216679
		bool IsCanShowUpgradeItem { get; set; }

		// Token: 0x17008B12 RID: 35602
		// (get) Token: 0x06034E68 RID: 216680
		// (set) Token: 0x06034E69 RID: 216681
		bool IsCanShowBreachItem { get; set; }

		// Token: 0x17008B13 RID: 35603
		// (get) Token: 0x06034E6A RID: 216682
		// (set) Token: 0x06034E6B RID: 216683
		bool IsFinish { get; set; }

		// Token: 0x17008B14 RID: 35604
		// (get) Token: 0x06034E6C RID: 216684
		// (set) Token: 0x06034E6D RID: 216685
		bool IsAllMaterialEnough { get; set; }

		// Token: 0x17008B15 RID: 35605
		// (get) Token: 0x06034E6E RID: 216686
		// (set) Token: 0x06034E6F RID: 216687
		List<IRoleDevDetailItemData> DetailItems { get; set; }
	}
}
