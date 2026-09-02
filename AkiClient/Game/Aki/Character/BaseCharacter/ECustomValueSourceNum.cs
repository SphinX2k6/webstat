using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F8 RID: 16888
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECustomValueSourceNum.ECustomValueSourceNum")]
	public enum ECustomValueSourceNum : byte
	{
		// Token: 0x040190BC RID: 102588
		固定值,
		// Token: 0x040190BD RID: 102589
		表达式,
		// Token: 0x040190BE RID: 102590
		ECustomValueSourceNum_MAX
	}
}
