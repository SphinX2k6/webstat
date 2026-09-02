using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F9 RID: 16889
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECustomValueSourceRotator.ECustomValueSourceRotator")]
	public enum ECustomValueSourceRotator : byte
	{
		// Token: 0x040190C0 RID: 102592
		固定值,
		// Token: 0x040190C1 RID: 102593
		表达式,
		// Token: 0x040190C2 RID: 102594
		技能目标朝向,
		// Token: 0x040190C3 RID: 102595
		使用者朝向,
		// Token: 0x040190C4 RID: 102596
		ECustomValueSourceRotator_MAX
	}
}
