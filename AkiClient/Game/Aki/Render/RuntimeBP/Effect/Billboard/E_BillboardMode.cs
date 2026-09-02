using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Billboard
{
	// Token: 0x02003D4C RID: 15692
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Billboard/E_BillboardMode.E_BillboardMode")]
	public enum E_BillboardMode : byte
	{
		// Token: 0x04013BB0 RID: 80816
		自由,
		// Token: 0x04013BB1 RID: 80817
		上方向轴,
		// Token: 0x04013BB2 RID: 80818
		右方向轴,
		// Token: 0x04013BB3 RID: 80819
		E_MAX
	}
}
