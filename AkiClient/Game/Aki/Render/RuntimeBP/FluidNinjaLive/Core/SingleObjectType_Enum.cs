using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D11 RID: 15633
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/SingleObjectType_Enum.SingleObjectType_Enum")]
	public enum SingleObjectType_Enum : byte
	{
		// Token: 0x040137EF RID: 79855
		Skeletal_Mesh_Bone,
		// Token: 0x040137F0 RID: 79856
		Primitive_Component,
		// Token: 0x040137F1 RID: 79857
		SingleObjectType_MAX
	}
}
