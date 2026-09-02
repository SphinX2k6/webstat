using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A6 RID: 26022
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponEquipTitleItemData : IPinballWeaponEquipTitleItemData
	{
		// Token: 0x17009ECC RID: 40652
		// (get) Token: 0x06041034 RID: 266292 RVA: 0x010AE612 File Offset: 0x010AC812
		// (set) Token: 0x06041035 RID: 266293 RVA: 0x010AE61A File Offset: 0x010AC81A
		public string TypeIconPath { get; set; }

		// Token: 0x17009ECD RID: 40653
		// (get) Token: 0x06041036 RID: 266294 RVA: 0x010AE623 File Offset: 0x010AC823
		// (set) Token: 0x06041037 RID: 266295 RVA: 0x010AE62B File Offset: 0x010AC82B
		public TableTextArgNew DescTextData { get; set; }

		// Token: 0x17009ECE RID: 40654
		// (get) Token: 0x06041038 RID: 266296 RVA: 0x010AE634 File Offset: 0x010AC834
		// (set) Token: 0x06041039 RID: 266297 RVA: 0x010AE63C File Offset: 0x010AC83C
		public bool CanEquip { get; set; }
	}
}
