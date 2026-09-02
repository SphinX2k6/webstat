using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x0200559F RID: 21919
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaSkillData : IPhantomArenaSkillData
	{
		// Token: 0x17008FC1 RID: 36801
		// (get) Token: 0x06037CB2 RID: 228530 RVA: 0x00E23510 File Offset: 0x00E21710
		// (set) Token: 0x06037CB3 RID: 228531 RVA: 0x00E23518 File Offset: 0x00E21718
		public bool IsOwn { get; set; }

		// Token: 0x17008FC2 RID: 36802
		// (get) Token: 0x06037CB4 RID: 228532 RVA: 0x00E23521 File Offset: 0x00E21721
		// (set) Token: 0x06037CB5 RID: 228533 RVA: 0x00E23529 File Offset: 0x00E21729
		public int SkillId { get; set; }

		// Token: 0x17008FC3 RID: 36803
		// (get) Token: 0x06037CB6 RID: 228534 RVA: 0x00E23532 File Offset: 0x00E21732
		// (set) Token: 0x06037CB7 RID: 228535 RVA: 0x00E2353A File Offset: 0x00E2173A
		public bool IsPassive { get; set; }

		// Token: 0x17008FC4 RID: 36804
		// (get) Token: 0x06037CB8 RID: 228536 RVA: 0x00E23543 File Offset: 0x00E21743
		// (set) Token: 0x06037CB9 RID: 228537 RVA: 0x00E2354B File Offset: 0x00E2174B
		public string Icon { get; set; }

		// Token: 0x17008FC5 RID: 36805
		// (get) Token: 0x06037CBA RID: 228538 RVA: 0x00E23554 File Offset: 0x00E21754
		// (set) Token: 0x06037CBB RID: 228539 RVA: 0x00E2355C File Offset: 0x00E2175C
		public string SkillName { get; set; }

		// Token: 0x17008FC6 RID: 36806
		// (get) Token: 0x06037CBC RID: 228540 RVA: 0x00E23565 File Offset: 0x00E21765
		// (set) Token: 0x06037CBD RID: 228541 RVA: 0x00E2356D File Offset: 0x00E2176D
		public string SkillDesc { get; set; }

		// Token: 0x17008FC7 RID: 36807
		// (get) Token: 0x06037CBE RID: 228542 RVA: 0x00E23576 File Offset: 0x00E21776
		// (set) Token: 0x06037CBF RID: 228543 RVA: 0x00E2357E File Offset: 0x00E2177E
		public List<string> SkillDescParams { get; set; }

		// Token: 0x17008FC8 RID: 36808
		// (get) Token: 0x06037CC0 RID: 228544 RVA: 0x00E23587 File Offset: 0x00E21787
		// (set) Token: 0x06037CC1 RID: 228545 RVA: 0x00E2358F File Offset: 0x00E2178F
		public int CostConsume { get; set; }
	}
}
