using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data
{
	// Token: 0x02003A68 RID: 14952
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/E_SE_PlayOrder.E_SE_PlayOrder")]
	public enum E_SE_PlayOrder : byte
	{
		// Token: 0x0400F728 RID: 63272
		ByOrder,
		// Token: 0x0400F729 RID: 63273
		Independent,
		// Token: 0x0400F72A RID: 63274
		E_SE_MAX
	}
}
