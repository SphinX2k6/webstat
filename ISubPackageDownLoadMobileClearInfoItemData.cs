using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AA3 RID: 10915
[NullableContext(2)]
public interface ISubPackageDownLoadMobileClearInfoItemData
{
	// Token: 0x17001C64 RID: 7268
	// (get) Token: 0x06015D5D RID: 89437
	// (set) Token: 0x06015D5E RID: 89438
	ESubPackageDownLoadPackageType Type { get; set; }

	// Token: 0x17001C65 RID: 7269
	// (get) Token: 0x06015D5F RID: 89439
	// (set) Token: 0x06015D60 RID: 89440
	int? SceneId { get; set; }

	// Token: 0x17001C66 RID: 7270
	// (get) Token: 0x06015D61 RID: 89441
	// (set) Token: 0x06015D62 RID: 89442
	bool? HaveVideoCanClear { get; set; }

	// Token: 0x17001C67 RID: 7271
	// (get) Token: 0x06015D63 RID: 89443
	// (set) Token: 0x06015D64 RID: 89444
	string VoiceLanguageCode { get; set; }
}
