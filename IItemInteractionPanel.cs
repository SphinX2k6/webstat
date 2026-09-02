using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001974 RID: 6516
[NullableContext(1)]
public interface IItemInteractionPanel
{
	// Token: 0x17000F33 RID: 3891
	// (get) Token: 0x0600BB51 RID: 47953
	// (set) Token: 0x0600BB52 RID: 47954
	List<IItemInteractionPanelItemInfo> ItemInfoList { get; set; }
}
