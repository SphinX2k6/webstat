using System;
using System.Runtime.CompilerServices;

// Token: 0x020013F5 RID: 5109
[NullableContext(2)]
public interface IMemoryItemData
{
	// Token: 0x17000BEA RID: 3050
	// (get) Token: 0x06008D80 RID: 36224
	// (set) Token: 0x06008D81 RID: 36225
	EMemoryContentId Type { get; set; }

	// Token: 0x17000BEB RID: 3051
	// (get) Token: 0x06008D82 RID: 36226
	// (set) Token: 0x06008D83 RID: 36227
	EMemoryClassify Classify { get; set; }

	// Token: 0x17000BEC RID: 3052
	// (get) Token: 0x06008D84 RID: 36228
	// (set) Token: 0x06008D85 RID: 36229
	[Nullable(1)]
	string Title { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000BED RID: 3053
	// (get) Token: 0x06008D86 RID: 36230
	// (set) Token: 0x06008D87 RID: 36231
	bool HasData { get; set; }

	// Token: 0x17000BEE RID: 3054
	// (get) Token: 0x06008D88 RID: 36232
	// (set) Token: 0x06008D89 RID: 36233
	bool IsDelegate { get; set; }

	// Token: 0x17000BEF RID: 3055
	// (get) Token: 0x06008D8A RID: 36234
	// (set) Token: 0x06008D8B RID: 36235
	int Sort { get; set; }

	// Token: 0x17000BF0 RID: 3056
	// (get) Token: 0x06008D8C RID: 36236
	// (set) Token: 0x06008D8D RID: 36237
	string Content { get; set; }

	// Token: 0x17000BF1 RID: 3057
	// (get) Token: 0x06008D8E RID: 36238
	// (set) Token: 0x06008D8F RID: 36239
	string SubContent { get; set; }

	// Token: 0x17000BF2 RID: 3058
	// (get) Token: 0x06008D90 RID: 36240
	// (set) Token: 0x06008D91 RID: 36241
	string IconPath { get; set; }
}
