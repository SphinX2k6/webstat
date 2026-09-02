using System;
using System.Runtime.CompilerServices;

// Token: 0x02001115 RID: 4373
[NullableContext(1)]
public interface IPlayCardInfo
{
	// Token: 0x17000934 RID: 2356
	// (get) Token: 0x0600719B RID: 29083
	// (set) Token: 0x0600719C RID: 29084
	int Value { get; set; }

	// Token: 0x17000935 RID: 2357
	// (get) Token: 0x0600719D RID: 29085
	// (set) Token: 0x0600719E RID: 29086
	int[] CardIdList { get; set; }
}
