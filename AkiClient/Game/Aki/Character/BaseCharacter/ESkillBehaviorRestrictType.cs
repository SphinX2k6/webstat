using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004221 RID: 16929
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillBehaviorRestrictType.ESkillBehaviorRestrictType")]
	public enum ESkillBehaviorRestrictType : byte
	{
		// Token: 0x040191E3 RID: 102883
		小队前台角色当前位置,
		// Token: 0x040191E4 RID: 102884
		技能施法者当前位置,
		// Token: 0x040191E5 RID: 102885
		技能施法者出生位置_怪物专用_,
		// Token: 0x040191E6 RID: 102886
		ESkillBehaviorRestrictType_MAX
	}
}
