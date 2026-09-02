using System;
using System.Runtime.CompilerServices;

// Token: 0x02002BB9 RID: 11193
[NullableContext(1)]
[Nullable(0)]
public class TodDayTime : IStaticVariableResetter
{
	// Token: 0x060164AA RID: 91306 RVA: 0x0062C8FF File Offset: 0x0062AAFF
	static TodDayTime()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TodDayTime.CreateStaticDefaultValue), new Action(TodDayTime.ResetStaticDefaultValue));
	}

	// Token: 0x17001D64 RID: 7524
	// (get) Token: 0x060164AB RID: 91307 RVA: 0x0062C91E File Offset: 0x0062AB1E
	private static double Rate
	{
		get
		{
			if (TodDayTime.RateInternal == 0.0)
			{
				TodDayTime.RateInternal = ConfigBase<TimeOfDayConfig>.Instance.GetRate();
			}
			return TodDayTime.RateInternal;
		}
	}

	// Token: 0x060164AC RID: 91308 RVA: 0x0062C944 File Offset: 0x0062AB44
	public static void CreateStaticDefaultValue()
	{
		TodDayTime.RateInternal = 0.0;
	}

	// Token: 0x060164AD RID: 91309 RVA: 0x0062C954 File Offset: 0x0062AB54
	public static void ResetStaticDefaultValue()
	{
		TodDayTime.RateInternal = 0.0;
	}

	// Token: 0x17001D65 RID: 7525
	// (get) Token: 0x060164AE RID: 91310 RVA: 0x0062C964 File Offset: 0x0062AB64
	// (set) Token: 0x060164AF RID: 91311 RVA: 0x0062C96C File Offset: 0x0062AB6C
	public double Second
	{
		get
		{
			return this.SecondInternal;
		}
		set
		{
			this.SecondInternal = TodDayTime.ConvertToOneDaySecond(value);
		}
	}

	// Token: 0x17001D66 RID: 7526
	// (get) Token: 0x060164B0 RID: 91312 RVA: 0x0062C97A File Offset: 0x0062AB7A
	public ETodDayState DayState
	{
		get
		{
			return ConfigBase<TimeOfDayConfig>.Instance.GetDayStateByGameTimeMinute(this.Minute);
		}
	}

	// Token: 0x17001D67 RID: 7527
	// (get) Token: 0x060164B1 RID: 91313 RVA: 0x0062C98C File Offset: 0x0062AB8C
	public double Hour
	{
		get
		{
			return this.Minute / 60.0;
		}
	}

	// Token: 0x17001D68 RID: 7528
	// (get) Token: 0x060164B2 RID: 91314 RVA: 0x0062C99E File Offset: 0x0062AB9E
	public double Minute
	{
		get
		{
			return this.Second / 60.0;
		}
	}

	// Token: 0x17001D69 RID: 7529
	// (get) Token: 0x060164B3 RID: 91315 RVA: 0x0062C9B0 File Offset: 0x0062ABB0
	public string HourMinuteString
	{
		get
		{
			return TodDayTime.ConvertToHourMinuteString(this.Second);
		}
	}

	// Token: 0x060164B4 RID: 91316 RVA: 0x0062C9C0 File Offset: 0x0062ABC0
	public static double ConvertFromRealTimeSecond(double realTimeSecond)
	{
		if (TodDayTime.Rate == 0.0)
		{
			Singleton<Log>.Instance.Error(ELogModule.TimeOfDay, ELogAuthor.TL, "获取时间流速比错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0.0;
		}
		return realTimeSecond * TodDayTime.Rate / 10000.0;
	}

	// Token: 0x060164B5 RID: 91317 RVA: 0x0062CA14 File Offset: 0x0062AC14
	public static ETodDayState ConvertToDayState(double second)
	{
		return ConfigBase<TimeOfDayConfig>.Instance.GetDayStateByGameTimeMinute(TodDayTime.ConvertToMinute(second));
	}

	// Token: 0x060164B6 RID: 91318 RVA: 0x0062CA26 File Offset: 0x0062AC26
	public static double ConvertToOneDaySecond(double second)
	{
		if (second < 0.0)
		{
			return 0.0;
		}
		return second % 86400.0;
	}

	// Token: 0x060164B7 RID: 91319 RVA: 0x0062CA4C File Offset: 0x0062AC4C
	public static string ConvertToHourMinuteString(double second)
	{
		double num = Math.Floor(second / 3600.0);
		double num2 = Math.Floor((second - num * 3600.0) / 60.0);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)num, "D2");
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)num2, "D2");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060164B8 RID: 91320 RVA: 0x0062CAC1 File Offset: 0x0062ACC1
	public static double ConvertToDay(double second)
	{
		return second / 86400.0;
	}

	// Token: 0x060164B9 RID: 91321 RVA: 0x0062CACE File Offset: 0x0062ACCE
	public static double ConvertToHour(double second)
	{
		return second / 3600.0;
	}

	// Token: 0x060164BA RID: 91322 RVA: 0x0062CADB File Offset: 0x0062ACDB
	public static double ConvertToMinute(double second)
	{
		return second / 60.0;
	}

	// Token: 0x060164BB RID: 91323 RVA: 0x0062CAE8 File Offset: 0x0062ACE8
	public static double ConvertFromMinute(double minute)
	{
		return minute * 60.0;
	}

	// Token: 0x060164BC RID: 91324 RVA: 0x0062CAF5 File Offset: 0x0062ACF5
	public static double ConvertFromHourMinute(double hour, double minute)
	{
		return hour * 3600.0 + minute * 60.0;
	}

	// Token: 0x060164BD RID: 91325 RVA: 0x0062CB10 File Offset: 0x0062AD10
	public static bool CheckInMinuteSpan(double minute, TTodTimeSpan minuteSpan)
	{
		if (minute < 0.0 || minute > 1440.0)
		{
			return false;
		}
		int startTime = minuteSpan.StartTime;
		int endTime = minuteSpan.EndTime;
		if (startTime < endTime)
		{
			if (minute >= (double)startTime && minute < (double)endTime)
			{
				return true;
			}
		}
		else if (minute >= (double)startTime || minute < (double)endTime)
		{
			return true;
		}
		return false;
	}

	// Token: 0x0400AC8F RID: 44175
	private double SecondInternal;

	// Token: 0x0400AC90 RID: 44176
	private static double RateInternal;
}
