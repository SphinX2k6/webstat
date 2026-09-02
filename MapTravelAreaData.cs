using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001387 RID: 4999
[NullableContext(1)]
[Nullable(0)]
public class MapTravelAreaData
{
	// Token: 0x0600895E RID: 35166 RVA: 0x00242DFE File Offset: 0x00240FFE
	public MapTravelAreaData(int areaId)
	{
		this.AreaId = areaId;
	}

	// Token: 0x17000BA5 RID: 2981
	// (get) Token: 0x0600895F RID: 35167 RVA: 0x00242E23 File Offset: 0x00241023
	public int AreaId { get; }

	// Token: 0x17000BA6 RID: 2982
	// (get) Token: 0x06008960 RID: 35168 RVA: 0x00242E2B File Offset: 0x0024102B
	public HashSet<int> TravelTaskIdSet { get; } = new HashSet<int>();

	// Token: 0x17000BA7 RID: 2983
	// (get) Token: 0x06008961 RID: 35169 RVA: 0x00242E33 File Offset: 0x00241033
	public HashSet<int> PhantomTaskIdSet { get; } = new HashSet<int>();

	// Token: 0x17000BA8 RID: 2984
	// (get) Token: 0x06008962 RID: 35170 RVA: 0x00242E3B File Offset: 0x0024103B
	// (set) Token: 0x06008963 RID: 35171 RVA: 0x00242E43 File Offset: 0x00241043
	public bool IsUnlock { get; set; }
}
