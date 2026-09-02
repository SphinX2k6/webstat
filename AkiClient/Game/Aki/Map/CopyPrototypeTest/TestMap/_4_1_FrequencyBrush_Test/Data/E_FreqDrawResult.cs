using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Map.CopyPrototypeTest.TestMap._4_1_FrequencyBrush_Test.Data
{
	// Token: 0x02003DB5 RID: 15797
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Map/CopyPrototypeTest/TestMap/4_1_FrequencyBrush_Test/Data/E_FreqDrawResult.E_FreqDrawResult")]
	public enum E_FreqDrawResult : byte
	{
		// Token: 0x040142A0 RID: 82592
		Point,
		// Token: 0x040142A1 RID: 82593
		Line,
		// Token: 0x040142A2 RID: 82594
		Circle,
		// Token: 0x040142A3 RID: 82595
		CloseShape,
		// Token: 0x040142A4 RID: 82596
		NoResult,
		// Token: 0x040142A5 RID: 82597
		E_MAX
	}
}
