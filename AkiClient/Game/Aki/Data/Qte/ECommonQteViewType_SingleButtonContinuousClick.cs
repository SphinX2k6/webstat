using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E3D RID: 15933
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/ECommonQteViewType_SingleButtonContinuousClick.ECommonQteViewType_SingleButtonContinuousClick")]
	public enum ECommonQteViewType_SingleButtonContinuousClick : byte
	{
		// Token: 0x040148D0 RID: 84176
		单按钮连击通用界面,
		// Token: 0x040148D1 RID: 84177
		单按钮连击3D界面,
		// Token: 0x040148D2 RID: 84178
		单按钮连击快启动界面,
		// Token: 0x040148D3 RID: 84179
		ECommonQteViewType_MAX
	}
}
