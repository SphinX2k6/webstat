using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D78 RID: 15736
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/ECharacterControllerType.ECharacterControllerType")]
	public enum ECharacterControllerType : byte
	{
		// Token: 0x04013EAD RID: 81581
		Timeline,
		// Token: 0x04013EAE RID: 81582
		Runtime,
		// Token: 0x04013EAF RID: 81583
		Manual,
		// Token: 0x04013EB0 RID: 81584
		ECharacterControllerType_MAX
	}
}
