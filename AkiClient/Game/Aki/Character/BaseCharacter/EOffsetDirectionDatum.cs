using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004211 RID: 16913
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EOffsetDirectionDatum.EOffsetDirectionDatum")]
	public enum EOffsetDirectionDatum : byte
	{
		// Token: 0x04019168 RID: 102760
		User,
		// Token: 0x04019169 RID: 102761
		TargetPosition,
		// Token: 0x0401916A RID: 102762
		UserToTarget,
		// Token: 0x0401916B RID: 102763
		EOffsetDirectionDatum_MAX
	}
}
