using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002FF0 RID: 12272
[NullableContext(1)]
[Nullable(0)]
public class FunctionRequestWithPriority<[Nullable(2)] T> : IFunctionRequestHandle<FunctionRequestWithPriority<T>>
{
	// Token: 0x06019031 RID: 102449 RVA: 0x0071966C File Offset: 0x0071786C
	public bool CompareRequest(FunctionRequestWithPriority<T> request)
	{
		return Comparer<T>.Default.Compare(this.Priority, request.Priority) > 0;
	}

	// Token: 0x0400C3B1 RID: 50097
	public string ModuleName = "";

	// Token: 0x0400C3B2 RID: 50098
	[Nullable(2)]
	public T Priority;
}
