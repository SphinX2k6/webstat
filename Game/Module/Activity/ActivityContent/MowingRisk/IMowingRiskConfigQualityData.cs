using System;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006692 RID: 26258
	public interface IMowingRiskConfigQualityData
	{
		// Token: 0x1700A009 RID: 40969
		// (get) Token: 0x0604192C RID: 268588
		// (set) Token: 0x0604192D RID: 268589
		EMowingBuffQualityHexColor HexColor { get; set; }

		// Token: 0x1700A00A RID: 40970
		// (get) Token: 0x0604192E RID: 268590
		// (set) Token: 0x0604192F RID: 268591
		InventoryDefine.EQuality CfgQualityInfoId { get; set; }

		// Token: 0x1700A00B RID: 40971
		// (get) Token: 0x06041930 RID: 268592
		// (set) Token: 0x06041931 RID: 268593
		EMowingBuffIntroduceQualityBackground BackgroundResource { get; set; }
	}
}
