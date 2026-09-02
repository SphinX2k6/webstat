using System;
using System.Runtime.CompilerServices;

// Token: 0x02001953 RID: 6483
[NullableContext(1)]
[Nullable(0)]
public class SortViewData
{
	// Token: 0x0600B9EE RID: 47598 RVA: 0x00318933 File Offset: 0x00316B33
	public SortViewData(int uniqueId, Action confirmFunction)
	{
		this.UniqueId = uniqueId;
		this.ConfirmFunction = confirmFunction;
	}

	// Token: 0x040057DD RID: 22493
	public int UniqueId;

	// Token: 0x040057DE RID: 22494
	public Action ConfirmFunction;
}
