using System;
using System.Runtime.CompilerServices;

// Token: 0x02002335 RID: 9013
[NullableContext(1)]
[Nullable(0)]
public class OnlineApplyData
{
	// Token: 0x060112FF RID: 70399 RVA: 0x004B8924 File Offset: 0x004B6B24
	public OnlineApplyData(string name, int playerId, double refuseTimestamp, int headId, int level, string thirdOnlineId)
	{
		this.NameInternal = name;
		this.PlayerIdInternal = playerId;
		this.RefuseTimestampInternal = refuseTimestamp;
		this.HeadIdInternal = headId;
		this.LevelInternal = level;
		this.ThirdOnlineId = thirdOnlineId;
	}

	// Token: 0x1700155B RID: 5467
	// (get) Token: 0x06011300 RID: 70400 RVA: 0x004B8964 File Offset: 0x004B6B64
	public double ApplyTimeLeftTime
	{
		get
		{
			return this.RefuseTimestampInternal - Singleton<TimeUtil>.Instance.GetServerTime();
		}
	}

	// Token: 0x1700155C RID: 5468
	// (get) Token: 0x06011301 RID: 70401 RVA: 0x004B8977 File Offset: 0x004B6B77
	public int PlayerId
	{
		get
		{
			return this.PlayerIdInternal;
		}
	}

	// Token: 0x1700155D RID: 5469
	// (get) Token: 0x06011302 RID: 70402 RVA: 0x004B897F File Offset: 0x004B6B7F
	public double RefuseTimestamp
	{
		get
		{
			return this.RefuseTimestampInternal;
		}
	}

	// Token: 0x1700155E RID: 5470
	// (get) Token: 0x06011303 RID: 70403 RVA: 0x004B8987 File Offset: 0x004B6B87
	public int Level
	{
		get
		{
			return this.LevelInternal;
		}
	}

	// Token: 0x1700155F RID: 5471
	// (get) Token: 0x06011304 RID: 70404 RVA: 0x004B898F File Offset: 0x004B6B8F
	public string Name
	{
		get
		{
			return this.NameInternal;
		}
	}

	// Token: 0x17001560 RID: 5472
	// (get) Token: 0x06011305 RID: 70405 RVA: 0x004B8997 File Offset: 0x004B6B97
	public int HeadId
	{
		get
		{
			return this.HeadIdInternal;
		}
	}

	// Token: 0x04008713 RID: 34579
	private readonly int PlayerIdInternal;

	// Token: 0x04008714 RID: 34580
	private readonly double RefuseTimestampInternal;

	// Token: 0x04008715 RID: 34581
	private readonly string NameInternal;

	// Token: 0x04008716 RID: 34582
	private readonly int LevelInternal;

	// Token: 0x04008717 RID: 34583
	private readonly int HeadIdInternal;

	// Token: 0x04008718 RID: 34584
	public string ThirdOnlineId = "";
}
