using System;
using System.Runtime.CompilerServices;

// Token: 0x02002447 RID: 9287
[NullableContext(1)]
public interface IPhantomArenaStartViewData
{
	// Token: 0x17001696 RID: 5782
	// (get) Token: 0x06011F57 RID: 73559
	// (set) Token: 0x06011F58 RID: 73560
	string ContentTextId { get; set; }

	// Token: 0x17001697 RID: 5783
	// (get) Token: 0x06011F59 RID: 73561
	// (set) Token: 0x06011F5A RID: 73562
	bool IsOwn { get; set; }

	// Token: 0x17001698 RID: 5784
	// (get) Token: 0x06011F5B RID: 73563
	// (set) Token: 0x06011F5C RID: 73564
	[Nullable(2)]
	Action Callback { [NullableContext(2)] get; [NullableContext(2)] set; }
}
