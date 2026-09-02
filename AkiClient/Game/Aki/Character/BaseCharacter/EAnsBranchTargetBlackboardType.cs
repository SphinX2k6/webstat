using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D7 RID: 16855
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EAnsBranchTargetBlackboardType.EAnsBranchTargetBlackboardType")]
	public enum EAnsBranchTargetBlackboardType : byte
	{
		// Token: 0x04018FD5 RID: 102357
		EntityId,
		// Token: 0x04018FD6 RID: 102358
		Location,
		// Token: 0x04018FD7 RID: 102359
		EAnsBranchTargetBlackboardType_MAX
	}
}
