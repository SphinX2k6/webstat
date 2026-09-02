using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B07 RID: 19207
	[NullableContext(1)]
	public interface IGameplayEntityExecutionContext
	{
		// Token: 0x17008580 RID: 34176
		// (get) Token: 0x0603216D RID: 205165
		WuWaGoGameModeBase GameMode { get; }

		// Token: 0x17008581 RID: 34177
		// (get) Token: 0x0603216E RID: 205166
		HashSet<int> ExecutingPullRodGroups { get; }

		// Token: 0x17008582 RID: 34178
		// (get) Token: 0x0603216F RID: 205167
		HashSet<int> PendingBowTrapPbDataIds { get; }

		// Token: 0x17008583 RID: 34179
		// (get) Token: 0x06032170 RID: 205168
		HashSet<int> PendingMovableFloorPbDataIds { get; }
	}
}
