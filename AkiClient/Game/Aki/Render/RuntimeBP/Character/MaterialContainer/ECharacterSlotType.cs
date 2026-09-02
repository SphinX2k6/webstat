using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer
{
	// Token: 0x02003D8A RID: 15754
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/ECharacterSlotType.ECharacterSlotType")]
	public enum ECharacterSlotType : byte
	{
		// Token: 0x04013F95 RID: 81813
		Error,
		// Token: 0x04013F96 RID: 81814
		Body,
		// Token: 0x04013F97 RID: 81815
		Outline,
		// Token: 0x04013F98 RID: 81816
		EyeMask,
		// Token: 0x04013F99 RID: 81817
		HairEyeTransparent,
		// Token: 0x04013F9A RID: 81818
		FaceShadow,
		// Token: 0x04013F9B RID: 81819
		ECharacterSlotType_MAX
	}
}
