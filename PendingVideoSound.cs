using System;
using Aki.Config;

// Token: 0x02002CEA RID: 11498
public class PendingVideoSound
{
	// Token: 0x060172CA RID: 94922 RVA: 0x0066AA5E File Offset: 0x00668C5E
	public PendingVideoSound(VideoSound soundConf, double startMomentMs)
	{
		this.SoundConf = soundConf;
		this.StartMomentMs = startMomentMs;
	}

	// Token: 0x0400B23A RID: 45626
	public VideoSound SoundConf;

	// Token: 0x0400B23B RID: 45627
	public double StartMomentMs;
}
