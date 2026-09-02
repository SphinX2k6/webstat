using System;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006693 RID: 26259
	public class MowingRiskConfigQualityData : IMowingRiskConfigQualityData
	{
		// Token: 0x1700A00C RID: 40972
		// (get) Token: 0x06041932 RID: 268594 RVA: 0x010D0FC1 File Offset: 0x010CF1C1
		// (set) Token: 0x06041933 RID: 268595 RVA: 0x010D0FC9 File Offset: 0x010CF1C9
		public EMowingBuffQualityHexColor HexColor { get; set; }

		// Token: 0x1700A00D RID: 40973
		// (get) Token: 0x06041934 RID: 268596 RVA: 0x010D0FD2 File Offset: 0x010CF1D2
		// (set) Token: 0x06041935 RID: 268597 RVA: 0x010D0FDA File Offset: 0x010CF1DA
		public InventoryDefine.EQuality CfgQualityInfoId { get; set; }

		// Token: 0x1700A00E RID: 40974
		// (get) Token: 0x06041936 RID: 268598 RVA: 0x010D0FE3 File Offset: 0x010CF1E3
		// (set) Token: 0x06041937 RID: 268599 RVA: 0x010D0FEB File Offset: 0x010CF1EB
		public EMowingBuffIntroduceQualityBackground BackgroundResource { get; set; }
	}
}
