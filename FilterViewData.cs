using System;
using System.Runtime.CompilerServices;

// Token: 0x020018FE RID: 6398
[NullableContext(2)]
[Nullable(0)]
public class FilterViewData
{
	// Token: 0x0600B7A5 RID: 47013 RVA: 0x0030D961 File Offset: 0x0030BB61
	public FilterViewData(int uniqueId, Action confirmFunction = null)
	{
		this.UniqueId = uniqueId;
		this.ConfirmFunction = confirmFunction;
	}

	// Token: 0x0400569C RID: 22172
	public int UniqueId;

	// Token: 0x0400569D RID: 22173
	public Action ConfirmFunction;
}
