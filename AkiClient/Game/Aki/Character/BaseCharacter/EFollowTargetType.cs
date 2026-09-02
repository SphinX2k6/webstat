using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004205 RID: 16901
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EFollowTargetType.EFollowTargetType")]
	public enum EFollowTargetType : byte
	{
		// Token: 0x04019119 RID: 102681
		玩家当前控制角色,
		// Token: 0x0401911A RID: 102682
		伴生物召唤者,
		// Token: 0x0401911B RID: 102683
		指定实体,
		// Token: 0x0401911C RID: 102684
		玩家当前载具,
		// Token: 0x0401911D RID: 102685
		EFollowTargetType_MAX
	}
}
