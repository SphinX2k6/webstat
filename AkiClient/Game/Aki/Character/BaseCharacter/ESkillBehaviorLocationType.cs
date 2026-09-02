using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004220 RID: 16928
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillBehaviorLocationType.ESkillBehaviorLocationType")]
	public enum ESkillBehaviorLocationType : byte
	{
		// Token: 0x040191D8 RID: 102872
		技能施法者,
		// Token: 0x040191D9 RID: 102873
		技能目标锁定点,
		// Token: 0x040191DA RID: 102874
		当前小队锁定目标,
		// Token: 0x040191DB RID: 102875
		小队当前角色,
		// Token: 0x040191DC RID: 102876
		召唤者_伴生物专用_,
		// Token: 0x040191DD RID: 102877
		当前小队摄像机,
		// Token: 0x040191DE RID: 102878
		黑板位置,
		// Token: 0x040191DF RID: 102879
		子弹位置,
		// Token: 0x040191E0 RID: 102880
		伴生物位置,
		// Token: 0x040191E1 RID: 102881
		ESkillBehaviorLocationType_MAX
	}
}
