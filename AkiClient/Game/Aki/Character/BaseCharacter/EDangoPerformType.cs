using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041FE RID: 16894
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EDangoPerformType.EDangoPerformType")]
	public enum EDangoPerformType : byte
	{
		// Token: 0x040190E5 RID: 102629
		默认,
		// Token: 0x040190E6 RID: 102630
		改变高度,
		// Token: 0x040190E7 RID: 102631
		欢呼,
		// Token: 0x040190E8 RID: 102632
		比赛胜利,
		// Token: 0x040190E9 RID: 102633
		单人欢呼,
		// Token: 0x040190EA RID: 102634
		改变顺序,
		// Token: 0x040190EB RID: 102635
		EDangoPerformType_MAX
	}
}
