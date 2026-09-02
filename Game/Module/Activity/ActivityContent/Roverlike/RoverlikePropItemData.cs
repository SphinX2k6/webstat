using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200644E RID: 25678
	public class RoverlikePropItemData : IRoverlikePropItemData
	{
		// Token: 0x17009E13 RID: 40467
		// (get) Token: 0x0604072D RID: 263981 RVA: 0x01085312 File Offset: 0x01083512
		// (set) Token: 0x0604072E RID: 263982 RVA: 0x0108531A File Offset: 0x0108351A
		public int ConfigId { get; set; }

		// Token: 0x17009E14 RID: 40468
		// (get) Token: 0x0604072F RID: 263983 RVA: 0x01085323 File Offset: 0x01083523
		// (set) Token: 0x06040730 RID: 263984 RVA: 0x0108532B File Offset: 0x0108352B
		public bool IsInGame { get; set; }

		// Token: 0x17009E15 RID: 40469
		// (get) Token: 0x06040731 RID: 263985 RVA: 0x01085334 File Offset: 0x01083534
		// (set) Token: 0x06040732 RID: 263986 RVA: 0x0108533C File Offset: 0x0108353C
		public int? IncId { get; set; }
	}
}
