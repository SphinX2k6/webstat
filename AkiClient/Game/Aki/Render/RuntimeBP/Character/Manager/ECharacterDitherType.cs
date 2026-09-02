using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager
{
	// Token: 0x02003D8F RID: 15759
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Manager/ECharacterDitherType.ECharacterDitherType")]
	public enum ECharacterDitherType : byte
	{
		// Token: 0x04013FCE RID: 81870
		UnDefined,
		// Token: 0x04013FCF RID: 81871
		Fight,
		// Token: 0x04013FD0 RID: 81872
		Sequence,
		// Token: 0x04013FD1 RID: 81873
		Temporary,
		// Token: 0x04013FD2 RID: 81874
		ECharacterDitherType_MAX
	}
}
