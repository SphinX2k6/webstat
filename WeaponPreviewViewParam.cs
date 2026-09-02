using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D08 RID: 11528
[NullableContext(1)]
[Nullable(0)]
public class WeaponPreviewViewParam : IWeaponPreviewViewParam
{
	// Token: 0x17001EA1 RID: 7841
	// (get) Token: 0x0601743D RID: 95293 RVA: 0x00673378 File Offset: 0x00671578
	// (set) Token: 0x0601743E RID: 95294 RVA: 0x00673380 File Offset: 0x00671580
	public WeaponDataBase[] WeaponDataList { get; set; }

	// Token: 0x17001EA2 RID: 7842
	// (get) Token: 0x0601743F RID: 95295 RVA: 0x00673389 File Offset: 0x00671589
	// (set) Token: 0x06017440 RID: 95296 RVA: 0x00673391 File Offset: 0x00671591
	public int SelectedIndex { get; set; }

	// Token: 0x17001EA3 RID: 7843
	// (get) Token: 0x06017441 RID: 95297 RVA: 0x0067339A File Offset: 0x0067159A
	// (set) Token: 0x06017442 RID: 95298 RVA: 0x006733A2 File Offset: 0x006715A2
	[Nullable(2)]
	public WeaponSkeletalObserverHandles WeaponObservers { [NullableContext(2)] get; [NullableContext(2)] set; }
}
