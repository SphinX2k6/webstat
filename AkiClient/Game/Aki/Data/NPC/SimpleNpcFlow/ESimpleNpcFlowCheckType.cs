using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.NPC.SimpleNpcFlow
{
	// Token: 0x02003E5A RID: 15962
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/NPC/SimpleNpcFlow/ESimpleNpcFlowCheckType.ESimpleNpcFlowCheckType")]
	public enum ESimpleNpcFlowCheckType : byte
	{
		// Token: 0x04014A18 RID: 84504
		无,
		// Token: 0x04014A19 RID: 84505
		下雨,
		// Token: 0x04014A1A RID: 84506
		打雷,
		// Token: 0x04014A1B RID: 84507
		清晨,
		// Token: 0x04014A1C RID: 84508
		上午,
		// Token: 0x04014A1D RID: 84509
		下午,
		// Token: 0x04014A1E RID: 84510
		晚上,
		// Token: 0x04014A1F RID: 84511
		任务进行中,
		// Token: 0x04014A20 RID: 84512
		任务完成,
		// Token: 0x04014A21 RID: 84513
		上线第一次靠近,
		// Token: 0x04014A22 RID: 84514
		ESimpleNpcFlowCheckType_MAX
	}
}
