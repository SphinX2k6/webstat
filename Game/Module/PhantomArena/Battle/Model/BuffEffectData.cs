using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x020055FB RID: 22011
	[NullableContext(1)]
	[Nullable(0)]
	public class BuffEffectData : IBuffEffectData
	{
		// Token: 0x1700900C RID: 36876
		// (get) Token: 0x0603816D RID: 229741 RVA: 0x00E35587 File Offset: 0x00E33787
		// (set) Token: 0x0603816E RID: 229742 RVA: 0x00E3558F File Offset: 0x00E3378F
		public int SourceFightId { get; set; }

		// Token: 0x1700900D RID: 36877
		// (get) Token: 0x0603816F RID: 229743 RVA: 0x00E35598 File Offset: 0x00E33798
		// (set) Token: 0x06038170 RID: 229744 RVA: 0x00E355A0 File Offset: 0x00E337A0
		public int SkillId { get; set; }

		// Token: 0x1700900E RID: 36878
		// (get) Token: 0x06038171 RID: 229745 RVA: 0x00E355A9 File Offset: 0x00E337A9
		// (set) Token: 0x06038172 RID: 229746 RVA: 0x00E355B1 File Offset: 0x00E337B1
		public List<int> SelectFightIdList { get; set; }

		// Token: 0x1700900F RID: 36879
		// (get) Token: 0x06038173 RID: 229747 RVA: 0x00E355BA File Offset: 0x00E337BA
		// (set) Token: 0x06038174 RID: 229748 RVA: 0x00E355C2 File Offset: 0x00E337C2
		public PhantomBattleEffectResultInfo Effect { get; set; }

		// Token: 0x17009010 RID: 36880
		// (get) Token: 0x06038175 RID: 229749 RVA: 0x00E355CB File Offset: 0x00E337CB
		// (set) Token: 0x06038176 RID: 229750 RVA: 0x00E355D3 File Offset: 0x00E337D3
		public ENotifyMessageId? NotifyId { get; set; }
	}
}
