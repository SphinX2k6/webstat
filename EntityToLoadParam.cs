using System;
using System.Runtime.CompilerServices;

// Token: 0x02003457 RID: 13399
[NullableContext(1)]
[Nullable(0)]
public class EntityToLoadParam : IEntityToLoadParam
{
	// Token: 0x17002658 RID: 9816
	// (get) Token: 0x0601C19F RID: 115103 RVA: 0x0086224E File Offset: 0x0086044E
	// (set) Token: 0x0601C1A0 RID: 115104 RVA: 0x00862256 File Offset: 0x00860456
	public long MaxLoadingCount { get; set; } = 4L;

	// Token: 0x17002659 RID: 9817
	// (get) Token: 0x0601C1A1 RID: 115105 RVA: 0x0086225F File Offset: 0x0086045F
	// (set) Token: 0x0601C1A2 RID: 115106 RVA: 0x00862267 File Offset: 0x00860467
	public long LoadingInterval { get; set; }

	// Token: 0x1700265A RID: 9818
	// (get) Token: 0x0601C1A3 RID: 115107 RVA: 0x00862270 File Offset: 0x00860470
	// (set) Token: 0x0601C1A4 RID: 115108 RVA: 0x00862278 File Offset: 0x00860478
	public string MaxLoadingDebugName { get; set; } = "MAX_LOADING_ENTITY_COUNT";

	// Token: 0x1700265B RID: 9819
	// (get) Token: 0x0601C1A5 RID: 115109 RVA: 0x00862281 File Offset: 0x00860481
	// (set) Token: 0x0601C1A6 RID: 115110 RVA: 0x00862289 File Offset: 0x00860489
	public string LoadingIntervalDebugName { get; set; } = "LOADING_INTERVAL";

	// Token: 0x0601C1A7 RID: 115111 RVA: 0x00862292 File Offset: 0x00860492
	public EntityToLoadParam()
	{
	}

	// Token: 0x0601C1A8 RID: 115112 RVA: 0x008622B8 File Offset: 0x008604B8
	[NullableContext(2)]
	public EntityToLoadParam(IEntityToLoadParam entityToLoadParam = null, long? maxLoadingCount = null, long? loadingInterval = null, string maxLoadingDebugName = null, string loadingIntervalDebugName = null)
	{
		if (entityToLoadParam != null)
		{
			this.MaxLoadingCount = entityToLoadParam.MaxLoadingCount;
			this.LoadingInterval = entityToLoadParam.LoadingInterval;
			this.MaxLoadingDebugName = entityToLoadParam.MaxLoadingDebugName;
			this.LoadingIntervalDebugName = entityToLoadParam.LoadingIntervalDebugName;
			return;
		}
		this.MaxLoadingCount = (maxLoadingCount ?? this.MaxLoadingCount);
		this.LoadingInterval = (loadingInterval ?? this.LoadingInterval);
		this.MaxLoadingDebugName = (maxLoadingDebugName ?? this.MaxLoadingDebugName);
		this.LoadingIntervalDebugName = (loadingIntervalDebugName ?? this.LoadingIntervalDebugName);
	}
}
