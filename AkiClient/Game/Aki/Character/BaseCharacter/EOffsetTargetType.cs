using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004212 RID: 16914
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EOffsetTargetType.EOffsetTargetType")]
	public enum EOffsetTargetType : byte
	{
		// Token: 0x0401916D RID: 102765
		自身,
		// Token: 0x0401916E RID: 102766
		玩家当前角色,
		// Token: 0x0401916F RID: 102767
		EOffsetTargetType_MAX
	}
}
