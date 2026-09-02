using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Gameplay.WuWaGo
{
	// Token: 0x02003E98 RID: 16024
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/WuWaGo/EWuWaGoClimbMontage.EWuWaGoClimbMontage")]
	public enum EWuWaGoClimbMontage : byte
	{
		// Token: 0x04014D6F RID: 85359
		Idle,
		// Token: 0x04014D70 RID: 85360
		Ground2Wall_Up,
		// Token: 0x04014D71 RID: 85361
		Ground2Wall_Down,
		// Token: 0x04014D72 RID: 85362
		Wall2Ground_Up,
		// Token: 0x04014D73 RID: 85363
		Wall2Ground_Down,
		// Token: 0x04014D74 RID: 85364
		Up,
		// Token: 0x04014D75 RID: 85365
		Down,
		// Token: 0x04014D76 RID: 85366
		Left,
		// Token: 0x04014D77 RID: 85367
		Right,
		// Token: 0x04014D78 RID: 85368
		EWuWaGoClimbMontage_MAX
	}
}
