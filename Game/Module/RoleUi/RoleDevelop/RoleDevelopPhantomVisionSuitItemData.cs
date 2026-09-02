using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200509B RID: 20635
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopPhantomVisionSuitItemData : IRoleDevelopPhantomVisionSuitItemData
	{
		// Token: 0x17008BE7 RID: 35815
		// (get) Token: 0x060352C6 RID: 217798 RVA: 0x00D5303C File Offset: 0x00D5123C
		// (set) Token: 0x060352C7 RID: 217799 RVA: 0x00D53044 File Offset: 0x00D51244
		public string Name { get; set; }

		// Token: 0x17008BE8 RID: 35816
		// (get) Token: 0x060352C8 RID: 217800 RVA: 0x00D5304D File Offset: 0x00D5124D
		// (set) Token: 0x060352C9 RID: 217801 RVA: 0x00D53055 File Offset: 0x00D51255
		public string ButtonName { get; set; }

		// Token: 0x17008BE9 RID: 35817
		// (get) Token: 0x060352CA RID: 217802 RVA: 0x00D5305E File Offset: 0x00D5125E
		// (set) Token: 0x060352CB RID: 217803 RVA: 0x00D53066 File Offset: 0x00D51266
		public EPhantomSuitItemType ItemType { get; set; }

		// Token: 0x17008BEA RID: 35818
		// (get) Token: 0x060352CC RID: 217804 RVA: 0x00D5306F File Offset: 0x00D5126F
		// (set) Token: 0x060352CD RID: 217805 RVA: 0x00D53077 File Offset: 0x00D51277
		public string TypeIcon { get; set; }

		// Token: 0x17008BEB RID: 35819
		// (get) Token: 0x060352CE RID: 217806 RVA: 0x00D53080 File Offset: 0x00D51280
		// (set) Token: 0x060352CF RID: 217807 RVA: 0x00D53088 File Offset: 0x00D51288
		public List<PhantomMonsterItemData> MonsterDataList { get; set; }

		// Token: 0x17008BEC RID: 35820
		// (get) Token: 0x060352D0 RID: 217808 RVA: 0x00D53091 File Offset: 0x00D51291
		// (set) Token: 0x060352D1 RID: 217809 RVA: 0x00D53099 File Offset: 0x00D51299
		public List<DropRewardItemData> RewardDataList { get; set; }

		// Token: 0x17008BED RID: 35821
		// (get) Token: 0x060352D2 RID: 217810 RVA: 0x00D530A2 File Offset: 0x00D512A2
		// (set) Token: 0x060352D3 RID: 217811 RVA: 0x00D530AA File Offset: 0x00D512AA
		public int DungeonId { get; set; }

		// Token: 0x17008BEE RID: 35822
		// (get) Token: 0x060352D4 RID: 217812 RVA: 0x00D530B3 File Offset: 0x00D512B3
		// (set) Token: 0x060352D5 RID: 217813 RVA: 0x00D530BB File Offset: 0x00D512BB
		public int FetterGroupId { get; set; }

		// Token: 0x17008BEF RID: 35823
		// (get) Token: 0x060352D6 RID: 217814 RVA: 0x00D530C4 File Offset: 0x00D512C4
		// (set) Token: 0x060352D7 RID: 217815 RVA: 0x00D530CC File Offset: 0x00D512CC
		public int RoleId { get; set; }

		// Token: 0x17008BF0 RID: 35824
		// (get) Token: 0x060352D8 RID: 217816 RVA: 0x00D530D5 File Offset: 0x00D512D5
		// (set) Token: 0x060352D9 RID: 217817 RVA: 0x00D530DD File Offset: 0x00D512DD
		public int? LogRoleId { get; set; }

		// Token: 0x17008BF1 RID: 35825
		// (get) Token: 0x060352DA RID: 217818 RVA: 0x00D530E6 File Offset: 0x00D512E6
		// (set) Token: 0x060352DB RID: 217819 RVA: 0x00D530EE File Offset: 0x00D512EE
		public ERoleDevelopCategoryType? LogMainPage { get; set; }

		// Token: 0x17008BF2 RID: 35826
		// (get) Token: 0x060352DC RID: 217820 RVA: 0x00D530F7 File Offset: 0x00D512F7
		// (set) Token: 0x060352DD RID: 217821 RVA: 0x00D530FF File Offset: 0x00D512FF
		public ERoleDevelopLogSubPage? LogSubPage { get; set; }
	}
}
