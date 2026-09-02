using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053D3 RID: 21459
	[NullableContext(2)]
	[Nullable(0)]
	public class ViewHandle
	{
		// Token: 0x17008DC0 RID: 36288
		// (get) Token: 0x06036C56 RID: 224342 RVA: 0x00DE485E File Offset: 0x00DE2A5E
		// (set) Token: 0x06036C57 RID: 224343 RVA: 0x00DE4866 File Offset: 0x00DE2A66
		public EUiViewName? ViewName { get; set; }

		// Token: 0x17008DC1 RID: 36289
		// (get) Token: 0x06036C58 RID: 224344 RVA: 0x00DE486F File Offset: 0x00DE2A6F
		// (set) Token: 0x06036C59 RID: 224345 RVA: 0x00DE4877 File Offset: 0x00DE2A77
		public UiParam Param { get; set; }

		// Token: 0x17008DC2 RID: 36290
		// (get) Token: 0x06036C5A RID: 224346 RVA: 0x00DE4880 File Offset: 0x00DE2A80
		// (set) Token: 0x06036C5B RID: 224347 RVA: 0x00DE4888 File Offset: 0x00DE2A88
		public TCallback Callback { get; set; }

		// Token: 0x17008DC3 RID: 36291
		// (get) Token: 0x06036C5C RID: 224348 RVA: 0x00DE4891 File Offset: 0x00DE2A91
		// (set) Token: 0x06036C5D RID: 224349 RVA: 0x00DE4899 File Offset: 0x00DE2A99
		public long? OwnerId { get; set; }

		// Token: 0x06036C5E RID: 224350 RVA: 0x00DE48A2 File Offset: 0x00DE2AA2
		public ViewHandle(EUiViewName? viewName = null, UiParam param = null, TCallback callback = null, long? ownerId = null)
		{
			this.ViewName = viewName;
			this.Param = param;
			this.Callback = callback;
			this.OwnerId = ownerId;
		}
	}
}
