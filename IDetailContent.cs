using System;
using System.Runtime.CompilerServices;

// Token: 0x020024C1 RID: 9409
[NullableContext(1)]
public interface IDetailContent
{
	// Token: 0x06012471 RID: 74865
	void SetUiActive(bool active);

	// Token: 0x06012472 RID: 74866
	void Refresh(PhantomInteractDetailViewModel viewModel);

	// Token: 0x06012473 RID: 74867
	void SetScrollListenerActive(bool active);
}
