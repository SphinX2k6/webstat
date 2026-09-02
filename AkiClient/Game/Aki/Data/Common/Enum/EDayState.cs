using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Common.Enum
{
	// Token: 0x02003F0C RID: 16140
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Common/Enum/EDayState.EDayState")]
	public enum EDayState : byte
	{
		// Token: 0x04015233 RID: 86579
		白天,
		// Token: 0x04015234 RID: 86580
		晚上,
		// Token: 0x04015235 RID: 86581
		EDayState_MAX
	}
}
