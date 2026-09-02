using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E36 RID: 15926
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/EBattleQteCustomAction.EBattleQteCustomAction")]
	public enum EBattleQteCustomAction : byte
	{
		// Token: 0x0401487D RID: 84093
		无,
		// Token: 0x0401487E RID: 84094
		切换角色,
		// Token: 0x0401487F RID: 84095
		切换到指定角色,
		// Token: 0x04014880 RID: 84096
		EBattleQteCustomAction_MAX
	}
}
