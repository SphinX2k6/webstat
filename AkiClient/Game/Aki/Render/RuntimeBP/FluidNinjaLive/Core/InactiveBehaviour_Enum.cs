using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D01 RID: 15617
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/InactiveBehaviour_Enum.InactiveBehaviour_Enum")]
	public enum InactiveBehaviour_Enum : byte
	{
		// Token: 0x040136CA RID: 79562
		Hold_last_frame_when_inactive,
		// Token: 0x040136CB RID: 79563
		Gray_when_inactive,
		// Token: 0x040136CC RID: 79564
		Hidden_when_inactive,
		// Token: 0x040136CD RID: 79565
		InactiveBehaviour_MAX
	}
}
