using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011FC RID: 4604
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerBuffViewData : IBabelTowerBuffViewData
{
	// Token: 0x17000A93 RID: 2707
	// (get) Token: 0x06007A05 RID: 31237 RVA: 0x001FD100 File Offset: 0x001FB300
	// (set) Token: 0x06007A06 RID: 31238 RVA: 0x001FD108 File Offset: 0x001FB308
	public List<IBabelTowerBuffItemData> BuffDataList { get; set; }

	// Token: 0x17000A94 RID: 2708
	// (get) Token: 0x06007A07 RID: 31239 RVA: 0x001FD111 File Offset: 0x001FB311
	// (set) Token: 0x06007A08 RID: 31240 RVA: 0x001FD119 File Offset: 0x001FB319
	public List<IBabelTowerBuffItemData> DeTermDataList { get; set; }
}
