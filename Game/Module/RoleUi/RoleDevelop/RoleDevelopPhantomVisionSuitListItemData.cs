using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200509D RID: 20637
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleDevelopPhantomVisionSuitListItemData : IRoleDevelopPhantomVisionSuitListItemData
	{
		// Token: 0x17008BF5 RID: 35829
		// (get) Token: 0x060352E3 RID: 217827 RVA: 0x00D53110 File Offset: 0x00D51310
		// (set) Token: 0x060352E4 RID: 217828 RVA: 0x00D53118 File Offset: 0x00D51318
		public PhantomMonsterItemData MonsterData { get; set; }

		// Token: 0x17008BF6 RID: 35830
		// (get) Token: 0x060352E5 RID: 217829 RVA: 0x00D53121 File Offset: 0x00D51321
		// (set) Token: 0x060352E6 RID: 217830 RVA: 0x00D53129 File Offset: 0x00D51329
		public DropRewardItemData RewardData { get; set; }
	}
}
