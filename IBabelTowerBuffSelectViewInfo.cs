using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011EC RID: 4588
[NullableContext(1)]
public interface IBabelTowerBuffSelectViewInfo
{
	// Token: 0x17000A43 RID: 2627
	// (get) Token: 0x0600795D RID: 31069
	// (set) Token: 0x0600795E RID: 31070
	int LevelId { get; set; }

	// Token: 0x17000A44 RID: 2628
	// (get) Token: 0x0600795F RID: 31071
	// (set) Token: 0x06007960 RID: 31072
	int MaxSelectBuffCount { get; set; }

	// Token: 0x17000A45 RID: 2629
	// (get) Token: 0x06007961 RID: 31073
	// (set) Token: 0x06007962 RID: 31074
	List<int> CurrentSelectBuffList { get; set; }

	// Token: 0x17000A46 RID: 2630
	// (get) Token: 0x06007963 RID: 31075
	// (set) Token: 0x06007964 RID: 31076
	int ShowBuffId { get; set; }

	// Token: 0x17000A47 RID: 2631
	// (get) Token: 0x06007965 RID: 31077
	// (set) Token: 0x06007966 RID: 31078
	List<IBabelTowerBuffInfo> AllBuffList { get; set; }

	// Token: 0x17000A48 RID: 2632
	// (get) Token: 0x06007967 RID: 31079
	// (set) Token: 0x06007968 RID: 31080
	Action<List<int>> OnConfirmCallBack { get; set; }
}
