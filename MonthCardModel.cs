using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020023A5 RID: 9125
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MonthCardModel : ModelBase<MonthCardModel>
{
	// Token: 0x06011955 RID: 72021 RVA: 0x004D240C File Offset: 0x004D060C
	protected override bool OnInit()
	{
		MonthCardContent? config = ConfigBase<MonthCardConfig>.Instance.GetConfig(1);
		this.LocalOnceReward = new TItem?(new TItem(new InventoryDefine.GetItemData(config.Value.ItemId, 0), config.Value.Count));
		this.LocalDailyReward = new TItem?(new TItem(new InventoryDefine.GetItemData(ConfigCommonParamById.GetIntConfig("MonthCardDailyItemId").Value, 0), ConfigCommonParamById.GetIntConfig("MonthCardDailyItemCount").Value));
		this.RedDotRefreshType = ConfigCommonParamById.GetIntConfig("MonthCardRedDotRefreshTime").Value;
		return true;
	}

	// Token: 0x06011956 RID: 72022 RVA: 0x004D24AC File Offset: 0x004D06AC
	public int GetRemainDays()
	{
		return this.MonthCardRemainDays;
	}

	// Token: 0x06011957 RID: 72023 RVA: 0x004D24B4 File Offset: 0x004D06B4
	public void SetRemainDays(int value)
	{
		this.MonthCardRemainDays = value;
	}

	// Token: 0x06011958 RID: 72024 RVA: 0x004D24C0 File Offset: 0x004D06C0
	public string GetRemainDayText([Nullable(2)] string colorTag = null)
	{
		int remainDays = ModelBase<MonthCardModel>.Instance.GetRemainDays();
		if (remainDays < 0)
		{
			return "";
		}
		if (remainDays == 0)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("MonthCardLeftTimeText_2");
			if (colorTag != null)
			{
				return StringUtils.Format(textById, new string[]
				{
					"<color=#" + colorTag + ">1</color>"
				});
			}
			return StringUtils.Format(textById, new string[]
			{
				"1"
			});
		}
		else
		{
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("MonthCardLeftTimeText_1");
			if (colorTag != null)
			{
				string inString = textById2;
				string[] array = new string[1];
				int num = 0;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#");
				defaultInterpolatedStringHandler.AppendFormatted(colorTag);
				defaultInterpolatedStringHandler.AppendLiteral(">");
				defaultInterpolatedStringHandler.AppendFormatted(remainDays.ToString());
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				array[num] = defaultInterpolatedStringHandler.ToStringAndClear();
				return StringUtils.Format(inString, array);
			}
			return StringUtils.Format(textById2, new string[]
			{
				remainDays.ToString()
			});
		}
	}

	// Token: 0x06011959 RID: 72025 RVA: 0x004D25B4 File Offset: 0x004D07B4
	public bool IsRemainDayInMaxLimit()
	{
		int? intConfig = ConfigCommonParamById.GetIntConfig("MonthCardMaxDays");
		int remainDays = this.GetRemainDays();
		int? num = intConfig;
		return remainDays <= num.GetValueOrDefault() & num != null;
	}

	// Token: 0x0601195A RID: 72026 RVA: 0x004D25E8 File Offset: 0x004D07E8
	public bool CheckMonthCardIfCanBuy()
	{
		int remainDays = ModelBase<MonthCardModel>.Instance.GetRemainDays();
		int? intConfig = ConfigCommonParamById.GetIntConfig("MonthCardMaxDays");
		int? num = intConfig;
		return !(remainDays > num.GetValueOrDefault() & num != null);
	}

	// Token: 0x0601195B RID: 72027 RVA: 0x004D2624 File Offset: 0x004D0824
	public bool GetPayButtonRedDotState()
	{
		if (this.NextShowPayButtonRedDotTime == null)
		{
			this.NextShowPayButtonRedDotTime = new long?(LocalStorage.GetPlayer<long>(ELocalStoragePlayerKey.MonthCardNextShowRedDotTime, 0L));
		}
		double serverTimeStamp = Singleton<Time>.Instance.ServerTimeStamp;
		long? nextShowPayButtonRedDotTime = this.NextShowPayButtonRedDotTime;
		double? num = (nextShowPayButtonRedDotTime != null) ? new double?((double)nextShowPayButtonRedDotTime.GetValueOrDefault()) : null;
		double num2 = serverTimeStamp;
		return (num.GetValueOrDefault() < num2 & num != null) && this.GetRemainDays() < 0;
	}

	// Token: 0x0601195C RID: 72028 RVA: 0x004D26A8 File Offset: 0x004D08A8
	public void RefreshNextShowPayButtonRedDotTime()
	{
		if (this.RedDotRefreshType == 1)
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Singleton<Time>.Instance.ServerTimeStamp);
			dateTime = dateTime.AddMonths(1);
			dateTime = new DateTime(dateTime.Year, dateTime.Month, 1, 4, 0, 0, DateTimeKind.Utc);
			double totalMilliseconds = dateTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
			long? nextShowPayButtonRedDotTime = this.NextShowPayButtonRedDotTime;
			long num = (long)totalMilliseconds;
			if (!(nextShowPayButtonRedDotTime.GetValueOrDefault() == num & nextShowPayButtonRedDotTime != null))
			{
				this.NextShowPayButtonRedDotTime = new long?((long)totalMilliseconds);
				LocalStorage.SetPlayer<long>(ELocalStoragePlayerKey.MonthCardNextShowRedDotTime, (long)totalMilliseconds);
			}
		}
		else if (this.RedDotRefreshType == 2)
		{
			DateTime dateTime2 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Singleton<Time>.Instance.ServerTimeStamp);
			dateTime2 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, 4, 0, 0, DateTimeKind.Utc);
			int num2 = (int)(((DayOfWeek)8 - (int)dateTime2.DayOfWeek) % (DayOfWeek)7);
			if (num2 == 0)
			{
				num2 = 7;
			}
			double totalMilliseconds2 = dateTime2.AddDays((double)num2).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
			long? nextShowPayButtonRedDotTime = this.NextShowPayButtonRedDotTime;
			long num = (long)totalMilliseconds2;
			if (!(nextShowPayButtonRedDotTime.GetValueOrDefault() == num & nextShowPayButtonRedDotTime != null))
			{
				this.NextShowPayButtonRedDotTime = new long?((long)totalMilliseconds2);
				LocalStorage.SetPlayer<long>(ELocalStoragePlayerKey.MonthCardNextShowRedDotTime, (long)totalMilliseconds2);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.PayShopGoodsBuy);
	}

	// Token: 0x0601195D RID: 72029 RVA: 0x004D2844 File Offset: 0x004D0A44
	protected override bool OnClear()
	{
		this.CanShowDailyRewardView = false;
		return true;
	}

	// Token: 0x0400898F RID: 35215
	private int MonthCardRemainDays = -1;

	// Token: 0x04008990 RID: 35216
	public bool CanShowDailyRewardView;

	// Token: 0x04008991 RID: 35217
	public TItem? ServerOnceReward;

	// Token: 0x04008992 RID: 35218
	public TItem? ServerDailyReward;

	// Token: 0x04008993 RID: 35219
	public TItem? LocalOnceReward;

	// Token: 0x04008994 RID: 35220
	public TItem? LocalDailyReward;

	// Token: 0x04008995 RID: 35221
	public long? NextShowPayButtonRedDotTime;

	// Token: 0x04008996 RID: 35222
	public int RedDotRefreshType = 1;
}
