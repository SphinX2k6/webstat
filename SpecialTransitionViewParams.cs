using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02002A89 RID: 10889
[NullableContext(2)]
[Nullable(0)]
public class SpecialTransitionViewParams : ISpecialTransitionViewParams
{
	// Token: 0x17001C49 RID: 7241
	// (get) Token: 0x06015CC7 RID: 89287 RVA: 0x0060BE21 File Offset: 0x0060A021
	// (set) Token: 0x06015CC8 RID: 89288 RVA: 0x0060BE29 File Offset: 0x0060A029
	public int? SpineId { get; set; }

	// Token: 0x17001C4A RID: 7242
	// (get) Token: 0x06015CC9 RID: 89289 RVA: 0x0060BE32 File Offset: 0x0060A032
	// (set) Token: 0x06015CCA RID: 89290 RVA: 0x0060BE3A File Offset: 0x0060A03A
	public string BgPath { get; set; }

	// Token: 0x17001C4B RID: 7243
	// (get) Token: 0x06015CCB RID: 89291 RVA: 0x0060BE43 File Offset: 0x0060A043
	// (set) Token: 0x06015CCC RID: 89292 RVA: 0x0060BE4B File Offset: 0x0060A04B
	public ICustomShowUi CustomShowUi { get; set; }

	// Token: 0x17001C4C RID: 7244
	// (get) Token: 0x06015CCD RID: 89293 RVA: 0x0060BE54 File Offset: 0x0060A054
	// (set) Token: 0x06015CCE RID: 89294 RVA: 0x0060BE5C File Offset: 0x0060A05C
	public string AkEvent { get; set; }
}
