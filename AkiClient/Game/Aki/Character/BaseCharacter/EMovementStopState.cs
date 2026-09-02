using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200420F RID: 16911
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EMovementStopState.EMovementStopState")]
	public enum EMovementStopState : byte
	{
		// Token: 0x0401915E RID: 102750
		None,
		// Token: 0x0401915F RID: 102751
		SprintStop,
		// Token: 0x04019160 RID: 102752
		RunStop,
		// Token: 0x04019161 RID: 102753
		WalkStop,
		// Token: 0x04019162 RID: 102754
		EMovementStopState_MAX
	}
}
