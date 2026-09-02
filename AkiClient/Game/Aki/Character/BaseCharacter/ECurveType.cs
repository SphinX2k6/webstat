using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F4 RID: 16884
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECurveType.ECurveType")]
	public enum ECurveType : byte
	{
		// Token: 0x040190A2 RID: 102562
		FootState,
		// Token: 0x040190A3 RID: 102563
		EnableFootIK_R,
		// Token: 0x040190A4 RID: 102564
		RootPos,
		// Token: 0x040190A5 RID: 102565
		ECurveType_MAX
	}
}
