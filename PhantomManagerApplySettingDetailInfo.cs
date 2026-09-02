using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002473 RID: 9331
[NullableContext(1)]
[Nullable(0)]
public class PhantomManagerApplySettingDetailInfo : IPhantomManagerApplySettingDetailInfo
{
	// Token: 0x170016C3 RID: 5827
	// (get) Token: 0x06012129 RID: 74025 RVA: 0x004F7EA4 File Offset: 0x004F60A4
	// (set) Token: 0x0601212A RID: 74026 RVA: 0x004F7EAC File Offset: 0x004F60AC
	public List<PhantomItemData> DiscardList { get; set; } = new List<PhantomItemData>();

	// Token: 0x170016C4 RID: 5828
	// (get) Token: 0x0601212B RID: 74027 RVA: 0x004F7EB5 File Offset: 0x004F60B5
	// (set) Token: 0x0601212C RID: 74028 RVA: 0x004F7EBD File Offset: 0x004F60BD
	public List<PhantomItemData> LockList { get; set; } = new List<PhantomItemData>();
}
