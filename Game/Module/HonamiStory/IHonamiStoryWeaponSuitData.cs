using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C83 RID: 23683
	[NullableContext(2)]
	public interface IHonamiStoryWeaponSuitData
	{
		// Token: 0x17009800 RID: 38912
		// (get) Token: 0x0603BD40 RID: 245056
		// (set) Token: 0x0603BD41 RID: 245057
		int SuitId { get; set; }

		// Token: 0x17009801 RID: 38913
		// (get) Token: 0x0603BD42 RID: 245058
		// (set) Token: 0x0603BD43 RID: 245059
		HonamiStoryRoleEquipData EquipData { get; set; }
	}
}
