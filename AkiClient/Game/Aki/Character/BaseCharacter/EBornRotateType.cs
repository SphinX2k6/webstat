using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E1 RID: 16865
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBornRotateType.EBornRotateType")]
	public enum EBornRotateType : byte
	{
		// Token: 0x04019008 RID: 102408
		保持自身,
		// Token: 0x04019009 RID: 102409
		同步玩家当前角色,
		// Token: 0x0401900A RID: 102410
		朝向镜头前一定距离,
		// Token: 0x0401900B RID: 102411
		EBornRotateType_MAX
	}
}
