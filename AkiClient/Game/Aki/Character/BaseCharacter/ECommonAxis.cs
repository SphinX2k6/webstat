using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F1 RID: 16881
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECommonAxis.ECommonAxis")]
	public enum ECommonAxis : byte
	{
		// Token: 0x04019091 RID: 102545
		X,
		// Token: 0x04019092 RID: 102546
		Y,
		// Token: 0x04019093 RID: 102547
		Z,
		// Token: 0x04019094 RID: 102548
		ECommonAxis_MAX
	}
}
