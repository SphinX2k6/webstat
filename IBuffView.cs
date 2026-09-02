using System;

// Token: 0x020014CD RID: 5325
public interface IBuffView
{
	// Token: 0x17000C93 RID: 3219
	// (get) Token: 0x060094CB RID: 38091
	// (set) Token: 0x060094CC RID: 38092
	int BuffId { get; set; }

	// Token: 0x17000C94 RID: 3220
	// (get) Token: 0x060094CD RID: 38093
	// (set) Token: 0x060094CE RID: 38094
	EPinballBuffType BuffType { get; set; }

	// Token: 0x17000C95 RID: 3221
	// (get) Token: 0x060094CF RID: 38095
	// (set) Token: 0x060094D0 RID: 38096
	int BuffCount { get; set; }

	// Token: 0x17000C96 RID: 3222
	// (get) Token: 0x060094D1 RID: 38097
	// (set) Token: 0x060094D2 RID: 38098
	int Sort { get; set; }
}
