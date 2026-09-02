using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001F50 RID: 8016
[NullableContext(1)]
public interface IHonamiStorySellConfirmBoxOpenParam
{
	// Token: 0x1700124D RID: 4685
	// (get) Token: 0x0600EFFF RID: 61439
	// (set) Token: 0x0600F000 RID: 61440
	List<IHonamiStoryItemSellInfo> SellItemList { get; set; }

	// Token: 0x1700124E RID: 4686
	// (get) Token: 0x0600F001 RID: 61441
	// (set) Token: 0x0600F002 RID: 61442
	Action SellCallback { get; set; }
}
