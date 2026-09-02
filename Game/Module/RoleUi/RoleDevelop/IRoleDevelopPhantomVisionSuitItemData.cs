using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200509A RID: 20634
	[NullableContext(1)]
	public interface IRoleDevelopPhantomVisionSuitItemData
	{
		// Token: 0x17008BDB RID: 35803
		// (get) Token: 0x060352AE RID: 217774
		// (set) Token: 0x060352AF RID: 217775
		string Name { get; set; }

		// Token: 0x17008BDC RID: 35804
		// (get) Token: 0x060352B0 RID: 217776
		// (set) Token: 0x060352B1 RID: 217777
		string ButtonName { get; set; }

		// Token: 0x17008BDD RID: 35805
		// (get) Token: 0x060352B2 RID: 217778
		// (set) Token: 0x060352B3 RID: 217779
		EPhantomSuitItemType ItemType { get; set; }

		// Token: 0x17008BDE RID: 35806
		// (get) Token: 0x060352B4 RID: 217780
		// (set) Token: 0x060352B5 RID: 217781
		string TypeIcon { get; set; }

		// Token: 0x17008BDF RID: 35807
		// (get) Token: 0x060352B6 RID: 217782
		// (set) Token: 0x060352B7 RID: 217783
		List<PhantomMonsterItemData> MonsterDataList { get; set; }

		// Token: 0x17008BE0 RID: 35808
		// (get) Token: 0x060352B8 RID: 217784
		// (set) Token: 0x060352B9 RID: 217785
		List<DropRewardItemData> RewardDataList { get; set; }

		// Token: 0x17008BE1 RID: 35809
		// (get) Token: 0x060352BA RID: 217786
		// (set) Token: 0x060352BB RID: 217787
		int DungeonId { get; set; }

		// Token: 0x17008BE2 RID: 35810
		// (get) Token: 0x060352BC RID: 217788
		// (set) Token: 0x060352BD RID: 217789
		int FetterGroupId { get; set; }

		// Token: 0x17008BE3 RID: 35811
		// (get) Token: 0x060352BE RID: 217790
		// (set) Token: 0x060352BF RID: 217791
		int RoleId { get; set; }

		// Token: 0x17008BE4 RID: 35812
		// (get) Token: 0x060352C0 RID: 217792
		// (set) Token: 0x060352C1 RID: 217793
		int? LogRoleId { get; set; }

		// Token: 0x17008BE5 RID: 35813
		// (get) Token: 0x060352C2 RID: 217794
		// (set) Token: 0x060352C3 RID: 217795
		ERoleDevelopCategoryType? LogMainPage { get; set; }

		// Token: 0x17008BE6 RID: 35814
		// (get) Token: 0x060352C4 RID: 217796
		// (set) Token: 0x060352C5 RID: 217797
		ERoleDevelopLogSubPage? LogSubPage { get; set; }
	}
}
