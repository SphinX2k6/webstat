using System;
using System.Runtime.CompilerServices;

// Token: 0x02002FEF RID: 12271
[NullableContext(1)]
public interface IFunctionRequestHandle<[Nullable(0)] T> where T : IFunctionRequestHandle<T>
{
	// Token: 0x06019030 RID: 102448
	bool CompareRequest(T request);
}
