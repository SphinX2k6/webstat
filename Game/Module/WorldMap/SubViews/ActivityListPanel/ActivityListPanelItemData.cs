using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.ActivityListPanel
{
	// Token: 0x02004BE1 RID: 19425
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityListPanelItemData : IActivityListPanelItemData
	{
		// Token: 0x17008714 RID: 34580
		// (get) Token: 0x06032AEC RID: 207596 RVA: 0x00CB15AF File Offset: 0x00CAF7AF
		// (set) Token: 0x06032AED RID: 207597 RVA: 0x00CB15B7 File Offset: 0x00CAF7B7
		public IActivityListItemData Data { get; set; }

		// Token: 0x17008715 RID: 34581
		// (get) Token: 0x06032AEE RID: 207598 RVA: 0x00CB15C0 File Offset: 0x00CAF7C0
		// (set) Token: 0x06032AEF RID: 207599 RVA: 0x00CB15C8 File Offset: 0x00CAF7C8
		public Action OnClickCb { get; set; }
	}
}
