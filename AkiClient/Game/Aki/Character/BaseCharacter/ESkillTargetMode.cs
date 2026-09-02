using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200422B RID: 16939
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillTargetMode.ESkillTargetMode")]
	public enum ESkillTargetMode : byte
	{
		// Token: 0x0401922A RID: 102954
		NotChange,
		// Token: 0x0401922B RID: 102955
		HateOrLockOn,
		// Token: 0x0401922C RID: 102956
		ChangeWhenTargetDie,
		// Token: 0x0401922D RID: 102957
		ESkillTargetMode_MAX
	}
}
