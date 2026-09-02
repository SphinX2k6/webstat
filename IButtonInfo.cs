using System;
using System.Runtime.CompilerServices;

// Token: 0x02001997 RID: 6551
[NullableContext(1)]
public interface IButtonInfo
{
	// Token: 0x17000F50 RID: 3920
	// (get) Token: 0x0600BC12 RID: 48146
	// (set) Token: 0x0600BC13 RID: 48147
	Action<int> Function { get; set; }

	// Token: 0x17000F51 RID: 3921
	// (get) Token: 0x0600BC14 RID: 48148
	// (set) Token: 0x0600BC15 RID: 48149
	string Text { get; set; }

	// Token: 0x17000F52 RID: 3922
	// (get) Token: 0x0600BC16 RID: 48150
	// (set) Token: 0x0600BC17 RID: 48151
	int Index { get; set; }

	// Token: 0x17000F53 RID: 3923
	// (get) Token: 0x0600BC18 RID: 48152
	// (set) Token: 0x0600BC19 RID: 48153
	ERedDotName? RedDotName { get; set; }

	// Token: 0x17000F54 RID: 3924
	// (get) Token: 0x0600BC1A RID: 48154
	// (set) Token: 0x0600BC1B RID: 48155
	int? RedDotId { get; set; }
}
