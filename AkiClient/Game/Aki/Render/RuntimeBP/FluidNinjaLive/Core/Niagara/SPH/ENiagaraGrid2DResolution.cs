using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core.Niagara.SPH
{
	// Token: 0x02003D17 RID: 15639
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/Niagara/SPH/ENiagaraGrid2DResolution.ENiagaraGrid2DResolution")]
	public enum ENiagaraGrid2DResolution : byte
	{
		// Token: 0x0401380F RID: 79887
		Independent,
		// Token: 0x04013810 RID: 79888
		Max_Axis,
		// Token: 0x04013811 RID: 79889
		World_Cell_Size,
		// Token: 0x04013812 RID: 79890
		Other_Grid,
		// Token: 0x04013813 RID: 79891
		ENiagaraGrid2DResolution_MAX
	}
}
