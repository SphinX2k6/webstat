using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E16 RID: 15894
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/EQtaCondition_CheckInputType.EQtaCondition_CheckInputType")]
	public enum EQtaCondition_CheckInputType : byte
	{
		// Token: 0x0401478B RID: 83851
		按下按键,
		// Token: 0x0401478C RID: 83852
		抬起按键,
		// Token: 0x0401478D RID: 83853
		已按键,
		// Token: 0x0401478E RID: 83854
		没按键,
		// Token: 0x0401478F RID: 83855
		EQtaCondition_MAX
	}
}
