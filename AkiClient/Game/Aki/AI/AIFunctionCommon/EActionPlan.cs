using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon
{
	// Token: 0x02004388 RID: 17288
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/EActionPlan.EActionPlan")]
	public enum EActionPlan : byte
	{
		// Token: 0x04019E3D RID: 106045
		游荡,
		// Token: 0x04019E3E RID: 106046
		技能,
		// Token: 0x04019E3F RID: 106047
		巡逻,
		// Token: 0x04019E40 RID: 106048
		跟随,
		// Token: 0x04019E41 RID: 106049
		脱战,
		// Token: 0x04019E42 RID: 106050
		EActionPlan_MAX
	}
}
