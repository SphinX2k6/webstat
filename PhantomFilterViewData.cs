using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020018FF RID: 6399
[NullableContext(2)]
[Nullable(0)]
public class PhantomFilterViewData<T> : FilterViewData
{
	// Token: 0x0600B7A6 RID: 47014 RVA: 0x0030D977 File Offset: 0x0030BB77
	public PhantomFilterViewData(int uniqueId, EFilterSortGroupId groupId, Action confirmFunction = null, [Nullable(1)] Func<List<T>> getFilteredDataListFunc = null, Action onFilterViewClose = null) : base(uniqueId, confirmFunction)
	{
		this.GroupId = groupId;
		this.GetFilteredDataListFunc = getFilteredDataListFunc;
		this.OnFilterViewClose = onFilterViewClose;
	}

	// Token: 0x0400569E RID: 22174
	[Nullable(1)]
	public Func<List<T>> GetFilteredDataListFunc;

	// Token: 0x0400569F RID: 22175
	public EFilterSortGroupId GroupId;

	// Token: 0x040056A0 RID: 22176
	public Action OnFilterViewClose;
}
