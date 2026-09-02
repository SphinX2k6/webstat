using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.AIGearStrategy.AIRaceStrategy
{
	// Token: 0x02003F21 RID: 16161
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/EAiRaceStrategyMultiParamFuncType.EAiRaceStrategyMultiParamFuncType")]
	public enum EAiRaceStrategyMultiParamFuncType : byte
	{
		// Token: 0x04015371 RID: 86897
		Sum,
		// Token: 0x04015372 RID: 86898
		Max,
		// Token: 0x04015373 RID: 86899
		Min,
		// Token: 0x04015374 RID: 86900
		Avg,
		// Token: 0x04015375 RID: 86901
		EAiRaceStrategyMultiParamFuncType_MAX
	}
}
