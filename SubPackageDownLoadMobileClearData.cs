using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002AA2 RID: 10914
[NullableContext(2)]
[Nullable(0)]
public class SubPackageDownLoadMobileClearData : ISubPackageDownLoadMobileClearData
{
	// Token: 0x17001C60 RID: 7264
	// (get) Token: 0x06015D54 RID: 89428 RVA: 0x0060EA04 File Offset: 0x0060CC04
	// (set) Token: 0x06015D55 RID: 89429 RVA: 0x0060EA0C File Offset: 0x0060CC0C
	public int TitleId { get; set; }

	// Token: 0x17001C61 RID: 7265
	// (get) Token: 0x06015D56 RID: 89430 RVA: 0x0060EA15 File Offset: 0x0060CC15
	// (set) Token: 0x06015D57 RID: 89431 RVA: 0x0060EA1D File Offset: 0x0060CC1D
	public List<int> SceneIdList { get; set; } = new List<int>();

	// Token: 0x17001C62 RID: 7266
	// (get) Token: 0x06015D58 RID: 89432 RVA: 0x0060EA26 File Offset: 0x0060CC26
	// (set) Token: 0x06015D59 RID: 89433 RVA: 0x0060EA2E File Offset: 0x0060CC2E
	public bool? HaveVideoCanClear { get; set; }

	// Token: 0x17001C63 RID: 7267
	// (get) Token: 0x06015D5A RID: 89434 RVA: 0x0060EA37 File Offset: 0x0060CC37
	// (set) Token: 0x06015D5B RID: 89435 RVA: 0x0060EA3F File Offset: 0x0060CC3F
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> VoiceLanguageCodeList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
