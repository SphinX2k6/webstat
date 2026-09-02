using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D07 RID: 11527
[NullableContext(1)]
public interface IWeaponPreviewViewParam
{
	// Token: 0x17001E9E RID: 7838
	// (get) Token: 0x06017437 RID: 95287
	// (set) Token: 0x06017438 RID: 95288
	WeaponDataBase[] WeaponDataList { get; set; }

	// Token: 0x17001E9F RID: 7839
	// (get) Token: 0x06017439 RID: 95289
	// (set) Token: 0x0601743A RID: 95290
	int SelectedIndex { get; set; }

	// Token: 0x17001EA0 RID: 7840
	// (get) Token: 0x0601743B RID: 95291
	// (set) Token: 0x0601743C RID: 95292
	[Nullable(2)]
	WeaponSkeletalObserverHandles WeaponObservers { [NullableContext(2)] get; [NullableContext(2)] set; }
}
