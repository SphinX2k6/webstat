using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041FA RID: 16890
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECustomValueSourceVector.ECustomValueSourceVector")]
	public enum ECustomValueSourceVector : byte
	{
		// Token: 0x040190C6 RID: 102598
		固定值,
		// Token: 0x040190C7 RID: 102599
		表达式,
		// Token: 0x040190C8 RID: 102600
		技能目标位置,
		// Token: 0x040190C9 RID: 102601
		使用者位置,
		// Token: 0x040190CA RID: 102602
		使用者朝技能目标标准向量,
		// Token: 0x040190CB RID: 102603
		使用者朝技能目标水平标准向量,
		// Token: 0x040190CC RID: 102604
		使用者前向量,
		// Token: 0x040190CD RID: 102605
		使用者右向量,
		// Token: 0x040190CE RID: 102606
		使用者上向量,
		// Token: 0x040190CF RID: 102607
		技能目标前向量,
		// Token: 0x040190D0 RID: 102608
		技能目标右向量,
		// Token: 0x040190D1 RID: 102609
		技能目标上向量,
		// Token: 0x040190D2 RID: 102610
		ECustomValueSourceVector_MAX
	}
}
