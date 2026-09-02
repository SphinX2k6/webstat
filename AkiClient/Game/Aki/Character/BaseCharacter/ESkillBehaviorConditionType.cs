using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200421E RID: 16926
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillBehaviorConditionType.ESkillBehaviorConditionType")]
	public enum ESkillBehaviorConditionType : byte
	{
		// Token: 0x040191C6 RID: 102854
		是否有技能目标,
		// Token: 0x040191C7 RID: 102855
		与技能目标锁定点距离,
		// Token: 0x040191C8 RID: 102856
		与技能目标锁定点角度,
		// Token: 0x040191C9 RID: 102857
		施法者标签检测,
		// Token: 0x040191CA RID: 102858
		施法者属性检测,
		// Token: 0x040191CB RID: 102859
		空中高度检测,
		// Token: 0x040191CC RID: 102860
		与技能目标锁定点高度,
		// Token: 0x040191CD RID: 102861
		是否有技能目标和是否战斗单位,
		// Token: 0x040191CE RID: 102862
		是否有摇杆输入,
		// Token: 0x040191CF RID: 102863
		ESkillBehaviorConditionType_MAX
	}
}
