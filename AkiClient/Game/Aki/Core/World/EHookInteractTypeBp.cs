using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.World
{
	// Token: 0x02003F44 RID: 16196
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/World/EHookInteractTypeBp.EHookInteractTypeBp")]
	public enum EHookInteractTypeBp : byte
	{
		// Token: 0x0401545A RID: 87130
		FixedPointHook,
		// Token: 0x0401545B RID: 87131
		SuiGuangHook,
		// Token: 0x0401545C RID: 87132
		KiteHook,
		// Token: 0x0401545D RID: 87133
		RagDollJumpingPoint,
		// Token: 0x0401545E RID: 87134
		RagDollClimbingPoint,
		// Token: 0x0401545F RID: 87135
		MovementPointHook,
		// Token: 0x04015460 RID: 87136
		SlashHook,
		// Token: 0x04015461 RID: 87137
		LightSlashHook,
		// Token: 0x04015462 RID: 87138
		ChargeSlashHook,
		// Token: 0x04015463 RID: 87139
		CableWayHook,
		// Token: 0x04015464 RID: 87140
		FollowerShoot,
		// Token: 0x04015465 RID: 87141
		MotorPullInteract,
		// Token: 0x04015466 RID: 87142
		SpaceStationEnergyCore,
		// Token: 0x04015467 RID: 87143
		MotorEject,
		// Token: 0x04015468 RID: 87144
		EHookInteractTypeBp_MAX
	}
}
