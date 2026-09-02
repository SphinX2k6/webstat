using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AA4 RID: 10916
[NullableContext(2)]
[Nullable(0)]
public class SubPackageDownLoadMobileClearInfoItemData : ISubPackageDownLoadMobileClearInfoItemData
{
	// Token: 0x17001C68 RID: 7272
	// (get) Token: 0x06015D65 RID: 89445 RVA: 0x0060EA5B File Offset: 0x0060CC5B
	// (set) Token: 0x06015D66 RID: 89446 RVA: 0x0060EA63 File Offset: 0x0060CC63
	public ESubPackageDownLoadPackageType Type { get; set; }

	// Token: 0x17001C69 RID: 7273
	// (get) Token: 0x06015D67 RID: 89447 RVA: 0x0060EA6C File Offset: 0x0060CC6C
	// (set) Token: 0x06015D68 RID: 89448 RVA: 0x0060EA74 File Offset: 0x0060CC74
	public int? SceneId { get; set; } = new int?(0);

	// Token: 0x17001C6A RID: 7274
	// (get) Token: 0x06015D69 RID: 89449 RVA: 0x0060EA7D File Offset: 0x0060CC7D
	// (set) Token: 0x06015D6A RID: 89450 RVA: 0x0060EA85 File Offset: 0x0060CC85
	public bool? HaveVideoCanClear { get; set; }

	// Token: 0x17001C6B RID: 7275
	// (get) Token: 0x06015D6B RID: 89451 RVA: 0x0060EA8E File Offset: 0x0060CC8E
	// (set) Token: 0x06015D6C RID: 89452 RVA: 0x0060EA96 File Offset: 0x0060CC96
	public string VoiceLanguageCode { get; set; }
}
