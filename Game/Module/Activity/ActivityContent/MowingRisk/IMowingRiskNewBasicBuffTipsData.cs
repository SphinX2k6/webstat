using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006698 RID: 26264
	[NullableContext(1)]
	public interface IMowingRiskNewBasicBuffTipsData
	{
		// Token: 0x1700A01D RID: 40989
		// (get) Token: 0x06041957 RID: 268631
		// (set) Token: 0x06041958 RID: 268632
		bool IsGolden { get; set; }

		// Token: 0x1700A01E RID: 40990
		// (get) Token: 0x06041959 RID: 268633
		// (set) Token: 0x0604195A RID: 268634
		string NameTextId { get; set; }

		// Token: 0x1700A01F RID: 40991
		// (get) Token: 0x0604195B RID: 268635
		// (set) Token: 0x0604195C RID: 268636
		string NameHexColor { get; set; }

		// Token: 0x1700A020 RID: 40992
		// (get) Token: 0x0604195D RID: 268637
		// (set) Token: 0x0604195E RID: 268638
		string IconPath { get; set; }

		// Token: 0x1700A021 RID: 40993
		// (get) Token: 0x0604195F RID: 268639
		// (set) Token: 0x06041960 RID: 268640
		string DescriptionTextId { get; set; }

		// Token: 0x1700A022 RID: 40994
		// (get) Token: 0x06041961 RID: 268641
		// (set) Token: 0x06041962 RID: 268642
		string[] DescriptionArgs { get; set; }

		// Token: 0x1700A023 RID: 40995
		// (get) Token: 0x06041963 RID: 268643
		// (set) Token: 0x06041964 RID: 268644
		string QualityTexPath { get; set; }

		// Token: 0x1700A024 RID: 40996
		// (get) Token: 0x06041965 RID: 268645
		// (set) Token: 0x06041966 RID: 268646
		string QualityFlowPath { get; set; }
	}
}
