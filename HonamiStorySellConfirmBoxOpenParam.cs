using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001F51 RID: 8017
[NullableContext(1)]
[Nullable(0)]
public class HonamiStorySellConfirmBoxOpenParam : IHonamiStorySellConfirmBoxOpenParam
{
	// Token: 0x1700124F RID: 4687
	// (get) Token: 0x0600F003 RID: 61443 RVA: 0x004195E0 File Offset: 0x004177E0
	// (set) Token: 0x0600F004 RID: 61444 RVA: 0x004195E8 File Offset: 0x004177E8
	public List<IHonamiStoryItemSellInfo> SellItemList { get; set; } = new List<IHonamiStoryItemSellInfo>();

	// Token: 0x17001250 RID: 4688
	// (get) Token: 0x0600F005 RID: 61445 RVA: 0x004195F1 File Offset: 0x004177F1
	// (set) Token: 0x0600F006 RID: 61446 RVA: 0x004195F9 File Offset: 0x004177F9
	public Action SellCallback { get; set; } = delegate()
	{
	};
}
