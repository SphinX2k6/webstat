using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x02004009 RID: 16393
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/EFootstepAkAudioEventType.EFootstepAkAudioEventType")]
	public enum EFootstepAkAudioEventType : byte
	{
		// Token: 0x04017294 RID: 94868
		Walk,
		// Token: 0x04017295 RID: 94869
		Run,
		// Token: 0x04017296 RID: 94870
		Sprint,
		// Token: 0x04017297 RID: 94871
		Fallback,
		// Token: 0x04017298 RID: 94872
		EFootstepAkAudioEventType_MAX
	}
}
