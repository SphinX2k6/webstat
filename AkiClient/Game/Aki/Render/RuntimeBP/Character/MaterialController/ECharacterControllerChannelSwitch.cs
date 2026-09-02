using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D77 RID: 15735
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/ECharacterControllerChannelSwitch.ECharacterControllerChannelSwitch")]
	public enum ECharacterControllerChannelSwitch : byte
	{
		// Token: 0x04013EA6 RID: 81574
		RGB,
		// Token: 0x04013EA7 RID: 81575
		R,
		// Token: 0x04013EA8 RID: 81576
		G,
		// Token: 0x04013EA9 RID: 81577
		B,
		// Token: 0x04013EAA RID: 81578
		A,
		// Token: 0x04013EAB RID: 81579
		ECharacterControllerChannelSwitch_MAX
	}
}
