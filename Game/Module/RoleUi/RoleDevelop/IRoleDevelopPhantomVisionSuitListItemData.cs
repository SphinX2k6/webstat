using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200509C RID: 20636
	[NullableContext(2)]
	public interface IRoleDevelopPhantomVisionSuitListItemData
	{
		// Token: 0x17008BF3 RID: 35827
		// (get) Token: 0x060352DF RID: 217823
		// (set) Token: 0x060352E0 RID: 217824
		PhantomMonsterItemData MonsterData { get; set; }

		// Token: 0x17008BF4 RID: 35828
		// (get) Token: 0x060352E1 RID: 217825
		// (set) Token: 0x060352E2 RID: 217826
		DropRewardItemData RewardData { get; set; }
	}
}
