using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.PayShop;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002406 RID: 9222
[NullableContext(2)]
[Nullable(0)]
public class WeekCardViewModel
{
	// Token: 0x06011D80 RID: 73088 RVA: 0x004E8762 File Offset: 0x004E6962
	public WeekCardViewModel(EWeekCardKind kind)
	{
		this.Kind = kind;
	}

	// Token: 0x06011D81 RID: 73089 RVA: 0x004E8771 File Offset: 0x004E6971
	private ActivityNewPlayerSupportActivityV2Controller GetNewPlayerActivityController()
	{
		return ActivityManager.GetActivityController(ActivityType.NewPlayerSupportActivityV2) as ActivityNewPlayerSupportActivityV2Controller;
	}

	// Token: 0x06011D82 RID: 73090 RVA: 0x004E8780 File Offset: 0x004E6980
	private int ResolveTargetWeekCardId()
	{
		List<WeekCard> configListByKind = ConfigBase<WeekCardConfig>.Instance.GetConfigListByKind(this.Kind);
		if (configListByKind.Count == 0)
		{
			return 0;
		}
		if (configListByKind.Count == 1)
		{
			return configListByKind[0].Id;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		foreach (WeekCard weekCard in configListByKind)
		{
			WeekCardData byId = ModelBase<WeekCardModel>.Instance.GetById(weekCard.Id);
			if (byId != null && byId.GetIsWeekCardInRewardStage())
			{
				return weekCard.Id;
			}
		}
		foreach (WeekCard weekCard2 in configListByKind)
		{
			PayPackageData payGiftDataById = ModelBase<PayGiftModel>.Instance.GetPayGiftDataById(weekCard2.PayGiftId);
			if (payGiftDataById != null && serverTime >= (double)payGiftDataById.BeginTime && (double)payGiftDataById.EndTime > serverTime)
			{
				return weekCard2.Id;
			}
		}
		return configListByKind[0].Id;
	}

	// Token: 0x06011D83 RID: 73091 RVA: 0x004E88B8 File Offset: 0x004E6AB8
	public int GetTargetWeekCardId()
	{
		return this.ResolveTargetWeekCardId();
	}

	// Token: 0x06011D84 RID: 73092 RVA: 0x004E88C0 File Offset: 0x004E6AC0
	public WeekCardData GetTargetCard()
	{
		int num = this.ResolveTargetWeekCardId();
		if (num == 0)
		{
			return null;
		}
		return ModelBase<WeekCardModel>.Instance.GetById(num);
	}

	// Token: 0x06011D85 RID: 73093 RVA: 0x004E88E4 File Offset: 0x004E6AE4
	private PayPackageData GetTargetPayGift()
	{
		int num = this.ResolveTargetWeekCardId();
		if (num == 0)
		{
			return null;
		}
		WeekCard? config = ConfigBase<WeekCardConfig>.Instance.GetConfig(num);
		if (config == null)
		{
			return null;
		}
		return ModelBase<PayGiftModel>.Instance.GetPayGiftDataById(config.Value.PayGiftId);
	}

	// Token: 0x06011D86 RID: 73094 RVA: 0x004E8930 File Offset: 0x004E6B30
	private bool IsConfigBuyOpen()
	{
		PayPackageData targetPayGift = this.GetTargetPayGift();
		if (targetPayGift == null)
		{
			return false;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return serverTime >= (double)targetPayGift.BeginTime && (double)targetPayGift.EndTime > serverTime;
	}

	// Token: 0x06011D87 RID: 73095 RVA: 0x004E896A File Offset: 0x004E6B6A
	public bool IsBuy()
	{
		WeekCardData targetCard = this.GetTargetCard();
		return targetCard != null && targetCard.GetHasBuyWeekCard();
	}

	// Token: 0x06011D88 RID: 73096 RVA: 0x004E897D File Offset: 0x004E6B7D
	public bool IsBuyOpen()
	{
		return this.IsConfigBuyOpen();
	}

	// Token: 0x06011D89 RID: 73097 RVA: 0x004E8985 File Offset: 0x004E6B85
	public bool IsInRewardStage()
	{
		WeekCardData targetCard = this.GetTargetCard();
		return targetCard != null && targetCard.GetIsWeekCardInRewardStage();
	}

	// Token: 0x06011D8A RID: 73098 RVA: 0x004E8998 File Offset: 0x004E6B98
	public bool IsKindOpen()
	{
		if (this.IsBuy())
		{
			return this.IsInRewardStage();
		}
		return this.IsConfigBuyOpen();
	}

	// Token: 0x06011D8B RID: 73099 RVA: 0x004E89B0 File Offset: 0x004E6BB0
	public double GetCountDownLeftSec()
	{
		WeekCardData targetCard = this.GetTargetCard();
		if (targetCard != null && targetCard.GetHasBuyWeekCard())
		{
			return Singleton<TimeUtil>.Instance.SetTimeSecond((double)targetCard.EndTimeStamp) - Singleton<TimeUtil>.Instance.GetServerTime();
		}
		if (this.Kind == EWeekCardKind.NewPlayer)
		{
			ActivityNewPlayerSupportActivityV2Controller newPlayerActivityController = this.GetNewPlayerActivityController();
			ActivityNewPlayerSupportActivityV2Data activityNewPlayerSupportActivityV2Data = (newPlayerActivityController != null) ? newPlayerActivityController.ActivityData : null;
			if (activityNewPlayerSupportActivityV2Data == null)
			{
				return 0.0;
			}
			return (double)activityNewPlayerSupportActivityV2Data.GetDisplayRemainEndTime() - Singleton<TimeUtil>.Instance.GetServerTime();
		}
		else
		{
			PayPackageData targetPayGift = this.GetTargetPayGift();
			if (targetPayGift == null)
			{
				return 0.0;
			}
			return (double)targetPayGift.EndTime - Singleton<TimeUtil>.Instance.GetServerTime();
		}
	}

	// Token: 0x06011D8C RID: 73100 RVA: 0x004E8A4E File Offset: 0x004E6C4E
	[NullableContext(1)]
	public string GetCountDownTextKey()
	{
		if (!this.IsBuy())
		{
			return "WeekCard_1004";
		}
		return "WeekCard_1005";
	}

	// Token: 0x06011D8D RID: 73101 RVA: 0x004E8A64 File Offset: 0x004E6C64
	public WeekCardContentInfo GetWeekCardContentInfo(int index)
	{
		WeekCardData targetCard = this.GetTargetCard();
		if (targetCard == null)
		{
			return null;
		}
		List<WeekCardContentInfo> allWeekCardContentInfos = targetCard.GetAllWeekCardContentInfos();
		if (index < 0 || index >= allWeekCardContentInfos.Count)
		{
			return null;
		}
		return targetCard.GetWeekCardContentInfo(index);
	}

	// Token: 0x06011D8E RID: 73102 RVA: 0x004E8A9C File Offset: 0x004E6C9C
	public string GetContentRewardTexturePath(int contentId)
	{
		WeekCardContent? weekCardContent;
		string text = (ConfigBase<WeekCardConfig>.Instance.GetContentConfig(contentId) != null) ? weekCardContent.GetValueOrDefault().RewardTexture : null;
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		return text;
	}

	// Token: 0x06011D8F RID: 73103 RVA: 0x004E8ADC File Offset: 0x004E6CDC
	[NullableContext(1)]
	public List<IWeekCostData> GetTotalRewardData()
	{
		WeekCardData targetCard = this.GetTargetCard();
		List<WeekCardContentInfo> list = ((targetCard != null) ? targetCard.GetAllWeekCardContentInfos() : null) ?? new List<WeekCardContentInfo>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (WeekCardContentInfo weekCardContentInfo in list)
		{
			foreach (KeyValuePair<int, int> keyValuePair in weekCardContentInfo.RewardContent)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (dictionary.ContainsKey(key))
				{
					Dictionary<int, int> dictionary2 = dictionary;
					int key2 = key;
					dictionary2[key2] += value;
				}
				else
				{
					dictionary[key] = value;
				}
			}
		}
		List<IWeekCostData> list2 = new List<IWeekCostData>();
		foreach (KeyValuePair<int, int> keyValuePair2 in dictionary)
		{
			list2.Add(new WeekCostData
			{
				ItemId = keyValuePair2.Key,
				Count = keyValuePair2.Value,
				Tips = ""
			});
		}
		list2.Sort((IWeekCostData a, IWeekCostData b) => a.ItemId - b.ItemId);
		return list2;
	}

	// Token: 0x06011D90 RID: 73104 RVA: 0x004E8C50 File Offset: 0x004E6E50
	public IWeekScoreData GetSendCostItemData()
	{
		PayPackageData targetPayGift = this.GetTargetPayGift();
		if (targetPayGift == null)
		{
			return null;
		}
		TotalTopUpController instance = ControllerBase<TotalTopUpController>.Instance;
		if (instance == null)
		{
			return null;
		}
		TotalTopUpData singleActivityData = instance.GetSingleActivityData();
		if (singleActivityData == null)
		{
			return null;
		}
		string totalUpScoreIcon = ConfigBase<TotalTopUpConfig>.Instance.GetTotalUpScoreIcon(singleActivityData.Id);
		if (string.IsNullOrEmpty(totalUpScoreIcon))
		{
			return null;
		}
		PayShopGoods payShopGoods = targetPayGift.GetPayShopGoods();
		if (payShopGoods == null)
		{
			return null;
		}
		int goodsScore = instance.GetGoodsScore(payShopGoods.GetGoodsData().Id);
		return new WeekScoreData
		{
			Tips = "WeekCard_1009",
			IconPath = totalUpScoreIcon,
			Count = goodsScore
		};
	}

	// Token: 0x06011D91 RID: 73105 RVA: 0x004E8CDC File Offset: 0x004E6EDC
	[NullableContext(1)]
	public string GetPrice()
	{
		PayPackageData targetPayGift = this.GetTargetPayGift();
		PayShopGoods payShopGoods = (targetPayGift != null) ? targetPayGift.GetPayShopGoods() : null;
		return ((payShopGoods != null) ? payShopGoods.GetDirectPriceText() : null) ?? "";
	}

	// Token: 0x06011D92 RID: 73106 RVA: 0x004E8D05 File Offset: 0x004E6F05
	[NullableContext(1)]
	public string GetBuyButtonText()
	{
		if (!this.IsBuy())
		{
			return "WeekCard_1007";
		}
		return "WeekCard_1008";
	}

	// Token: 0x06011D93 RID: 73107 RVA: 0x004E8D1C File Offset: 0x004E6F1C
	public int? GetHelpGroupId()
	{
		int num = this.ResolveTargetWeekCardId();
		if (num == 0)
		{
			return null;
		}
		WeekCard? config = ConfigBase<WeekCardConfig>.Instance.GetConfig(num);
		if (config == null)
		{
			return null;
		}
		return new int?(config.Value.HelpGroupId);
	}

	// Token: 0x06011D94 RID: 73108 RVA: 0x004E8D70 File Offset: 0x004E6F70
	public string GetTitleTextKey()
	{
		int num = this.ResolveTargetWeekCardId();
		if (num == 0)
		{
			return null;
		}
		WeekCard? weekCard;
		string text = (ConfigBase<WeekCardConfig>.Instance.GetConfig(num) != null) ? weekCard.GetValueOrDefault().Title : null;
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		return text;
	}

	// Token: 0x06011D95 RID: 73109 RVA: 0x004E8DBC File Offset: 0x004E6FBC
	public string GetDiscountTexturePath()
	{
		int num = this.ResolveTargetWeekCardId();
		if (num == 0)
		{
			return null;
		}
		WeekCard? weekCard;
		string text = (ConfigBase<WeekCardConfig>.Instance.GetConfig(num) != null) ? weekCard.GetValueOrDefault().DiscountTexture : null;
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		return text;
	}

	// Token: 0x06011D96 RID: 73110 RVA: 0x004E8E08 File Offset: 0x004E7008
	public bool GetRedDotState()
	{
		WeekCardData targetCard = this.GetTargetCard();
		return targetCard != null && targetCard.GetWeekCardRedDotState();
	}

	// Token: 0x06011D97 RID: 73111 RVA: 0x004E8E1C File Offset: 0x004E701C
	public int? GetPayGiftId()
	{
		PayPackageData targetPayGift = this.GetTargetPayGift();
		if (targetPayGift == null)
		{
			return null;
		}
		return new int?(targetPayGift.Id);
	}

	// Token: 0x06011D98 RID: 73112 RVA: 0x004E8E48 File Offset: 0x004E7048
	public int? GetPayShopGoodsId()
	{
		PayPackageData targetPayGift = this.GetTargetPayGift();
		if (targetPayGift == null)
		{
			return null;
		}
		PayShopGoods payShopGoods = targetPayGift.GetPayShopGoods();
		if (payShopGoods == null)
		{
			return null;
		}
		return new int?(payShopGoods.GetGoodsId());
	}

	// Token: 0x06011D99 RID: 73113 RVA: 0x004E8E88 File Offset: 0x004E7088
	[NullableContext(0)]
	public UniTask<bool> RequestInfo()
	{
		WeekCardViewModel.<RequestInfo>d__26 <RequestInfo>d__;
		<RequestInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestInfo>d__.<>4__this = this;
		<RequestInfo>d__.<>1__state = -1;
		<RequestInfo>d__.<>t__builder.Start<WeekCardViewModel.<RequestInfo>d__26>(ref <RequestInfo>d__);
		return <RequestInfo>d__.<>t__builder.Task;
	}

	// Token: 0x06011D9A RID: 73114 RVA: 0x004E8ECC File Offset: 0x004E70CC
	public void OnBuy()
	{
		int num = this.ResolveTargetWeekCardId();
		if (num != 0)
		{
			ConfigBase<WeekCardConfig>.Instance.GetConfig(num);
		}
		int? payGiftId = this.GetPayGiftId();
		if (payGiftId == null)
		{
			return;
		}
		ControllerBase<PayGiftController>.Instance.SdkPay(payGiftId.Value);
	}

	// Token: 0x06011D9B RID: 73115 RVA: 0x004E8F14 File Offset: 0x004E7114
	[NullableContext(0)]
	public UniTask<bool> OnReceiveReward(int contentId)
	{
		WeekCardViewModel.<OnReceiveReward>d__28 <OnReceiveReward>d__;
		<OnReceiveReward>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnReceiveReward>d__.contentId = contentId;
		<OnReceiveReward>d__.<>1__state = -1;
		<OnReceiveReward>d__.<>t__builder.Start<WeekCardViewModel.<OnReceiveReward>d__28>(ref <OnReceiveReward>d__);
		return <OnReceiveReward>d__.<>t__builder.Task;
	}

	// Token: 0x06011D9C RID: 73116 RVA: 0x004E8F57 File Offset: 0x004E7157
	public void OnAfterShow()
	{
		PayPackageData targetPayGift = this.GetTargetPayGift();
		PayShopGoods payShopGoods = (targetPayGift != null) ? targetPayGift.GetPayShopGoods() : null;
		if (payShopGoods == null)
		{
			return;
		}
		payShopGoods.SaveRemindState((long)Singleton<TimeUtil>.Instance.GetServerTime());
	}

	// Token: 0x04008B8C RID: 35724
	private readonly EWeekCardKind Kind;
}
