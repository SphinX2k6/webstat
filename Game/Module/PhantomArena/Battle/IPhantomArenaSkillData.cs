using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x0200559E RID: 21918
	[NullableContext(1)]
	public interface IPhantomArenaSkillData
	{
		// Token: 0x17008FB9 RID: 36793
		// (get) Token: 0x06037CA2 RID: 228514
		// (set) Token: 0x06037CA3 RID: 228515
		bool IsOwn { get; set; }

		// Token: 0x17008FBA RID: 36794
		// (get) Token: 0x06037CA4 RID: 228516
		// (set) Token: 0x06037CA5 RID: 228517
		int SkillId { get; set; }

		// Token: 0x17008FBB RID: 36795
		// (get) Token: 0x06037CA6 RID: 228518
		// (set) Token: 0x06037CA7 RID: 228519
		bool IsPassive { get; set; }

		// Token: 0x17008FBC RID: 36796
		// (get) Token: 0x06037CA8 RID: 228520
		// (set) Token: 0x06037CA9 RID: 228521
		string Icon { get; set; }

		// Token: 0x17008FBD RID: 36797
		// (get) Token: 0x06037CAA RID: 228522
		// (set) Token: 0x06037CAB RID: 228523
		string SkillName { get; set; }

		// Token: 0x17008FBE RID: 36798
		// (get) Token: 0x06037CAC RID: 228524
		// (set) Token: 0x06037CAD RID: 228525
		string SkillDesc { get; set; }

		// Token: 0x17008FBF RID: 36799
		// (get) Token: 0x06037CAE RID: 228526
		// (set) Token: 0x06037CAF RID: 228527
		List<string> SkillDescParams { get; set; }

		// Token: 0x17008FC0 RID: 36800
		// (get) Token: 0x06037CB0 RID: 228528
		// (set) Token: 0x06037CB1 RID: 228529
		int CostConsume { get; set; }
	}
}
