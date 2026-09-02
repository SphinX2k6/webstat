using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D6 RID: 16854
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EAnsBlackboardType.EAnsBlackboardType")]
	public enum EAnsBlackboardType : byte
	{
		// Token: 0x04018FCF RID: 102351
		Direct,
		// Token: 0x04018FD0 RID: 102352
		Location,
		// Token: 0x04018FD1 RID: 102353
		EntityId,
		// Token: 0x04018FD2 RID: 102354
		Int,
		// Token: 0x04018FD3 RID: 102355
		EAnsBlackboardType_MAX
	}
}
