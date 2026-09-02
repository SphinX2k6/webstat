using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.UiNavigation.Enum
{
	// Token: 0x02003DF9 RID: 15865
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/UiNavigation/Enum/ECursorOffsetType.ECursorOffsetType")]
	public enum ECursorOffsetType : byte
	{
		// Token: 0x04014642 RID: 83522
		Left,
		// Token: 0x04014643 RID: 83523
		Top,
		// Token: 0x04014644 RID: 83524
		Right,
		// Token: 0x04014645 RID: 83525
		Down,
		// Token: 0x04014646 RID: 83526
		ECursorOffsetType_MAX
	}
}
