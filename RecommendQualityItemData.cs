using System;
using System.Runtime.CompilerServices;

// Token: 0x0200274D RID: 10061
[NullableContext(1)]
[Nullable(0)]
public class RecommendQualityItemData : IRecommendQualityItemData
{
	// Token: 0x17001966 RID: 6502
	// (get) Token: 0x06013DCB RID: 81355 RVA: 0x00589105 File Offset: 0x00587305
	// (set) Token: 0x06013DCC RID: 81356 RVA: 0x0058910D File Offset: 0x0058730D
	public EGameQualitySettingLevel Quality { get; set; }

	// Token: 0x17001967 RID: 6503
	// (get) Token: 0x06013DCD RID: 81357 RVA: 0x00589116 File Offset: 0x00587316
	// (set) Token: 0x06013DCE RID: 81358 RVA: 0x0058911E File Offset: 0x0058731E
	public string Name { get; set; } = "";

	// Token: 0x17001968 RID: 6504
	// (get) Token: 0x06013DCF RID: 81359 RVA: 0x00589127 File Offset: 0x00587327
	// (set) Token: 0x06013DD0 RID: 81360 RVA: 0x0058912F File Offset: 0x0058732F
	public bool IsRecommend { get; set; }

	// Token: 0x17001969 RID: 6505
	// (get) Token: 0x06013DD1 RID: 81361 RVA: 0x00589138 File Offset: 0x00587338
	// (set) Token: 0x06013DD2 RID: 81362 RVA: 0x00589140 File Offset: 0x00587340
	public string Bg { get; set; } = "";
}
