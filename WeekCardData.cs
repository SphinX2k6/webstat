using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.PayShop;

// Token: 0x020023F7 RID: 9207
[NullableContext(1)]
[Nullable(0)]
public class WeekCardData
{
	// Token: 0x06011D17 RID: 72983 RVA: 0x004E7194 File Offset: 0x004E5394
	public WeekCardData(WeekCardInfo info)
	{
		this.Update(info);
	}

	// Token: 0x06011D18 RID: 72984 RVA: 0x004E71B0 File Offset: 0x004E53B0
	public void Update(WeekCardInfo info)
	{
		this.WeekCardIdInner = info.WeekCardId;
		this.DaysInner = info.Days;
		this.BuyTimeStampInner = info.BuyTimeStamp;
		this.EndTimeStampInner = info.EndTimeStamp;
		this.WeekCardContentInfosInner = new List<WeekCardContentInfo>(info.WeekCardContentInfos);
	}

	// Token: 0x17001672 RID: 5746
	// (get) Token: 0x06011D19 RID: 72985 RVA: 0x004E71FE File Offset: 0x004E53FE
	public int WeekCardId
	{
		get
		{
			return this.WeekCardIdInner;
		}
	}

	// Token: 0x17001673 RID: 5747
	// (get) Token: 0x06011D1A RID: 72986 RVA: 0x004E7206 File Offset: 0x004E5406
	public int Days
	{
		get
		{
			return this.DaysInner;
		}
	}

	// Token: 0x17001674 RID: 5748
	// (get) Token: 0x06011D1B RID: 72987 RVA: 0x004E720E File Offset: 0x004E540E
	public long BuyTimeStamp
	{
		get
		{
			return this.BuyTimeStampInner;
		}
	}

	// Token: 0x17001675 RID: 5749
	// (get) Token: 0x06011D1C RID: 72988 RVA: 0x004E7216 File Offset: 0x004E5416
	public long EndTimeStamp
	{
		get
		{
			return this.EndTimeStampInner;
		}
	}

	// Token: 0x06011D1D RID: 72989 RVA: 0x004E721E File Offset: 0x004E541E
	public WeekCardContentInfo GetWeekCardContentInfo(int index)
	{
		return this.WeekCardContentInfosInner[index];
	}

	// Token: 0x06011D1E RID: 72990 RVA: 0x004E722C File Offset: 0x004E542C
	public List<WeekCardContentInfo> GetAllWeekCardContentInfos()
	{
		return this.WeekCardContentInfosInner;
	}

	// Token: 0x06011D1F RID: 72991 RVA: 0x004E7234 File Offset: 0x004E5434
	[NullableContext(2)]
	public PayPackageData GetWeekCardGiftData()
	{
		WeekCard? config = ConfigBase<WeekCardConfig>.Instance.GetConfig(this.WeekCardIdInner);
		if (config == null)
		{
			return null;
		}
		return ModelBase<PayGiftModel>.Instance.GetPayGiftDataByType(EPayGiftType.WeekCard).FirstOrDefault((PayPackageData g) => g.Id == config.Value.PayGiftId);
	}

	// Token: 0x06011D20 RID: 72992 RVA: 0x004E7288 File Offset: 0x004E5488
	public long GetActivityBeginTime()
	{
		PayPackageData weekCardGiftData = this.GetWeekCardGiftData();
		if (weekCardGiftData == null)
		{
			return 0L;
		}
		return weekCardGiftData.BeginTime;
	}

	// Token: 0x06011D21 RID: 72993 RVA: 0x004E729C File Offset: 0x004E549C
	public long GetActivityEndTime()
	{
		PayPackageData weekCardGiftData = this.GetWeekCardGiftData();
		if (weekCardGiftData == null)
		{
			return 0L;
		}
		return weekCardGiftData.EndTime;
	}

	// Token: 0x06011D22 RID: 72994 RVA: 0x004E72B0 File Offset: 0x004E54B0
	public bool GetIsWeekCardBuyOpen()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return (double)this.GetActivityEndTime() > serverTime && serverTime >= (double)this.GetActivityBeginTime();
	}

	// Token: 0x06011D23 RID: 72995 RVA: 0x004E72E1 File Offset: 0x004E54E1
	public bool GetHasBuyWeekCard()
	{
		return this.EndTimeStampInner > 0L;
	}

	// Token: 0x06011D24 RID: 72996 RVA: 0x004E72ED File Offset: 0x004E54ED
	public bool GetIsWeekCardInRewardStage()
	{
		return this.GetHasBuyWeekCard() && Singleton<TimeUtil>.Instance.SetTimeSecond((double)this.EndTimeStampInner) > Singleton<TimeUtil>.Instance.GetServerTime();
	}

	// Token: 0x06011D25 RID: 72997 RVA: 0x004E7318 File Offset: 0x004E5518
	public bool HasRewardUnReceive()
	{
		if (!this.GetIsWeekCardInRewardStage())
		{
			return false;
		}
		using (List<WeekCardContentInfo>.Enumerator enumerator = this.WeekCardContentInfosInner.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == 1)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06011D26 RID: 72998 RVA: 0x004E737C File Offset: 0x004E557C
	public bool GetWeekCardRedDotState()
	{
		if (!this.HasRewardUnReceive())
		{
			PayPackageData weekCardGiftData = this.GetWeekCardGiftData();
			bool? flag;
			if (weekCardGiftData == null)
			{
				flag = null;
			}
			else
			{
				PayShopGoods payShopGoods = weekCardGiftData.GetPayShopGoods();
				flag = ((payShopGoods != null) ? new bool?(payShopGoods.GetIfNeedRemind()) : null);
			}
			bool? flag2 = flag;
			return flag2.GetValueOrDefault();
		}
		return true;
	}

	// Token: 0x06011D27 RID: 72999 RVA: 0x004E73CE File Offset: 0x004E55CE
	public bool GetWeekCardIsOpen()
	{
		if (this.GetHasBuyWeekCard())
		{
			return this.GetIsWeekCardInRewardStage();
		}
		return this.GetIsWeekCardBuyOpen();
	}

	// Token: 0x04008B62 RID: 35682
	private int WeekCardIdInner;

	// Token: 0x04008B63 RID: 35683
	private int DaysInner;

	// Token: 0x04008B64 RID: 35684
	private long BuyTimeStampInner;

	// Token: 0x04008B65 RID: 35685
	private long EndTimeStampInner;

	// Token: 0x04008B66 RID: 35686
	private List<WeekCardContentInfo> WeekCardContentInfosInner = new List<WeekCardContentInfo>();
}
