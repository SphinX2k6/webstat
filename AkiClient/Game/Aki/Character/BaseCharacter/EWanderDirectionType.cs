using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004232 RID: 16946
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EWanderDirectionType.EWanderDirectionType")]
	public enum EWanderDirectionType : byte
	{
		// Token: 0x04019257 RID: 102999
		FBLR,
		// Token: 0x04019258 RID: 103000
		FB,
		// Token: 0x04019259 RID: 103001
		LR,
		// Token: 0x0401925A RID: 103002
		EWanderDirectionType_MAX
	}
}
