using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005362 RID: 21346
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotReviewItemData
	{
		// Token: 0x17008D7B RID: 36219
		// (get) Token: 0x06036721 RID: 223009 RVA: 0x00DBBB6B File Offset: 0x00DB9D6B
		// (set) Token: 0x06036722 RID: 223010 RVA: 0x00DBBB73 File Offset: 0x00DB9D73
		public EPlotReviewItemType Type { get; set; }

		// Token: 0x17008D7C RID: 36220
		// (get) Token: 0x06036723 RID: 223011 RVA: 0x00DBBB7C File Offset: 0x00DB9D7C
		// (set) Token: 0x06036724 RID: 223012 RVA: 0x00DBBB84 File Offset: 0x00DB9D84
		public object Data { get; set; }
	}
}
