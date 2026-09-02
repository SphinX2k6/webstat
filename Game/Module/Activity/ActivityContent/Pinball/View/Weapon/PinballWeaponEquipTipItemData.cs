using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A3 RID: 26019
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponEquipTipItemData : IPinballWeaponEquipTipItemData
	{
		// Token: 0x17009EC5 RID: 40645
		// (get) Token: 0x0604101A RID: 266266 RVA: 0x010AE216 File Offset: 0x010AC416
		// (set) Token: 0x0604101B RID: 266267 RVA: 0x010AE21E File Offset: 0x010AC41E
		public PinballWeaponData WeaponData { get; set; }

		// Token: 0x17009EC6 RID: 40646
		// (get) Token: 0x0604101C RID: 266268 RVA: 0x010AE227 File Offset: 0x010AC427
		// (set) Token: 0x0604101D RID: 266269 RVA: 0x010AE22F File Offset: 0x010AC42F
		public bool ShowButton { get; set; }

		// Token: 0x17009EC7 RID: 40647
		// (get) Token: 0x0604101E RID: 266270 RVA: 0x010AE238 File Offset: 0x010AC438
		// (set) Token: 0x0604101F RID: 266271 RVA: 0x010AE240 File Offset: 0x010AC440
		public EPinballWeaponEquipState State { get; set; }

		// Token: 0x17009EC8 RID: 40648
		// (get) Token: 0x06041020 RID: 266272 RVA: 0x010AE249 File Offset: 0x010AC449
		// (set) Token: 0x06041021 RID: 266273 RVA: 0x010AE251 File Offset: 0x010AC451
		public Action ConfirmDelegate { get; set; }
	}
}
