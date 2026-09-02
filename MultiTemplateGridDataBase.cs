using System;
using System.Runtime.CompilerServices;

// Token: 0x02002CDC RID: 11484
[NullableContext(1)]
[Nullable(0)]
public abstract class MultiTemplateGridDataBase<[Nullable(2)] TData, [Nullable(0)] TProxy> : IMultiTemplateGridData<TData, TProxy>, IMultiTemplateGridData where TProxy : ISyncGridProxy<TData>
{
	// Token: 0x17001E75 RID: 7797
	// (get) Token: 0x06017251 RID: 94801 RVA: 0x00669DEF File Offset: 0x00667FEF
	// (set) Token: 0x06017252 RID: 94802 RVA: 0x00669DF7 File Offset: 0x00667FF7
	public TData Data { get; set; }

	// Token: 0x17001E76 RID: 7798
	// (get) Token: 0x06017253 RID: 94803 RVA: 0x00669E00 File Offset: 0x00668000
	object IMultiTemplateGridData.Data
	{
		get
		{
			return this.Data;
		}
	}

	// Token: 0x06017254 RID: 94804
	public abstract int GetTemplateIndex();

	// Token: 0x06017255 RID: 94805
	public abstract TProxy CreateProxy();

	// Token: 0x06017256 RID: 94806 RVA: 0x00669E0D File Offset: 0x0066800D
	public virtual bool IsNavigable()
	{
		return true;
	}

	// Token: 0x06017257 RID: 94807 RVA: 0x00669E10 File Offset: 0x00668010
	ISyncGridProxy IMultiTemplateGridData.CreateProxy()
	{
		return this.CreateProxy();
	}
}
