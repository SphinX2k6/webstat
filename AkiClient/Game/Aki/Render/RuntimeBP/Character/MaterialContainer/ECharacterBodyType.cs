using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer
{
	// Token: 0x02003D88 RID: 15752
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/ECharacterBodyType.ECharacterBodyType")]
	public enum ECharacterBodyType : byte
	{
		// Token: 0x04013F89 RID: 81801
		Body,
		// Token: 0x04013F8A RID: 81802
		Weapon,
		// Token: 0x04013F8B RID: 81803
		Hulu,
		// Token: 0x04013F8C RID: 81804
		Other,
		// Token: 0x04013F8D RID: 81805
		ECharacterBodyType_MAX
	}
}
