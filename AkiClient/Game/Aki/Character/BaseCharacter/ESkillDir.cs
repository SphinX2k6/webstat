using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004223 RID: 16931
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillDir.ESkillDir")]
	public enum ESkillDir : byte
	{
		// Token: 0x040191F1 RID: 102897
		角色面朝方向,
		// Token: 0x040191F2 RID: 102898
		废弃1,
		// Token: 0x040191F3 RID: 102899
		就近锁定目标瞄准点,
		// Token: 0x040191F4 RID: 102900
		摇杆方向,
		// Token: 0x040191F5 RID: 102901
		相机方向,
		// Token: 0x040191F6 RID: 102902
		ESkillDir_MAX
	}
}
