using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F61 RID: 16225
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/ECampType.ECampType")]
	public enum ECampType : byte
	{
		// Token: 0x040155A1 RID: 87457
		不生效,
		// Token: 0x040155A2 RID: 87458
		对自己,
		// Token: 0x040155A3 RID: 87459
		对敌方,
		// Token: 0x040155A4 RID: 87460
		对友方,
		// Token: 0x040155A5 RID: 87461
		对自己和友方,
		// Token: 0x040155A6 RID: 87462
		对自己和敌方,
		// Token: 0x040155A7 RID: 87463
		全部,
		// Token: 0x040155A8 RID: 87464
		ECampType_MAX
	}
}
