using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F6 RID: 16886
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECustomValueReturn.ECustomValueReturn")]
	public enum ECustomValueReturn : byte
	{
		// Token: 0x040190AF RID: 102575
		数字,
		// Token: 0x040190B0 RID: 102576
		向量,
		// Token: 0x040190B1 RID: 102577
		旋转,
		// Token: 0x040190B2 RID: 102578
		ECustomValueReturn_MAX
	}
}
