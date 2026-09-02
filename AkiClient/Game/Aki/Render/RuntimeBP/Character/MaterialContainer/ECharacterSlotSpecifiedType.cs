using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer
{
	// Token: 0x02003D89 RID: 15753
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/ECharacterSlotSpecifiedType.ECharacterSlotSpecifiedType")]
	public enum ECharacterSlotSpecifiedType : byte
	{
		// Token: 0x04013F8F RID: 81807
		All,
		// Token: 0x04013F90 RID: 81808
		BodyAndOutline,
		// Token: 0x04013F91 RID: 81809
		Body,
		// Token: 0x04013F92 RID: 81810
		Outline,
		// Token: 0x04013F93 RID: 81811
		ECharacterSlotSpecifiedType_MAX
	}
}
