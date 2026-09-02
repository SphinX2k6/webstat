using System;

// Token: 0x02001869 RID: 6249
public interface IHandler
{
	// Token: 0x17000E88 RID: 3720
	// (get) Token: 0x0600B308 RID: 45832
	EHandlerType Type { get; }

	// Token: 0x17000E89 RID: 3721
	// (get) Token: 0x0600B309 RID: 45833
	// (set) Token: 0x0600B30A RID: 45834
	bool? IsSync { get; set; }

	// Token: 0x17000E8A RID: 3722
	// (get) Token: 0x0600B30B RID: 45835
	// (set) Token: 0x0600B30C RID: 45836
	bool? IsCache { get; set; }
}
