using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042EB RID: 17131
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EAimAssistMode.EAimAssistMode")]
	public enum EAimAssistMode : byte
	{
		// Token: 0x040197DF RID: 104415
		Closed,
		// Token: 0x040197E0 RID: 104416
		OpenOnStart,
		// Token: 0x040197E1 RID: 104417
		FullyOpen,
		// Token: 0x040197E2 RID: 104418
		EAimAssistMode_MAX
	}
}
