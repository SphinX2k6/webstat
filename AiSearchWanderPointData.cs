using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001FD5 RID: 8149
internal sealed class AiSearchWanderPointData
{
	// Token: 0x0600F5F8 RID: 62968 RVA: 0x00435C62 File Offset: 0x00433E62
	public void AddSearchedWanderPointId(int wanderPointId)
	{
		this.SearchedWanderPointIdSet.Add(wanderPointId);
	}

	// Token: 0x0600F5F9 RID: 62969 RVA: 0x00435C71 File Offset: 0x00433E71
	public void ClearSearchedWanderPointIdSet()
	{
		this.SearchedWanderPointIdSet.Clear();
	}

	// Token: 0x0600F5FA RID: 62970 RVA: 0x00435C7E File Offset: 0x00433E7E
	public bool HasSearchedWanderPointId(int wanderPointId)
	{
		return this.SearchedWanderPointIdSet.Contains(wanderPointId);
	}

	// Token: 0x040076F7 RID: 30455
	[Nullable(1)]
	public HashSet<int> SearchedWanderPointIdSet = new HashSet<int>();
}
