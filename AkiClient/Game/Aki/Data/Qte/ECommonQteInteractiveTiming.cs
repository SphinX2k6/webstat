using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E38 RID: 15928
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/ECommonQteInteractiveTiming.ECommonQteInteractiveTiming")]
	public enum ECommonQteInteractiveTiming : byte
	{
		// Token: 0x040148AE RID: 84142
		始终,
		// Token: 0x040148AF RID: 84143
		开始动画结束后,
		// Token: 0x040148B0 RID: 84144
		ECommonQteInteractiveTiming_MAX
	}
}
