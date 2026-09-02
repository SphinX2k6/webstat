using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Launcher.Platform.PlatformSdk;

// Token: 0x020023AE RID: 9134
[NullableContext(1)]
[Nullable(0)]
public class PayPackageData
{
	// Token: 0x060119C7 RID: 72135 RVA: 0x004D4B18 File Offset: 0x004D2D18
	public void Phrase(PayGiftInfo payGiftInfo)
	{
		this.Id = payGiftInfo.Id;
		this.PayId = payGiftInfo.PayId;
		this.ItemId = payGiftInfo.ItemId;
		this.ItemCount = payGiftInfo.ItemCount;
		this.Sort = payGiftInfo.Sort;
		this.BuyLimit = payGiftInfo.BuyLimit;
		this.BoughtCount = payGiftInfo.BoughtCount;
		this.StageImage = (payGiftInfo.StageImage ?? "");
		this.ShowStageImage = (payGiftInfo.ShowStageImage ?? "");
		this.BeginTime = payGiftInfo.BeginTime;
		this.EndTime = payGiftInfo.EndTime;
		this.UpdateTime = payGiftInfo.UpdateTime;
		this.LastUpdateTime = payGiftInfo.LastUpdateTime;
		this.UpdateType = (PayShopDefine.EPayShopUpdateType)payGiftInfo.UpdateType;
		this.ProductId = (payGiftInfo.ProductId ?? "");
		this.Amount = (payGiftInfo.Amount ?? "");
		this.TabId = payGiftInfo.TabId;
		this.Type = (EPayGiftType)payGiftInfo.Type;
		this.IsLock = payGiftInfo.Locked;
		this.IsCanBuy = payGiftInfo.IsCanBuy;
		this.IsRemind = payGiftInfo.IsRemind;
		this.VersionGroupId = payGiftInfo.VersionId;
		this.BuyCondition = payGiftInfo.BuyConditionId;
		this.CloudGameTime = payGiftInfo.CloudGameTime;
		this.CloudGameIcon = (payGiftInfo.CloudGameIcon ?? "");
		this.CloudGameDesc = (payGiftInfo.Desc ?? "");
		this.LabelId = payGiftInfo.Tag;
		this.PromotionShow = payGiftInfo.PromotionShow;
		this.NeedConsoleRulePrompt = payGiftInfo.NeedConsoleRulePrompt;
		this.CurrencyDiscountTags.Clear();
		foreach (KeyValuePair<string, int> keyValuePair in payGiftInfo.CurrencyDiscountTags)
		{
			this.CurrencyDiscountTags.Add(keyValuePair.Key, keyValuePair.Value);
		}
		this.DisclaimerText = payGiftInfo.ComplianceDetail;
		this.ShopId = this.ResolveShopId(payGiftInfo.ShopId);
		this.CalculateGoodsName();
		if (this.PayShopGoods == null)
		{
			this.PayShopGoods = new PayShopGoods(this.ShopId);
		}
		else
		{
			this.PayShopGoods.SetPayShopId(this.ShopId);
		}
		this.PayShopGoods.SetGoodsData(this.ConvertToPayShopGoodsData());
		this.PayShopGoods.SetPayGiftId(this.Id);
		if (this.ShowInSkinTab())
		{
			PayShopGoodsData goodsData = this.PayShopGoods.GetGoodsData();
			if (goodsData == null)
			{
				return;
			}
			goodsData.SetShowAfterSoldOut(true);
		}
	}

	// Token: 0x060119C8 RID: 72136 RVA: 0x004D4DA4 File Offset: 0x004D2FA4
	private unsafe PayShopDefine.EPayShopTabType ResolveShopId(int rawShopId)
	{
		if (rawShopId == 0)
		{
			return PayShopDefine.EPayShopTabType.GiftBag;
		}
		if (rawShopId == 3 || rawShopId == 7)
		{
			return (PayShopDefine.EPayShopTabType)rawShopId;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.TZJ;
		string message = "[礼包商店区分] PayPackageData unknown Proto_ShopId, fallback to GiftBag";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Proto_ShopId", rawShopId);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return PayShopDefine.EPayShopTabType.GiftBag;
	}

	// Token: 0x060119C9 RID: 72137 RVA: 0x004D4E24 File Offset: 0x004D3024
	private void CalculateGoodsName()
	{
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId);
		if (itemConfigData != null)
		{
			this.Name = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.Name, null);
		}
		if (this.ItemCount > 1)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("GoodsName"), null);
			this.Name = StringUtils.Format(localTextNew, new string[]
			{
				this.Name,
				this.ItemCount.ToString()
			});
		}
	}

	// Token: 0x060119CA RID: 72138 RVA: 0x004D4E9F File Offset: 0x004D309F
	public bool ShowInShop()
	{
		return this.Type != EPayGiftType.BattlePass && !this.ShowInSkinTab() && this.Type != EPayGiftType.RegressBp && this.Type != EPayGiftType.WeekCard;
	}

	// Token: 0x060119CB RID: 72139 RVA: 0x004D4ECC File Offset: 0x004D30CC
	public bool ShowInSkinTab()
	{
		PayShopGoods payShopGoods = this.PayShopGoods;
		return payShopGoods != null && this.Type != EPayGiftType.CdkGift && (payShopGoods.CheckIfRoleSkinGoods() || payShopGoods.CheckIfFlySkinGoods() || payShopGoods.CheckIfMotorSkinGoods() || payShopGoods.CheckIfOrnamentGoods());
	}

	// Token: 0x060119CC RID: 72140 RVA: 0x004D4F10 File Offset: 0x004D3110
	public string GetName()
	{
		return this.Name;
	}

	// Token: 0x060119CD RID: 72141 RVA: 0x004D4F18 File Offset: 0x004D3118
	[NullableContext(2)]
	public PayShopGoods GetPayShopGoods()
	{
		return this.PayShopGoods;
	}

	// Token: 0x060119CE RID: 72142 RVA: 0x004D4F20 File Offset: 0x004D3120
	public int GetDiscount()
	{
		string queryProductCurrency = ModelBase<KuroSdkModel>.Instance.GetQueryProductCurrency(this.PayId.ToString());
		int result;
		if (this.CurrencyDiscountTags.TryGetValue(queryProductCurrency, out result))
		{
			return result;
		}
		int result2;
		if (this.CurrencyDiscountTags.TryGetValue("Default", out result2))
		{
			return result2;
		}
		return 0;
	}

	// Token: 0x060119CF RID: 72143 RVA: 0x004D4F6C File Offset: 0x004D316C
	public bool HasDiscount()
	{
		return this.GetDiscount() > 0;
	}

	// Token: 0x060119D0 RID: 72144 RVA: 0x004D4F77 File Offset: 0x004D3177
	private PayShopGoodsData ConvertToPayShopGoodsData()
	{
		PayShopGoodsData payShopGoodsData = new PayShopGoodsData();
		payShopGoodsData.PhraseFromPayPackageData(this);
		return payShopGoodsData;
	}

	// Token: 0x060119D1 RID: 72145 RVA: 0x004D4F85 File Offset: 0x004D3185
	public bool CanShowInShopTab()
	{
		return !Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().NeedConfirmSdkProductInfo() || ModelBase<PayItemModel>.Instance.GetProductInfoByGoodsId(this.ProductId) != null;
	}

	// Token: 0x040089AD RID: 35245
	private const string DEFAULTCURRENCYKEY = "Default";

	// Token: 0x040089AE RID: 35246
	private string Name = "";

	// Token: 0x040089AF RID: 35247
	[Nullable(2)]
	private PayShopGoods PayShopGoods;

	// Token: 0x040089B0 RID: 35248
	public int Id;

	// Token: 0x040089B1 RID: 35249
	public int PayId;

	// Token: 0x040089B2 RID: 35250
	public int ItemId;

	// Token: 0x040089B3 RID: 35251
	public int ItemCount;

	// Token: 0x040089B4 RID: 35252
	public int Sort;

	// Token: 0x040089B5 RID: 35253
	public int BuyLimit;

	// Token: 0x040089B6 RID: 35254
	public int BoughtCount;

	// Token: 0x040089B7 RID: 35255
	public string StageImage = "";

	// Token: 0x040089B8 RID: 35256
	public string ShowStageImage = "";

	// Token: 0x040089B9 RID: 35257
	public long BeginTime;

	// Token: 0x040089BA RID: 35258
	public long EndTime;

	// Token: 0x040089BB RID: 35259
	public long UpdateTime;

	// Token: 0x040089BC RID: 35260
	public PayShopDefine.EPayShopUpdateType UpdateType;

	// Token: 0x040089BD RID: 35261
	public string ProductId = "";

	// Token: 0x040089BE RID: 35262
	public string Amount = "";

	// Token: 0x040089BF RID: 35263
	public int TabId;

	// Token: 0x040089C0 RID: 35264
	public EPayGiftType Type = EPayGiftType.LimitGift;

	// Token: 0x040089C1 RID: 35265
	public bool IsLock;

	// Token: 0x040089C2 RID: 35266
	public bool IsCanBuy = true;

	// Token: 0x040089C3 RID: 35267
	public bool IsRemind;

	// Token: 0x040089C4 RID: 35268
	public int VersionGroupId;

	// Token: 0x040089C5 RID: 35269
	public int BuyCondition;

	// Token: 0x040089C6 RID: 35270
	public int CloudGameTime;

	// Token: 0x040089C7 RID: 35271
	public string CloudGameIcon = "";

	// Token: 0x040089C8 RID: 35272
	public string CloudGameDesc = "";

	// Token: 0x040089C9 RID: 35273
	public int LabelId;

	// Token: 0x040089CA RID: 35274
	public long LastUpdateTime;

	// Token: 0x040089CB RID: 35275
	public int PromotionShow;

	// Token: 0x040089CC RID: 35276
	public Dictionary<string, int> CurrencyDiscountTags = new Dictionary<string, int>();

	// Token: 0x040089CD RID: 35277
	public string DisclaimerText = "";

	// Token: 0x040089CE RID: 35278
	public PayShopDefine.EPayShopTabType ShopId = PayShopDefine.EPayShopTabType.GiftBag;

	// Token: 0x040089CF RID: 35279
	public bool NeedConsoleRulePrompt;
}
