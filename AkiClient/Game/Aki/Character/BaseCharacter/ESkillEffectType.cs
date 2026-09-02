using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004224 RID: 16932
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillEffectType.ESkillEffectType")]
	public enum ESkillEffectType : byte
	{
		// Token: 0x040191F8 RID: 102904
		None,
		// Token: 0x040191F9 RID: 102905
		EndEffect,
		// Token: 0x040191FA RID: 102906
		DestroyEffect,
		// Token: 0x040191FB RID: 102907
		ESkillEffectType_MAX
	}
}
