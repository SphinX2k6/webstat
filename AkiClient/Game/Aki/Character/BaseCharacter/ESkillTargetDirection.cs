using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200422A RID: 16938
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillTargetDirection.ESkillTargetDirection")]
	public enum ESkillTargetDirection : byte
	{
		// Token: 0x04019223 RID: 102947
		技能目标方向,
		// Token: 0x04019224 RID: 102948
		摇杆方向,
		// Token: 0x04019225 RID: 102949
		角色方向,
		// Token: 0x04019226 RID: 102950
		相机方向,
		// Token: 0x04019227 RID: 102951
		技能目标方向_载具专用_,
		// Token: 0x04019228 RID: 102952
		ESkillTargetDirection_MAX
	}
}
