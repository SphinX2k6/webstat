using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061F9 RID: 25081
	public class BossInfo : IBossInfo
	{
		// Token: 0x17009B5D RID: 39773
		// (get) Token: 0x0603F4AE RID: 259246 RVA: 0x0103E635 File Offset: 0x0103C835
		// (set) Token: 0x0603F4AF RID: 259247 RVA: 0x0103E63D File Offset: 0x0103C83D
		public int WaveConfigId { get; set; }

		// Token: 0x17009B5E RID: 39774
		// (get) Token: 0x0603F4B0 RID: 259248 RVA: 0x0103E646 File Offset: 0x0103C846
		// (set) Token: 0x0603F4B1 RID: 259249 RVA: 0x0103E64E File Offset: 0x0103C84E
		public int Round { get; set; }

		// Token: 0x17009B5F RID: 39775
		// (get) Token: 0x0603F4B2 RID: 259250 RVA: 0x0103E657 File Offset: 0x0103C857
		// (set) Token: 0x0603F4B3 RID: 259251 RVA: 0x0103E65F File Offset: 0x0103C85F
		public double HpPercentage { get; set; }

		// Token: 0x17009B60 RID: 39776
		// (get) Token: 0x0603F4B4 RID: 259252 RVA: 0x0103E668 File Offset: 0x0103C868
		// (set) Token: 0x0603F4B5 RID: 259253 RVA: 0x0103E670 File Offset: 0x0103C870
		public double? LoseHpPercentage { get; set; }
	}
}
