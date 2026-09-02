using System;
using System.Runtime.CompilerServices;

// Token: 0x020013F6 RID: 5110
[NullableContext(2)]
[Nullable(0)]
public class MemoryItemData : IMemoryItemData
{
	// Token: 0x17000BF3 RID: 3059
	// (get) Token: 0x06008D92 RID: 36242 RVA: 0x0025360B File Offset: 0x0025180B
	// (set) Token: 0x06008D93 RID: 36243 RVA: 0x00253613 File Offset: 0x00251813
	public EMemoryContentId Type { get; set; }

	// Token: 0x17000BF4 RID: 3060
	// (get) Token: 0x06008D94 RID: 36244 RVA: 0x0025361C File Offset: 0x0025181C
	// (set) Token: 0x06008D95 RID: 36245 RVA: 0x00253624 File Offset: 0x00251824
	public EMemoryClassify Classify { get; set; }

	// Token: 0x17000BF5 RID: 3061
	// (get) Token: 0x06008D96 RID: 36246 RVA: 0x0025362D File Offset: 0x0025182D
	// (set) Token: 0x06008D97 RID: 36247 RVA: 0x00253635 File Offset: 0x00251835
	[Nullable(1)]
	public string Title { [NullableContext(1)] get; [NullableContext(1)] set; } = "";

	// Token: 0x17000BF6 RID: 3062
	// (get) Token: 0x06008D98 RID: 36248 RVA: 0x0025363E File Offset: 0x0025183E
	// (set) Token: 0x06008D99 RID: 36249 RVA: 0x00253646 File Offset: 0x00251846
	public bool HasData { get; set; }

	// Token: 0x17000BF7 RID: 3063
	// (get) Token: 0x06008D9A RID: 36250 RVA: 0x0025364F File Offset: 0x0025184F
	// (set) Token: 0x06008D9B RID: 36251 RVA: 0x00253657 File Offset: 0x00251857
	public bool IsDelegate { get; set; }

	// Token: 0x17000BF8 RID: 3064
	// (get) Token: 0x06008D9C RID: 36252 RVA: 0x00253660 File Offset: 0x00251860
	// (set) Token: 0x06008D9D RID: 36253 RVA: 0x00253668 File Offset: 0x00251868
	public int Sort { get; set; }

	// Token: 0x17000BF9 RID: 3065
	// (get) Token: 0x06008D9E RID: 36254 RVA: 0x00253671 File Offset: 0x00251871
	// (set) Token: 0x06008D9F RID: 36255 RVA: 0x00253679 File Offset: 0x00251879
	public string Content { get; set; }

	// Token: 0x17000BFA RID: 3066
	// (get) Token: 0x06008DA0 RID: 36256 RVA: 0x00253682 File Offset: 0x00251882
	// (set) Token: 0x06008DA1 RID: 36257 RVA: 0x0025368A File Offset: 0x0025188A
	public string SubContent { get; set; }

	// Token: 0x17000BFB RID: 3067
	// (get) Token: 0x06008DA2 RID: 36258 RVA: 0x00253693 File Offset: 0x00251893
	// (set) Token: 0x06008DA3 RID: 36259 RVA: 0x0025369B File Offset: 0x0025189B
	public string IconPath { get; set; }
}
