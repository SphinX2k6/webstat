using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E39 RID: 15929
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/ECommonQteType.ECommonQteType")]
	public enum ECommonQteType : byte
	{
		// Token: 0x040148B2 RID: 84146
		单按钮点击型,
		// Token: 0x040148B3 RID: 84147
		单按钮连击型,
		// Token: 0x040148B4 RID: 84148
		单按钮滑动型,
		// Token: 0x040148B5 RID: 84149
		单按钮长按型,
		// Token: 0x040148B6 RID: 84150
		多按钮选项型,
		// Token: 0x040148B7 RID: 84151
		ECommonQteType_MAX
	}
}
