using System;

// Token: 0x02001383 RID: 4995
public interface IMapTravelLevelData
{
	// Token: 0x17000B97 RID: 2967
	// (get) Token: 0x06008940 RID: 35136
	// (set) Token: 0x06008941 RID: 35137
	int Id { get; set; }

	// Token: 0x17000B98 RID: 2968
	// (get) Token: 0x06008942 RID: 35138
	// (set) Token: 0x06008943 RID: 35139
	int Level { get; set; }

	// Token: 0x17000B99 RID: 2969
	// (get) Token: 0x06008944 RID: 35140
	// (set) Token: 0x06008945 RID: 35141
	int AccumulateExp { get; set; }

	// Token: 0x17000B9A RID: 2970
	// (get) Token: 0x06008946 RID: 35142
	// (set) Token: 0x06008947 RID: 35143
	int TargetExp { get; set; }
}
