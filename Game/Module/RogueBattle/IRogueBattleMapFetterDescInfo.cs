using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200524E RID: 21070
	[NullableContext(1)]
	public interface IRogueBattleMapFetterDescInfo
	{
		// Token: 0x17008CD3 RID: 36051
		// (get) Token: 0x06035F15 RID: 220949
		// (set) Token: 0x06035F16 RID: 220950
		string TextId { get; set; }

		// Token: 0x17008CD4 RID: 36052
		// (get) Token: 0x06035F17 RID: 220951
		// (set) Token: 0x06035F18 RID: 220952
		[Nullable(2)]
		string Param { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008CD5 RID: 36053
		// (get) Token: 0x06035F19 RID: 220953
		// (set) Token: 0x06035F1A RID: 220954
		bool IsReached { get; set; }

		// Token: 0x17008CD6 RID: 36054
		// (get) Token: 0x06035F1B RID: 220955
		// (set) Token: 0x06035F1C RID: 220956
		ERogueResBondEffectType EffectType { get; set; }
	}
}
