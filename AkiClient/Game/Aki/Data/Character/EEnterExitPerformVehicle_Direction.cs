using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Character
{
	// Token: 0x02003F0F RID: 16143
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Character/EEnterExitPerformVehicle_Direction.EEnterExitPerformVehicle_Direction")]
	public enum EEnterExitPerformVehicle_Direction : byte
	{
		// Token: 0x04015245 RID: 86597
		All,
		// Token: 0x04015246 RID: 86598
		Left,
		// Token: 0x04015247 RID: 86599
		Right,
		// Token: 0x04015248 RID: 86600
		EEnterExitPerformVehicle_MAX
	}
}
