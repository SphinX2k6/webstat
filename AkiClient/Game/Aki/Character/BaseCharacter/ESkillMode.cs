using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004228 RID: 16936
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillMode.ESkillMode")]
	public enum ESkillMode : byte
	{
		// Token: 0x04019218 RID: 102936
		Simple,
		// Token: 0x04019219 RID: 102937
		GameplayAbility,
		// Token: 0x0401921A RID: 102938
		ESkillMode_MAX
	}
}
