using System;
using System.Runtime.CompilerServices;

// Token: 0x02003125 RID: 12581
[NullableContext(2)]
[Nullable(0)]
public class MultiSkillInfo
{
	// Token: 0x17002352 RID: 9042
	// (get) Token: 0x0601A0C4 RID: 106692 RVA: 0x007A1984 File Offset: 0x0079FB84
	public double RemainingStartTime
	{
		get
		{
			if (this.MultiSkillStartStamp != 0.0)
			{
				return (this.MultiSkillStartStamp - Singleton<Time>.Instance.FlowTime) * Singleton<TimeUtil>.Instance.Millisecond;
			}
			return 0.0;
		}
	}

	// Token: 0x17002353 RID: 9043
	// (get) Token: 0x0601A0C5 RID: 106693 RVA: 0x007A19BD File Offset: 0x0079FBBD
	public double RemainingStopTime
	{
		get
		{
			if (this.MultiSkillStopStamp != 0.0)
			{
				return (this.MultiSkillStopStamp - Singleton<Time>.Instance.FlowTime) * Singleton<TimeUtil>.Instance.Millisecond;
			}
			return 0.0;
		}
	}

	// Token: 0x0400D0E5 RID: 53477
	public int FirstSkillId;

	// Token: 0x0400D0E6 RID: 53478
	public int CurSkillId;

	// Token: 0x0400D0E7 RID: 53479
	public int? NextSkillId;

	// Token: 0x0400D0E8 RID: 53480
	public float StartTime;

	// Token: 0x0400D0E9 RID: 53481
	public double MultiSkillStartStamp;

	// Token: 0x0400D0EA RID: 53482
	public float StopTime;

	// Token: 0x0400D0EB RID: 53483
	public double MultiSkillStopStamp;

	// Token: 0x0400D0EC RID: 53484
	public bool IsReset;

	// Token: 0x0400D0ED RID: 53485
	public bool IsResetOnChangeRole;

	// Token: 0x0400D0EE RID: 53486
	public TimerHandle MultiSkillStartTimer;

	// Token: 0x0400D0EF RID: 53487
	public TimerHandle MultiSkillStopTimer;
}
