using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E3C RID: 15932
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/ECommonQteViewType_SingleButton.ECommonQteViewType_SingleButton")]
	public enum ECommonQteViewType_SingleButton : byte
	{
		// Token: 0x040148C8 RID: 84168
		单按钮通用界面,
		// Token: 0x040148C9 RID: 84169
		单按钮点击3D界面,
		// Token: 0x040148CA RID: 84170
		聚焦点击按钮,
		// Token: 0x040148CB RID: 84171
		单按钮无图标快启动界面,
		// Token: 0x040148CC RID: 84172
		圆环单击界面,
		// Token: 0x040148CD RID: 84173
		缩圈单击界面,
		// Token: 0x040148CE RID: 84174
		ECommonQteViewType_MAX
	}
}
