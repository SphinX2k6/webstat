using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023DA RID: 9178
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PayShopGiftItem : GridProxyAbstract<PayShopGoods>
{
	// Token: 0x06011BED RID: 72685 RVA: 0x004E0758 File Offset: 0x004DE958
	public PayShopGiftItem(EQualityPathType qualityPathType, UUIItem uiItem = null)
	{
		this.QualityPathType = qualityPathType;
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x06011BEE RID: 72686 RVA: 0x004E0788 File Offset: 0x004DE988
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.TipsClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011BEF RID: 72687 RVA: 0x004E09E4 File Offset: 0x004DEBE4
	private void ToggleClick(EToggleState toggleState)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.ToggleFunction(this.Data.GetGoodsId());
	}

	// Token: 0x06011BF0 RID: 72688 RVA: 0x004E0A0D File Offset: 0x004DEC0D
	private void TipsClick()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(this.HelpId);
	}

	// Token: 0x06011BF1 RID: 72689 RVA: 0x004E0A20 File Offset: 0x004DEC20
	protected override void OnStart()
	{
		base.GetButton(13).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x06011BF2 RID: 72690 RVA: 0x004E0A48 File Offset: 0x004DEC48
	protected void AddEventListener()
	{
		if (this.IsAddEvent)
		{
			return;
		}
		this.IsAddEvent = true;
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.RefreshPrice));
	}

	// Token: 0x06011BF3 RID: 72691 RVA: 0x004E0A76 File Offset: 0x004DEC76
	protected void RemoveEventListener()
	{
		if (!this.IsAddEvent)
		{
			return;
		}
		this.IsAddEvent = false;
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerCurrencyChange, new Action<int>(this.RefreshPrice));
	}

	// Token: 0x06011BF4 RID: 72692 RVA: 0x004E0AA4 File Offset: 0x004DECA4
	private void RefreshPrice(int itemId)
	{
		PayShopGoodsData goodsData = this.Data.GetGoodsData();
		if (goodsData.IsDirect())
		{
			return;
		}
		if (goodsData.Price.Id != itemId)
		{
			return;
		}
		this.SetPrice();
	}

	// Token: 0x06011BF5 RID: 72693 RVA: 0x004E0ADB File Offset: 0x004DECDB
	public void SetBelongViewName(EUiViewName viewName)
	{
		this.BelongViewName = new EUiViewName?(viewName);
	}

	// Token: 0x06011BF6 RID: 72694 RVA: 0x004E0AE9 File Offset: 0x004DECE9
	[NullableContext(1)]
	public void Refresh(PayShopGoods data)
	{
		this.AddEventListener();
		this.RefreshGiftItem(data);
	}

	// Token: 0x06011BF7 RID: 72695 RVA: 0x004E0AF8 File Offset: 0x004DECF8
	[NullableContext(1)]
	public void RefreshGiftItem(PayShopGoods data)
	{
		this.Data = data;
		this.RefreshState();
	}

	// Token: 0x06011BF8 RID: 72696 RVA: 0x004E0B07 File Offset: 0x004DED07
	public override void Clear()
	{
		this.RemoveEventListener();
		this.RemoveSellTimer();
		this.RemoveDiscountTimer();
	}

	// Token: 0x06011BF9 RID: 72697 RVA: 0x004E0B1B File Offset: 0x004DED1B
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
		this.RemoveSellTimer();
		this.RemoveDiscountTimer();
		Singleton<LguiResourceManager>.Instance.CancelLoadPrefab(this.DebugTextLoadId);
	}

	// Token: 0x06011BFA RID: 72698 RVA: 0x004E0B40 File Offset: 0x004DED40
	protected void RefreshState()
	{
		CSharpScript.Game.Module.PayShop.IItemData itemData = this.Data.GetItemData();
		this.SetQuality(itemData.Quality);
		this.SetIcon();
		this.SetTips();
		this.SetPrice();
		this.SetDiscountTime();
		this.SetSellTime();
		this.SetName(itemData.Name);
		this.ShowDebugText();
	}

	// Token: 0x06011BFB RID: 72699 RVA: 0x004E0B98 File Offset: 0x004DED98
	protected void SetQuality(int quality)
	{
		QualityInfo value = ConfigBase<ItemConfig>.Instance.GetQualityConfig(quality).Value;
		string path = value.PayShopTexture;
		if (this.QualityPathType == EQualityPathType.PathType2)
		{
			path = value.NewPayShopTexture;
		}
		base.SetTextureByPath(path, base.GetTexture(2), null, null);
	}

	// Token: 0x06011BFC RID: 72700 RVA: 0x004E0BEC File Offset: 0x004DEDEC
	protected void SetIcon()
	{
		UUITexture texture = base.GetTexture(1);
		base.SetItemIcon(texture, this.Data.GetItemData().ItemId, this.BelongViewName, null);
	}

	// Token: 0x06011BFD RID: 72701 RVA: 0x004E0C20 File Offset: 0x004DEE20
	protected void SetTips()
	{
		this.RootItem.SetAlpha(1f);
		UUIText text = base.GetText(4);
		if (this.Data.IsLocked())
		{
			string conditionTextId = this.Data.GetConditionTextId();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, conditionTextId, Array.Empty<object>());
			text.SetUIActive(true);
			this.RootItem.SetAlpha(0.6f);
			return;
		}
		if (!this.Data.IsLimitGoods())
		{
			text.SetUIActive(false);
			return;
		}
		text.SetUIActive(true);
		if (this.Data.IsSoldOut())
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "SoldoutText", Array.Empty<object>());
			this.RootItem.SetAlpha(0.6f);
			return;
		}
		IRemainingData remainingData = this.Data.GetRemainingData();
		Singleton<LguiUtil>.Instance.SetLocalText(text, remainingData.TextId, new <>z__ReadOnlySingleElementList<object>(remainingData.Count));
	}

	// Token: 0x06011BFE RID: 72702 RVA: 0x004E0D04 File Offset: 0x004DEF04
	protected void SetPrice()
	{
		UUIText text = base.GetText(7);
		UUITexture texture = base.GetTexture(5);
		UUIText text2 = base.GetText(6);
		if (this.Data.IsDirect())
		{
			text.SetUIActive(false);
			texture.SetUIActive(false);
			string directPriceText = this.Data.GetDirectPriceText();
			text2.SetText(directPriceText, true);
			return;
		}
		texture.SetUIActive(true);
		IPriceData priceData = this.Data.GetPriceData();
		if (priceData.OriginalPrice == null)
		{
			text.SetUIActive(false);
		}
		else
		{
			text.SetUIActive(true);
			text.SetText("<s>" + priceData.OriginalPrice.ToString() + "</s>", true);
		}
		text2.SetText(priceData.NowPrice.ToString(), true);
		UUIItem uuiitem = text2;
		bool bUseChangeColor = priceData.OwnNumber() < priceData.NowPrice;
		FColor? fcolor = new FColor?(text2.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		base.SetItemIcon(texture, priceData.CurrencyId, null, null);
	}

	// Token: 0x06011BFF RID: 72703 RVA: 0x004E0E10 File Offset: 0x004DF010
	protected void SetDiscountTime()
	{
		this.RemoveDiscountTimer();
		UUIItem item = base.GetItem(8);
		UUIText text = base.GetText(10);
		UUIItem item2 = base.GetItem(9);
		if (!this.Data.HasDiscount())
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		bool flag = this.Data.IsPermanentDiscount();
		item2.SetUIActive(!flag);
		text.SetText("-" + this.Data.GetDiscount().ToString() + "%", true);
		if (!flag)
		{
			CommonDefine.IRemainTime discountRemainTime = this.Data.GetDiscountRemainTime();
			this.DiscountTimerId = TimerSystem.RealTimeInstance.Delay(new TTimerAction(this.RefreshDiscountTime), (float)discountRemainTime.RemainingTime * 1000f, null, null, true, 1f);
		}
	}

	// Token: 0x06011C00 RID: 72704 RVA: 0x004E0EDB File Offset: 0x004DF0DB
	private void RefreshDiscountTime(float _)
	{
		this.DiscountTimerId = null;
		this.SetDiscountTime();
		if (!this.Data.HasDiscount())
		{
			this.SetPrice();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.GoodsRefreshDiscountTime, this.Data.GetGoodsId());
		}
	}

	// Token: 0x06011C01 RID: 72705 RVA: 0x004E0F18 File Offset: 0x004DF118
	protected void SetSellTime()
	{
		this.RemoveSellTimer();
		UUIItem item = base.GetItem(12);
		if (this.Data.IsPermanentSell())
		{
			item.SetUIActive(false);
			return;
		}
		if (!this.Data.InSellTime())
		{
			return;
		}
		CommonDefine.IPayShowCountDownRemainTime endTimeRemainData = this.Data.GetEndTimeRemainData();
		UUIText text = base.GetText(11);
		item.SetUIActive(true);
		CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = endTimeRemainData as CommonDefine.PayShowCountDownRemainTime<string>;
		if (payShowCountDownRemainTime != null)
		{
			text.SetText(payShowCountDownRemainTime.Value, true);
			return;
		}
		CommonDefine.IRemainTime remainTime = endTimeRemainData as CommonDefine.IRemainTime;
		if (remainTime != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue));
			this.SellTimerId = TimerSystem.RealTimeInstance.Delay(delegate(float _)
			{
				this.SellTimerId = null;
				this.SetSellTime();
			}, (float)remainTime.RemainingTime * 1000f, null, null, true, 1f);
		}
	}

	// Token: 0x06011C02 RID: 72706 RVA: 0x004E0FEC File Offset: 0x004DF1EC
	[NullableContext(1)]
	protected void SetName(string name)
	{
		UUIText text = base.GetText(3);
		PayShopGoodsData goodsData = this.Data.GetGoodsData();
		if (goodsData.ItemCount > 1)
		{
			TableTextArgNew tableTextArgNew = new TableTextArgNew(name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(text, "GoodsName", new <>z__ReadOnlyArray<object>(new object[]
			{
				tableTextArgNew,
				goodsData.ItemCount
			}));
			return;
		}
		text.ShowTextNew(name);
	}

	// Token: 0x06011C03 RID: 72707 RVA: 0x004E1058 File Offset: 0x004DF258
	protected void ShowDebugText()
	{
		if (!GlobalData.IsPlayInEditor)
		{
			return;
		}
		if (this.DebugText == null)
		{
			Singleton<LguiResourceManager>.Instance.CancelLoadPrefab(this.DebugTextLoadId);
			this.DebugTextLoadId = Singleton<LguiResourceManager>.Instance.LoadPrefabByResourceId("UiItem_DebugText_Prefab", this.RootItem, delegate([Nullable(2)] AActor actor, string str, ELguiLoadResultType ELguiLoadResultType)
			{
				this.DebugTextLoadId = Singleton<LguiResourceManager>.Instance.InvalidId;
				this.DebugText = (actor.GetComponentByClass(UUIText.StaticClass()) as UUIText);
				UUIText debugText2 = this.DebugText;
				if (debugText2 == null)
				{
					return;
				}
				debugText2.SetText(this.Data.GetGoodsId().ToString(), true);
			}, "js_undefined");
			return;
		}
		UUIText debugText = this.DebugText;
		if (debugText == null)
		{
			return;
		}
		debugText.SetText(this.Data.GetGoodsId().ToString(), true);
	}

	// Token: 0x06011C04 RID: 72708 RVA: 0x004E10D6 File Offset: 0x004DF2D6
	protected void RemoveSellTimer()
	{
		if (this.SellTimerId != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.SellTimerId);
			this.SellTimerId = null;
		}
	}

	// Token: 0x06011C05 RID: 72709 RVA: 0x004E10F8 File Offset: 0x004DF2F8
	protected void RemoveDiscountTimer()
	{
		if (this.DiscountTimerId != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.DiscountTimerId);
			this.DiscountTimerId = null;
		}
	}

	// Token: 0x06011C06 RID: 72710 RVA: 0x004E111A File Offset: 0x004DF31A
	[NullableContext(1)]
	public void SetToggleFunction(Action<int> callBack)
	{
		this.ToggleFunction = callBack;
	}

	// Token: 0x06011C07 RID: 72711 RVA: 0x004E1124 File Offset: 0x004DF324
	public void SetTipsIdAndShowTipsButton(int helpId)
	{
		base.GetButton(13).RootUIComp.Get().SetUIActive(true);
		this.HelpId = helpId;
	}

	// Token: 0x04008AE2 RID: 35554
	private const float SOLDOUT_ALPHA = 0.6f;

	// Token: 0x04008AE3 RID: 35555
	protected PayShopGoods Data;

	// Token: 0x04008AE4 RID: 35556
	protected TimerHandle SellTimerId;

	// Token: 0x04008AE5 RID: 35557
	protected TimerHandle DiscountTimerId;

	// Token: 0x04008AE6 RID: 35558
	protected Action<int> ToggleFunction;

	// Token: 0x04008AE7 RID: 35559
	private UUIText DebugText;

	// Token: 0x04008AE8 RID: 35560
	private bool IsAddEvent;

	// Token: 0x04008AE9 RID: 35561
	private int HelpId;

	// Token: 0x04008AEA RID: 35562
	private readonly EQualityPathType QualityPathType;

	// Token: 0x04008AEB RID: 35563
	private EUiViewName? BelongViewName;

	// Token: 0x04008AEC RID: 35564
	private int DebugTextLoadId = Singleton<LguiResourceManager>.Instance.InvalidId;

	// Token: 0x02008712 RID: 34578
	[NullableContext(0)]
	private class EPayShopGiftItemDefine
	{
		// Token: 0x0402DAF1 RID: 187121
		public const int Toggle = 0;

		// Token: 0x0402DAF2 RID: 187122
		public const int GiftIcon = 1;

		// Token: 0x0402DAF3 RID: 187123
		public const int GiftQuality = 2;

		// Token: 0x0402DAF4 RID: 187124
		public const int GiftName = 3;

		// Token: 0x0402DAF5 RID: 187125
		public const int TipsText = 4;

		// Token: 0x0402DAF6 RID: 187126
		public const int CurrencyIcon = 5;

		// Token: 0x0402DAF7 RID: 187127
		public const int CurrencyNowPrice = 6;

		// Token: 0x0402DAF8 RID: 187128
		public const int CurrencyOriginalPrice = 7;

		// Token: 0x0402DAF9 RID: 187129
		public const int DiscountTimeItem = 8;

		// Token: 0x0402DAFA RID: 187130
		public const int DiscountTimeIconItem = 9;

		// Token: 0x0402DAFB RID: 187131
		public const int DiscountTimeText = 10;

		// Token: 0x0402DAFC RID: 187132
		public const int SellTimeText = 11;

		// Token: 0x0402DAFD RID: 187133
		public const int SellTimeItem = 12;

		// Token: 0x0402DAFE RID: 187134
		public const int TipsButton = 13;
	}
}
