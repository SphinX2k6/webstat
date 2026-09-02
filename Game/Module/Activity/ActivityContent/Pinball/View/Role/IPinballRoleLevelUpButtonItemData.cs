using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065D7 RID: 26071
	[NullableContext(1)]
	public interface IPinballRoleLevelUpButtonItemData
	{
		// Token: 0x17009F0A RID: 40714
		// (get) Token: 0x0604121F RID: 266783
		// (set) Token: 0x06041220 RID: 266784
		int Times { get; set; }

		// Token: 0x17009F0B RID: 40715
		// (get) Token: 0x06041221 RID: 266785
		// (set) Token: 0x06041222 RID: 266786
		bool IsToMaxLevel { get; set; }

		// Token: 0x17009F0C RID: 40716
		// (get) Token: 0x06041223 RID: 266787
		// (set) Token: 0x06041224 RID: 266788
		Action<int> ConfirmDelegate { get; set; }

		// Token: 0x17009F0D RID: 40717
		// (get) Token: 0x06041225 RID: 266789
		// (set) Token: 0x06041226 RID: 266790
		ICostData CostItemData { get; set; }
	}
}
