using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E9 RID: 16873
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECaughtDirectionType.ECaughtDirectionType")]
	public enum ECaughtDirectionType : byte
	{
		// Token: 0x04019049 RID: 102473
		CaughtDirection,
		// Token: 0x0401904A RID: 102474
		BoxDirection,
		// Token: 0x0401904B RID: 102475
		SpeedDirection,
		// Token: 0x0401904C RID: 102476
		None,
		// Token: 0x0401904D RID: 102477
		ECaughtDirectionType_MAX
	}
}
