using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Enum
{
	// Token: 0x0200400F RID: 16399
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Enum/EWeaponViewName.EWeaponViewName")]
	public enum EWeaponViewName : byte
	{
		// Token: 0x040172C9 RID: 94921
		None,
		// Token: 0x040172CA RID: 94922
		RoleWeaponTabView,
		// Token: 0x040172CB RID: 94923
		WeaponLevelUpView,
		// Token: 0x040172CC RID: 94924
		WeaponResonanceView,
		// Token: 0x040172CD RID: 94925
		WeaponReplaceView,
		// Token: 0x040172CE RID: 94926
		GachaScanView,
		// Token: 0x040172CF RID: 94927
		EWeaponViewName_MAX
	}
}
