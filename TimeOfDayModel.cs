using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

// Token: 0x02002BBA RID: 11194
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class TimeOfDayModel : ModelBase<TimeOfDayModel>
{
	// Token: 0x17001D6A RID: 7530
	// (get) Token: 0x060164BF RID: 91327 RVA: 0x0062CB6A File Offset: 0x0062AD6A
	public TodDayTime GameTime
	{
		get
		{
			return this.GameTimeInternal;
		}
	}

	// Token: 0x060164C0 RID: 91328 RVA: 0x0062CB72 File Offset: 0x0062AD72
	public void SetTimeRunLockStateClient(bool state, bool needNotifyTs = true)
	{
		this.TimeRunLockStateClient = state;
		if (needNotifyTs)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.CsRequestLockTimeRunStateClient, state);
		}
	}

	// Token: 0x17001D6B RID: 7531
	// (get) Token: 0x060164C1 RID: 91329 RVA: 0x0062CB8F File Offset: 0x0062AD8F
	public bool TimeRunLockState
	{
		get
		{
			if (this.IsClientState == null || !this.IsClientState.Value)
			{
				return this.TimeRunLockStateServer;
			}
			return this.TimeRunLockStateClient;
		}
	}

	// Token: 0x060164C2 RID: 91330 RVA: 0x0062CBB8 File Offset: 0x0062ADB8
	public void SetTimeSyncLockStateClient(bool state, bool needNotifyTs = true)
	{
		this.TimeSyncLockStateClient = state;
		if (needNotifyTs)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.CsRequestLockTimeSyncLockStateClient, state);
		}
	}

	// Token: 0x17001D6C RID: 7532
	// (get) Token: 0x060164C3 RID: 91331 RVA: 0x0062CBD5 File Offset: 0x0062ADD5
	public bool TimeSynLockState
	{
		get
		{
			if (this.IsClientState == null || !this.IsClientState.Value)
			{
				return this.TimeSyncLockStateServer;
			}
			return this.TimeSyncLockStateClient;
		}
	}

	// Token: 0x060164C4 RID: 91332 RVA: 0x0062CBFE File Offset: 0x0062ADFE
	public double GetPassSceneTime()
	{
		return this.PassSceneTime;
	}

	// Token: 0x060164C5 RID: 91333 RVA: 0x0062CC06 File Offset: 0x0062AE06
	public void SetPassSceneTime(double time)
	{
		this.PassSceneTime = time;
	}

	// Token: 0x17001D6D RID: 7533
	// (get) Token: 0x060164C6 RID: 91334 RVA: 0x0062CC0F File Offset: 0x0062AE0F
	public float OldTimeScale
	{
		get
		{
			return this.OldTimeScaleInternal;
		}
	}

	// Token: 0x060164C7 RID: 91335 RVA: 0x0062CC17 File Offset: 0x0062AE17
	public void SetTimeScale(float value, bool needNotifyTs = true)
	{
		if (this.FreezeTimeScale)
		{
			return;
		}
		if (value < 0f)
		{
			return;
		}
		this.OldTimeScaleInternal = this.TimeScaleInternal;
		this.TimeScaleInternal = value;
		if (needNotifyTs)
		{
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.CsRequestSetTimeScale, value);
		}
	}

	// Token: 0x17001D6E RID: 7534
	// (get) Token: 0x060164C8 RID: 91336 RVA: 0x0062CC52 File Offset: 0x0062AE52
	public float TimeScale
	{
		get
		{
			return this.TimeScaleInternal;
		}
	}

	// Token: 0x060164C9 RID: 91337 RVA: 0x0062CC5A File Offset: 0x0062AE5A
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x060164CA RID: 91338 RVA: 0x0062CC5D File Offset: 0x0062AE5D
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x060164CB RID: 91339 RVA: 0x0062CC60 File Offset: 0x0062AE60
	public void CacheTimeRecords()
	{
		this.CurrentCachedSecondInternal = this.GameTime.Second;
		this.LastCacheRecordTime = Singleton<Time>.Instance.Now;
	}

	// Token: 0x060164CC RID: 91340 RVA: 0x0062CC83 File Offset: 0x0062AE83
	public bool CheckCanCacheRecord()
	{
		return this.LastCacheRecordTime == 0.0 || Singleton<Time>.Instance.Now - this.LastCacheRecordTime >= 120000.0;
	}

	// Token: 0x060164CD RID: 91341 RVA: 0x0062CCB8 File Offset: 0x0062AEB8
	public bool IsCurrentTimePassedNormally()
	{
		if (this.CurrentCachedSecondInternal == 0.0)
		{
			return this.GameTime.Second >= 86280.0;
		}
		if (this.GameTime.Second < 120.0)
		{
			return this.CurrentCachedSecondInternal >= 86280.0 + this.GameTime.Second || this.CurrentCachedSecondInternal <= this.GameTime.Second;
		}
		return this.GameTime.Second - this.CurrentCachedSecondInternal > 0.0 && this.GameTime.Second - this.CurrentCachedSecondInternal < 120.0;
	}

	// Token: 0x060164CE RID: 91342 RVA: 0x0062CD78 File Offset: 0x0062AF78
	public TimeOfDaySecondItemSt[] GetTimeOfDayShowData()
	{
		List<TimeOfDaySecondItemSt> list = new List<TimeOfDaySecondItemSt>();
		TimeOfDay? config = ConfigBase<TimeOfDayConfig>.Instance.GetConfig();
		int timePresetLength = config.Value.TimePresetLength;
		int num = 0;
		double second = this.GameTime.Second;
		IReadOnlyList<DaySelectPreset> dayTimeChangePresets = ConfigBase<TimeOfDayConfig>.Instance.GetDayTimeChangePresets();
		for (int i = 0; i < dayTimeChangePresets.Count; i++)
		{
			for (int j = 0; j < timePresetLength; j++)
			{
				DicIntString? dicIntString = config.Value.TimePreset(j);
				if (dayTimeChangePresets[i].ChangeDayNum != 0 || second <= (double)dicIntString.Value.Key)
				{
					list.Add(new TimeOfDaySecondItemSt
					{
						Id = num,
						ChangeDayIndex = i,
						SetTime = dicIntString.Value.Key,
						ShowName = ConfigMultiTextLang.GetLocalTextNew(dayTimeChangePresets[i].Title, null)
					});
					num++;
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x060164CF RID: 91343 RVA: 0x0062CE91 File Offset: 0x0062B091
	public void SetCurrentDay(double day)
	{
		double currentDay = this.CurrentDay;
		this.CurrentDay = day;
	}

	// Token: 0x060164D0 RID: 91344 RVA: 0x0062CEA3 File Offset: 0x0062B0A3
	public double GetCurrentDay()
	{
		return this.CurrentDay;
	}

	// Token: 0x060164D1 RID: 91345 RVA: 0x0062CEAC File Offset: 0x0062B0AC
	public void SetUseClientLockState(bool enable)
	{
		this.IsClientState = new bool?(enable);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.TimeOfDay;
		ELogAuthor author = ELogAuthor.FZX;
		string message = "使用客户端时间锁定状态";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("enable", enable);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0400AC91 RID: 44177
	private readonly TodDayTime GameTimeInternal = new TodDayTime();

	// Token: 0x0400AC92 RID: 44178
	private double LastCacheRecordTime;

	// Token: 0x0400AC93 RID: 44179
	private float TimeScaleInternal = 1f;

	// Token: 0x0400AC94 RID: 44180
	private float OldTimeScaleInternal = 1f;

	// Token: 0x0400AC95 RID: 44181
	public bool FreezeTimeScale;

	// Token: 0x0400AC96 RID: 44182
	[Nullable(2)]
	public string PlayerAccount;

	// Token: 0x0400AC97 RID: 44183
	[Nullable(2)]
	public TimeOfDaySecondItemSt CurrentSelectTimeItemSt;

	// Token: 0x0400AC98 RID: 44184
	private double CurrentCachedSecondInternal;

	// Token: 0x0400AC99 RID: 44185
	private double CurrentDay;

	// Token: 0x0400AC9A RID: 44186
	private double PassSceneTime;

	// Token: 0x0400AC9B RID: 44187
	private bool? IsClientState;

	// Token: 0x0400AC9C RID: 44188
	public bool TimeRunLockStateClient;

	// Token: 0x0400AC9D RID: 44189
	public bool TimeRunLockStateServer;

	// Token: 0x0400AC9E RID: 44190
	public bool TimeSyncLockStateClient;

	// Token: 0x0400AC9F RID: 44191
	public bool TimeSyncLockStateServer;
}
