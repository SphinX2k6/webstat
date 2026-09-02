using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E3B RID: 15931
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/ECommonQteViewType_SelectOption.ECommonQteViewType_SelectOption")]
	public enum ECommonQteViewType_SelectOption : byte
	{
		// Token: 0x040148C4 RID: 84164
		一体式单选界面,
		// Token: 0x040148C5 RID: 84165
		分体式单选界面,
		// Token: 0x040148C6 RID: 84166
		ECommonQteViewType_MAX
	}
}
