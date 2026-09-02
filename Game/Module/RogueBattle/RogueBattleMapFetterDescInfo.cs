using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200524F RID: 21071
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleMapFetterDescInfo : IRogueBattleMapFetterDescInfo
	{
		// Token: 0x17008CD7 RID: 36055
		// (get) Token: 0x06035F1D RID: 220957 RVA: 0x00D9211F File Offset: 0x00D9031F
		// (set) Token: 0x06035F1E RID: 220958 RVA: 0x00D92127 File Offset: 0x00D90327
		public string TextId { get; set; } = string.Empty;

		// Token: 0x17008CD8 RID: 36056
		// (get) Token: 0x06035F1F RID: 220959 RVA: 0x00D92130 File Offset: 0x00D90330
		// (set) Token: 0x06035F20 RID: 220960 RVA: 0x00D92138 File Offset: 0x00D90338
		[Nullable(2)]
		public string Param { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008CD9 RID: 36057
		// (get) Token: 0x06035F21 RID: 220961 RVA: 0x00D92141 File Offset: 0x00D90341
		// (set) Token: 0x06035F22 RID: 220962 RVA: 0x00D92149 File Offset: 0x00D90349
		public bool IsReached { get; set; }

		// Token: 0x17008CDA RID: 36058
		// (get) Token: 0x06035F23 RID: 220963 RVA: 0x00D92152 File Offset: 0x00D90352
		// (set) Token: 0x06035F24 RID: 220964 RVA: 0x00D9215A File Offset: 0x00D9035A
		public ERogueResBondEffectType EffectType { get; set; }
	}
}
