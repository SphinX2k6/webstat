using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Condition.Enum
{
	// Token: 0x02003F07 RID: 16135
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Condition/Enum/SConDitionGroupType.SConditionGroupType")]
	public enum SConditionGroupType : byte
	{
		// Token: 0x04015211 RID: 86545
		AND,
		// Token: 0x04015212 RID: 86546
		OR,
		// Token: 0x04015213 RID: 86547
		SConditionGroupType_MAX
	}
}
