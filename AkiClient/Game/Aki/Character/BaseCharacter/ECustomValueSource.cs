using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F7 RID: 16887
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECustomValueSource.ECustomValueSource")]
	public enum ECustomValueSource : byte
	{
		// Token: 0x040190B4 RID: 102580
		固定值,
		// Token: 0x040190B5 RID: 102581
		表达式,
		// Token: 0x040190B6 RID: 102582
		技能目标位置,
		// Token: 0x040190B7 RID: 102583
		使用者位置,
		// Token: 0x040190B8 RID: 102584
		技能目标朝向,
		// Token: 0x040190B9 RID: 102585
		使用者朝向,
		// Token: 0x040190BA RID: 102586
		ECustomValueSource_MAX
	}
}
