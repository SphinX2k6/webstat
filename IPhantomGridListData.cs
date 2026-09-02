using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020024BA RID: 9402
[NullableContext(1)]
public interface IPhantomGridListData
{
	// Token: 0x17001717 RID: 5911
	// (get) Token: 0x060123F8 RID: 74744
	// (set) Token: 0x060123F9 RID: 74745
	EGridTitleType TitleType { get; set; }

	// Token: 0x17001718 RID: 5912
	// (get) Token: 0x060123FA RID: 74746
	// (set) Token: 0x060123FB RID: 74747
	List<int> MonsterIds { get; set; }
}
