using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F3 RID: 17139
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/ECameraModifyParamType.ECameraModifyParamType")]
	public enum ECameraModifyParamType : byte
	{
		// Token: 0x0401983A RID: 104506
		数值,
		// Token: 0x0401983B RID: 104507
		曲线,
		// Token: 0x0401983C RID: 104508
		ECameraModifyParamType_MAX
	}
}
