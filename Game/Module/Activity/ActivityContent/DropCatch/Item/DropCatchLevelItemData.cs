using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068E2 RID: 26850
	public class DropCatchLevelItemData : IDropCatchLevelItemData
	{
		// Token: 0x1700A1BC RID: 41404
		// (get) Token: 0x06042BD3 RID: 273363 RVA: 0x01121084 File Offset: 0x0111F284
		// (set) Token: 0x06042BD4 RID: 273364 RVA: 0x0112108C File Offset: 0x0111F28C
		public int CfgId { get; set; }

		// Token: 0x1700A1BD RID: 41405
		// (get) Token: 0x06042BD5 RID: 273365 RVA: 0x01121095 File Offset: 0x0111F295
		// (set) Token: 0x06042BD6 RID: 273366 RVA: 0x0112109D File Offset: 0x0111F29D
		public EDropCatchLevelState? State { get; set; }

		// Token: 0x1700A1BE RID: 41406
		// (get) Token: 0x06042BD7 RID: 273367 RVA: 0x011210A6 File Offset: 0x0111F2A6
		// (set) Token: 0x06042BD8 RID: 273368 RVA: 0x011210AE File Offset: 0x0111F2AE
		public bool HasRedPoint { get; set; }
	}
}
