using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x020055FD RID: 22013
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillTriggerInfo : ISkillTriggerInfo
	{
		// Token: 0x1700901A RID: 36890
		// (get) Token: 0x0603818A RID: 229770 RVA: 0x00E355E4 File Offset: 0x00E337E4
		// (set) Token: 0x0603818B RID: 229771 RVA: 0x00E355EC File Offset: 0x00E337EC
		public EPhantomArenaBuffEffectType InteractType { get; set; }

		// Token: 0x1700901B RID: 36891
		// (get) Token: 0x0603818C RID: 229772 RVA: 0x00E355F5 File Offset: 0x00E337F5
		// (set) Token: 0x0603818D RID: 229773 RVA: 0x00E355FD File Offset: 0x00E337FD
		public List<int> SelectFightIdList { get; set; }

		// Token: 0x1700901C RID: 36892
		// (get) Token: 0x0603818E RID: 229774 RVA: 0x00E35606 File Offset: 0x00E33806
		// (set) Token: 0x0603818F RID: 229775 RVA: 0x00E3560E File Offset: 0x00E3380E
		public int SelectNum { get; set; }

		// Token: 0x1700901D RID: 36893
		// (get) Token: 0x06038190 RID: 229776 RVA: 0x00E35617 File Offset: 0x00E33817
		// (set) Token: 0x06038191 RID: 229777 RVA: 0x00E3561F File Offset: 0x00E3381F
		public int? SkillId { get; set; }

		// Token: 0x1700901E RID: 36894
		// (get) Token: 0x06038192 RID: 229778 RVA: 0x00E35628 File Offset: 0x00E33828
		// (set) Token: 0x06038193 RID: 229779 RVA: 0x00E35630 File Offset: 0x00E33830
		public int? DataId { get; set; }

		// Token: 0x1700901F RID: 36895
		// (get) Token: 0x06038194 RID: 229780 RVA: 0x00E35639 File Offset: 0x00E33839
		// (set) Token: 0x06038195 RID: 229781 RVA: 0x00E35641 File Offset: 0x00E33841
		public bool IsRole { get; set; }

		// Token: 0x17009020 RID: 36896
		// (get) Token: 0x06038196 RID: 229782 RVA: 0x00E3564A File Offset: 0x00E3384A
		// (set) Token: 0x06038197 RID: 229783 RVA: 0x00E35652 File Offset: 0x00E33852
		public bool IsPassive { get; set; }

		// Token: 0x17009021 RID: 36897
		// (get) Token: 0x06038198 RID: 229784 RVA: 0x00E3565B File Offset: 0x00E3385B
		// (set) Token: 0x06038199 RID: 229785 RVA: 0x00E35663 File Offset: 0x00E33863
		public bool IsFight { get; set; }

		// Token: 0x17009022 RID: 36898
		// (get) Token: 0x0603819A RID: 229786 RVA: 0x00E3566C File Offset: 0x00E3386C
		// (set) Token: 0x0603819B RID: 229787 RVA: 0x00E35674 File Offset: 0x00E33874
		public bool IsClickInteract { get; set; }
	}
}
