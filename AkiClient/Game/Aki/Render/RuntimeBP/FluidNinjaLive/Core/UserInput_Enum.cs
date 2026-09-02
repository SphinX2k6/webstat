using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D12 RID: 15634
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/UserInput_Enum.UserInput_Enum")]
	public enum UserInput_Enum : byte
	{
		// Token: 0x040137F3 RID: 79859
		No_user_input,
		// Token: 0x040137F4 RID: 79860
		Mouse_single,
		// Token: 0x040137F5 RID: 79861
		Touch_single,
		// Token: 0x040137F6 RID: 79862
		Touch_multiple,
		// Token: 0x040137F7 RID: 79863
		UserInput_MAX
	}
}
