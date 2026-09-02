using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

// Token: 0x0200323C RID: 12860
public static class EPerformanceOptimizationMap
{
	// Token: 0x0601AC52 RID: 109650 RVA: 0x007FA838 File Offset: 0x007F8A38
	// Note: this type is marked as 'beforefieldinit'.
	static EPerformanceOptimizationMap()
	{
		Dictionary<EPerformanceOptimizationType, Type> dictionary = new Dictionary<EPerformanceOptimizationType, Type>();
		dictionary[EPerformanceOptimizationType.PlaneMovementOptimization] = typeof(PlanarMoveOptimizationStrategy);
		dictionary[EPerformanceOptimizationType.DamageTextOptimization] = typeof(DamageOptimizationStrategy);
		EPerformanceOptimizationMap.Map = dictionary;
	}

	// Token: 0x0400D92C RID: 55596
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EPerformanceOptimizationType, Type> Map;
}
