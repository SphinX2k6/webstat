using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A2 RID: 26018
	[NullableContext(1)]
	public interface IPinballWeaponEquipTipItemData
	{
		// Token: 0x17009EC1 RID: 40641
		// (get) Token: 0x06041012 RID: 266258
		// (set) Token: 0x06041013 RID: 266259
		PinballWeaponData WeaponData { get; set; }

		// Token: 0x17009EC2 RID: 40642
		// (get) Token: 0x06041014 RID: 266260
		// (set) Token: 0x06041015 RID: 266261
		bool ShowButton { get; set; }

		// Token: 0x17009EC3 RID: 40643
		// (get) Token: 0x06041016 RID: 266262
		// (set) Token: 0x06041017 RID: 266263
		EPinballWeaponEquipState State { get; set; }

		// Token: 0x17009EC4 RID: 40644
		// (get) Token: 0x06041018 RID: 266264
		// (set) Token: 0x06041019 RID: 266265
		Action ConfirmDelegate { get; set; }
	}
}
