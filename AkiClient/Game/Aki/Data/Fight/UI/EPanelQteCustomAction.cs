using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EB8 RID: 16056
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/EPanelQteCustomAction.EPanelQteCustomAction")]
	public enum EPanelQteCustomAction : byte
	{
		// Token: 0x04014ECE RID: 85710
		RemoveFrozenBuff,
		// Token: 0x04014ECF RID: 85711
		ChangeRole,
		// Token: 0x04014ED0 RID: 85712
		FreeRunningRush,
		// Token: 0x04014ED1 RID: 85713
		FreeRunningHook,
		// Token: 0x04014ED2 RID: 85714
		FreeRunningJump,
		// Token: 0x04014ED3 RID: 85715
		EPanelQteCustomAction_MAX
	}
}
