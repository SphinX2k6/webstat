using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BD9 RID: 3033
public class EffectPerformanceStatistics
{
	// Token: 0x040004C6 RID: 1222
	public long? Frame;

	// Token: 0x040004C7 RID: 1223
	public double StartTime = -1.0;

	// Token: 0x040004C8 RID: 1224
	public double EndTime = -1.0;

	// Token: 0x040004C9 RID: 1225
	public int ParticleCount;

	// Token: 0x040004CA RID: 1226
	public int EmitterCount;

	// Token: 0x040004CB RID: 1227
	[Nullable(1)]
	public string Type = "None";
}
