using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004215 RID: 16917
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EPokerStateType.EPokerStateType")]
	public enum EPokerStateType : byte
	{
		// Token: 0x0401917C RID: 102780
		Idel,
		// Token: 0x0401917D RID: 102781
		BeChosenCardStrong,
		// Token: 0x0401917E RID: 102782
		BeChosenCardWeak,
		// Token: 0x0401917F RID: 102783
		BeDrawnCardHappy,
		// Token: 0x04019180 RID: 102784
		BeDrawnCardSad,
		// Token: 0x04019181 RID: 102785
		DrawCardNormal,
		// Token: 0x04019182 RID: 102786
		DrawCardThinking,
		// Token: 0x04019183 RID: 102787
		GetCardHappy,
		// Token: 0x04019184 RID: 102788
		GetCardSad,
		// Token: 0x04019185 RID: 102789
		Win,
		// Token: 0x04019186 RID: 102790
		Lose,
		// Token: 0x04019187 RID: 102791
		IdelPerformance,
		// Token: 0x04019188 RID: 102792
		EPokerStateType_MAX
	}
}
