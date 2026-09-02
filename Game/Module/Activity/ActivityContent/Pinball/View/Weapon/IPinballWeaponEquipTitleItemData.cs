using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A5 RID: 26021
	[NullableContext(1)]
	public interface IPinballWeaponEquipTitleItemData
	{
		// Token: 0x17009EC9 RID: 40649
		// (get) Token: 0x0604102E RID: 266286
		// (set) Token: 0x0604102F RID: 266287
		string TypeIconPath { get; set; }

		// Token: 0x17009ECA RID: 40650
		// (get) Token: 0x06041030 RID: 266288
		// (set) Token: 0x06041031 RID: 266289
		TableTextArgNew DescTextData { get; set; }

		// Token: 0x17009ECB RID: 40651
		// (get) Token: 0x06041032 RID: 266290
		// (set) Token: 0x06041033 RID: 266291
		bool CanEquip { get; set; }
	}
}
