using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004225 RID: 16933
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillEventType.ESkillEventType")]
	public enum ESkillEventType : byte
	{
		// Token: 0x040191FD RID: 102909
		攻击事件,
		// Token: 0x040191FE RID: 102910
		弃置的功能添加GE现在专用为使用子弹,
		// Token: 0x040191FF RID: 102911
		ESkillEventType_MAX
	}
}
