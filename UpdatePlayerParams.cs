using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002960 RID: 10592
[NullableContext(1)]
[Nullable(0)]
public class UpdatePlayerParams : IUpdatePlayerParams
{
	// Token: 0x17001BAA RID: 7082
	// (get) Token: 0x060150D1 RID: 86225 RVA: 0x005D3002 File Offset: 0x005D1202
	// (set) Token: 0x060150D2 RID: 86226 RVA: 0x005D300A File Offset: 0x005D120A
	public int PlayerId { get; set; }

	// Token: 0x17001BAB RID: 7083
	// (get) Token: 0x060150D3 RID: 86227 RVA: 0x005D3013 File Offset: 0x005D1213
	// (set) Token: 0x060150D4 RID: 86228 RVA: 0x005D301B File Offset: 0x005D121B
	public ETeamGroupType CurrentGroupType { get; set; }

	// Token: 0x17001BAC RID: 7084
	// (get) Token: 0x060150D5 RID: 86229 RVA: 0x005D3024 File Offset: 0x005D1224
	// (set) Token: 0x060150D6 RID: 86230 RVA: 0x005D302C File Offset: 0x005D122C
	public IList<IUpdateGroupParams> Groups { get; set; }
}
