using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041DA RID: 16858
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EAttackType.EAttackType")]
	public enum EAttackType : byte
	{
		// Token: 0x04018FE4 RID: 102372
		Auto,
		// Token: 0x04018FE5 RID: 102373
		Cast,
		// Token: 0x04018FE6 RID: 102374
		Ultra,
		// Token: 0x04018FE7 RID: 102375
		QTE,
		// Token: 0x04018FE8 RID: 102376
		EAttackType_MAX
	}
}
