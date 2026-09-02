using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023E0 RID: 9184
[NullableContext(1)]
[Nullable(0)]
public class PayShopItemBase : UiPanelBase
{
	// Token: 0x06011C36 RID: 72758 RVA: 0x004E2530 File Offset: 0x004E0730
	public PayShopItemBase(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
		this.Data = null;
		this.SetNameState = false;
		this.HandleId = -1;
		this.CachePriceData = null;
		this.CurrentPriceColor = "";
		this.LeftTimeTextShowOnceBuy = false;
		this.LeftTimeTextShowState = true;
		this.RefreshRedDotState = true;
	}

	// Token: 0x06011C37 RID: 72759 RVA: 0x004E2586 File Offset: 0x004E0786
	public void Init()
	{
		base.SetRootActor(this.SourceItem.GetOwner(), true);
	}

	// Token: 0x06011C38 RID: 72760 RVA: 0x004E259C File Offset: 0x004E079C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.TipsClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011C39 RID: 72761 RVA: 0x004E27D4 File Offset: 0x004E09D4
	private void TipsClick()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(9);
	}

	// Token: 0x06011C3A RID: 72762 RVA: 0x004E27E2 File Offset: 0x004E09E2
	public void SetDownPriceShowState(bool state)
	{
		base.GetSprite(1).SetUIActive(state);
		base.GetItem(6).SetUIActive(state);
		base.GetText(10).SetUIActive(state);
	}

	// Token: 0x06011C3B RID: 72763 RVA: 0x004E280C File Offset: 0x004E0A0C
	public void SetDownPriceOnlyShow(bool state)
	{
		base.GetSprite(1).SetUIActive(state);
		base.GetItem(6).SetUIActive(state);
		base.GetText(10).SetUIActive(!state);
	}

	// Token: 0x06011C3C RID: 72764 RVA: 0x004E2839 File Offset: 0x004E0A39
	public void OnTimerRefresh(PayShopItemBaseSt data, bool isSelected, int gridIndex)
	{
		if (this.Data == null || this.Data.Id != data.Id)
		{
			this.SetNameState = false;
		}
		this.Data = data;
		this.RefreshTimeConnectInfo();
	}

	// Token: 0x06011C3D RID: 72765 RVA: 0x004E286C File Offset: 0x004E0A6C
	public void Refresh(PayShopItemBaseSt data, bool isSelected, int gridIndex)
	{
		if (this.Data == null || this.Data.Id != data.Id)
		{
			this.SetNameState = false;
		}
		this.Data = data;
		this.LeftTimeTextShowState = true;
		this.RefreshQualityTexture();
		this.RefreshTexture();
		this.RefreshShopItemName();
		this.RefreshPriceIcon();
		this.RefreshTipsButton();
		this.RefreshNormalItemBg();
		this.RefreshTimeConnectInfo();
	}

	// Token: 0x06011C3E RID: 72766 RVA: 0x004E28D3 File Offset: 0x004E0AD3
	private void RefreshTimeConnectInfo()
	{
		this.OriginalPriceText();
		this.RefreshPrice();
		this.RefreshLeftTimeText();
		this.RefreshDownTextTipsColor();
		this.RefreshRedDot();
	}

	// Token: 0x06011C3F RID: 72767 RVA: 0x004E28F3 File Offset: 0x004E0AF3
	protected override void OnBeforeDestroy()
	{
		this.CancelLoad();
	}

	// Token: 0x06011C40 RID: 72768 RVA: 0x004E28FC File Offset: 0x004E0AFC
	private void RefreshDownTextTipsColor()
	{
		if (this.Data.GetTextTipsColor == null)
		{
			return;
		}
		string hexStr = this.Data.GetTextTipsColor();
		base.GetText(10).SetColor(FColor.FromHex(hexStr));
	}

	// Token: 0x06011C41 RID: 72769 RVA: 0x004E293C File Offset: 0x004E0B3C
	private void RefreshTipsButton()
	{
		int monthCardShopId = ConfigBase<PayShopConfig>.Instance.GetMonthCardShopId();
		base.GetButton(3).RootUIComp.Get().SetUIActive(this.Data.Id == monthCardShopId);
	}

	// Token: 0x06011C42 RID: 72770 RVA: 0x004E297C File Offset: 0x004E0B7C
	private void RefreshQualityTexture()
	{
		string payShopItemQualitySpriteByItemIdAndQuality = ModelBase<PayShopModel>.Instance.GetPayShopItemQualitySpriteByItemIdAndQuality(this.Data.ItemId, this.Data.Quality);
		this.SetSpriteByPath(payShopItemQualitySpriteByItemIdAndQuality, base.GetSprite(0), false, null, null);
	}

	// Token: 0x06011C43 RID: 72771 RVA: 0x004E29C4 File Offset: 0x004E0BC4
	private void RefreshTexture()
	{
		UUITexture texture = base.GetTexture(2);
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.Data.ItemId));
		if (this.Data.IfRechargeItem)
		{
			texture.SetUIActive(false);
			texture = base.GetTexture(12);
			texture.SetUIActive(true);
			string stageImage = this.Data.StageImage;
			base.SetTextureByPath(stageImage, texture, null, null);
			return;
		}
		if (this.Data.ShowStageImage != "")
		{
			string showStageImage = this.Data.ShowStageImage;
			base.SetTextureByPath(showStageImage, texture, null, null);
			return;
		}
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleItem)
		{
			base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.Data.ItemId).Value.Card, texture, this.Data.ItemId, null, null);
		}
		else
		{
			base.SetItemIcon(texture, this.Data.ItemId, null, null);
		}
		this.CancelLoad();
		this.StartLoad();
	}

	// Token: 0x06011C44 RID: 72772 RVA: 0x004E2AE0 File Offset: 0x004E0CE0
	private void CancelLoad()
	{
		if (this.HandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
			this.HandleId = -1;
		}
	}

	// Token: 0x06011C45 RID: 72773 RVA: 0x004E2B04 File Offset: 0x004E0D04
	private void StartLoad()
	{
		int itemDataTypeByConfigId = (int)ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.Data.ItemId));
		UUITexture giftIcon = base.GetTexture(2);
		if (itemDataTypeByConfigId == 3)
		{
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string path = (instance != null) ? instance.GetResourcePath("MI_HeadYuan") : null;
			this.HandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInterface>(path, delegate([Nullable(2)] UMaterialInterface materialInterface, string _)
			{
				giftIcon.SetCustomUIMaterial(materialInterface);
			}, 102, "js_undefined");
			return;
		}
		giftIcon.SetCustomUIMaterial(null);
	}

	// Token: 0x06011C46 RID: 72774 RVA: 0x004E2B89 File Offset: 0x004E0D89
	private void RefreshShopItemName()
	{
		if (!this.SetNameState)
		{
			base.GetText(5).SetText(this.Data.ItemName, true);
			this.SetNameState = true;
		}
	}

	// Token: 0x06011C47 RID: 72775 RVA: 0x004E2BB4 File Offset: 0x004E0DB4
	private void RefreshPriceIcon()
	{
		UUITexture texture = base.GetTexture(7);
		if (this.Data.IsDirect)
		{
			texture.SetUIActive(false);
			return;
		}
		IPriceData priceData = this.Data.PriceData;
		if (priceData.NowPrice == 0)
		{
			texture.SetUIActive(false);
			return;
		}
		texture.SetUIActive(true);
		base.SetItemIcon(texture, priceData.CurrencyId, null, null);
	}

	// Token: 0x06011C48 RID: 72776 RVA: 0x004E2C18 File Offset: 0x004E0E18
	private void OriginalPriceText()
	{
		UUIText text = base.GetText(9);
		if (this.Data.IsDirect)
		{
			text.SetUIActive(false);
			return;
		}
		IPriceData priceData = this.Data.PriceData;
		if (priceData.OriginalPrice == null || !priceData.InDiscountTime)
		{
			text.SetUIActive(false);
			return;
		}
		text.SetUIActive(true);
		text.SetText("<s>" + priceData.OriginalPrice.ToString() + "</s>", true);
	}

	// Token: 0x06011C49 RID: 72777 RVA: 0x004E2CA0 File Offset: 0x004E0EA0
	private void RefreshPrice()
	{
		string text = "F9FFFFFF";
		if (!this.Data.IsDirect && this.Data.PriceData.OwnNumber() < this.Data.PriceData.NowPrice)
		{
			text = "F55E66FF";
		}
		if (this.CachePriceData != null && this.CachePriceData == this.Data.PriceData && this.CurrentPriceColor == text)
		{
			return;
		}
		this.CurrentPriceColor = text;
		PayShopItemBaseSt data = this.Data;
		this.CachePriceData = ((data != null) ? data.PriceData : null);
		UUIText text2 = base.GetText(8);
		if (this.Data.IsDirect)
		{
			Func<string> getDirectPriceTextFunc = this.Data.GetDirectPriceTextFunc;
			string text3 = (getDirectPriceTextFunc != null) ? getDirectPriceTextFunc() : null;
			if (text3 != null)
			{
				string newText = text3;
				text2.SetText(newText, true);
				text2.SetColor(FColor.FromHex(text));
			}
			return;
		}
		IPriceData priceData = this.Data.PriceData;
		if (priceData.NowPrice == 0)
		{
			text2.ShowTextNew("ShopDiscountLabel_4");
		}
		else
		{
			text2.SetText(priceData.NowPrice.ToString(), true);
		}
		string hexStr = text;
		text2.SetColor(FColor.FromHex(hexStr));
	}

	// Token: 0x06011C4A RID: 72778 RVA: 0x004E2DC8 File Offset: 0x004E0FC8
	private void RefreshLeftTimeText()
	{
		Func<string> getShopTipsText = this.Data.GetShopTipsText;
		string text = (getShopTipsText != null) ? getShopTipsText() : null;
		UUIText text2 = base.GetText(4);
		if (this.LeftTimeTextShowOnceBuy && this.Data.OnceBuyLimitCount > 0)
		{
			text2.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "SingleBuyLimit", new <>z__ReadOnlySingleElementList<object>(this.Data.OnceBuyLimitCount));
			return;
		}
		if (this.LeftTimeTextShowState && !StringUtils.IsEmpty(text))
		{
			text2.SetUIActive(true);
			text2.SetText(text, true);
			return;
		}
		text2.SetUIActive(false);
	}

	// Token: 0x06011C4B RID: 72779 RVA: 0x004E2E60 File Offset: 0x004E1060
	public void SetLeftTimeTextShowOnceBuy(bool state)
	{
		this.LeftTimeTextShowOnceBuy = state;
		if (this.Data != null)
		{
			int onceBuyLimitCount = this.Data.OnceBuyLimitCount;
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetUIActive(this.LeftTimeTextShowOnceBuy && onceBuyLimitCount > 0);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "SingleBuyLimit", new <>z__ReadOnlySingleElementList<object>(onceBuyLimitCount));
		}
	}

	// Token: 0x06011C4C RID: 72780 RVA: 0x004E2EC4 File Offset: 0x004E10C4
	public void SetLeftTimeTextShowState(bool state)
	{
		this.LeftTimeTextShowState = state;
		if (this.Data != null && !this.LeftTimeTextShowOnceBuy)
		{
			Func<string> getShopTipsText = this.Data.GetShopTipsText;
			string content = (getShopTipsText != null) ? getShopTipsText() : null;
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(this.LeftTimeTextShowState && !StringUtils.IsEmpty(content));
		}
	}

	// Token: 0x06011C4D RID: 72781 RVA: 0x004E2F25 File Offset: 0x004E1125
	public void SetNameTextShowState(bool state)
	{
		base.GetText(5).SetUIActive(state);
	}

	// Token: 0x06011C4E RID: 72782 RVA: 0x004E2F34 File Offset: 0x004E1134
	public void SetRedDotVisible(bool state)
	{
		base.GetItem(11).SetUIActive(state);
	}

	// Token: 0x06011C4F RID: 72783 RVA: 0x004E2F44 File Offset: 0x004E1144
	public void RefreshRedDot()
	{
		if (this.RefreshRedDotState && this.Data.RedDotExistFunc != null)
		{
			this.SetRedDotVisible(this.Data.RedDotExistFunc());
		}
	}

	// Token: 0x06011C50 RID: 72784 RVA: 0x004E2F71 File Offset: 0x004E1171
	private void RefreshNormalItemBg()
	{
		UUIItem item = base.GetItem(13);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!this.Data.IfRechargeItem);
	}

	// Token: 0x04008B1F RID: 35615
	[Nullable(2)]
	private PayShopItemBaseSt Data;

	// Token: 0x04008B20 RID: 35616
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x04008B21 RID: 35617
	private bool SetNameState;

	// Token: 0x04008B22 RID: 35618
	private int HandleId;

	// Token: 0x04008B23 RID: 35619
	[Nullable(2)]
	private IPriceData CachePriceData;

	// Token: 0x04008B24 RID: 35620
	private string CurrentPriceColor;

	// Token: 0x04008B25 RID: 35621
	private bool LeftTimeTextShowState;

	// Token: 0x04008B26 RID: 35622
	private bool LeftTimeTextShowOnceBuy;

	// Token: 0x04008B27 RID: 35623
	public bool RefreshRedDotState;

	// Token: 0x02008718 RID: 34584
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402DB1B RID: 187163
		public const int QualitySprite = 0;

		// Token: 0x0402DB1C RID: 187164
		public const int DownBgSprite = 1;

		// Token: 0x0402DB1D RID: 187165
		public const int Texture = 2;

		// Token: 0x0402DB1E RID: 187166
		public const int TipsButton = 3;

		// Token: 0x0402DB1F RID: 187167
		public const int LeftTimeText = 4;

		// Token: 0x0402DB20 RID: 187168
		public const int NameText = 5;

		// Token: 0x0402DB21 RID: 187169
		public const int PriceItem = 6;

		// Token: 0x0402DB22 RID: 187170
		public const int PriceIcon = 7;

		// Token: 0x0402DB23 RID: 187171
		public const int PriceText = 8;

		// Token: 0x0402DB24 RID: 187172
		public const int SourcePriceText = 9;

		// Token: 0x0402DB25 RID: 187173
		public const int PriceTipsText = 10;

		// Token: 0x0402DB26 RID: 187174
		public const int RedDot = 11;

		// Token: 0x0402DB27 RID: 187175
		public const int RechargeTexture = 12;

		// Token: 0x0402DB28 RID: 187176
		public const int NormalItemBg = 13;
	}
}
