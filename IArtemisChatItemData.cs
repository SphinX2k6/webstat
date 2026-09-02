using System;
using System.Runtime.CompilerServices;

// Token: 0x020011AE RID: 4526
[NullableContext(1)]
public interface IArtemisChatItemData
{
	// Token: 0x17000A07 RID: 2567
	// (get) Token: 0x0600772A RID: 30506
	string Content { get; }

	// Token: 0x17000A08 RID: 2568
	// (get) Token: 0x0600772B RID: 30507
	string PicturePath { get; }

	// Token: 0x17000A09 RID: 2569
	// (get) Token: 0x0600772C RID: 30508
	bool IsLock { get; }

	// Token: 0x17000A0A RID: 2570
	// (get) Token: 0x0600772D RID: 30509
	bool IsShowEffect { get; }
}
