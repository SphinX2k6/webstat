using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.AIGearStrategy.AIRaceStrategy
{
	// Token: 0x02003F22 RID: 16162
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/EAiRaceStrategyOneParamFuncType.EAiRaceStrategyOneParamFuncType")]
	public enum EAiRaceStrategyOneParamFuncType : byte
	{
		// Token: 0x04015377 RID: 86903
		Constant,
		// Token: 0x04015378 RID: 86904
		Linear,
		// Token: 0x04015379 RID: 86905
		Quadratic,
		// Token: 0x0401537A RID: 86906
		Comparison,
		// Token: 0x0401537B RID: 86907
		EAiRaceStrategyOneParamFuncType_MAX
	}
}
