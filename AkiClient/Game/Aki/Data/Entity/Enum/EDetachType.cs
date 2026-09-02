using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Entity.Enum
{
	// Token: 0x02003EFA RID: 16122
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Enum/EDetachType.EDetachType")]
	public enum EDetachType : byte
	{
		// Token: 0x040151B5 RID: 86453
		ManualDestroy,
		// Token: 0x040151B6 RID: 86454
		EntityDestroy,
		// Token: 0x040151B7 RID: 86455
		DestroyExternal,
		// Token: 0x040151B8 RID: 86456
		EDetachType_MAX
	}
}
