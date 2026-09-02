using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001B7B RID: 7035
[NullableContext(1)]
[Nullable(0)]
public class AreaExplorePlayState : IAreaExplorePlayState
{
	// Token: 0x17001081 RID: 4225
	// (get) Token: 0x0600CC53 RID: 52307 RVA: 0x00366808 File Offset: 0x00364A08
	// (set) Token: 0x0600CC54 RID: 52308 RVA: 0x00366810 File Offset: 0x00364A10
	public EExploreType ExploreType { get; set; }

	// Token: 0x17001082 RID: 4226
	// (get) Token: 0x0600CC55 RID: 52309 RVA: 0x00366819 File Offset: 0x00364A19
	// (set) Token: 0x0600CC56 RID: 52310 RVA: 0x00366821 File Offset: 0x00364A21
	public List<EPlayPointState> PlayPointStateList { get; set; }
}
