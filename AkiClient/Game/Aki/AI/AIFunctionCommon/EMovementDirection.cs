using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon
{
	// Token: 0x0200438D RID: 17293
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/EMovementDirection.EMovementDirection")]
	public enum EMovementDirection : byte
	{
		// Token: 0x04019E65 RID: 106085
		前,
		// Token: 0x04019E66 RID: 106086
		后,
		// Token: 0x04019E67 RID: 106087
		左,
		// Token: 0x04019E68 RID: 106088
		右,
		// Token: 0x04019E69 RID: 106089
		停,
		// Token: 0x04019E6A RID: 106090
		EMovementDirection_MAX
	}
}
