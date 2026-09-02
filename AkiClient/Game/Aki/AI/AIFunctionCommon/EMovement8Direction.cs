using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon
{
	// Token: 0x0200438C RID: 17292
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/EMovement8Direction.EMovement8Direction")]
	public enum EMovement8Direction : byte
	{
		// Token: 0x04019E5A RID: 106074
		前,
		// Token: 0x04019E5B RID: 106075
		后,
		// Token: 0x04019E5C RID: 106076
		左,
		// Token: 0x04019E5D RID: 106077
		右,
		// Token: 0x04019E5E RID: 106078
		停,
		// Token: 0x04019E5F RID: 106079
		左前,
		// Token: 0x04019E60 RID: 106080
		左后,
		// Token: 0x04019E61 RID: 106081
		右前,
		// Token: 0x04019E62 RID: 106082
		右后,
		// Token: 0x04019E63 RID: 106083
		EMovement8Direction_MAX
	}
}
