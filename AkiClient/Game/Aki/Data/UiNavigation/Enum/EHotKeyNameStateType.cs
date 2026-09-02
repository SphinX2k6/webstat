using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.UiNavigation.Enum
{
	// Token: 0x02003DFA RID: 15866
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/UiNavigation/Enum/EHotKeyNameStateType.EHotKeyNameStateType")]
	public enum EHotKeyNameStateType : byte
	{
		// Token: 0x04014648 RID: 83528
		None,
		// Token: 0x04014649 RID: 83529
		Normal,
		// Token: 0x0401464A RID: 83530
		ToggleSelected,
		// Token: 0x0401464B RID: 83531
		EHotKeyNameStateType_MAX
	}
}
