using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006802 RID: 26626
	public class FishingTechNode : IFishingTechNode
	{
		// Token: 0x1700A15B RID: 41307
		// (get) Token: 0x06042601 RID: 271873 RVA: 0x011046ED File Offset: 0x011028ED
		// (set) Token: 0x06042602 RID: 271874 RVA: 0x011046F5 File Offset: 0x011028F5
		public int ConfigId { get; set; }

		// Token: 0x1700A15C RID: 41308
		// (get) Token: 0x06042603 RID: 271875 RVA: 0x011046FE File Offset: 0x011028FE
		// (set) Token: 0x06042604 RID: 271876 RVA: 0x01104706 File Offset: 0x01102906
		public EFishingTechNodeType NodeType { get; set; }

		// Token: 0x1700A15D RID: 41309
		// (get) Token: 0x06042605 RID: 271877 RVA: 0x0110470F File Offset: 0x0110290F
		// (set) Token: 0x06042606 RID: 271878 RVA: 0x01104717 File Offset: 0x01102917
		public int Area { get; set; }

		// Token: 0x1700A15E RID: 41310
		// (get) Token: 0x06042607 RID: 271879 RVA: 0x01104720 File Offset: 0x01102920
		// (set) Token: 0x06042608 RID: 271880 RVA: 0x01104728 File Offset: 0x01102928
		public int PreNode { get; set; }
	}
}
