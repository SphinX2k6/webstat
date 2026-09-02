using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001B7A RID: 7034
[NullableContext(1)]
public interface IAreaExplorePlayState
{
	// Token: 0x1700107F RID: 4223
	// (get) Token: 0x0600CC4F RID: 52303
	// (set) Token: 0x0600CC50 RID: 52304
	EExploreType ExploreType { get; set; }

	// Token: 0x17001080 RID: 4224
	// (get) Token: 0x0600CC51 RID: 52305
	// (set) Token: 0x0600CC52 RID: 52306
	List<EPlayPointState> PlayPointStateList { get; set; }
}
