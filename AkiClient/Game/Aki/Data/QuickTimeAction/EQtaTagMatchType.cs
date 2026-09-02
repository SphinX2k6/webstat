using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E1A RID: 15898
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/EQtaTagMatchType.EQtaTagMatchType")]
	public enum EQtaTagMatchType : byte
	{
		// Token: 0x040147A8 RID: 83880
		All,
		// Token: 0x040147A9 RID: 83881
		Any,
		// Token: 0x040147AA RID: 83882
		EQtaTagMatchType_MAX
	}
}
