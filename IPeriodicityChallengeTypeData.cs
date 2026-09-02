using System;
using System.Runtime.CompilerServices;

// Token: 0x02001765 RID: 5989
[NullableContext(1)]
public interface IPeriodicityChallengeTypeData
{
	// Token: 0x17000DD8 RID: 3544
	// (get) Token: 0x0600A847 RID: 43079
	// (set) Token: 0x0600A848 RID: 43080
	float LeftTime { get; set; }

	// Token: 0x17000DD9 RID: 3545
	// (get) Token: 0x0600A849 RID: 43081
	// (set) Token: 0x0600A84A RID: 43082
	int CurrentNum { get; set; }

	// Token: 0x17000DDA RID: 3546
	// (get) Token: 0x0600A84B RID: 43083
	// (set) Token: 0x0600A84C RID: 43084
	int TotalNum { get; set; }

	// Token: 0x17000DDB RID: 3547
	// (get) Token: 0x0600A84D RID: 43085
	// (set) Token: 0x0600A84E RID: 43086
	bool IsFinish { get; set; }

	// Token: 0x17000DDC RID: 3548
	// (get) Token: 0x0600A84F RID: 43087
	// (set) Token: 0x0600A850 RID: 43088
	bool RedPoint { get; set; }

	// Token: 0x17000DDD RID: 3549
	// (get) Token: 0x0600A851 RID: 43089
	// (set) Token: 0x0600A852 RID: 43090
	string SubText { get; set; }
}
