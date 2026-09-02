using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Monster.Common
{
	// Token: 0x0200419B RID: 16795
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Monster/Common/EAiLevelVarSource.EAiLevelVarSource")]
	public enum EAiLevelVarSource : byte
	{
		// Token: 0x04018CD4 RID: 101588
		Global,
		// Token: 0x04018CD5 RID: 101589
		SelfEntity,
		// Token: 0x04018CD6 RID: 101590
		OtherEntity,
		// Token: 0x04018CD7 RID: 101591
		Quest,
		// Token: 0x04018CD8 RID: 101592
		LevelPlay,
		// Token: 0x04018CD9 RID: 101593
		EAiLevelVarSource_MAX
	}
}
