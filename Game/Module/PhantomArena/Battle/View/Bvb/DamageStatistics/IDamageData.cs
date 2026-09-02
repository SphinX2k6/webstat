using System;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb.DamageStatistics
{
	// Token: 0x020055DC RID: 21980
	public interface IDamageData
	{
		// Token: 0x17008FF5 RID: 36853
		// (get) Token: 0x0603802D RID: 229421
		// (set) Token: 0x0603802E RID: 229422
		long EntityId { get; set; }

		// Token: 0x17008FF6 RID: 36854
		// (get) Token: 0x0603802F RID: 229423
		// (set) Token: 0x06038030 RID: 229424
		int Damage { get; set; }
	}
}
