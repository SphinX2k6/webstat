using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer
{
	// Token: 0x02003D87 RID: 15751
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialContainer/ECharacterBodySpecifiedType.ECharacterBodySpecifiedType")]
	public enum ECharacterBodySpecifiedType : byte
	{
		// Token: 0x04013F7F RID: 81791
		All,
		// Token: 0x04013F80 RID: 81792
		Body,
		// Token: 0x04013F81 RID: 81793
		Weapon,
		// Token: 0x04013F82 RID: 81794
		Hulu,
		// Token: 0x04013F83 RID: 81795
		WeaponAndHulu,
		// Token: 0x04013F84 RID: 81796
		Other,
		// Token: 0x04013F85 RID: 81797
		ExtraBody,
		// Token: 0x04013F86 RID: 81798
		External,
		// Token: 0x04013F87 RID: 81799
		ECharacterBodySpecifiedType_MAX
	}
}
