using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.GamePlay
{
	// Token: 0x02003DC2 RID: 15810
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/GamePlay/EGameplayFunctionType.EGameplayFunctionType")]
	public enum EGameplayFunctionType : byte
	{
		// Token: 0x040142F8 RID: 82680
		None,
		// Token: 0x040142F9 RID: 82681
		Gear,
		// Token: 0x040142FA RID: 82682
		TreasureBox,
		// Token: 0x040142FB RID: 82683
		LanternCat,
		// Token: 0x040142FC RID: 82684
		Weapon,
		// Token: 0x040142FD RID: 82685
		CheckGear,
		// Token: 0x040142FE RID: 82686
		ShootTarget,
		// Token: 0x040142FF RID: 82687
		InstanceOpen,
		// Token: 0x04014300 RID: 82688
		Ore,
		// Token: 0x04014301 RID: 82689
		StartShootTarget,
		// Token: 0x04014302 RID: 82690
		Teleport,
		// Token: 0x04014303 RID: 82691
		Controller,
		// Token: 0x04014304 RID: 82692
		TreasureBoxController,
		// Token: 0x04014305 RID: 82693
		Elevator,
		// Token: 0x04014306 RID: 82694
		EGameplayFunctionType_MAX
	}
}
