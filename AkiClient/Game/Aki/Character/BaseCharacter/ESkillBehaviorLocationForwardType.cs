using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200421F RID: 16927
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillBehaviorLocationForwardType.ESkillBehaviorLocationForwardType")]
	public enum ESkillBehaviorLocationForwardType : byte
	{
		// Token: 0x040191D1 RID: 102865
		位置基准目标正方向,
		// Token: 0x040191D2 RID: 102866
		技能施法者正方向,
		// Token: 0x040191D3 RID: 102867
		水平面上基准目标朝向技能施法者的方向,
		// Token: 0x040191D4 RID: 102868
		镜头方向,
		// Token: 0x040191D5 RID: 102869
		水平面上基准目标朝向前台角色的方向,
		// Token: 0x040191D6 RID: 102870
		ESkillBehaviorLocationForwardType_MAX
	}
}
