using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x020055A2 RID: 21922
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleLoadingInfo : IPhantomArenaBattleLoadingInfo
	{
		// Token: 0x17008FCC RID: 36812
		// (get) Token: 0x06037CCA RID: 228554 RVA: 0x00E235A8 File Offset: 0x00E217A8
		// (set) Token: 0x06037CCB RID: 228555 RVA: 0x00E235B0 File Offset: 0x00E217B0
		public int Index { get; set; }

		// Token: 0x17008FCD RID: 36813
		// (get) Token: 0x06037CCC RID: 228556 RVA: 0x00E235B9 File Offset: 0x00E217B9
		// (set) Token: 0x06037CCD RID: 228557 RVA: 0x00E235C1 File Offset: 0x00E217C1
		public bool IsMe { get; set; }

		// Token: 0x17008FCE RID: 36814
		// (get) Token: 0x06037CCE RID: 228558 RVA: 0x00E235CA File Offset: 0x00E217CA
		// (set) Token: 0x06037CCF RID: 228559 RVA: 0x00E235D2 File Offset: 0x00E217D2
		public PhantomCardData CardData { get; set; }
	}
}
