using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.ActivityListPanel
{
	// Token: 0x02004BE0 RID: 19424
	[NullableContext(1)]
	public interface IActivityListPanelItemData
	{
		// Token: 0x17008712 RID: 34578
		// (get) Token: 0x06032AE8 RID: 207592
		// (set) Token: 0x06032AE9 RID: 207593
		IActivityListItemData Data { get; set; }

		// Token: 0x17008713 RID: 34579
		// (get) Token: 0x06032AEA RID: 207594
		// (set) Token: 0x06032AEB RID: 207595
		Action OnClickCb { get; set; }
	}
}
