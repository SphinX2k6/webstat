using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041FC RID: 16892
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EDangoActionTargetType.EDangoActionTargetType")]
	public enum EDangoActionTargetType : byte
	{
		// Token: 0x040190DC RID: 102620
		自身团子,
		// Token: 0x040190DD RID: 102621
		自身与堆叠上方团子,
		// Token: 0x040190DE RID: 102622
		EDangoActionTargetType_MAX
	}
}
