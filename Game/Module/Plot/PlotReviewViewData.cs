using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005363 RID: 21347
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotReviewViewData
	{
		// Token: 0x17008D7D RID: 36221
		// (get) Token: 0x06036726 RID: 223014 RVA: 0x00DBBB95 File Offset: 0x00DB9D95
		// (set) Token: 0x06036727 RID: 223015 RVA: 0x00DBBB9D File Offset: 0x00DB9D9D
		public List<PlotReviewItemData> PlotReviewItemDataList { get; set; }

		// Token: 0x06036728 RID: 223016 RVA: 0x00DBBBA6 File Offset: 0x00DB9DA6
		public PlotReviewViewData()
		{
			this.PlotReviewItemDataList = new List<PlotReviewItemData>();
		}
	}
}
