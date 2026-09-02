using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E3A RID: 15930
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/ECommonQteViewType_Drag.ECommonQteViewType_Drag")]
	public enum ECommonQteViewType_Drag : byte
	{
		// Token: 0x040148B9 RID: 84153
		滑动通用界面,
		// Token: 0x040148BA RID: 84154
		锚定仪界面,
		// Token: 0x040148BB RID: 84155
		全屏上拉界面,
		// Token: 0x040148BC RID: 84156
		全屏下拉界面,
		// Token: 0x040148BD RID: 84157
		罗盘旋转界面,
		// Token: 0x040148BE RID: 84158
		右半屏拖动界面,
		// Token: 0x040148BF RID: 84159
		穗穗左右滑界面,
		// Token: 0x040148C0 RID: 84160
		穗穗右滑界面,
		// Token: 0x040148C1 RID: 84161
		穗穗下滑界面,
		// Token: 0x040148C2 RID: 84162
		ECommonQteViewType_MAX
	}
}
