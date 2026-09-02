using System;
using System.Runtime.CompilerServices;

// Token: 0x02001116 RID: 4374
[NullableContext(1)]
[Nullable(0)]
public class PlayCardInfo : IPlayCardInfo
{
	// Token: 0x17000936 RID: 2358
	// (get) Token: 0x0600719F RID: 29087 RVA: 0x001DAD81 File Offset: 0x001D8F81
	// (set) Token: 0x060071A0 RID: 29088 RVA: 0x001DAD89 File Offset: 0x001D8F89
	public int Value { get; set; }

	// Token: 0x17000937 RID: 2359
	// (get) Token: 0x060071A1 RID: 29089 RVA: 0x001DAD92 File Offset: 0x001D8F92
	// (set) Token: 0x060071A2 RID: 29090 RVA: 0x001DAD9A File Offset: 0x001D8F9A
	public int[] CardIdList { get; set; } = Array.Empty<int>();
}
