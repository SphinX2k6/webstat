using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E3E RID: 15934
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/ECommonQteViewType_SingleButtonLongPress.ECommonQteViewType_SingleButtonLongPress")]
	public enum ECommonQteViewType_SingleButtonLongPress : byte
	{
		// Token: 0x040148D5 RID: 84181
		单按钮长按通用界面,
		// Token: 0x040148D6 RID: 84182
		单按钮长按3D界面,
		// Token: 0x040148D7 RID: 84183
		单按钮全屏长按界面,
		// Token: 0x040148D8 RID: 84184
		单按钮长按无图标快启动界面,
		// Token: 0x040148D9 RID: 84185
		ECommonQteViewType_MAX
	}
}
