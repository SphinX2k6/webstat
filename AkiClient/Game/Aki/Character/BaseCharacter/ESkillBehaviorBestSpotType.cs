using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200421B RID: 16923
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillBehaviorBestSpotType.ESkillBehaviorBestSpotType")]
	public enum ESkillBehaviorBestSpotType : byte
	{
		// Token: 0x040191B2 RID: 102834
		撞墙停止,
		// Token: 0x040191B3 RID: 102835
		撞墙停止_技能施法者不穿墙,
		// Token: 0x040191B4 RID: 102836
		四向查询,
		// Token: 0x040191B5 RID: 102837
		四向查询_技能施法者不穿墙,
		// Token: 0x040191B6 RID: 102838
		四向查询_前台角色不穿墙_QTE专用_,
		// Token: 0x040191B7 RID: 102839
		编队位置,
		// Token: 0x040191B8 RID: 102840
		ESkillBehaviorBestSpotType_MAX
	}
}
