using System;

// Token: 0x02000F52 RID: 3922
public interface IGenerate
{
	// Token: 0x17000753 RID: 1875
	// (get) Token: 0x06006284 RID: 25220
	// (set) Token: 0x06006285 RID: 25221
	int BornTrack { get; set; }

	// Token: 0x17000754 RID: 1876
	// (get) Token: 0x06006286 RID: 25222
	// (set) Token: 0x06006287 RID: 25223
	float BornDistance { get; set; }

	// Token: 0x17000755 RID: 1877
	// (get) Token: 0x06006288 RID: 25224
	// (set) Token: 0x06006289 RID: 25225
	EGenerateType GenerateType { get; set; }

	// Token: 0x17000756 RID: 1878
	// (get) Token: 0x0600628A RID: 25226
	// (set) Token: 0x0600628B RID: 25227
	int RefreshId { get; set; }

	// Token: 0x17000757 RID: 1879
	// (get) Token: 0x0600628C RID: 25228
	// (set) Token: 0x0600628D RID: 25229
	int BuffGateBornGroup { get; set; }
}
