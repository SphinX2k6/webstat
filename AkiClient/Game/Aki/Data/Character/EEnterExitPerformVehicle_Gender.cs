using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Character
{
	// Token: 0x02003F10 RID: 16144
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Character/EEnterExitPerformVehicle_Gender.EEnterExitPerformVehicle_Gender")]
	public enum EEnterExitPerformVehicle_Gender : byte
	{
		// Token: 0x0401524A RID: 86602
		All,
		// Token: 0x0401524B RID: 86603
		Male,
		// Token: 0x0401524C RID: 86604
		Female,
		// Token: 0x0401524D RID: 86605
		EEnterExitPerformVehicle_MAX
	}
}
