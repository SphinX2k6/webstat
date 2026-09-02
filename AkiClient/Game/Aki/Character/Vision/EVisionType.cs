using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Vision
{
	// Token: 0x02003F8B RID: 16267
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Vision/EVisionType.EVisionType")]
	public enum EVisionType : byte
	{
		// Token: 0x040157A7 RID: 87975
		召唤,
		// Token: 0x040157A8 RID: 87976
		变身,
		// Token: 0x040157A9 RID: 87977
		探索,
		// Token: 0x040157AA RID: 87978
		操控,
		// Token: 0x040157AB RID: 87979
		驻场,
		// Token: 0x040157AC RID: 87980
		BossRush,
		// Token: 0x040157AD RID: 87981
		新探索,
		// Token: 0x040157AE RID: 87982
		EVisionType_MAX
	}
}
