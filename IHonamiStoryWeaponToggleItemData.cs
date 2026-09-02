using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001F70 RID: 8048
[NullableContext(2)]
public interface IHonamiStoryWeaponToggleItemData
{
	// Token: 0x17001261 RID: 4705
	// (get) Token: 0x0600F109 RID: 61705
	// (set) Token: 0x0600F10A RID: 61706
	int WeaponId { get; set; }

	// Token: 0x17001262 RID: 4706
	// (get) Token: 0x0600F10B RID: 61707
	// (set) Token: 0x0600F10C RID: 61708
	HonamiStoryRoleEquipData EquipData { get; set; }

	// Token: 0x17001263 RID: 4707
	// (get) Token: 0x0600F10D RID: 61709
	// (set) Token: 0x0600F10E RID: 61710
	EHonamiStoryWeaponUseWay UseWay { get; set; }
}
