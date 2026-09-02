using System;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;

// Token: 0x02000054 RID: 84
[Nullable(new byte[]
{
	0,
	1
})]
public class Time : Singleton<Time>
{
	// Token: 0x17000019 RID: 25
	// (get) Token: 0x06000191 RID: 401 RVA: 0x00009F36 File Offset: 0x00008136
	public double ServerTimeStamp
	{
		get
		{
			return KuroTime.GetMilliseconds64() + this.ServerTimeStampOffsetInternal;
		}
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00009F44 File Offset: 0x00008144
	public void SetServerTimeStamp(double serverTimeStampMs)
	{
		double num = serverTimeStampMs + (double)(Singleton<NetInfo>.Instance.RttMs / 2f) - KuroTime.GetMilliseconds64();
		this.ServerTimeStampOffsetInternal = num;
		if (this.LastServerTime == 0.0)
		{
			this.LastServerTime = num;
		}
	}

	// Token: 0x06000193 RID: 403 RVA: 0x00009F8A File Offset: 0x0000818A
	public void SetServerFlowTimeStamp(double flowTimeStampMs)
	{
		this.ServerFlowTimeStampOffsetInternal = flowTimeStampMs + (double)(Singleton<NetInfo>.Instance.RttMs / 2f) - this.FlowTime;
	}

	// Token: 0x06000194 RID: 404 RVA: 0x00009FAC File Offset: 0x000081AC
	public void SyncTime(double serverTimeStampMs, double flowTimeStampMs, double serverCombatTimeOffsetMs, double serverStopTimeOffsetMs)
	{
		this.SetServerTimeStamp(serverTimeStampMs);
		this.SetServerTimeOffset(serverTimeStampMs - this.Now);
		this.SetServerStopTimeOffset(serverStopTimeOffsetMs);
		this.SetServerFlowTimeStamp(flowTimeStampMs);
		this.ServerCombatTimeOffsetInternal = serverCombatTimeOffsetMs;
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000195 RID: 405 RVA: 0x00009FD9 File Offset: 0x000081D9
	public float TimeDilation
	{
		get
		{
			return this.WorldTimeDilationInternal;
		}
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x06000196 RID: 406 RVA: 0x00009FE1 File Offset: 0x000081E1
	public float FlowTimeDilation
	{
		get
		{
			return this.FlowTimeDilationInternal;
		}
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x06000197 RID: 407 RVA: 0x00009FE9 File Offset: 0x000081E9
	public double ServerStopTimeStamp
	{
		get
		{
			return this.ServerStopTimeStampOffsetInner + this.WorldTime + (double)(Singleton<NetInfo>.Instance.RttMs / 2f);
		}
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000198 RID: 408 RVA: 0x0000A00A File Offset: 0x0000820A
	public float InverseSelfCenteredTimeDilation
	{
		get
		{
			return this.InverseSelfCenteredTimeDilationInternal;
		}
	}

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x06000199 RID: 409 RVA: 0x0000A012 File Offset: 0x00008212
	public double ServerFlowTimeStamp
	{
		get
		{
			return this.ServerFlowTimeStampOffsetInternal + this.FlowTime + (double)(Singleton<NetInfo>.Instance.RttMs / 2f);
		}
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x0600019A RID: 410 RVA: 0x0000A033 File Offset: 0x00008233
	public double ServerCombatStopTime
	{
		get
		{
			return Math.Floor(this.ServerCombatTimeOffsetInternal + this.FlowTime + (double)(Singleton<NetInfo>.Instance.RttMs / 2f));
		}
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x0600019B RID: 411 RVA: 0x0000A059 File Offset: 0x00008259
	public double CombatServerTime
	{
		get
		{
			return (double)((long)Math.Floor(this.ServerTimeOffsetInternal + this.Now + (double)(Singleton<NetInfo>.Instance.RttMs / 2f)));
		}
	}

	// Token: 0x0600019C RID: 412 RVA: 0x0000A081 File Offset: 0x00008281
	public void SetServerTimeOffset(double serverTimeOffsetMs)
	{
		this.ServerTimeOffsetInternal = serverTimeOffsetMs;
	}

	// Token: 0x0600019D RID: 413 RVA: 0x0000A08A File Offset: 0x0000828A
	public void SetServerStopTimeOffset(double serverStopTimeOffsetMs)
	{
		this.ServerStopTimeStampOffsetInner = serverStopTimeOffsetMs;
	}

	// Token: 0x0600019E RID: 414 RVA: 0x0000A093 File Offset: 0x00008293
	public void SetTimeDilation(float timeDilation)
	{
		this.WorldTimeDilationInternal = timeDilation;
	}

	// Token: 0x0600019F RID: 415 RVA: 0x0000A09C File Offset: 0x0000829C
	public void SetFlowTimeDilation(float timeDilation)
	{
		this.FlowTimeDilationInternal = timeDilation;
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x0000A0A5 File Offset: 0x000082A5
	public void SetInverseSelfCenteredTimeDilation(float timeDilation)
	{
		this.InverseSelfCenteredTimeDilationInternal = timeDilation;
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x060001A1 RID: 417 RVA: 0x0000A0AE File Offset: 0x000082AE
	public float DeltaTime
	{
		get
		{
			return this.DeltaTimeMsInternal;
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000A0B6 File Offset: 0x000082B6
	public float DeltaTimeSeconds
	{
		get
		{
			return this.DeltaTimeMsInternal * 0.001f;
		}
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x060001A3 RID: 419 RVA: 0x0000A0C4 File Offset: 0x000082C4
	public int Frame
	{
		get
		{
			return this.FrameInternal;
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x060001A4 RID: 420 RVA: 0x0000A0CC File Offset: 0x000082CC
	public double Now
	{
		get
		{
			return this.FrameNowInternal;
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x060001A5 RID: 421 RVA: 0x0000A0D4 File Offset: 0x000082D4
	public double NowSeconds
	{
		get
		{
			return this.FrameNowInternal * 0.0010000000474974513;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000A0E6 File Offset: 0x000082E6
	public double PlayerTime
	{
		get
		{
			return this.FramePlayerTimeInternal;
		}
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000A0EE File Offset: 0x000082EE
	public double PlayerTimeSeconds
	{
		get
		{
			return this.FramePlayerTimeInternal * 0.0010000000474974513;
		}
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x060001A8 RID: 424 RVA: 0x0000A100 File Offset: 0x00008300
	public double WorldTime
	{
		get
		{
			return this.FrameWorldTimeInternal;
		}
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x060001A9 RID: 425 RVA: 0x0000A108 File Offset: 0x00008308
	public double WorldTimeSeconds
	{
		get
		{
			return this.FrameWorldTimeInternal * 0.0010000000474974513;
		}
	}

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x060001AA RID: 426 RVA: 0x0000A11A File Offset: 0x0000831A
	public double PlayerWorldTime
	{
		get
		{
			return this.FramePlayerWorldTimeInternal;
		}
	}

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x060001AB RID: 427 RVA: 0x0000A122 File Offset: 0x00008322
	public double PlayerWorldTimeSeconds
	{
		get
		{
			return this.FramePlayerWorldTimeInternal * 0.0010000000474974513;
		}
	}

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x060001AC RID: 428 RVA: 0x0000A134 File Offset: 0x00008334
	public double FlowTime
	{
		get
		{
			return this.FrameFlowTimeInternal;
		}
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x060001AD RID: 429 RVA: 0x0000A13C File Offset: 0x0000833C
	public double SystemNow
	{
		get
		{
			return this.SystemNowInternal;
		}
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x060001AE RID: 430 RVA: 0x0000A144 File Offset: 0x00008344
	public double SystemNowSeconds
	{
		get
		{
			return this.SystemNowInternal * 0.0010000000474974513;
		}
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x060001AF RID: 431 RVA: 0x0000A156 File Offset: 0x00008356
	public bool IsAfterPrePhysicTick
	{
		get
		{
			return this.AfterTickFrameInternal == this.Frame;
		}
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x0000A166 File Offset: 0x00008366
	public void AfterTickPriority1(float delta)
	{
		this.AfterTickFrameInternal = this.FrameInternal;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x0000A174 File Offset: 0x00008374
	public void Initialize()
	{
		this.FrameInternal = 0;
		this.FrameNowInternal = 0.0;
		this.FrameWorldTimeInternal = 0.0;
		this.FrameFlowTimeInternal = 0.0;
		this.DeltaTimeMsInternal = 0f;
		this.SystemNowInternal = 0.0;
		this.SystemStart = (double)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		this.OriginTimeDilation = 1f;
		this.WorldTimeDilationInternal = 1f;
		this.FlowTimeDilationInternal = 1f;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x0000A204 File Offset: 0x00008404
	public void Tick(float delta)
	{
		this.DeltaTimeMsInternal = delta;
		this.FrameInternal++;
		this.FrameNowInternal += (double)delta;
		this.FramePlayerTimeInternal += (double)delta * (double)this.InverseSelfCenteredTimeDilationInternal;
		this.FrameWorldTimeInternal += (double)delta * (double)this.WorldTimeDilationInternal;
		this.FramePlayerWorldTimeInternal += (double)delta * (double)this.WorldTimeDilationInternal * (double)this.InverseSelfCenteredTimeDilationInternal;
		this.FrameFlowTimeInternal += (double)delta * (double)this.WorldTimeDilationInternal * (double)this.FlowTimeDilationInternal;
		this.SystemNowInternal = (double)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - this.SystemStart;
	}

	// Token: 0x04000178 RID: 376
	private const float MsToSecond = 0.001f;

	// Token: 0x04000179 RID: 377
	private int FrameInternal;

	// Token: 0x0400017A RID: 378
	private double FrameNowInternal;

	// Token: 0x0400017B RID: 379
	private double FramePlayerTimeInternal;

	// Token: 0x0400017C RID: 380
	private double FrameWorldTimeInternal;

	// Token: 0x0400017D RID: 381
	private double FramePlayerWorldTimeInternal;

	// Token: 0x0400017E RID: 382
	private double FrameFlowTimeInternal;

	// Token: 0x0400017F RID: 383
	private float DeltaTimeMsInternal;

	// Token: 0x04000180 RID: 384
	private double SystemNowInternal;

	// Token: 0x04000181 RID: 385
	private double SystemStart;

	// Token: 0x04000182 RID: 386
	private double ServerTimeStampOffsetInternal;

	// Token: 0x04000183 RID: 387
	private double ServerFlowTimeStampOffsetInternal;

	// Token: 0x04000184 RID: 388
	private double ServerStopTimeStampOffsetInner;

	// Token: 0x04000185 RID: 389
	private double ServerTimeOffsetInternal;

	// Token: 0x04000186 RID: 390
	private double ServerCombatTimeOffsetInternal;

	// Token: 0x04000187 RID: 391
	private float WorldTimeDilationInternal = 1f;

	// Token: 0x04000188 RID: 392
	private float FlowTimeDilationInternal = 1f;

	// Token: 0x04000189 RID: 393
	private float InverseSelfCenteredTimeDilationInternal = 1f;

	// Token: 0x0400018A RID: 394
	public float OriginTimeDilation = 1f;

	// Token: 0x0400018B RID: 395
	public int LastPauseTimeFrame;

	// Token: 0x0400018C RID: 396
	public int LastResumeTimeFrame;

	// Token: 0x0400018D RID: 397
	public double LastServerTime;

	// Token: 0x0400018E RID: 398
	private int AfterTickFrameInternal;
}
