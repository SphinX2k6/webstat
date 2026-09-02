using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools
{
	// Token: 0x02004290 RID: 17040
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/EWeaponType.EWeaponType")]
	public enum EWeaponType : byte
	{
		// Token: 0x040195F5 RID: 103925
		无,
		// Token: 0x040195F6 RID: 103926
		大刀,
		// Token: 0x040195F7 RID: 103927
		迅刀,
		// Token: 0x040195F8 RID: 103928
		双枪,
		// Token: 0x040195F9 RID: 103929
		拳套,
		// Token: 0x040195FA RID: 103930
		法器,
		// Token: 0x040195FB RID: 103931
		EWeaponType_MAX
	}
}
