using System;
using System.Runtime.CompilerServices;

// Token: 0x02002CDA RID: 11482
[NullableContext(1)]
public interface IMultiTemplateGridData<[Nullable(2)] TData, [Nullable(0)] TProxy> : IMultiTemplateGridData where TProxy : ISyncGridProxy<TData>
{
	// Token: 0x17001E73 RID: 7795
	// (get) Token: 0x0601724A RID: 94794
	// (set) Token: 0x0601724B RID: 94795
	TData Data { get; set; }

	// Token: 0x0601724C RID: 94796
	int GetTemplateIndex();
}
