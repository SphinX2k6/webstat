using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.GamePlay.TriggerItems
{
	// Token: 0x02003DC4 RID: 15812
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/GamePlay/TriggerItems/ETriggerOpenType.ETriggerOpenType")]
	public enum ETriggerOpenType : byte
	{
		// Token: 0x0401430D RID: 82701
		Alway,
		// Token: 0x0401430E RID: 82702
		Task,
		// Token: 0x0401430F RID: 82703
		GamePlay,
		// Token: 0x04014310 RID: 82704
		ETriggerOpenType_MAX
	}
}
