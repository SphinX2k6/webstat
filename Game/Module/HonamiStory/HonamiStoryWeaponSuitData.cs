using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C84 RID: 23684
	[NullableContext(2)]
	[Nullable(0)]
	public class HonamiStoryWeaponSuitData : IHonamiStoryWeaponSuitData
	{
		// Token: 0x17009802 RID: 38914
		// (get) Token: 0x0603BD44 RID: 245060 RVA: 0x00F2B34C File Offset: 0x00F2954C
		// (set) Token: 0x0603BD45 RID: 245061 RVA: 0x00F2B354 File Offset: 0x00F29554
		public int SuitId { get; set; }

		// Token: 0x17009803 RID: 38915
		// (get) Token: 0x0603BD46 RID: 245062 RVA: 0x00F2B35D File Offset: 0x00F2955D
		// (set) Token: 0x0603BD47 RID: 245063 RVA: 0x00F2B365 File Offset: 0x00F29565
		public HonamiStoryRoleEquipData EquipData { get; set; }
	}
}
