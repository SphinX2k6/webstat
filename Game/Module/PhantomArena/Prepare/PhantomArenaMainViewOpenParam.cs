using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054A7 RID: 21671
	[NullableContext(2)]
	[Nullable(0)]
	public class PhantomArenaMainViewOpenParam : IPhantomArenaMainViewOpenParam
	{
		// Token: 0x17008E22 RID: 36386
		// (get) Token: 0x06037290 RID: 225936 RVA: 0x00E01E62 File Offset: 0x00E00062
		// (set) Token: 0x06037291 RID: 225937 RVA: 0x00E01E6A File Offset: 0x00E0006A
		public int ChallengeId { get; set; }

		// Token: 0x17008E23 RID: 36387
		// (get) Token: 0x06037292 RID: 225938 RVA: 0x00E01E73 File Offset: 0x00E00073
		// (set) Token: 0x06037293 RID: 225939 RVA: 0x00E01E7B File Offset: 0x00E0007B
		public EPhantomArenaChildViewName OpenView { get; set; }

		// Token: 0x17008E24 RID: 36388
		// (get) Token: 0x06037294 RID: 225940 RVA: 0x00E01E84 File Offset: 0x00E00084
		// (set) Token: 0x06037295 RID: 225941 RVA: 0x00E01E8C File Offset: 0x00E0008C
		public int ActivityId { get; set; }

		// Token: 0x17008E25 RID: 36389
		// (get) Token: 0x06037296 RID: 225942 RVA: 0x00E01E95 File Offset: 0x00E00095
		// (set) Token: 0x06037297 RID: 225943 RVA: 0x00E01E9D File Offset: 0x00E0009D
		public DeckInfo RecommendDeck { get; set; }
	}
}
