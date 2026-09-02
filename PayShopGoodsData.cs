using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x020023AF RID: 9135
[NullableContext(1)]
[Nullable(0)]
public class PayShopGoodsData
{
	// Token: 0x060119D3 RID: 72147 RVA: 0x004D503C File Offset: 0x004D323C
	public unsafe void Phrase(Aki.Protocol.PayShopItem data)
	{
		this.Id = data.Id;
		this.TabId = data.TabId;
		this.ShopId = data.ShopId;
		this.ItemId = data.ItemId;
		this.ShopItemQuality = data.Quality;
		this.ItemCount = data.ItemCount;
		this.Locked = data.Locked;
		this.CanBuy = data.CanBuyGoods;
		this.BuyLimit = data.BuyLimit;
		this.OnceBuyLimit = data.OnceBuyLimit;
		this.LimitBuyConditionId = data.BuyLimitConditionId;
		this.BoughtCount = data.BoughtCount;
		this.Price.Phrase(data.Price);
		this.Coupons = new List<int>(data.Coupons);
		this.BeginTime = data.BeginTime;
		this.EndTime = data.EndTime;
		int activityId = data.ActivityId;
		if (activityId > 0)
		{
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(activityId);
			if (activityById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Shop;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "活动商品对应的活动数据为空";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("goodsId", this.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("activityId", activityId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.EndTime = activityById.EndShowTime;
		}
		this.BeginPromotionTime = data.BeginPromotionTime;
		this.EndPromotionTime = data.EndPromotionTime;
		this.UpdateTime = data.UpdateTime;
		this.UpdateType = (PayShopDefine.EPayShopUpdateType)data.UpdateType;
		this.ShopItemType = (PayShopDefine.EPayShopItemType)data.ShopItemType;
		this.LastUpdateTime = data.LastUpdateTime;
		this.LabelId = data.Tag;
		this.LabelBeginTime = data.TagBeginTime;
		this.LabelEndTime = data.TagEndTime;
		this.Sort = data.Sort;
		this.DiscountSort = data.DiscountSort;
		this.PromotionShow = data.PromotionShow;
		this.ShowRecommendTag = data.IsRecommend;
		this.IsShowHaveNum = data.IsShowHaveNum;
		this.IsBuyMaxButton = data.IsBuyMaxButton;
		this.ConfirmLimitCount = data.ConfirmLimitCount;
		this.ShowAfterSoldOut = data.SoldoutShowInShop;
		this.NeedRemind = data.IsRemind;
		this.StageImage = data.StageImage;
		this.ShowStageImage = data.ShowStageImage;
		this.Show = data.Show;
		this.DisclaimerText = data.ComplianceDetail;
		this.CalculateGoodsName();
		this.CheckVersionGroupConflict();
	}

	// Token: 0x060119D4 RID: 72148 RVA: 0x004D52B0 File Offset: 0x004D34B0
	public bool GetIfCanBuy()
	{
		if (this.IfRoleCallBackItem())
		{
			return this.IfHaveRoleCallBackItemNeedRole() && this.IfCanResonant();
		}
		if (this.IfRoleItem())
		{
			return this.IfCanBuyRoleItem();
		}
		return (!this.CheckIfMonthCardItem() || ModelBase<MonthCardModel>.Instance.CheckMonthCardIfCanBuy()) && this.CanBuy;
	}

	// Token: 0x060119D5 RID: 72149 RVA: 0x004D5309 File Offset: 0x004D3509
	public bool GetCanBuyValue()
	{
		return this.CanBuy;
	}

	// Token: 0x060119D6 RID: 72150 RVA: 0x004D5311 File Offset: 0x004D3511
	public bool IfRoleItem()
	{
		return ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.ItemId)) == InventoryDefine.EItemDataType.RoleItem;
	}

	// Token: 0x060119D7 RID: 72151 RVA: 0x004D532C File Offset: 0x004D352C
	public bool IfRoleCallBackItem()
	{
		ItemConfig itemConfig = this.GetItemConfig();
		return itemConfig != null && itemConfig.ShowTypes != null && itemConfig.ShowTypes.Contains(30);
	}

	// Token: 0x060119D8 RID: 72152 RVA: 0x004D535C File Offset: 0x004D355C
	public bool IfCanBuyRoleItem()
	{
		return ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.ItemId) == null || ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(this.ItemId) > 0;
	}

	// Token: 0x060119D9 RID: 72153 RVA: 0x004D5388 File Offset: 0x004D3588
	public bool IfHaveRoleCallBackItemNeedRole()
	{
		if (this.IfRoleCallBackItem())
		{
			int id = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(this.ItemId)[0];
			if (ModelBase<RoleModel>.Instance.GetRoleInstanceById(id) == null)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060119DA RID: 72154 RVA: 0x004D53C0 File Offset: 0x004D35C0
	public bool IfCanResonant()
	{
		if (this.IfRoleCallBackItem())
		{
			int roleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(this.ItemId)[0];
			if (ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(roleId) <= 0)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060119DB RID: 72155 RVA: 0x004D53F9 File Offset: 0x004D35F9
	public int GetBuyConditionId()
	{
		if (this.GoodType != PayShopGoodsData.EGoodType.PayGift)
		{
			return this.LimitBuyConditionId;
		}
		if (this.UnFinishedCondition != null && this.UnFinishedCondition.Count > 0)
		{
			return this.UnFinishedCondition[0];
		}
		return 0;
	}

	// Token: 0x060119DC RID: 72156 RVA: 0x004D5430 File Offset: 0x004D3630
	[NullableContext(2)]
	public string GetUnFinishConditionText()
	{
		if (this.IfRoleCallBackItem())
		{
			if (!this.IfHaveRoleCallBackItemNeedRole())
			{
				return ConfigMultiTextLang.GetLocalTextNew("DontHaveRole", null);
			}
			if (!this.IfCanResonant())
			{
				return ConfigMultiTextLang.GetLocalTextNew("RoleBrenchItemMax", null);
			}
		}
		if (this.IfRoleItem())
		{
			return ConfigMultiTextLang.GetLocalTextNew("RoleBrenchItemMax", null);
		}
		if (this.CheckIfMonthCardItem())
		{
			return ConfigMultiTextLang.GetLocalTextNew("Text_MonthlyCardMax_Text", null);
		}
		int buyConditionId = this.GetBuyConditionId();
		if (buyConditionId != 0)
		{
			return ConfigMultiTextLang.GetLocalTextNew(LevelGeneralCommons.GetConditionGroupHintText(buyConditionId) ?? "", null);
		}
		return "";
	}

	// Token: 0x060119DD RID: 72157 RVA: 0x004D54BA File Offset: 0x004D36BA
	public bool CheckIfMonthCardItem()
	{
		return this.Id == ConfigBase<PayShopConfig>.Instance.GetMonthCardShopId();
	}

	// Token: 0x060119DE RID: 72158 RVA: 0x004D54D0 File Offset: 0x004D36D0
	private void CalculateGoodsName()
	{
		string text = "";
		if (text == "")
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId);
			text = ConfigMultiTextLang.GetLocalTextNew(((itemConfigData != null) ? itemConfigData.Name : null) ?? "", null);
		}
		if (this.ItemCount > 1)
		{
			text = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("GoodsName"), null), new string[]
			{
				text,
				this.ItemCount.ToString()
			});
		}
		this.CurrentNameLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		this.Name = text;
	}

	// Token: 0x060119DF RID: 72159 RVA: 0x004D5570 File Offset: 0x004D3770
	public void PhraseFromPayPackageData(PayPackageData data)
	{
		this.Id = data.Id;
		this.ItemId = data.ItemId;
		this.ItemCount = data.ItemCount;
		this.Locked = data.IsLock;
		this.CanBuy = data.IsCanBuy;
		this.BuyLimit = data.BuyLimit;
		this.BoughtCount = data.BoughtCount;
		this.Price.Id = data.PayId;
		this.BeginTime = data.BeginTime;
		this.EndTime = data.EndTime;
		this.UpdateTime = data.UpdateTime;
		this.LastUpdateTime = data.LastUpdateTime;
		this.UpdateType = data.UpdateType;
		this.ShopItemType = PayShopDefine.EPayShopItemType.Direct;
		this.LabelId = data.LabelId;
		this.LabelBeginTime = 0L;
		this.LabelEndTime = 0L;
		this.Sort = data.Sort;
		this.PromotionShow = 0;
		this.TabId = data.TabId;
		this.StageImage = data.StageImage;
		this.ShowStageImage = data.ShowStageImage;
		this.GoodType = PayShopGoodsData.EGoodType.PayGift;
		this.NeedRemind = data.IsRemind;
		this.VersionGroupId = data.VersionGroupId;
		this.CloudGameTime = data.CloudGameTime;
		this.CloudGameIcon = data.CloudGameIcon;
		this.CloudGameDesc = data.CloudGameDesc;
		this.PayPackageType = new EPayGiftType?(data.Type);
		if (data.BuyCondition > 0)
		{
			this.UnFinishedCondition = new List<int>();
			this.UnFinishedCondition.Add(data.BuyCondition);
		}
		this.ProductId = data.ProductId;
		this.DisclaimerText = data.DisclaimerText;
		ModelBase<RechargeModel>.Instance.SetRechargeInfo(data.PayId, data.Amount, data.ProductId);
		this.Name = data.GetName();
		this.CheckVersionGroupConflict();
	}

	// Token: 0x060119E0 RID: 72160 RVA: 0x004D5738 File Offset: 0x004D3938
	public void PhraseFromTempData(int id, int count)
	{
		this.ItemId = id;
		this.ItemCount = count;
		this.GoodType = PayShopGoodsData.EGoodType.ClientItem;
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(id);
		this.Name = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.Name, null);
	}

	// Token: 0x060119E1 RID: 72161 RVA: 0x004D5778 File Offset: 0x004D3978
	[NullableContext(2)]
	public ItemConfig GetItemConfig()
	{
		return ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId);
	}

	// Token: 0x060119E2 RID: 72162 RVA: 0x004D578A File Offset: 0x004D398A
	public string GetGoodsName(string language)
	{
		if (this.CurrentNameLanguage != Singleton<LanguageSystem>.Instance.PackageLanguage)
		{
			this.CalculateGoodsName();
		}
		return this.Name;
	}

	// Token: 0x060119E3 RID: 72163 RVA: 0x004D57AF File Offset: 0x004D39AF
	public bool IfMayReSell()
	{
		if (this.UpdateType != PayShopDefine.EPayShopUpdateType.None && this.UpdateType != PayShopDefine.EPayShopUpdateType.Forever)
		{
			if (this.EndTime == 0L)
			{
				return true;
			}
			if (this.UpdateTime < this.EndTime)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060119E4 RID: 72164 RVA: 0x004D57E0 File Offset: 0x004D39E0
	public bool InLabelShowTime()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return this.LabelId != 0 && ((this.LabelBeginTime > 0L && serverTime >= (double)this.LabelBeginTime && this.LabelEndTime == 0L) || (this.LabelBeginTime == 0L && this.LabelEndTime == 0L) || ((double)this.LabelEndTime > serverTime && serverTime >= (double)this.LabelBeginTime));
	}

	// Token: 0x060119E5 RID: 72165 RVA: 0x004D584B File Offset: 0x004D3A4B
	public int GetSortValue()
	{
		if (this.NeedDiscountSort())
		{
			return this.DiscountSort;
		}
		return this.Sort;
	}

	// Token: 0x060119E6 RID: 72166 RVA: 0x004D5862 File Offset: 0x004D3A62
	private bool NeedDiscountSort()
	{
		return this.HasDiscount() && this.DiscountSort != 0 && this.GetIfCanBuy() && this.GetRemainingCount() != 0 && !this.IsDirect();
	}

	// Token: 0x060119E7 RID: 72167 RVA: 0x004D5893 File Offset: 0x004D3A93
	public bool IsWeeklyRefresh()
	{
		return this.UpdateType != PayShopDefine.EPayShopUpdateType.None && this.UpdateType != PayShopDefine.EPayShopUpdateType.Forever;
	}

	// Token: 0x060119E8 RID: 72168 RVA: 0x004D58AB File Offset: 0x004D3AAB
	public void SetShowAfterSoldOut(bool show)
	{
		this.ShowAfterSoldOut = show;
	}

	// Token: 0x060119E9 RID: 72169 RVA: 0x004D58B4 File Offset: 0x004D3AB4
	public bool IfShowAfterSoldOut()
	{
		return this.ShowAfterSoldOut;
	}

	// Token: 0x060119EA RID: 72170 RVA: 0x004D58BC File Offset: 0x004D3ABC
	public bool HasDiscount()
	{
		if (this.Price.PromotionCount <= 0)
		{
			return false;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if ((this.EndPromotionTime == 0L && this.BeginPromotionTime == 0L) || (this.EndPromotionTime == 0L && this.BeginPromotionTime > 0L && serverTime >= (double)this.BeginPromotionTime))
		{
			return true;
		}
		bool flag = Singleton<TimeUtil>.Instance.IsExceededServerTime(this.EndPromotionTime);
		bool flag2 = (double)this.EndPromotionTime > serverTime && serverTime >= (double)this.BeginPromotionTime;
		return flag && flag2;
	}

	// Token: 0x060119EB RID: 72171 RVA: 0x004D5940 File Offset: 0x004D3B40
	public int? GetOriginalPrice()
	{
		if (this.HasDiscount())
		{
			return new int?(this.Price.Count);
		}
		return null;
	}

	// Token: 0x060119EC RID: 72172 RVA: 0x004D596F File Offset: 0x004D3B6F
	public int GetDiscount()
	{
		if (this.PromotionShow > 0)
		{
			return this.PromotionShow / 100;
		}
		return this.Price.GetDiscount();
	}

	// Token: 0x060119ED RID: 72173 RVA: 0x004D598F File Offset: 0x004D3B8F
	public int GetDiscountNew()
	{
		if (this.PromotionShow > 0)
		{
			return this.PromotionShow / 100;
		}
		return this.Price.GetDiscountNew();
	}

	// Token: 0x060119EE RID: 72174 RVA: 0x004D59AF File Offset: 0x004D3BAF
	public int GetRemainingCount()
	{
		return this.BuyLimit - this.BoughtCount;
	}

	// Token: 0x060119EF RID: 72175 RVA: 0x004D59BE File Offset: 0x004D3BBE
	public string GetRemainingTextId()
	{
		return PayShopDefine.payShopUpdateTypeTextId[this.UpdateType];
	}

	// Token: 0x060119F0 RID: 72176 RVA: 0x004D59D0 File Offset: 0x004D3BD0
	public bool HasBuyLimit()
	{
		return this.BuyLimit > 0;
	}

	// Token: 0x060119F1 RID: 72177 RVA: 0x004D59DB File Offset: 0x004D3BDB
	public bool HasOnceBuyLimit()
	{
		return this.OnceBuyLimit > 0;
	}

	// Token: 0x060119F2 RID: 72178 RVA: 0x004D59E6 File Offset: 0x004D3BE6
	public void SetUnLock()
	{
		this.Locked = false;
	}

	// Token: 0x060119F3 RID: 72179 RVA: 0x004D59EF File Offset: 0x004D3BEF
	public bool IsDirect()
	{
		return this.ShopItemType == PayShopDefine.EPayShopItemType.Direct;
	}

	// Token: 0x060119F4 RID: 72180 RVA: 0x004D59FA File Offset: 0x004D3BFA
	public int GetNowPrice()
	{
		if (this.HasDiscount())
		{
			return this.Price.PromotionCount;
		}
		return this.Price.Count;
	}

	// Token: 0x060119F5 RID: 72181 RVA: 0x004D5A1B File Offset: 0x004D3C1B
	public bool IsShowInShop()
	{
		if (this.GoodType == PayShopGoodsData.EGoodType.DiscountItem)
		{
			return this.Show && !this.Locked;
		}
		return this.GoodType != PayShopGoodsData.EGoodType.PayGift || !this.Locked;
	}

	// Token: 0x060119F6 RID: 72182 RVA: 0x004D5A4D File Offset: 0x004D3C4D
	public bool IfPayGift()
	{
		return this.GoodType == PayShopGoodsData.EGoodType.PayGift;
	}

	// Token: 0x060119F7 RID: 72183 RVA: 0x004D5A58 File Offset: 0x004D3C58
	public int? GetGiftId()
	{
		int? result = null;
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId);
		if (itemConfigData.ItemType.GetValueOrDefault() == InventoryDefine.EItemType.Gift)
		{
			int value;
			if (itemConfigData.Parameters.TryGetValue(2, out value))
			{
				result = new int?(value);
			}
			int value2;
			if (result == null && itemConfigData.Parameters.TryGetValue(4, out value2))
			{
				result = new int?(value2);
			}
		}
		return result;
	}

	// Token: 0x060119F8 RID: 72184 RVA: 0x004D5AC7 File Offset: 0x004D3CC7
	public InventoryDefine.EItemType? GetRewardItemType()
	{
		return ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId).ItemType;
	}

	// Token: 0x060119F9 RID: 72185 RVA: 0x004D5ADE File Offset: 0x004D3CDE
	public string GetProductId()
	{
		return this.ProductId;
	}

	// Token: 0x060119FA RID: 72186 RVA: 0x004D5AE8 File Offset: 0x004D3CE8
	public bool GetIfNeedRemind()
	{
		if (this.VersionGroupId > 0)
		{
			int? num = this.GetVersionRedDotStorage().Get(this.Id);
			if (this.NeedRemind)
			{
				int? num2 = num;
				int versionGroupId = this.VersionGroupId;
				return !(num2.GetValueOrDefault() == versionGroupId & num2 != null);
			}
			return false;
		}
		else
		{
			bool flag = true;
			if (this.GoodType != PayShopGoodsData.EGoodType.PayGift)
			{
				PayShopInfoData payShopInfoById = ModelBase<PayShopModel>.Instance.GetPayShopInfoById((PayShopDefine.EPayShopTabType)this.ShopId);
				flag = (payShopInfoById != null && payShopInfoById.EnableServerRedDot);
			}
			if (!flag)
			{
				return false;
			}
			int? num3 = this.GetReadTimeStorage().Get(this.Id);
			uint? num4 = (num3 == null) ? null : new uint?((uint)num3.Value);
			long num5 = (long)Math.Floor((double)this.LastUpdateTime / 1000.0);
			long num6 = (long)Math.Floor((double)this.UpdateTime / 1000.0);
			if (this.LastUpdateTime > 0L && num4 != null)
			{
				uint? num7 = num4;
				uint num8 = 0U;
				if (num7.GetValueOrDefault() > num8 & num7 != null)
				{
					num7 = num4;
					long? num9 = (num7 != null) ? new long?((long)((ulong)num7.GetValueOrDefault())) : null;
					long num10 = num5;
					if (num9.GetValueOrDefault() > num10 & num9 != null)
					{
						num7 = num4;
						num9 = ((num7 != null) ? new long?((long)((ulong)num7.GetValueOrDefault())) : null);
						num10 = num6;
						if (num9.GetValueOrDefault() < num10 & num9 != null)
						{
							return false;
						}
					}
				}
			}
			else if (num4 != null)
			{
				uint? num7 = num4;
				uint num8 = 0U;
				if (num7.GetValueOrDefault() > num8 & num7 != null)
				{
					return false;
				}
			}
			return this.NeedRemind;
		}
	}

	// Token: 0x060119FB RID: 72187 RVA: 0x004D5CBC File Offset: 0x004D3EBC
	public int SaveRemindState(long timestamp)
	{
		if (this.VersionGroupId > 0)
		{
			ServerStorageMap versionRedDotStorage = this.GetVersionRedDotStorage();
			int? num = versionRedDotStorage.Get(this.Id);
			int versionGroupId = this.VersionGroupId;
			if (num.GetValueOrDefault() == versionGroupId & num != null)
			{
				return -1;
			}
			versionRedDotStorage.Set(this.Id, this.VersionGroupId);
			return 0;
		}
		else
		{
			bool flag = true;
			if (this.GoodType != PayShopGoodsData.EGoodType.PayGift)
			{
				PayShopInfoData payShopInfoById = ModelBase<PayShopModel>.Instance.GetPayShopInfoById((PayShopDefine.EPayShopTabType)this.ShopId);
				flag = (payShopInfoById != null && payShopInfoById.EnableServerRedDot);
			}
			if (!flag)
			{
				return 0;
			}
			ServerStorageMap readTimeStorage = this.GetReadTimeStorage();
			int? num2 = readTimeStorage.Get(this.Id);
			uint? num3 = (num2 == null) ? null : new uint?((uint)num2.Value);
			long num4 = (long)Math.Floor((double)this.LastUpdateTime / 1000.0);
			long num5 = (long)Math.Floor((double)this.UpdateTime / 1000.0);
			if (this.LastUpdateTime == 0L)
			{
				if (num3 != null)
				{
					uint? num6 = num3;
					uint num7 = 0U;
					if (num6.GetValueOrDefault() > num7 & num6 != null)
					{
						return -1;
					}
				}
			}
			else if (num3 != null)
			{
				uint? num6 = num3;
				long? num8 = (num6 != null) ? new long?((long)((ulong)num6.GetValueOrDefault())) : null;
				long num9 = num4;
				if (num8.GetValueOrDefault() > num9 & num8 != null)
				{
					num6 = num3;
					num8 = ((num6 != null) ? new long?((long)((ulong)num6.GetValueOrDefault())) : null);
					num9 = num5;
					if (num8.GetValueOrDefault() < num9 & num8 != null)
					{
						return -1;
					}
				}
			}
			long num10 = (long)Math.Floor((double)timestamp / 1000.0);
			readTimeStorage.Set(this.Id, (int)num10);
			return 0;
		}
	}

	// Token: 0x060119FC RID: 72188 RVA: 0x004D5E9D File Offset: 0x004D409D
	private ServerStorageMap GetVersionRedDotStorage()
	{
		return (ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.VersionPayGiftRedDot);
	}

	// Token: 0x060119FD RID: 72189 RVA: 0x004D5EB0 File Offset: 0x004D40B0
	private ServerStorageMap GetReadTimeStorage()
	{
		return (ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.NormalPayGiftRedDot);
	}

	// Token: 0x060119FE RID: 72190 RVA: 0x004D5EC4 File Offset: 0x004D40C4
	private unsafe void CheckVersionGroupConflict()
	{
		if (this.VersionGroupId > 0 && this.UpdateType != PayShopDefine.EPayShopUpdateType.None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Shop;
			ELogAuthor author = ELogAuthor.CCJ;
			string message = "版本礼包不应同时配置周期刷新";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("goodsId", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("versionGroupId", this.VersionGroupId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("updateType", this.UpdateType);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
	}

	// Token: 0x060119FF RID: 72191 RVA: 0x004D5F74 File Offset: 0x004D4174
	public List<int> GetCouponList()
	{
		List<int> list = new List<int>();
		foreach (int num in this.Coupons)
		{
			if (num > 0)
			{
				list.Add(num);
			}
		}
		return list;
	}

	// Token: 0x040089D0 RID: 35280
	public int Id;

	// Token: 0x040089D1 RID: 35281
	public int TabId;

	// Token: 0x040089D2 RID: 35282
	public int ShopId;

	// Token: 0x040089D3 RID: 35283
	public int ItemId;

	// Token: 0x040089D4 RID: 35284
	public int ShopItemQuality;

	// Token: 0x040089D5 RID: 35285
	public int ItemCount;

	// Token: 0x040089D6 RID: 35286
	public bool Locked;

	// Token: 0x040089D7 RID: 35287
	private bool CanBuy = true;

	// Token: 0x040089D8 RID: 35288
	public int BuyLimit;

	// Token: 0x040089D9 RID: 35289
	public int OnceBuyLimit;

	// Token: 0x040089DA RID: 35290
	public int BoughtCount;

	// Token: 0x040089DB RID: 35291
	public PayShopGoodsPrice Price = new PayShopGoodsPrice();

	// Token: 0x040089DC RID: 35292
	public PayShopDefine.EPayShopUpdateType UpdateType;

	// Token: 0x040089DD RID: 35293
	public PayShopDefine.EPayShopItemType ShopItemType;

	// Token: 0x040089DE RID: 35294
	public long BeginTime;

	// Token: 0x040089DF RID: 35295
	public long EndTime;

	// Token: 0x040089E0 RID: 35296
	public long BeginPromotionTime;

	// Token: 0x040089E1 RID: 35297
	public long EndPromotionTime;

	// Token: 0x040089E2 RID: 35298
	public long UpdateTime;

	// Token: 0x040089E3 RID: 35299
	public int LabelId;

	// Token: 0x040089E4 RID: 35300
	public long LabelBeginTime;

	// Token: 0x040089E5 RID: 35301
	public long LabelEndTime;

	// Token: 0x040089E6 RID: 35302
	public int Sort;

	// Token: 0x040089E7 RID: 35303
	public int DiscountSort;

	// Token: 0x040089E8 RID: 35304
	public bool Show = true;

	// Token: 0x040089E9 RID: 35305
	public int PromotionShow;

	// Token: 0x040089EA RID: 35306
	private string Name = "";

	// Token: 0x040089EB RID: 35307
	public string StageImage = "";

	// Token: 0x040089EC RID: 35308
	private PayShopGoodsData.EGoodType GoodType;

	// Token: 0x040089ED RID: 35309
	private string CurrentNameLanguage = "";

	// Token: 0x040089EE RID: 35310
	private bool ShowAfterSoldOut;

	// Token: 0x040089EF RID: 35311
	[Nullable(2)]
	public List<int> UnFinishedCondition;

	// Token: 0x040089F0 RID: 35312
	public int LimitBuyConditionId;

	// Token: 0x040089F1 RID: 35313
	private bool NeedRemind;

	// Token: 0x040089F2 RID: 35314
	private int VersionGroupId;

	// Token: 0x040089F3 RID: 35315
	private string ProductId = "";

	// Token: 0x040089F4 RID: 35316
	private List<int> Coupons = new List<int>();

	// Token: 0x040089F5 RID: 35317
	public int CloudGameTime;

	// Token: 0x040089F6 RID: 35318
	public string CloudGameIcon = "";

	// Token: 0x040089F7 RID: 35319
	public string CloudGameDesc = "";

	// Token: 0x040089F8 RID: 35320
	private long LastUpdateTime;

	// Token: 0x040089F9 RID: 35321
	public string ShowStageImage = "";

	// Token: 0x040089FA RID: 35322
	public string DisclaimerText = "";

	// Token: 0x040089FB RID: 35323
	public bool ShowRecommendTag;

	// Token: 0x040089FC RID: 35324
	public bool IsShowHaveNum;

	// Token: 0x040089FD RID: 35325
	public bool IsBuyMaxButton;

	// Token: 0x040089FE RID: 35326
	public EPayGiftType? PayPackageType;

	// Token: 0x040089FF RID: 35327
	public int ConfirmLimitCount;

	// Token: 0x020086D0 RID: 34512
	[NullableContext(0)]
	private enum EGoodType
	{
		// Token: 0x0402D973 RID: 186739
		ClientItem = -1,
		// Token: 0x0402D974 RID: 186740
		DiscountItem,
		// Token: 0x0402D975 RID: 186741
		PayGift
	}
}
