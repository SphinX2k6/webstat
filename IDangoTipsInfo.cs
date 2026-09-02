using System;
using System.Runtime.CompilerServices;

// Token: 0x020012EE RID: 4846
[NullableContext(1)]
public interface IDangoTipsInfo
{
	// Token: 0x17000B13 RID: 2835
	// (get) Token: 0x06008338 RID: 33592
	// (set) Token: 0x06008339 RID: 33593
	string Text { get; set; }

	// Token: 0x17000B14 RID: 2836
	// (get) Token: 0x0600833A RID: 33594
	// (set) Token: 0x0600833B RID: 33595
	[Nullable(2)]
	string Icon { [NullableContext(2)] get; [NullableContext(2)] set; }
}
