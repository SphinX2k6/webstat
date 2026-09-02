using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053E8 RID: 21480
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotOptionComponentContext
	{
		// Token: 0x17008DF3 RID: 36339
		// (get) Token: 0x06036D60 RID: 224608 RVA: 0x00DE7D6C File Offset: 0x00DE5F6C
		// (set) Token: 0x06036D61 RID: 224609 RVA: 0x00DE7D74 File Offset: 0x00DE5F74
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<ITalkOption[]> OptionsRefreshDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }

		// Token: 0x17008DF4 RID: 36340
		// (get) Token: 0x06036D62 RID: 224610 RVA: 0x00DE7D7D File Offset: 0x00DE5F7D
		// (set) Token: 0x06036D63 RID: 224611 RVA: 0x00DE7D85 File Offset: 0x00DE5F85
		public Action OptionsShowDelegate { get; set; }

		// Token: 0x17008DF5 RID: 36341
		// (get) Token: 0x06036D64 RID: 224612 RVA: 0x00DE7D8E File Offset: 0x00DE5F8E
		// (set) Token: 0x06036D65 RID: 224613 RVA: 0x00DE7D96 File Offset: 0x00DE5F96
		public Action OptionsHideDelegate { get; set; }
	}
}
