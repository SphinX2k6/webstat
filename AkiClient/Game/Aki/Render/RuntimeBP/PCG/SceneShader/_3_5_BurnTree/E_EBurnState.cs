using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader._3_5_BurnTree
{
	// Token: 0x02003B84 RID: 15236
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_5_BurnTree/E_EBurnState.E_EBurnState")]
	public enum E_EBurnState : byte
	{
		// Token: 0x04010FC9 RID: 69577
		Idle,
		// Token: 0x04010FCA RID: 69578
		PreBurn,
		// Token: 0x04010FCB RID: 69579
		Burning,
		// Token: 0x04010FCC RID: 69580
		LeavesDecay,
		// Token: 0x04010FCD RID: 69581
		EmberFadeOut,
		// Token: 0x04010FCE RID: 69582
		BurnedOut,
		// Token: 0x04010FCF RID: 69583
		E_MAX
	}
}
