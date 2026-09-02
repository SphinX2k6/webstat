using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200420B RID: 16907
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EMorphType.EMorphType")]
	public enum EMorphType : byte
	{
		// Token: 0x04019143 RID: 102723
		默认形态,
		// Token: 0x04019144 RID: 102724
		变身形态,
		// Token: 0x04019145 RID: 102725
		EMorphType_MAX
	}
}
