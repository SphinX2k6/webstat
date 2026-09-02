using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041EE RID: 16878
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECharState.ECharState")]
	public enum ECharState : byte
	{
		// Token: 0x04019066 RID: 102502
		其他,
		// Token: 0x04019067 RID: 102503
		站立,
		// Token: 0x04019068 RID: 102504
		行走,
		// Token: 0x04019069 RID: 102505
		行走停止,
		// Token: 0x0401906A RID: 102506
		跑步,
		// Token: 0x0401906B RID: 102507
		跑步停止,
		// Token: 0x0401906C RID: 102508
		冲刺,
		// Token: 0x0401906D RID: 102509
		冲刺停止,
		// Token: 0x0401906E RID: 102510
		闪避,
		// Token: 0x0401906F RID: 102511
		弹反,
		// Token: 0x04019070 RID: 102512
		落地翻滚,
		// Token: 0x04019071 RID: 102513
		击倒,
		// Token: 0x04019072 RID: 102514
		轻击,
		// Token: 0x04019073 RID: 102515
		重击,
		// Token: 0x04019074 RID: 102516
		正常攀爬,
		// Token: 0x04019075 RID: 102517
		快速攀爬,
		// Token: 0x04019076 RID: 102518
		滑翔,
		// Token: 0x04019077 RID: 102519
		击飞,
		// Token: 0x04019078 RID: 102520
		加速游泳,
		// Token: 0x04019079 RID: 102521
		正常游泳,
		// Token: 0x0401907A RID: 102522
		摇荡,
		// Token: 0x0401907B RID: 102523
		被抓取,
		// Token: 0x0401907C RID: 102524
		滑坡,
		// Token: 0x0401907D RID: 102525
		特殊飞行,
		// Token: 0x0401907E RID: 102526
		进入攀爬,
		// Token: 0x0401907F RID: 102527
		退出攀爬,
		// Token: 0x04019080 RID: 102528
		普通滑雪,
		// Token: 0x04019081 RID: 102529
		受击倒地起身,
		// Token: 0x04019082 RID: 102530
		翱翔,
		// Token: 0x04019083 RID: 102531
		ECharState_MAX
	}
}
