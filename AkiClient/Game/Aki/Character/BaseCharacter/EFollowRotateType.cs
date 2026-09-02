using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004204 RID: 16900
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EFollowRotateType.EFollowRotateType")]
	public enum EFollowRotateType : byte
	{
		// Token: 0x04019113 RID: 102675
		朝向镜头前一定距离,
		// Token: 0x04019114 RID: 102676
		朝向指定实体,
		// Token: 0x04019115 RID: 102677
		同步指定实体,
		// Token: 0x04019116 RID: 102678
		朝向自身技能目标,
		// Token: 0x04019117 RID: 102679
		EFollowRotateType_MAX
	}
}
