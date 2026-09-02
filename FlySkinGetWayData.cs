using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A53 RID: 10835
[NullableContext(1)]
[Nullable(0)]
public class FlySkinGetWayData : IFlySkinGetWayData
{
	// Token: 0x17001C17 RID: 7191
	// (get) Token: 0x06015B3B RID: 88891 RVA: 0x00605F30 File Offset: 0x00604130
	// (set) Token: 0x06015B3C RID: 88892 RVA: 0x00605F38 File Offset: 0x00604138
	public int Id { get; set; }

	// Token: 0x17001C18 RID: 7192
	// (get) Token: 0x06015B3D RID: 88893 RVA: 0x00605F41 File Offset: 0x00604141
	// (set) Token: 0x06015B3E RID: 88894 RVA: 0x00605F49 File Offset: 0x00604149
	public int ConfigId { get; set; }

	// Token: 0x17001C19 RID: 7193
	// (get) Token: 0x06015B3F RID: 88895 RVA: 0x00605F52 File Offset: 0x00604152
	// (set) Token: 0x06015B40 RID: 88896 RVA: 0x00605F5A File Offset: 0x0060415A
	public EFlySkinGetWayType Type { get; set; }

	// Token: 0x17001C1A RID: 7194
	// (get) Token: 0x06015B41 RID: 88897 RVA: 0x00605F63 File Offset: 0x00604163
	// (set) Token: 0x06015B42 RID: 88898 RVA: 0x00605F6B File Offset: 0x0060416B
	public string Text { get; set; }

	// Token: 0x17001C1B RID: 7195
	// (get) Token: 0x06015B43 RID: 88899 RVA: 0x00605F74 File Offset: 0x00604174
	// (set) Token: 0x06015B44 RID: 88900 RVA: 0x00605F7C File Offset: 0x0060417C
	public int SortIndex { get; set; }
}
