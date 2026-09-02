using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002AA1 RID: 10913
[NullableContext(2)]
public interface ISubPackageDownLoadMobileClearData
{
	// Token: 0x17001C5C RID: 7260
	// (get) Token: 0x06015D4C RID: 89420
	// (set) Token: 0x06015D4D RID: 89421
	int TitleId { get; set; }

	// Token: 0x17001C5D RID: 7261
	// (get) Token: 0x06015D4E RID: 89422
	// (set) Token: 0x06015D4F RID: 89423
	List<int> SceneIdList { get; set; }

	// Token: 0x17001C5E RID: 7262
	// (get) Token: 0x06015D50 RID: 89424
	// (set) Token: 0x06015D51 RID: 89425
	bool? HaveVideoCanClear { get; set; }

	// Token: 0x17001C5F RID: 7263
	// (get) Token: 0x06015D52 RID: 89426
	// (set) Token: 0x06015D53 RID: 89427
	[Nullable(new byte[]
	{
		2,
		1
	})]
	List<string> VoiceLanguageCodeList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
