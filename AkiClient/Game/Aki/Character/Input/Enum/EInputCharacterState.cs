using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Input.Enum
{
	// Token: 0x020041AD RID: 16813
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Input/Enum/EInputCharacterState.EInputCharacterState")]
	public enum EInputCharacterState : byte
	{
		// Token: 0x04018D83 RID: 101763
		None,
		// Token: 0x04018D84 RID: 101764
		InGround,
		// Token: 0x04018D85 RID: 101765
		InGroundArm,
		// Token: 0x04018D86 RID: 101766
		InAir,
		// Token: 0x04018D87 RID: 101767
		InWater,
		// Token: 0x04018D88 RID: 101768
		InClimbing,
		// Token: 0x04018D89 RID: 101769
		InControllState,
		// Token: 0x04018D8A RID: 101770
		InControllSelect,
		// Token: 0x04018D8B RID: 101771
		InThrowState,
		// Token: 0x04018D8C RID: 101772
		EInputCharacterState_MAX
	}
}
