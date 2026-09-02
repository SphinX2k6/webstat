using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B08 RID: 19208
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class GameplayEntityExecutionContext : IGameplayEntityExecutionContext
	{
		// Token: 0x17008584 RID: 34180
		// (get) Token: 0x06032171 RID: 205169 RVA: 0x00C88ADA File Offset: 0x00C86CDA
		// (set) Token: 0x06032172 RID: 205170 RVA: 0x00C88AE2 File Offset: 0x00C86CE2
		[RequiredMember]
		public WuWaGoGameModeBase GameMode { get; set; }

		// Token: 0x17008585 RID: 34181
		// (get) Token: 0x06032173 RID: 205171 RVA: 0x00C88AEB File Offset: 0x00C86CEB
		// (set) Token: 0x06032174 RID: 205172 RVA: 0x00C88AF3 File Offset: 0x00C86CF3
		[RequiredMember]
		public HashSet<int> ExecutingPullRodGroups { get; set; }

		// Token: 0x17008586 RID: 34182
		// (get) Token: 0x06032175 RID: 205173 RVA: 0x00C88AFC File Offset: 0x00C86CFC
		// (set) Token: 0x06032176 RID: 205174 RVA: 0x00C88B04 File Offset: 0x00C86D04
		[RequiredMember]
		public HashSet<int> PendingBowTrapPbDataIds { get; set; }

		// Token: 0x17008587 RID: 34183
		// (get) Token: 0x06032177 RID: 205175 RVA: 0x00C88B0D File Offset: 0x00C86D0D
		// (set) Token: 0x06032178 RID: 205176 RVA: 0x00C88B15 File Offset: 0x00C86D15
		[RequiredMember]
		public HashSet<int> PendingMovableFloorPbDataIds { get; set; }

		// Token: 0x06032179 RID: 205177 RVA: 0x00C88B1E File Offset: 0x00C86D1E
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public GameplayEntityExecutionContext()
		{
		}
	}
}
