using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200420C RID: 16908
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EMovementAction.EMovementAction")]
	public enum EMovementAction : byte
	{
		// Token: 0x04019147 RID: 102727
		None,
		// Token: 0x04019148 RID: 102728
		LowClimb,
		// Token: 0x04019149 RID: 102729
		HighClimb,
		// Token: 0x0401914A RID: 102730
		Dodge,
		// Token: 0x0401914B RID: 102731
		GettingUp,
		// Token: 0x0401914C RID: 102732
		HeavyLand,
		// Token: 0x0401914D RID: 102733
		EMovementAction_MAX
	}
}
