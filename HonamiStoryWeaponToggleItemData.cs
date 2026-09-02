using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001F71 RID: 8049
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryWeaponToggleItemData : IHonamiStoryWeaponToggleItemData
{
	// Token: 0x17001264 RID: 4708
	// (get) Token: 0x0600F10F RID: 61711 RVA: 0x0041E03C File Offset: 0x0041C23C
	// (set) Token: 0x0600F110 RID: 61712 RVA: 0x0041E044 File Offset: 0x0041C244
	public int WeaponId { get; set; }

	// Token: 0x17001265 RID: 4709
	// (get) Token: 0x0600F111 RID: 61713 RVA: 0x0041E04D File Offset: 0x0041C24D
	// (set) Token: 0x0600F112 RID: 61714 RVA: 0x0041E055 File Offset: 0x0041C255
	public HonamiStoryRoleEquipData EquipData { get; set; }

	// Token: 0x17001266 RID: 4710
	// (get) Token: 0x0600F113 RID: 61715 RVA: 0x0041E05E File Offset: 0x0041C25E
	// (set) Token: 0x0600F114 RID: 61716 RVA: 0x0041E066 File Offset: 0x0041C266
	public EHonamiStoryWeaponUseWay UseWay { get; set; }
}
