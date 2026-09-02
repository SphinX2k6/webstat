using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnrealEngine;

// Token: 0x02000E66 RID: 3686
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TimeUtil : Singleton<TimeUtil>, ITickable
{
	// Token: 0x060058D2 RID: 22738 RVA: 0x00108850 File Offset: 0x00106A50
	public void Init(TextConfig textConfig)
	{
		this.TextConfigInternal = textConfig;
	}

	// Token: 0x060058D3 RID: 22739 RVA: 0x00108859 File Offset: 0x00106A59
	public double GetServerTimeStamp()
	{
		return Singleton<Time>.Instance.ServerTimeStamp;
	}

	// Token: 0x060058D4 RID: 22740 RVA: 0x00108865 File Offset: 0x00106A65
	public double GetServerStopTimeStamp()
	{
		return Singleton<Time>.Instance.ServerFlowTimeStamp;
	}

	// Token: 0x060058D5 RID: 22741 RVA: 0x00108871 File Offset: 0x00106A71
	public double GetServerTime()
	{
		return Singleton<Time>.Instance.ServerTimeStamp * this.Millisecond;
	}

	// Token: 0x060058D6 RID: 22742 RVA: 0x00108884 File Offset: 0x00106A84
	public void SetServerTimeStamp(double serverTimeStamp)
	{
		Singleton<Time>.Instance.SetServerTimeStamp(serverTimeStamp);
		this.InitNextDayTimeStamp();
	}

	// Token: 0x060058D7 RID: 22743 RVA: 0x00108897 File Offset: 0x00106A97
	public void Tick(float delta)
	{
		if (this.NextDayTimeStamp > 0.0 && Singleton<Time>.Instance.ServerTimeStamp >= this.NextDayTimeStamp)
		{
			this.InitNextDayTimeStamp();
		}
	}

	// Token: 0x060058D8 RID: 22744 RVA: 0x001088C4 File Offset: 0x00106AC4
	public void InitNextDayTimeStamp()
	{
		DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)Singleton<Time>.Instance.ServerTimeStamp).UtcDateTime;
		if (dateTime.Hour >= this.CrossDayHour)
		{
			dateTime = dateTime.AddDays(1.0);
		}
		DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, this.CrossDayHour, 0, 0, 0, 0, TimeSpan.Zero);
		this.NextDayTimeStamp = (double)dateTimeOffset.ToUnixTimeSeconds() + new Random().NextDouble();
	}

	// Token: 0x060058D9 RID: 22745 RVA: 0x0010894E File Offset: 0x00106B4E
	public double GetNextDayTimeStamp()
	{
		return this.NextDayTimeStamp;
	}

	// Token: 0x060058DA RID: 22746 RVA: 0x00108956 File Offset: 0x00106B56
	public double SetTimeMillisecond(double time)
	{
		return time * (double)this.InverseMillisecond;
	}

	// Token: 0x060058DB RID: 22747 RVA: 0x00108961 File Offset: 0x00106B61
	public double SetTimeSecond(double time)
	{
		return time / (double)this.InverseMillisecond;
	}

	// Token: 0x060058DC RID: 22748 RVA: 0x0010896C File Offset: 0x00106B6C
	public string DateFormat(DateTime date)
	{
		return date.ToString("yyyy.MM.dd-HH.mm.ss:fff");
	}

	// Token: 0x060058DD RID: 22749 RVA: 0x0010897A File Offset: 0x00106B7A
	public string DateFormat2(DateTime date)
	{
		return date.ToString("yyyy-MM-dd HH:mm:ss");
	}

	// Token: 0x060058DE RID: 22750 RVA: 0x00108988 File Offset: 0x00106B88
	public string DateFormat3(DateTime date)
	{
		return date.ToString("yyyy/MM/dd HH:mm");
	}

	// Token: 0x060058DF RID: 22751 RVA: 0x00108996 File Offset: 0x00106B96
	public string DateFormat4(DateTime date)
	{
		return date.ToString("yyyy/MM/dd");
	}

	// Token: 0x060058E0 RID: 22752 RVA: 0x001089A4 File Offset: 0x00106BA4
	public string DateFormat4String(double timeStampSecond)
	{
		DateTime localDateTime = DateTimeOffset.FromUnixTimeSeconds((long)timeStampSecond).LocalDateTime;
		return this.DateFormat4(localDateTime);
	}

	// Token: 0x060058E1 RID: 22753 RVA: 0x001089C8 File Offset: 0x00106BC8
	public string DateFormat5(DateTime date)
	{
		return date.ToString("yyyy-MM-dd HH:mm:ss");
	}

	// Token: 0x060058E2 RID: 22754 RVA: 0x001089D8 File Offset: 0x00106BD8
	public string DateFormat6String(double timeStampSecond)
	{
		return DateTimeOffset.FromUnixTimeMilliseconds((long)timeStampSecond).LocalDateTime.ToString("MM.dd");
	}

	// Token: 0x060058E3 RID: 22755 RVA: 0x00108A04 File Offset: 0x00106C04
	public string DateFormat7String(double timeStampSecond)
	{
		return DateTimeOffset.FromUnixTimeMilliseconds((long)timeStampSecond).LocalDateTime.ToString("HH:mm");
	}

	// Token: 0x060058E4 RID: 22756 RVA: 0x00108A2D File Offset: 0x00106C2D
	public string DateFormat8(in DateTime dateTime, string suffixStr)
	{
		return dateTime.ToString("yyyy-MM-dd HH:mm:ss") + suffixStr;
	}

	// Token: 0x060058E5 RID: 22757 RVA: 0x00108A40 File Offset: 0x00106C40
	public string DateFormat9String(double timeStampSecond)
	{
		return DateTimeOffset.FromUnixTimeSeconds((long)timeStampSecond).LocalDateTime.ToString("yyyy.MM.dd");
	}

	// Token: 0x060058E6 RID: 22758 RVA: 0x00108A69 File Offset: 0x00106C69
	public double GetServerUnixTime()
	{
		return (double)((long)Singleton<Time>.Instance.ServerTimeStamp / (long)this.InverseMillisecond);
	}

	// Token: 0x060058E7 RID: 22759 RVA: 0x00108A80 File Offset: 0x00106C80
	public string DateFormatString(double timeStampSecond)
	{
		return DateTimeOffset.FromUnixTimeSeconds((long)timeStampSecond).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
	}

	// Token: 0x060058E8 RID: 22760 RVA: 0x00108AAC File Offset: 0x00106CAC
	public string DateFormatString2(double timeStampSecond)
	{
		return DateTimeOffset.FromUnixTimeSeconds((long)timeStampSecond).LocalDateTime.ToString("yyyyMMddHHmmss");
	}

	// Token: 0x060058E9 RID: 22761 RVA: 0x00108AD8 File Offset: 0x00106CD8
	public string GetTimeString(double second)
	{
		if (second < 0.0)
		{
			return "";
		}
		double num = second % this.Minute;
		string str = (num < 10.0) ? ("0" + num.ToString()) : num.ToString();
		double num2 = Math.Floor(second / this.Minute);
		return ((num2 < 10.0) ? ("0" + num2.ToString()) : num2.ToString()) + ":" + str;
	}

	// Token: 0x060058EA RID: 22762 RVA: 0x00108B68 File Offset: 0x00106D68
	public DateTime GetDataFromTimeStamp(double timeStampSecond)
	{
		return DateTimeOffset.FromUnixTimeSeconds((long)timeStampSecond).LocalDateTime;
	}

	// Token: 0x060058EB RID: 22763 RVA: 0x00108B84 File Offset: 0x00106D84
	public int CalculateMailDayGapByServerTime(double timeStampSeconds)
	{
		DateTime localDateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)this.GetServerTimeStamp()).LocalDateTime;
		DateTime localDateTime2 = DateTimeOffset.FromUnixTimeSeconds((long)timeStampSeconds).LocalDateTime;
		DateTime d = new DateTime(localDateTime.Year, localDateTime.Month, localDateTime.Day);
		DateTime d2 = new DateTime(localDateTime2.Year, localDateTime2.Month, localDateTime2.Day);
		return Math.Abs((int)Math.Round((d - d2).TotalDays));
	}

	// Token: 0x060058EC RID: 22764 RVA: 0x00108C08 File Offset: 0x00106E08
	public int CalculateDayGapBetweenNow(double timeStamp, bool isFuture)
	{
		double num = Singleton<Time>.Instance.ServerTimeStamp / (double)this.InverseMillisecond;
		DateTime now = DateTime.Now;
		DateTime localDateTime = DateTimeOffset.FromUnixTimeSeconds((long)timeStamp).LocalDateTime;
		double num2;
		if ((num2 = (isFuture ? (timeStamp - num) : (num - timeStamp)) / 86400.0) < 2.0)
		{
			if (isFuture)
			{
				num2 = (double)((now.Month < localDateTime.Month) ? 1 : (localDateTime.Day - now.Day));
			}
			else
			{
				num2 = (double)((now.Month > localDateTime.Month) ? 1 : (now.Day - localDateTime.Day));
			}
		}
		return int.Parse(num2.ToString("0"));
	}

	// Token: 0x060058ED RID: 22765 RVA: 0x00108CCC File Offset: 0x00106ECC
	public int CalculateDayTimeStampGapBetweenNow(double timeStamp, bool isFuture)
	{
		double num = Singleton<Time>.Instance.ServerTimeStamp / (double)this.InverseMillisecond;
		return (int)Math.Floor((isFuture ? (timeStamp - num) : (num - timeStamp)) / 86400.0);
	}

	// Token: 0x060058EE RID: 22766 RVA: 0x00108D14 File Offset: 0x00106F14
	public double CalculateHourGapBetweenNow(double timeStamp, bool isFuture)
	{
		double num = this.GetServerTimeStamp() / (double)this.InverseMillisecond;
		return (isFuture ? (timeStamp - num) : (num - timeStamp)) / 3600.0;
	}

	// Token: 0x060058EF RID: 22767 RVA: 0x00108D54 File Offset: 0x00106F54
	public double CalculateMinuteGapBetweenNow(double timeStamp, bool isFuture)
	{
		double num = Singleton<Time>.Instance.ServerTimeStamp / (double)this.InverseMillisecond;
		return (isFuture ? (timeStamp - num) : (num - timeStamp)) / 60.0;
	}

	// Token: 0x060058F0 RID: 22768 RVA: 0x00108D98 File Offset: 0x00106F98
	public string GetCoolDown(double leftTime)
	{
		string text = "";
		double num = Math.Floor(leftTime);
		if (num < 10.0)
		{
			string str = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num);
			text = str + defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			string str2 = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<double>(num);
			text = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return text;
	}

	// Token: 0x060058F1 RID: 22769 RVA: 0x00108E0C File Offset: 0x0010700C
	public float GetHoursFloat()
	{
		DateTime utcDateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)Singleton<Time>.Instance.ServerTimeStamp).UtcDateTime;
		double hour = (double)utcDateTime.Hour;
		int minute = utcDateTime.Minute;
		int second = utcDateTime.Second;
		return (float)(hour + (double)minute / this.Minute + (double)second / this.Hour);
	}

	// Token: 0x060058F2 RID: 22770 RVA: 0x00108E5F File Offset: 0x0010705F
	public bool IsExceededServerTime(long time)
	{
		return (double)time >= this.GetServerTime();
	}

	// Token: 0x060058F3 RID: 22771 RVA: 0x00108E70 File Offset: 0x00107070
	[NullableContext(2)]
	public CommonDefine.IRemainTime CalculateRemainingTime(double time, CommonDefine.ETimeType minTimeType = CommonDefine.ETimeType.Minute)
	{
		if (time <= 0.0)
		{
			return null;
		}
		CommonDefine.ETimeType etimeType = CommonDefine.ETimeType.Day;
		CommonDefine.RemainTime remainTime = new CommonDefine.RemainTime
		{
			TimeValue = 0,
			RemainingTime = time + this.TimeDeviation,
			TextId = CommonDefine.remainTimeTextId[minTimeType]
		};
		while (etimeType >= minTimeType)
		{
			ValueTuple<int, int>? valueTuple = this.RemainTimeFunction[etimeType](time);
			if (valueTuple != null)
			{
				remainTime.TimeValue = valueTuple.Value.Item1;
				remainTime.TextId = CommonDefine.remainTimeTextId[etimeType];
				remainTime.RemainingTime = (double)valueTuple.Value.Item2 + this.TimeDeviation;
				return remainTime;
			}
			etimeType--;
		}
		return remainTime;
	}

	// Token: 0x060058F4 RID: 22772 RVA: 0x00108F20 File Offset: 0x00107120
	private CommonDefine.ICountDown GetCountDownInfoByType(double time, CommonDefine.ETimeTextType textType, CommonDefine.ETimeType? inStartType = null, CommonDefine.ETimeType? inEndType = null)
	{
		if (time <= 0.0)
		{
			return new CommonDefine.CountDown
			{
				CountDownText = null,
				RemainingTime = this.TimeDeviation
			};
		}
		StringBuilder stringBuilder = new StringBuilder();
		double num = time;
		CommonDefine.ETimeType etimeType = inStartType.GetValueOrDefault(CommonDefine.ETimeType.Day);
		CommonDefine.ETimeType valueOrDefault = inEndType.GetValueOrDefault(CommonDefine.ETimeType.Minute);
		Dictionary<CommonDefine.ETimeType, string> dictionary;
		if (textType != CommonDefine.ETimeTextType.TimeType1)
		{
			if (textType != CommonDefine.ETimeTextType.TimeType2)
			{
				dictionary = CommonDefine.remainTimeTextId;
			}
			else
			{
				dictionary = CommonDefine.remainTimeTextIdFormat2;
			}
		}
		else
		{
			dictionary = CommonDefine.remainTimeTextId;
		}
		while (etimeType >= valueOrDefault)
		{
			ValueTuple<int, int>? valueTuple = this.RemainTimeFunction[etimeType](num);
			string value = StringUtils.Format(this.TextConfigInternal.GetTextById(dictionary[etimeType]), new string[]
			{
				((double)((valueTuple != null) ? valueTuple.GetValueOrDefault().Item1 : 0)).ToString()
			});
			int? num2 = (valueTuple != null) ? new int?(valueTuple.GetValueOrDefault().Item2) : null;
			num = ((num2 != null) ? ((double)num2.GetValueOrDefault()) : num);
			stringBuilder.Append(value);
			etimeType--;
		}
		return new CommonDefine.CountDown
		{
			CountDownText = stringBuilder.ToString(),
			RemainingTime = num + this.TimeDeviation
		};
	}

	// Token: 0x060058F5 RID: 22773 RVA: 0x00109065 File Offset: 0x00107265
	public CommonDefine.ICountDown GetCountDownData(double time, CommonDefine.ETimeType? inStartType = null, CommonDefine.ETimeType? inEndType = null)
	{
		return this.GetCountDownInfoByType(time, CommonDefine.ETimeTextType.TimeType1, inStartType, inEndType);
	}

	// Token: 0x060058F6 RID: 22774 RVA: 0x00109071 File Offset: 0x00107271
	public CommonDefine.ICountDown GetCountDownDataFormat2(double time, CommonDefine.ETimeType? inStartType = null, CommonDefine.ETimeType? inEndType = null)
	{
		return this.GetCountDownInfoByType(time, CommonDefine.ETimeTextType.TimeType2, inStartType, inEndType);
	}

	// Token: 0x060058F7 RID: 22775 RVA: 0x00109080 File Offset: 0x00107280
	public CommonDefine.ICountDown GetRemainTimeDataFormat(double remainTime)
	{
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> timeTypeData = this.GetTimeTypeData(remainTime);
		if (timeTypeData.Item1 == CommonDefine.ETimeType.Second)
		{
			return new CommonDefine.CountDown
			{
				CountDownText = ConfigBase<TextConfig>.Instance.GetTextById("NotEnoughOneHour"),
				RemainingTime = remainTime
			};
		}
		return this.GetCountDownDataFormat2(remainTime, new CommonDefine.ETimeType?(timeTypeData.Item1), new CommonDefine.ETimeType?(timeTypeData.Item2));
	}

	// Token: 0x060058F8 RID: 22776 RVA: 0x001090DC File Offset: 0x001072DC
	[NullableContext(0)]
	public ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> GetTimeTypeData(double remainTime)
	{
		if (remainTime > 86400.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Hour);
		}
		if (remainTime > 3600.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Hour);
		}
		return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Second, CommonDefine.ETimeType.Second);
	}

	// Token: 0x060058F9 RID: 22777 RVA: 0x00109110 File Offset: 0x00107310
	public CommonDefine.ICountDown GetRemainTimeDataFormat3(double remainTime)
	{
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Second, CommonDefine.ETimeType.Second);
		if (remainTime > 86400.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Hour);
		}
		else if (remainTime > 3600.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Minute);
		}
		else if (remainTime > 60.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Second);
		}
		return this.GetCountDownInfoByType(remainTime, CommonDefine.ETimeTextType.TimeType2, new CommonDefine.ETimeType?(valueTuple.Item1), new CommonDefine.ETimeType?(valueTuple.Item2));
	}

	// Token: 0x060058FA RID: 22778 RVA: 0x00109184 File Offset: 0x00107384
	public CommonDefine.ICountDown GetRemainTimeDataFormat4(double remainTime)
	{
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Minute);
		if (remainTime < 60.0)
		{
			return this.GetCountDownInfoByType(60.0, CommonDefine.ETimeTextType.TimeType2, new CommonDefine.ETimeType?(valueTuple.Item1), new CommonDefine.ETimeType?(valueTuple.Item2));
		}
		return this.GetCountDownInfoByType(remainTime, CommonDefine.ETimeTextType.TimeType2, new CommonDefine.ETimeType?(valueTuple.Item1), new CommonDefine.ETimeType?(valueTuple.Item2));
	}

	// Token: 0x060058FB RID: 22779 RVA: 0x001091EC File Offset: 0x001073EC
	public string GetRemainTimeDataFormat5(double cdRemainTime)
	{
		double num = Math.Min(Math.Max(0.0, cdRemainTime), this.Hour);
		double num2 = Math.Floor(num / this.Minute);
		double num3 = Math.Floor(num % this.Minute);
		double num4 = Math.Floor((num - Math.Floor(num)) * 100.0);
		string value = num2.ToString().PadLeft(2, '0');
		string value2 = num3.ToString().PadLeft(2, '0');
		string value3 = num4.ToString().PadLeft(2, '0');
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(value3);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060058FC RID: 22780 RVA: 0x001092BC File Offset: 0x001074BC
	public string GetRemainTimeDataFormat6(double cdRemainTime)
	{
		double num = Math.Max(0.0, cdRemainTime);
		double num2 = Math.Floor(num % this.Hour / this.Minute);
		double num3 = Math.Floor(num % this.Minute);
		string str = num2.ToString().PadLeft(2, '0');
		string str2 = num3.ToString().PadLeft(2, '0');
		return str + ":" + str2;
	}

	// Token: 0x060058FD RID: 22781 RVA: 0x00109324 File Offset: 0x00107524
	public bool IsInTimeSpan(double startTime, double endTime)
	{
		double serverTime = this.GetServerTime();
		return serverTime >= startTime && serverTime <= endTime;
	}

	// Token: 0x060058FE RID: 22782 RVA: 0x00109344 File Offset: 0x00107544
	public double GetCurrentCrossDayStamp()
	{
		DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)Singleton<Time>.Instance.ServerTimeStamp).UtcDateTime;
		if (dateTime.Hour < this.CrossDayHour)
		{
			dateTime = dateTime.AddDays(-1.0);
		}
		dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, this.CrossDayHour, 0, 0);
		return (double)(dateTime.Ticks / 10000L);
	}

	// Token: 0x060058FF RID: 22783 RVA: 0x001093C0 File Offset: 0x001075C0
	public string GetTimeDataFormat(double secondTime)
	{
		new StringBuilder().Append(((int)Math.Floor(secondTime / 60.0)).ToString().PadLeft(2, '0'));
		object obj2;
		object obj = obj2;
		obj.Append(':');
		obj.Append(((int)(secondTime % 60.0)).ToString().PadLeft(2, '0'));
		return obj.ToString();
	}

	// Token: 0x06005900 RID: 22784 RVA: 0x0010942C File Offset: 0x0010762C
	public string GetTimeDataFormatWithHour(double secondTime)
	{
		double num = Math.Max(0.0, secondTime);
		double num2 = Math.Floor(num / this.Hour);
		double num3 = Math.Floor(num % this.Hour / this.Minute);
		double num4 = Math.Floor(num % this.Minute);
		string value = num2.ToString().PadLeft(2, '0');
		string value2 = num3.ToString().PadLeft(2, '0');
		string value3 = num4.ToString().PadLeft(2, '0');
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(value3);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06005901 RID: 22785 RVA: 0x001094EC File Offset: 0x001076EC
	public FTimespan GetTimeZoneOffset()
	{
		FDateTime b = UKismetMathLibrary.UtcNow();
		FTimespan ftimespan = UKismetMathLibrary.Subtract_DateTimeDateTime(UKismetMathLibrary.Now(), b);
		if (UKismetMathLibrary.GetSeconds(ftimespan) < 0)
		{
			FDateTime a = UKismetMathLibrary.Now();
			b = UKismetMathLibrary.UtcNow();
			ftimespan = UKismetMathLibrary.Subtract_DateTimeDateTime(a, b);
		}
		return ftimespan;
	}

	// Token: 0x06005902 RID: 22786 RVA: 0x00109528 File Offset: 0x00107728
	public string GetTimeZoneOffsetString()
	{
		FTimespan timeZoneOffset = this.GetTimeZoneOffset();
		int hours = UKismetMathLibrary.GetHours(timeZoneOffset);
		int minutes = UKismetMathLibrary.GetMinutes(timeZoneOffset);
		string result;
		if (hours >= 0)
		{
			string text;
			if (minutes != 0)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(hours);
				defaultInterpolatedStringHandler.AppendLiteral(":");
				defaultInterpolatedStringHandler.AppendFormatted<int>(minutes);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(hours);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			result = text;
		}
		else
		{
			int value = -hours;
			int value2 = -minutes;
			string text2;
			if (minutes != 0)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral(":");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
				text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			result = text2;
		}
		return result;
	}

	// Token: 0x06005903 RID: 22787 RVA: 0x00109620 File Offset: 0x00107820
	public void LogTimeZoneOffset()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.TimeUtil;
		ELogAuthor author = ELogAuthor.CFT;
		string message = "本地时间和UTC时间的偏移";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", this.GetTimeZoneOffsetString());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06005904 RID: 22788 RVA: 0x0010965C File Offset: 0x0010785C
	public CommonDefine.ICountDown GetRemainTimeDataFormat7(double remainTime)
	{
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Second, CommonDefine.ETimeType.Second);
		if (remainTime >= 86400.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Day);
		}
		else if (remainTime >= 3600.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Hour);
		}
		else if (remainTime >= 60.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Minute);
		}
		return Singleton<TimeUtil>.Instance.GetCountDownInfoByType(remainTime, CommonDefine.ETimeTextType.TimeType2, new CommonDefine.ETimeType?(valueTuple.Item1), new CommonDefine.ETimeType?(valueTuple.Item2));
	}

	// Token: 0x06005905 RID: 22789 RVA: 0x001096D8 File Offset: 0x001078D8
	public CommonDefine.ICountDown GetRemainTimeDataFormat8(double remainTime)
	{
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Minute);
		if (remainTime >= 86400.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Day);
		}
		else if (remainTime >= 3600.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Hour);
		}
		return this.GetCountDownInfoByType(remainTime, CommonDefine.ETimeTextType.TimeType2, new CommonDefine.ETimeType?(valueTuple.Item1), new CommonDefine.ETimeType?(valueTuple.Item2));
	}

	// Token: 0x06005906 RID: 22790 RVA: 0x00109738 File Offset: 0x00107938
	public CommonDefine.ICountDown GetRemainTimeDataFormat9(double remainTime)
	{
		if (remainTime < 60.0)
		{
			return new CommonDefine.CountDown
			{
				CountDownText = ConfigBase<TextConfig>.Instance.GetTextById("NotEnoughOneMinute"),
				RemainingTime = remainTime
			};
		}
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Second, CommonDefine.ETimeType.Second);
		if (remainTime > 86400.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Hour);
		}
		else if (remainTime > 3600.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Minute);
		}
		else if (remainTime > 60.0)
		{
			valueTuple = new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Second);
		}
		return this.GetCountDownInfoByType(remainTime, CommonDefine.ETimeTextType.TimeType2, new CommonDefine.ETimeType?(valueTuple.Item1), new CommonDefine.ETimeType?(valueTuple.Item2));
	}

	// Token: 0x06005907 RID: 22791 RVA: 0x001097DC File Offset: 0x001079DC
	public string GetCountDownTextFormat10(double remainTime)
	{
		if (remainTime >= 86400.0)
		{
			int num = (int)Math.Floor(remainTime / 86400.0);
			string id = CommonDefine.remainTimeTextIdFormat3[CommonDefine.ETimeType.Day];
			return StringUtils.Format(this.TextConfigInternal.GetTextById(id), new string[]
			{
				num.ToString()
			});
		}
		if (remainTime >= 3600.0)
		{
			int num2 = (int)Math.Floor(remainTime / 3600.0);
			string id2 = CommonDefine.remainTimeTextIdFormat3[CommonDefine.ETimeType.Hour];
			return StringUtils.Format(this.TextConfigInternal.GetTextById(id2), new string[]
			{
				num2.ToString()
			});
		}
		if (remainTime >= 60.0)
		{
			int num3 = (int)Math.Floor(remainTime / 60.0);
			string id3 = CommonDefine.remainTimeTextIdFormat3[CommonDefine.ETimeType.Minute];
			return StringUtils.Format(this.TextConfigInternal.GetTextById(id3), new string[]
			{
				num3.ToString()
			});
		}
		int num4 = (int)Math.Floor((remainTime < 0.0) ? 0.0 : remainTime);
		string id4 = CommonDefine.remainTimeTextIdFormat3[CommonDefine.ETimeType.Second];
		return StringUtils.Format(this.TextConfigInternal.GetTextById(id4), new string[]
		{
			num4.ToString()
		});
	}

	// Token: 0x06005908 RID: 22792 RVA: 0x00109920 File Offset: 0x00107B20
	public TimeUtil()
	{
		Dictionary<CommonDefine.ETimeType, Func<double, ValueTuple<int, int>?>> dictionary = new Dictionary<CommonDefine.ETimeType, Func<double, ValueTuple<int, int>?>>();
		dictionary[CommonDefine.ETimeType.Second] = delegate(double remainTime)
		{
			if (remainTime > 0.0)
			{
				int num = (int)Math.Floor(remainTime);
				return new ValueTuple<int, int>?(new ValueTuple<int, int>(num, num));
			}
			return null;
		};
		dictionary[CommonDefine.ETimeType.Minute] = delegate(double remainTime)
		{
			if (remainTime >= 60.0)
			{
				double num = remainTime % 60.0;
				return new ValueTuple<int, int>?(new ValueTuple<int, int>((int)((remainTime - num) / 60.0), (int)num));
			}
			return null;
		};
		dictionary[CommonDefine.ETimeType.Hour] = delegate(double remainTime)
		{
			if (remainTime >= 3600.0)
			{
				double num = remainTime % 3600.0;
				return new ValueTuple<int, int>?(new ValueTuple<int, int>((int)((remainTime - num) / 3600.0), (int)num));
			}
			return null;
		};
		dictionary[CommonDefine.ETimeType.Day] = delegate(double remainTime)
		{
			if (remainTime >= 86400.0)
			{
				double num = remainTime % 86400.0;
				return new ValueTuple<int, int>?(new ValueTuple<int, int>((int)((remainTime - num) / 86400.0), (int)num));
			}
			return null;
		};
		this.RemainTimeFunction = dictionary;
		base..ctor();
	}

	// Token: 0x04002949 RID: 10569
	public readonly double OneDayHourCount = 24.0;

	// Token: 0x0400294A RID: 10570
	public readonly double Hour = 3600.0;

	// Token: 0x0400294B RID: 10571
	public readonly double Minute = 60.0;

	// Token: 0x0400294C RID: 10572
	public readonly int OneDaySeconds = 86400;

	// Token: 0x0400294D RID: 10573
	public readonly double Millisecond = 0.001;

	// Token: 0x0400294E RID: 10574
	public readonly int InverseMillisecond = 1000;

	// Token: 0x0400294F RID: 10575
	public readonly int CrossDayHour = 4;

	// Token: 0x04002950 RID: 10576
	private double NextDayTimeStamp;

	// Token: 0x04002951 RID: 10577
	public readonly double TimeDeviation = 0.1;

	// Token: 0x04002952 RID: 10578
	[Nullable(2)]
	private TextConfig TextConfigInternal;

	// Token: 0x04002953 RID: 10579
	[Nullable(new byte[]
	{
		1,
		1,
		0
	})]
	private readonly Dictionary<CommonDefine.ETimeType, Func<double, ValueTuple<int, int>?>> RemainTimeFunction;
}
