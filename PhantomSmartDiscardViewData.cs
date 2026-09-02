using System;
using System.Runtime.CompilerServices;

// Token: 0x02002042 RID: 8258
[NullableContext(2)]
[Nullable(0)]
public class PhantomSmartDiscardViewData : IPhantomSmartDiscardViewData
{
	// Token: 0x17001298 RID: 4760
	// (get) Token: 0x0600FB93 RID: 64403 RVA: 0x00450EE5 File Offset: 0x0044F0E5
	// (set) Token: 0x0600FB94 RID: 64404 RVA: 0x00450EED File Offset: 0x0044F0ED
	public Action OnConfirm { get; set; }

	// Token: 0x17001299 RID: 4761
	// (get) Token: 0x0600FB95 RID: 64405 RVA: 0x00450EF6 File Offset: 0x0044F0F6
	// (set) Token: 0x0600FB96 RID: 64406 RVA: 0x00450EFE File Offset: 0x0044F0FE
	public Action OnCancel { get; set; }
}
