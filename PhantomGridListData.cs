using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020024BB RID: 9403
[NullableContext(1)]
[Nullable(0)]
public class PhantomGridListData : IPhantomGridListData
{
	// Token: 0x17001719 RID: 5913
	// (get) Token: 0x060123FC RID: 74748 RVA: 0x00505BFE File Offset: 0x00503DFE
	// (set) Token: 0x060123FD RID: 74749 RVA: 0x00505C06 File Offset: 0x00503E06
	public EGridTitleType TitleType { get; set; }

	// Token: 0x1700171A RID: 5914
	// (get) Token: 0x060123FE RID: 74750 RVA: 0x00505C0F File Offset: 0x00503E0F
	// (set) Token: 0x060123FF RID: 74751 RVA: 0x00505C17 File Offset: 0x00503E17
	public List<int> MonsterIds { get; set; } = new List<int>();
}
