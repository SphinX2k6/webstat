using System;
using System.Runtime.CompilerServices;

// Token: 0x02002041 RID: 8257
[NullableContext(2)]
public interface IPhantomSmartDiscardViewData
{
	// Token: 0x17001296 RID: 4758
	// (get) Token: 0x0600FB8F RID: 64399
	// (set) Token: 0x0600FB90 RID: 64400
	Action OnConfirm { get; set; }

	// Token: 0x17001297 RID: 4759
	// (get) Token: 0x0600FB91 RID: 64401
	// (set) Token: 0x0600FB92 RID: 64402
	Action OnCancel { get; set; }
}
