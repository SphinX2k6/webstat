using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PayShop.MotorSkinTab
{
	// Token: 0x020056BF RID: 22207
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardItemGridData : IRewardItemGridData
	{
		// Token: 0x170090BA RID: 37050
		// (get) Token: 0x06038864 RID: 231524 RVA: 0x00E521B1 File Offset: 0x00E503B1
		// (set) Token: 0x06038865 RID: 231525 RVA: 0x00E521B9 File Offset: 0x00E503B9
		public string IconPath { get; set; } = string.Empty;

		// Token: 0x170090BB RID: 37051
		// (get) Token: 0x06038866 RID: 231526 RVA: 0x00E521C2 File Offset: 0x00E503C2
		// (set) Token: 0x06038867 RID: 231527 RVA: 0x00E521CA File Offset: 0x00E503CA
		public int Count { get; set; }
	}
}
