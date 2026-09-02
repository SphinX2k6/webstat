using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200420E RID: 16910
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EMovementState.EMovementState")]
	public enum EMovementState : byte
	{
		// Token: 0x04019154 RID: 102740
		None,
		// Token: 0x04019155 RID: 102741
		Grounded,
		// Token: 0x04019156 RID: 102742
		InAir,
		// Token: 0x04019157 RID: 102743
		Ragdoll,
		// Token: 0x04019158 RID: 102744
		Mantling,
		// Token: 0x04019159 RID: 102745
		InWater,
		// Token: 0x0401915A RID: 102746
		Climbing,
		// Token: 0x0401915B RID: 102747
		Flying,
		// Token: 0x0401915C RID: 102748
		EMovementState_MAX
	}
}
