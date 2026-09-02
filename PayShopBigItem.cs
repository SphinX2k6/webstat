using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020023D5 RID: 9173
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PayShopBigItem : GridProxyAbstract<IPayShopUnionData>
{
	// Token: 0x06011BC0 RID: 72640 RVA: 0x004DEFB8 File Offset: 0x004DD1B8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 26;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickExplainBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickItem));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011BC1 RID: 72641 RVA: 0x004DF3AB File Offset: 0x004DD5AB
	protected override void OnStart()
	{
		base.GetButton(0).SetCanClickWhenDisable(true);
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		base.GetTexture(14).SetUIActive(false);
	}

	// Token: 0x06011BC2 RID: 72642 RVA: 0x004DF3DC File Offset: 0x004DD5DC
	public void SetOnClickRechargeCallback(Action<PayItemData> callback)
	{
		this.OnClickRechargeCallback = callback;
	}

	// Token: 0x06011BC3 RID: 72643 RVA: 0x004DF3E5 File Offset: 0x004DD5E5
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011BC4 RID: 72644 RVA: 0x004DF420 File Offset: 0x004DD620
	[NullableContext(2)]
	public override void Refresh(IPayShopUnionData data, bool isSelected, int gridIndex)
	{
		if (data == null)
		{
			return;
		}
		this.Data = data;
		PayShopGoods payShopGoods = data as PayShopGoods;
		if (payShopGoods != null)
		{
			this.DataSt = payShopGoods.ConvertToPayShopBaseSt();
			ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = payShopGoods.GetCountDownData();
			this.CurrentCountDownState = (countDownData.Item3 != 0.0);
			this.CountDownType = countDownData.Item1;
			this.CurrentDiscountItemState = payShopGoods.HasDiscount();
			this.CurrentDiscountValue = payShopGoods.GetDiscountNew();
		}
		else
		{
			PayItemData payItemData = data as PayItemData;
			if (payItemData != null)
			{
				this.DataSt = ModelBase<PayItemModel>.Instance.ConvertPayItemDataToPayShopItemBaseSt(payItemData);
			}
		}
		base.GetText(3).SetText(this.DataSt.ItemName, true);
		UUITexture texture = base.GetTexture(2);
		if (this.DataSt.StageImage != "")
		{
			string stageImage = this.DataSt.StageImage;
			base.SetTextureByPath(stageImage, texture, null, null);
		}
		else
		{
			base.SetItemIcon(texture, this.DataSt.ItemId, null, null);
		}
		this.RefreshQualityTexture(this.DataSt.Quality, this.DataSt.QualityType);
		this.RefreshEffect(this.DataSt.Quality, this.DataSt.QualityType);
		int monthCardShopId = ConfigBase<PayShopConfig>.Instance.GetMonthCardShopId();
		base.GetButton(7).RootUIComp.Get().SetUIActive(this.DataSt.Id == monthCardShopId);
		UUITexture texture2 = base.GetTexture(13);
		IPriceData priceData = this.DataSt.PriceData;
		if (this.DataSt.IsDirect || priceData.NowPrice == 0)
		{
			texture2.SetUIActive(false);
		}
		else
		{
			texture2.SetUIActive(true);
			base.SetItemIcon(texture2, priceData.CurrencyId, null, null);
		}
		this.RefreshOriginalPriceText();
		this.RefreshPrice();
		this.RefreshGachaDescItem();
		this.RefreshLeftTimesText();
		this.RefreshRedDot();
		this.RefreshCommonItem();
		this.RefreshRechargeItem();
	}

	// Token: 0x06011BC5 RID: 72645 RVA: 0x004DF618 File Offset: 0x004DD818
	private void RefreshQualityTexture(int quality, EItemQualityType qualityType)
	{
		QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(quality);
		string path;
		string path2;
		string hexStr;
		if (qualityType == EItemQualityType.Item)
		{
			path = qualityConfig.Value.PayShopQualityTexture;
			path2 = qualityConfig.Value.PayShopQualityLightTexture;
			hexStr = qualityConfig.Value.PayShopLineColor;
		}
		else
		{
			path = qualityConfig.Value.PayShopItemQualityTexture;
			path2 = qualityConfig.Value.PayShopItemQualityLightTexture;
			hexStr = qualityConfig.Value.PayShopItemLineColor;
		}
		base.SetTextureByPath(path, base.GetTexture(1), null, null);
		base.SetTextureByPath(path2, base.GetTexture(19), null, null);
		base.GetTexture(18).SetColor(FColor.FromHex(hexStr));
	}

	// Token: 0x06011BC6 RID: 72646 RVA: 0x004DF6F4 File Offset: 0x004DD8F4
	public void RefreshCommonItem()
	{
		if (this.Data == null || this.Data is PayItemData)
		{
			return;
		}
		this.RefreshCommonItemTag((PayShopGoods)this.Data);
		this.RefreshShopItemState((PayShopGoods)this.Data);
		this.RefreshDiscount((PayShopGoods)this.Data);
		this.RefreshCountDown((PayShopGoods)this.Data);
		this.RefreshTotalScoreTagForGoods((PayShopGoods)this.Data);
	}

	// Token: 0x06011BC7 RID: 72647 RVA: 0x004DF76C File Offset: 0x004DD96C
	public void RefreshRechargeItem()
	{
		if (this.Data == null || this.Data is PayShopGoods)
		{
			return;
		}
		this.RefreshRechargeItemTag((PayItemData)this.Data);
		this.RefreshTotalScoreTagForItem((PayItemData)this.Data);
	}

	// Token: 0x06011BC8 RID: 72648 RVA: 0x004DF7A8 File Offset: 0x004DD9A8
	private void RefreshDiscount(PayShopGoods data)
	{
		PayShopBigItem.<>c__DisplayClass25_0 CS$<>8__locals1 = new PayShopBigItem.<>c__DisplayClass25_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.data = data;
		if (this.CurrentTagType != 0)
		{
			PayShopTagItem payShopTagItem;
			if (this.TagItemMap.TryGetValue(PayShopDefine.EPayShopTagType.Discount, out payShopTagItem) && payShopTagItem != null)
			{
				payShopTagItem.SetUiActive(false);
			}
			return;
		}
		bool isVisible = CS$<>8__locals1.data.HasDiscount();
		this.SetTagVisible(PayShopDefine.EPayShopTagType.Discount, isVisible, new Action(CS$<>8__locals1.<RefreshDiscount>g__callback|0), true);
	}

	// Token: 0x06011BC9 RID: 72649 RVA: 0x004DF80F File Offset: 0x004DDA0F
	private void RefreshTotalScoreTagForGoods(PayShopGoods data)
	{
		this.SetTagVisible(PayShopDefine.EPayShopTagType.TotalTopUp, data.GetIfShowTotalTopUpScore(), new Action(PayShopBigItem.<RefreshTotalScoreTagForGoods>g__callback|26_0), true);
	}

	// Token: 0x06011BCA RID: 72650 RVA: 0x004DF82C File Offset: 0x004DDA2C
	private void RefreshTotalScoreTagForItem(PayItemData data)
	{
		this.SetTagVisible(PayShopDefine.EPayShopTagType.TotalTopUp, data.GetIfShowTotalTopUpScore(), new Action(PayShopBigItem.<RefreshTotalScoreTagForItem>g__callback|27_0), true);
	}

	// Token: 0x06011BCB RID: 72651 RVA: 0x004DF84C File Offset: 0x004DDA4C
	private void RefreshCountDown(PayShopGoods data)
	{
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = data.GetCountDownData();
		this.CountDownType = countDownData.Item1;
		CommonDefine.IPayShowCountDownRemainTime item = countDownData.Item2;
		if (countDownData.Item3 == 0.0)
		{
			base.GetItem(9).SetUIActive(false);
			base.GetTexture(14).SetUIActive(false);
			return;
		}
		this.SetCountDownText(item);
	}

	// Token: 0x06011BCC RID: 72652 RVA: 0x004DF8A8 File Offset: 0x004DDAA8
	private void SetCountDownText(CommonDefine.IPayShowCountDownRemainTime countDownTime)
	{
		base.GetItem(9).SetUIActive(true);
		base.GetTexture(14).SetUIActive(true);
		UUIText text = base.GetText(10);
		CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = countDownTime as CommonDefine.PayShowCountDownRemainTime<string>;
		if (payShowCountDownRemainTime != null)
		{
			text.SetText(payShowCountDownRemainTime.Value, true);
			return;
		}
		CommonDefine.PayShowCountDownRemainTime<CommonDefine.RemainTime> payShowCountDownRemainTime2 = countDownTime as CommonDefine.PayShowCountDownRemainTime<CommonDefine.RemainTime>;
		if (payShowCountDownRemainTime2 != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, payShowCountDownRemainTime2.Value.TextId, new <>z__ReadOnlySingleElementList<object>(payShowCountDownRemainTime2.Value.TimeValue));
		}
	}

	// Token: 0x06011BCD RID: 72653 RVA: 0x004DF928 File Offset: 0x004DDB28
	private void RefreshShopItemState(PayShopGoods data)
	{
		PayShopBigItem.<>c__DisplayClass30_0 CS$<>8__locals1 = new PayShopBigItem.<>c__DisplayClass30_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.data = data;
		bool isVisible = CS$<>8__locals1.data.IsLimitGoods() && CS$<>8__locals1.data.IsSoldOut();
		this.SetTagVisible(PayShopDefine.EPayShopTagType.SoldOut, isVisible, new Action(CS$<>8__locals1.<RefreshShopItemState>g__callback|0), false);
		bool isVisible2 = !CS$<>8__locals1.data.IfCanBuy();
		this.SetTagVisible(PayShopDefine.EPayShopTagType.Lock, isVisible2, new Action(CS$<>8__locals1.<RefreshShopItemState>g__callback2|1), false);
	}

	// Token: 0x06011BCE RID: 72654 RVA: 0x004DF9A0 File Offset: 0x004DDBA0
	private void RefreshCommonItemTag(PayShopGoods data)
	{
		PayShopBigItem.<>c__DisplayClass31_0 CS$<>8__locals1 = new PayShopBigItem.<>c__DisplayClass31_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.data = data;
		CS$<>8__locals1.tagId = CS$<>8__locals1.data.GetDiscountLabel();
		if (this.CurrentTagType != CS$<>8__locals1.tagId)
		{
			this.SetTagVisible((PayShopDefine.EPayShopTagType)this.CurrentTagType, false, delegate
			{
			}, true);
			this.CurrentTagType = CS$<>8__locals1.tagId;
		}
		bool isVisible = CS$<>8__locals1.tagId > 0 && CS$<>8__locals1.data.InLabelShowTime();
		this.SetTagVisible((PayShopDefine.EPayShopTagType)this.CurrentTagType, isVisible, new Action(CS$<>8__locals1.<RefreshCommonItemTag>g__callback|1), true);
	}

	// Token: 0x06011BCF RID: 72655 RVA: 0x004DFA4C File Offset: 0x004DDC4C
	private void RefreshRechargeItemTag(PayItemData data)
	{
		PayShopBigItem.<>c__DisplayClass32_0 CS$<>8__locals1 = new PayShopBigItem.<>c__DisplayClass32_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.data = data;
		bool canSpecialBonus = CS$<>8__locals1.data.CanSpecialBonus;
		this.SetTagVisible(PayShopDefine.EPayShopTagType.RechargeGiven, canSpecialBonus, new Action(CS$<>8__locals1.<RefreshRechargeItemTag>g__callback|0), true);
		bool isVisible = CS$<>8__locals1.data.BonusItemCount > 0 && !canSpecialBonus;
		this.SetTagVisible(PayShopDefine.EPayShopTagType.RechargeDouble, isVisible, new Action(CS$<>8__locals1.<RefreshRechargeItemTag>g__callback2|1), true);
	}

	// Token: 0x06011BD0 RID: 72656 RVA: 0x004DFABC File Offset: 0x004DDCBC
	private void RefreshGachaDescItem()
	{
		if (!ModelBase<PayShopModel>.Instance.BusinessCompliance)
		{
			base.GetItem(15).SetUIActive(false);
			return;
		}
		double num = (this.DataSt.GachaAverageCount != null) ? this.DataSt.GachaAverageCount() : 0.0;
		bool flag = num > 0.0;
		base.GetItem(15).SetUIActive(flag);
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "DisclaimerNumText", new <>z__ReadOnlySingleElementList<object>(num.ToString()));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), "DisclaimerText", new <>z__ReadOnlySingleElementList<object>((this.DataSt.GachaPrice != null) ? this.DataSt.GachaPrice() : ""));
		}
	}

	// Token: 0x06011BD1 RID: 72657 RVA: 0x004DFB90 File Offset: 0x004DDD90
	private void SetTagVisible(PayShopDefine.EPayShopTagType tagType, bool isVisible, Action callback, bool inLeftTop = true)
	{
		PayShopTagItem payShopTagItem = null;
		this.TagItemMap.TryGetValue(tagType, out payShopTagItem);
		if (isVisible && payShopTagItem == null)
		{
			Func<PayShopExtraTagItem> func;
			PayShopDefine.payShopTagTypeToExtraConstructor.TryGetValue(tagType, out func);
			PayShopTagItem newTagItem = (func != null) ? func() : new PayShopTagItem();
			this.TagItemMap.Add(tagType, newTagItem);
			string resourceId = PayShopDefine.payShopTagTypeToResourceId[tagType];
			UUIItem parentItem = inLeftTop ? base.GetItem(12) : base.GetItem(11);
			newTagItem.CreateThenShowByResourceIdAsync(resourceId, parentItem, false).ContinueWith(delegate()
			{
				PayShopExtraTagItem payShopExtraTagItem = newTagItem as PayShopExtraTagItem;
				if (payShopExtraTagItem != null)
				{
					payShopExtraTagItem.Refresh(this.Data);
				}
				callback();
			});
		}
		if (payShopTagItem != null)
		{
			payShopTagItem.SetUiActive(isVisible);
		}
		callback();
	}

	// Token: 0x06011BD2 RID: 72658 RVA: 0x004DFC58 File Offset: 0x004DDE58
	private void RefreshOriginalPriceText()
	{
		UUIText text = base.GetText(6);
		IPriceData priceData = this.DataSt.PriceData;
		if (priceData == null || priceData.OriginalPrice == null || !priceData.InDiscountTime)
		{
			text.SetUIActive(false);
			return;
		}
		text.SetUIActive(true);
		text.SetText("<s>" + priceData.OriginalPrice.ToString() + "</s>", true);
	}

	// Token: 0x06011BD3 RID: 72659 RVA: 0x004DFCD0 File Offset: 0x004DDED0
	private void RefreshPrice()
	{
		string text = "FFEF6FFF";
		if (!this.DataSt.IsDirect && this.DataSt.PriceData.OwnNumber() < this.DataSt.PriceData.NowPrice)
		{
			text = "F55E66FF";
		}
		if (this.CachePriceData != null && this.CachePriceData == this.DataSt.PriceData && this.CurrentPriceColor == text)
		{
			return;
		}
		this.CurrentPriceColor = text;
		PayShopItemBaseSt dataSt = this.DataSt;
		this.CachePriceData = ((dataSt != null) ? dataSt.PriceData : null);
		UUIText text2 = base.GetText(5);
		if (this.DataSt.IsDirect)
		{
			Func<string> getDirectPriceTextFunc = this.DataSt.GetDirectPriceTextFunc;
			string text3 = (getDirectPriceTextFunc != null) ? getDirectPriceTextFunc() : null;
			if (text3 != null)
			{
				string newText = text3;
				text2.SetText(newText, true);
				text2.SetColor(FColor.FromHex(text));
			}
			return;
		}
		IPriceData priceData = this.DataSt.PriceData;
		if (priceData.NowPrice == 0)
		{
			text2.ShowTextNew("ShopDiscountLabel_4");
		}
		else
		{
			text2.SetText(priceData.NowPrice.ToString(), true);
		}
		text2.SetColor(FColor.FromHex(text));
	}

	// Token: 0x06011BD4 RID: 72660 RVA: 0x004DFDF4 File Offset: 0x004DDFF4
	private void RefreshLeftTimesText()
	{
		UUIText text = base.GetText(4);
		Func<string> getShopTipsText = this.DataSt.GetShopTipsText;
		string text2 = (getShopTipsText != null) ? getShopTipsText() : null;
		if (this.CountDownType != EPayCountTimeType.Resell && !StringUtils.IsEmpty(text2))
		{
			text.SetUIActive(true);
			text.SetText(text2, true);
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x06011BD5 RID: 72661 RVA: 0x004DFE49 File Offset: 0x004DE049
	public void RefreshRedDot()
	{
		if (this.DataSt.RedDotExistFunc != null)
		{
			base.GetItem(8).SetUIActive(this.DataSt.RedDotExistFunc());
			return;
		}
		base.GetItem(8).SetUIActive(false);
	}

	// Token: 0x06011BD6 RID: 72662 RVA: 0x004DFE84 File Offset: 0x004DE084
	private void RefreshEffect(int quality, EItemQualityType qualityType)
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		if (qualityType == EItemQualityType.PayShop)
		{
			list = this.SpecialGoldEffectArray;
			list2.AddRange(this.PurpleEffectArray);
			list2.AddRange(this.GoldEffectArray);
		}
		else if (quality == 4)
		{
			list = this.PurpleEffectArray;
			list2.AddRange(this.GoldEffectArray);
			list2.AddRange(this.SpecialGoldEffectArray);
		}
		else
		{
			list = this.GoldEffectArray;
			list2.AddRange(this.PurpleEffectArray);
			list2.AddRange(this.SpecialGoldEffectArray);
		}
		foreach (int name in list)
		{
			UUIItem item = base.GetItem(name);
			if (item != null)
			{
				item.SetUIActive(true);
			}
		}
		foreach (int name2 in list2)
		{
			UUIItem item2 = base.GetItem(name2);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
	}

	// Token: 0x06011BD7 RID: 72663 RVA: 0x004DFFA0 File Offset: 0x004DE1A0
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011BD8 RID: 72664 RVA: 0x004DFFDC File Offset: 0x004DE1DC
	private void OnDiscountShopTimerRefresh()
	{
		if (this.Data == null || !base.IsUiActiveInHierarchy())
		{
			return;
		}
		this.RefreshCommonItem();
		this.RefreshRechargeItem();
		this.RefreshOriginalPriceText();
		this.RefreshPrice();
		this.RefreshGachaDescItem();
		this.RefreshLeftTimesText();
		this.RefreshRedDot();
		PayShopGoods payShopGoods = this.Data as PayShopGoods;
		if (payShopGoods != null && (this.IsCountDownChange(payShopGoods) || this.IsDiscountChange(payShopGoods)))
		{
			this.TryEmitRefreshTips();
		}
	}

	// Token: 0x06011BD9 RID: 72665 RVA: 0x004E0050 File Offset: 0x004DE250
	private bool IsCountDownChange(PayShopGoods data)
	{
		double item = data.GetCountDownData().Item3;
		if (item == 0.0 && this.CurrentCountDownState)
		{
			this.CurrentCountDownState = false;
			return true;
		}
		if (item != 0.0 && !this.CurrentCountDownState)
		{
			this.CurrentCountDownState = true;
			return true;
		}
		return false;
	}

	// Token: 0x06011BDA RID: 72666 RVA: 0x004E00A4 File Offset: 0x004DE2A4
	private bool IsDiscountChange(PayShopGoods data)
	{
		bool flag = data.HasDiscount();
		if (flag && !this.CurrentDiscountItemState)
		{
			this.CurrentDiscountItemState = true;
			return true;
		}
		if (!flag && this.CurrentDiscountItemState)
		{
			this.CurrentDiscountItemState = false;
			return true;
		}
		int discountNew = data.GetDiscountNew();
		if (discountNew != 0 && discountNew != this.CurrentDiscountValue)
		{
			this.CurrentDiscountValue = discountNew;
			return true;
		}
		return false;
	}

	// Token: 0x06011BDB RID: 72667 RVA: 0x004E0100 File Offset: 0x004DE300
	protected void TryEmitRefreshTips()
	{
		ControllerBase<PayShopController>.Instance.ClosePayShopGoodDetailPopView();
		if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
		{
			return;
		}
		if (this.Data is PayItemData)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.RefreshPayShop, (int)((PayShopGoods)this.Data).PayShopId, true);
	}

	// Token: 0x06011BDC RID: 72668 RVA: 0x004E0154 File Offset: 0x004DE354
	private unsafe void OnPayItemSuccess(PayItemSuccess notify)
	{
		if (this.Data is PayShopGoods || notify.PayItemId != ((PayItemData)this.Data).PayItemId)
		{
			return;
		}
		((PayItemData)this.Data).CanSpecialBonus = false;
		this.Refresh(this.Data, false, 0);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:ShopItem 充值成功,道具到账";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("订单号", notify.OrderId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("道具id", notify.ItemId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("道具数量", notify.ItemCount);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06011BDD RID: 72669 RVA: 0x004E022A File Offset: 0x004DE42A
	private void OnClickExplainBtn()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(9);
	}

	// Token: 0x06011BDE RID: 72670 RVA: 0x004E0238 File Offset: 0x004DE438
	private void OnClickItem()
	{
		PayItemData payItemData = this.Data as PayItemData;
		if (payItemData == null)
		{
			PayShopGoods payShopGoods = this.Data as PayShopGoods;
			if (payShopGoods != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Shop;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "PayShop:ShopItem 点击商品";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", payShopGoods.GetGoodsData().Id);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<PayShopController>.Instance.OpenBuyViewByGoodsId(payShopGoods, null);
			}
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Shop;
		ELogAuthor author2 = ELogAuthor.XXJ;
		string message2 = "PayShop:ShopItem 点击充值";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", payItemData.PayItemId);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		ControllerBase<PayItemController>.Instance.SdkPay(payItemData.PayItemId);
		Action<PayItemData> onClickRechargeCallback = this.OnClickRechargeCallback;
		if (onClickRechargeCallback == null)
		{
			return;
		}
		onClickRechargeCallback(payItemData);
	}

	// Token: 0x06011BE0 RID: 72672 RVA: 0x004E0379 File Offset: 0x004DE579
	[CompilerGenerated]
	internal static void <RefreshTotalScoreTagForGoods>g__callback|26_0()
	{
	}

	// Token: 0x06011BE1 RID: 72673 RVA: 0x004E037B File Offset: 0x004DE57B
	[CompilerGenerated]
	internal static void <RefreshTotalScoreTagForItem>g__callback|27_0()
	{
	}

	// Token: 0x04008ACE RID: 35534
	private const string NORMALCOLOR = "FFEF6FFF";

	// Token: 0x04008ACF RID: 35535
	private const string REDCOLOR = "F55E66FF";

	// Token: 0x04008AD0 RID: 35536
	[Nullable(2)]
	private IPayShopUnionData Data;

	// Token: 0x04008AD1 RID: 35537
	[Nullable(2)]
	private PayShopItemBaseSt DataSt;

	// Token: 0x04008AD2 RID: 35538
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Dictionary<PayShopDefine.EPayShopTagType, PayShopTagItem> TagItemMap = new Dictionary<PayShopDefine.EPayShopTagType, PayShopTagItem>();

	// Token: 0x04008AD3 RID: 35539
	[Nullable(2)]
	private IPriceData CachePriceData;

	// Token: 0x04008AD4 RID: 35540
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PayItemData> OnClickRechargeCallback;

	// Token: 0x04008AD5 RID: 35541
	private bool CurrentDiscountItemState;

	// Token: 0x04008AD6 RID: 35542
	private int CurrentDiscountValue;

	// Token: 0x04008AD7 RID: 35543
	private bool CurrentCountDownState = true;

	// Token: 0x04008AD8 RID: 35544
	private EPayCountTimeType CountDownType;

	// Token: 0x04008AD9 RID: 35545
	private string CurrentPriceColor = "";

	// Token: 0x04008ADA RID: 35546
	private int CurrentTagType;

	// Token: 0x04008ADB RID: 35547
	private List<int> PurpleEffectArray = new List<int>
	{
		21,
		22
	};

	// Token: 0x04008ADC RID: 35548
	private List<int> GoldEffectArray = new List<int>
	{
		23,
		24
	};

	// Token: 0x04008ADD RID: 35549
	private List<int> SpecialGoldEffectArray = new List<int>
	{
		25,
		26
	};

	// Token: 0x02008709 RID: 34569
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402DABD RID: 187069
		public const int BtnBuy = 0;

		// Token: 0x0402DABE RID: 187070
		public const int TextureQuality = 1;

		// Token: 0x0402DABF RID: 187071
		public const int TextureIcon = 2;

		// Token: 0x0402DAC0 RID: 187072
		public const int TextName = 3;

		// Token: 0x0402DAC1 RID: 187073
		public const int TextLeftTimes = 4;

		// Token: 0x0402DAC2 RID: 187074
		public const int TextPrice = 5;

		// Token: 0x0402DAC3 RID: 187075
		public const int TextOriginalPrice = 6;

		// Token: 0x0402DAC4 RID: 187076
		public const int BtnHelp = 7;

		// Token: 0x0402DAC5 RID: 187077
		public const int ItemRedDot = 8;

		// Token: 0x0402DAC6 RID: 187078
		public const int ItemCountDown = 9;

		// Token: 0x0402DAC7 RID: 187079
		public const int TextCountDown = 10;

		// Token: 0x0402DAC8 RID: 187080
		public const int ItemStatePanel = 11;

		// Token: 0x0402DAC9 RID: 187081
		public const int ItemTagPanel = 12;

		// Token: 0x0402DACA RID: 187082
		public const int TexturePriceIcon = 13;

		// Token: 0x0402DACB RID: 187083
		public const int TextureTimeBg = 14;

		// Token: 0x0402DACC RID: 187084
		public const int GachaDescItem = 15;

		// Token: 0x0402DACD RID: 187085
		public const int GachaRewardText = 16;

		// Token: 0x0402DACE RID: 187086
		public const int GachaRewardPriceText = 17;

		// Token: 0x0402DACF RID: 187087
		public const int TextureQualityLine = 18;

		// Token: 0x0402DAD0 RID: 187088
		public const int TextureQualityLineLight = 19;

		// Token: 0x0402DAD1 RID: 187089
		public const int PurpleNiagaraEffect = 21;

		// Token: 0x0402DAD2 RID: 187090
		public const int PurpleStarEffect = 22;

		// Token: 0x0402DAD3 RID: 187091
		public const int GoldNiagaraEffect = 23;

		// Token: 0x0402DAD4 RID: 187092
		public const int GoldStarEffect = 24;

		// Token: 0x0402DAD5 RID: 187093
		public const int SpecialGoldNiagaraEffect = 25;

		// Token: 0x0402DAD6 RID: 187094
		public const int SpecialGoldStarEffect = 26;
	}
}
