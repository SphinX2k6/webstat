using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x020023DF RID: 9183
[NullableContext(1)]
[Nullable(0)]
public class PayShopItemBaseSt
{
	// Token: 0x06011C32 RID: 72754 RVA: 0x004E21E8 File Offset: 0x004E03E8
	public PayShopItemBaseSt()
	{
		this.Id = 0;
		this.Quality = 0;
		this.ItemId = 0;
		this.ItemCount = 0;
		this.ItemName = "";
		this.IsDirect = false;
		this.PriceData = null;
		this.IfRechargeItem = false;
		this.StageImage = "";
		this.ShowStageImage = "";
		this.GetShopTipsText = null;
		this.GetIfNeedShowDownTipsText = null;
		this.GetDownTipsText = null;
		this.GetSpriteTextBgColor = null;
		this.GetTextTipsColor = null;
		this.RedDotExistFunc = null;
		this.GetDirectPriceTextFunc = null;
		this.GachaAverageCount = null;
		this.GachaPrice = null;
		this.CurrentLanguage = "";
	}

	// Token: 0x06011C33 RID: 72755 RVA: 0x004E2298 File Offset: 0x004E0498
	public void Refresh(IPayShopUnionData data)
	{
		if (this.CurrentLanguage != Singleton<LanguageSystem>.Instance.PackageLanguage)
		{
			PayShopGoods payShopGoods = data as PayShopGoods;
			if (payShopGoods != null)
			{
				this.PhraseFromPayItemData(payShopGoods);
				return;
			}
			PayItemData payItemData = data as PayItemData;
			if (payItemData != null)
			{
				this.PhrasePromPayItemData(payItemData);
			}
		}
	}

	// Token: 0x06011C34 RID: 72756 RVA: 0x004E22E0 File Offset: 0x004E04E0
	public void PhraseFromPayItemData(PayShopGoods data)
	{
		this.Quality = data.GetItemData().Quality;
		this.QualityType = data.GetItemData().QualityType;
		this.ItemId = data.GetItemData().ItemId;
		this.ItemCount = data.GetGoodsData().ItemCount;
		this.ItemName = data.GetGoodsData().GetGoodsName(Singleton<LanguageSystem>.Instance.PackageLanguage);
		this.IsDirect = data.IsDirect();
		this.Id = data.GetGoodsData().Id;
		this.OnceBuyLimitCount = data.GetGoodsData().OnceBuyLimit;
		this.StageImage = data.GetGoodsData().StageImage;
		this.ShowStageImage = data.GetGoodsData().ShowStageImage;
		this.PriceData = data.GetPriceData();
		this.GetShopTipsText = new Func<string>(data.GetShopTipsText);
		this.GetIfNeedShowDownTipsText = new Func<bool>(data.GetIfNeedShowDownTipsText);
		this.GetDownTipsText = new Func<string>(data.GetDownTipsText);
		this.GetTextTipsColor = new Func<string>(data.GetTextTipsColor);
		this.GetSpriteTextBgColor = new Func<string>(data.GetSpriteTextBgColor);
		this.GetDirectPriceTextFunc = new Func<string>(data.GetDirectPriceText);
		this.RedDotExistFunc = new Func<bool>(data.GetIfNeedRemind);
		this.CurrentLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
	}

	// Token: 0x06011C35 RID: 72757 RVA: 0x004E2438 File Offset: 0x004E0638
	public void PhrasePromPayItemData(PayItemData data)
	{
		this.Quality = data.GetQuality();
		this.QualityType = data.GetQualityType();
		this.ItemId = data.ItemId;
		this.ItemCount = data.ItemCount;
		this.StageImage = data.StageImage;
		this.ItemName = data.GetPayItemShowName();
		this.IsDirect = true;
		this.Id = data.PayItemId;
		if (this.IsDirect)
		{
			this.GetDirectPriceTextFunc = (() => data.GetDirectPriceText());
		}
		this.IfRechargeItem = true;
		this.CurrentLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		this.GachaAverageCount = new Func<double>(data.GetGachaAverageCount);
		this.GachaPrice = new Func<string>(data.GetGachaAveragePriceText);
	}

	// Token: 0x04008B09 RID: 35593
	public int Id;

	// Token: 0x04008B0A RID: 35594
	public int Quality;

	// Token: 0x04008B0B RID: 35595
	public EItemQualityType QualityType;

	// Token: 0x04008B0C RID: 35596
	public int ItemId;

	// Token: 0x04008B0D RID: 35597
	public int ItemCount;

	// Token: 0x04008B0E RID: 35598
	public string ItemName;

	// Token: 0x04008B0F RID: 35599
	public bool IsDirect;

	// Token: 0x04008B10 RID: 35600
	[Nullable(2)]
	public IPriceData PriceData;

	// Token: 0x04008B11 RID: 35601
	public bool IfRechargeItem;

	// Token: 0x04008B12 RID: 35602
	public string StageImage;

	// Token: 0x04008B13 RID: 35603
	public string ShowStageImage;

	// Token: 0x04008B14 RID: 35604
	public int OnceBuyLimitCount;

	// Token: 0x04008B15 RID: 35605
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<string> GetShopTipsText;

	// Token: 0x04008B16 RID: 35606
	[Nullable(2)]
	public Func<bool> GetIfNeedShowDownTipsText;

	// Token: 0x04008B17 RID: 35607
	[Nullable(2)]
	public Func<string> GetDownTipsText;

	// Token: 0x04008B18 RID: 35608
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<string> GetSpriteTextBgColor;

	// Token: 0x04008B19 RID: 35609
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<string> GetTextTipsColor;

	// Token: 0x04008B1A RID: 35610
	[Nullable(2)]
	public Func<bool> RedDotExistFunc;

	// Token: 0x04008B1B RID: 35611
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<string> GetDirectPriceTextFunc;

	// Token: 0x04008B1C RID: 35612
	[Nullable(2)]
	public Func<double> GachaAverageCount;

	// Token: 0x04008B1D RID: 35613
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<string> GachaPrice;

	// Token: 0x04008B1E RID: 35614
	private string CurrentLanguage;
}
