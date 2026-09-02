using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002CD8 RID: 11480
[NullableContext(1)]
[Nullable(0)]
public class MultiTemplateScrollViewRefreshContext
{
	// Token: 0x17001E6E RID: 7790
	// (get) Token: 0x06017235 RID: 94773 RVA: 0x00669811 File Offset: 0x00667A11
	// (set) Token: 0x06017236 RID: 94774 RVA: 0x00669819 File Offset: 0x00667A19
	public List<IMultiTemplateGridData> DataList { get; set; }

	// Token: 0x17001E6F RID: 7791
	// (get) Token: 0x06017237 RID: 94775 RVA: 0x00669822 File Offset: 0x00667A22
	// (set) Token: 0x06017238 RID: 94776 RVA: 0x0066982A File Offset: 0x00667A2A
	public bool KeepContentPosition { get; set; }

	// Token: 0x17001E70 RID: 7792
	// (get) Token: 0x06017239 RID: 94777 RVA: 0x00669833 File Offset: 0x00667A33
	// (set) Token: 0x0601723A RID: 94778 RVA: 0x0066983B File Offset: 0x00667A3B
	public int ScrollToGridIndex { get; set; } = -1;

	// Token: 0x17001E71 RID: 7793
	// (get) Token: 0x0601723B RID: 94779 RVA: 0x00669844 File Offset: 0x00667A44
	// (set) Token: 0x0601723C RID: 94780 RVA: 0x0066984C File Offset: 0x00667A4C
	public bool PlayGridAnim { get; set; }

	// Token: 0x17001E72 RID: 7794
	// (get) Token: 0x0601723D RID: 94781 RVA: 0x00669855 File Offset: 0x00667A55
	// (set) Token: 0x0601723E RID: 94782 RVA: 0x0066985D File Offset: 0x00667A5D
	public string GridAnimName { get; set; } = "";

	// Token: 0x0601723F RID: 94783 RVA: 0x00669866 File Offset: 0x00667A66
	public MultiTemplateScrollViewRefreshContext(List<IMultiTemplateGridData> dataList)
	{
		this.DataList = dataList;
	}
}
