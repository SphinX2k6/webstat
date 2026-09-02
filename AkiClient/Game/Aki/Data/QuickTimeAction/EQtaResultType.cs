using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E19 RID: 15897
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/EQtaResultType.EQtaResultType")]
	public enum EQtaResultType : byte
	{
		// Token: 0x040147A1 RID: 83873
		None,
		// Token: 0x040147A2 RID: 83874
		成功,
		// Token: 0x040147A3 RID: 83875
		失败,
		// Token: 0x040147A4 RID: 83876
		超时,
		// Token: 0x040147A5 RID: 83877
		失活,
		// Token: 0x040147A6 RID: 83878
		EQtaResultType_MAX
	}
}
