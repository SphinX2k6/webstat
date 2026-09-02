using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E15 RID: 15893
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/EQtaConditionType.EQtaConditionType")]
	public enum EQtaConditionType : byte
	{
		// Token: 0x04014786 RID: 83846
		检查输入,
		// Token: 0x04014787 RID: 83847
		检查Tag,
		// Token: 0x04014788 RID: 83848
		事件变化,
		// Token: 0x04014789 RID: 83849
		EQtaConditionType_MAX
	}
}
