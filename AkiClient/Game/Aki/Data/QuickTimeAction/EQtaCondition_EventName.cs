using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E17 RID: 15895
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/EQtaCondition_EventName.EQtaCondition_EventName")]
	public enum EQtaCondition_EventName : byte
	{
		// Token: 0x04014791 RID: 83857
		角色死亡,
		// Token: 0x04014792 RID: 83858
		当前技能结束,
		// Token: 0x04014793 RID: 83859
		相机模式变更,
		// Token: 0x04014794 RID: 83860
		EQtaCondition_MAX
	}
}
