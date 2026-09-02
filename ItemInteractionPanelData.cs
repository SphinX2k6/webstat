using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001975 RID: 6517
[NullableContext(1)]
[Nullable(0)]
public class ItemInteractionPanelData : IItemInteractionPanel
{
	// Token: 0x17000F34 RID: 3892
	// (get) Token: 0x0600BB53 RID: 47955 RVA: 0x0031C370 File Offset: 0x0031A570
	// (set) Token: 0x0600BB54 RID: 47956 RVA: 0x0031C378 File Offset: 0x0031A578
	public List<IItemInteractionPanelItemInfo> ItemInfoList { get; set; } = new List<IItemInteractionPanelItemInfo>();
}
