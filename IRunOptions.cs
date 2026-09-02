using System;

// Token: 0x020034C9 RID: 13513
public interface IRunOptions
{
	// Token: 0x170026C1 RID: 9921
	// (get) Token: 0x0601C8E8 RID: 116968
	// (set) Token: 0x0601C8E9 RID: 116969
	int? Concurrency { get; set; }

	// Token: 0x170026C2 RID: 9922
	// (get) Token: 0x0601C8EA RID: 116970
	// (set) Token: 0x0601C8EB RID: 116971
	bool? ContinueEvenFail { get; set; }
}
