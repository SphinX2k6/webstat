using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006696 RID: 26262
	public interface IMowingRiskPercentageData
	{
		// Token: 0x1700A015 RID: 40981
		// (get) Token: 0x06041946 RID: 268614
		// (set) Token: 0x06041947 RID: 268615
		int Count { get; set; }

		// Token: 0x1700A016 RID: 40982
		// (get) Token: 0x06041948 RID: 268616
		// (set) Token: 0x06041949 RID: 268617
		int SuperLevel { get; set; }

		// Token: 0x1700A017 RID: 40983
		// (get) Token: 0x0604194A RID: 268618
		// (set) Token: 0x0604194B RID: 268619
		float Partial { get; set; }

		// Token: 0x1700A018 RID: 40984
		// (get) Token: 0x0604194C RID: 268620
		// (set) Token: 0x0604194D RID: 268621
		float Overall { get; set; }
	}
}
