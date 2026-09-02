using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200421C RID: 16924
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillBehaviorBuffTargetType.ESkillBehaviorBuffTargetType")]
	public enum ESkillBehaviorBuffTargetType : byte
	{
		// Token: 0x040191BA RID: 102842
		施法者,
		// Token: 0x040191BB RID: 102843
		技能目标,
		// Token: 0x040191BC RID: 102844
		ESkillBehaviorBuffTargetType_MAX
	}
}
