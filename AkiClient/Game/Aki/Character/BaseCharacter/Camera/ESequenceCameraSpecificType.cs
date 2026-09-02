using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200430C RID: 17164
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/ESequenceCameraSpecificType.ESequenceCameraSpecificType")]
	public enum ESequenceCameraSpecificType : byte
	{
		// Token: 0x040199E3 RID: 104931
		无,
		// Token: 0x040199E4 RID: 104932
		梦境链接,
		// Token: 0x040199E5 RID: 104933
		ESequenceCameraSpecificType_MAX
	}
}
