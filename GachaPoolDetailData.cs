using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001CE9 RID: 7401
[NullableContext(1)]
[Nullable(0)]
public class GachaPoolDetailData
{
	// Token: 0x040067BB RID: 26555
	public string TitleTextKey = "";

	// Token: 0x040067BC RID: 26556
	public string TitleDescKey = "";

	// Token: 0x040067BD RID: 26557
	public List<GachaPoolDrop> ItemList = new List<GachaPoolDrop>();
}
