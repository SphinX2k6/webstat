using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D0E RID: 15630
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/RenderTargetList.RenderTargetList")]
	public enum RenderTargetList : byte
	{
		// Token: 0x040137E0 RID: 79840
		RT_VelocityDensity,
		// Token: 0x040137E1 RID: 79841
		RT_Divergence,
		// Token: 0x040137E2 RID: 79842
		RT_Pressure,
		// Token: 0x040137E3 RID: 79843
		RT_Painter,
		// Token: 0x040137E4 RID: 79844
		RT_Output,
		// Token: 0x040137E5 RID: 79845
		RenderTargetList_MAX
	}
}
