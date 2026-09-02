using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EB9 RID: 16057
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/EPanelQteViewType.EPanelQteViewType")]
	public enum EPanelQteViewType : byte
	{
		// Token: 0x04014ED5 RID: 85717
		Frozen,
		// Token: 0x04014ED6 RID: 85718
		Interact,
		// Token: 0x04014ED7 RID: 85719
		YouHu,
		// Token: 0x04014ED8 RID: 85720
		FreeRunning,
		// Token: 0x04014ED9 RID: 85721
		EPanelQteViewType_MAX
	}
}
