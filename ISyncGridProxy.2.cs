using System;
using System.Runtime.CompilerServices;

// Token: 0x02002CCF RID: 11471
public interface ISyncGridProxy<[Nullable(2)] TData> : ISyncGridProxy
{
	// Token: 0x060171C3 RID: 94659
	[NullableContext(1)]
	void Refresh(TData data);
}
