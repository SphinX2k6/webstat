using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D8 RID: 16856
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EAnsRotateBlackboardType.EAnsRotateBlackboardType")]
	public enum EAnsRotateBlackboardType : byte
	{
		// Token: 0x04018FD9 RID: 102361
		EntityId,
		// Token: 0x04018FDA RID: 102362
		Location,
		// Token: 0x04018FDB RID: 102363
		Direct,
		// Token: 0x04018FDC RID: 102364
		Int,
		// Token: 0x04018FDD RID: 102365
		EAnsRotateBlackboardType_MAX
	}
}
