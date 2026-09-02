using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200422E RID: 16942
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESwim.ESwim")]
	public enum ESwim : byte
	{
		// Token: 0x0401923F RID: 102975
		NormalSwim,
		// Token: 0x04019240 RID: 102976
		FastSwim,
		// Token: 0x04019241 RID: 102977
		Floating,
		// Token: 0x04019242 RID: 102978
		ESwim_MAX
	}
}
