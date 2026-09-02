using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200422C RID: 16940
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillTargetPriority.ESkillTargetPriority")]
	public enum ESkillTargetPriority : byte
	{
		// Token: 0x0401922F RID: 102959
		摇杆方向优先,
		// Token: 0x04019230 RID: 102960
		角色方向优先,
		// Token: 0x04019231 RID: 102961
		锁定目标优先,
		// Token: 0x04019232 RID: 102962
		距离优先,
		// Token: 0x04019233 RID: 102963
		镜头方向优先,
		// Token: 0x04019234 RID: 102964
		摇杆方向优先_精准模式_,
		// Token: 0x04019235 RID: 102965
		镜头方向优先_精准模式_,
		// Token: 0x04019236 RID: 102966
		角色方向优先_精准模式_,
		// Token: 0x04019237 RID: 102967
		系统设置,
		// Token: 0x04019238 RID: 102968
		ESkillTargetPriority_MAX
	}
}
