using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020021E9 RID: 8681
public class LordGymEntranceInfo
{
	// Token: 0x06010601 RID: 67073 RVA: 0x00479E2C File Offset: 0x0047802C
	[NullableContext(1)]
	public void Phrase(Aki.Protocol.LordGymEntranceInfo info)
	{
		this.Id = info.Id;
		this.EffectBeginTime = (double)Singleton<MathUtils>.Instance.LongToNumber(info.EffectBeginTime) / 1000.0;
		this.EffectEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(info.EffectEndTime) / 1000.0;
	}

	// Token: 0x04008125 RID: 33061
	public int Id;

	// Token: 0x04008126 RID: 33062
	public double EffectBeginTime;

	// Token: 0x04008127 RID: 33063
	public double EffectEndTime;
}
