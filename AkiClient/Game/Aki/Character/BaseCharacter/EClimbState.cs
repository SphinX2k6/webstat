using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F0 RID: 16880
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EClimbState.EClimbState")]
	public enum EClimbState : byte
	{
		// Token: 0x0401908A RID: 102538
		无,
		// Token: 0x0401908B RID: 102539
		进入攀爬,
		// Token: 0x0401908C RID: 102540
		攀爬中,
		// Token: 0x0401908D RID: 102541
		退出攀爬,
		// Token: 0x0401908E RID: 102542
		跳下退出,
		// Token: 0x0401908F RID: 102543
		EClimbState_MAX
	}
}
