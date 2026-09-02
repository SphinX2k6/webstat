using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E18 RID: 15896
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/EQtaPromptType.EQtaPromptType")]
	public enum EQtaPromptType : byte
	{
		// Token: 0x04014796 RID: 83862
		Qta开始,
		// Token: 0x04014797 RID: 83863
		进入有效范围提示,
		// Token: 0x04014798 RID: 83864
		离开有效范围提示,
		// Token: 0x04014799 RID: 83865
		按下提示,
		// Token: 0x0401479A RID: 83866
		抬起提示,
		// Token: 0x0401479B RID: 83867
		操作有效提示,
		// Token: 0x0401479C RID: 83868
		操作无效提示,
		// Token: 0x0401479D RID: 83869
		结果成功提示,
		// Token: 0x0401479E RID: 83870
		结果失败提示,
		// Token: 0x0401479F RID: 83871
		EQtaPromptType_MAX
	}
}
