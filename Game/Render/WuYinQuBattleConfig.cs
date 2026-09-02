using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004741 RID: 18241
	[NullableContext(1)]
	[Nullable(0)]
	public class WuYinQuBattleConfig
	{
		// Token: 0x0401AF36 RID: 110390
		[StaticVariableRuleIgnore]
		public static readonly FVector TriggerThreshold = new FVector(80f, 80f, 80f);

		// Token: 0x0401AF37 RID: 110391
		public const float TriggerTransitionTime = 3.5f;

		// Token: 0x0401AF38 RID: 110392
		public const float LandscapeHardness = 0.0001f;

		// Token: 0x0401AF39 RID: 110393
		public const string MarkFightingStart1 = "FightingStart1";

		// Token: 0x0401AF3A RID: 110394
		public const string MarkFightingCycle1 = "FightingCycle1";

		// Token: 0x0401AF3B RID: 110395
		public const string MarkFightingEnd1 = "FightingEnd1";

		// Token: 0x0401AF3C RID: 110396
		public const string MarkFightingStart2 = "FightingStart2";

		// Token: 0x0401AF3D RID: 110397
		public const string MarkFightingCycle2 = "FightingCycle2";

		// Token: 0x0401AF3E RID: 110398
		public const string MarkFightingEnd2 = "FightingEnd2";

		// Token: 0x0401AF3F RID: 110399
		public const string MarkFightingStart3 = "FightingStart3";

		// Token: 0x0401AF40 RID: 110400
		public const string MarkFightingCycle3 = "FightingCycle3";

		// Token: 0x0401AF41 RID: 110401
		public const string MarkFightingEnd3 = "FightingEnd3";

		// Token: 0x0401AF42 RID: 110402
		public const string MarkFightingOverStart = "FightingOverStart";

		// Token: 0x0401AF43 RID: 110403
		public const string MarkFightingOverEnd = "FightingOverEnd";
	}
}
