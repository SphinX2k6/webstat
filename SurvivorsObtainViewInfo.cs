using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AE4 RID: 10980
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsObtainViewInfo : ISurvivorsObtainViewInfo
{
	// Token: 0x17001C7A RID: 7290
	// (get) Token: 0x06015F54 RID: 89940 RVA: 0x00618FE3 File Offset: 0x006171E3
	// (set) Token: 0x06015F55 RID: 89941 RVA: 0x00618FEB File Offset: 0x006171EB
	public string CaptionId { get; set; } = "";

	// Token: 0x17001C7B RID: 7291
	// (get) Token: 0x06015F56 RID: 89942 RVA: 0x00618FF4 File Offset: 0x006171F4
	// (set) Token: 0x06015F57 RID: 89943 RVA: 0x00618FFC File Offset: 0x006171FC
	public string TitleId { get; set; } = "";

	// Token: 0x17001C7C RID: 7292
	// (get) Token: 0x06015F58 RID: 89944 RVA: 0x00619005 File Offset: 0x00617205
	// (set) Token: 0x06015F59 RID: 89945 RVA: 0x0061900D File Offset: 0x0061720D
	public string ButtonId { get; set; } = "";

	// Token: 0x17001C7D RID: 7293
	// (get) Token: 0x06015F5A RID: 89946 RVA: 0x00619016 File Offset: 0x00617216
	// (set) Token: 0x06015F5B RID: 89947 RVA: 0x0061901E File Offset: 0x0061721E
	public ISurvivorsChooseData ChooseData { get; set; }

	// Token: 0x17001C7E RID: 7294
	// (get) Token: 0x06015F5C RID: 89948 RVA: 0x00619027 File Offset: 0x00617227
	// (set) Token: 0x06015F5D RID: 89949 RVA: 0x0061902F File Offset: 0x0061722F
	public IList<GoodsDetail> GoodsList { get; set; }
}
