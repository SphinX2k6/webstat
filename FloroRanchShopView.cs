using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.FloroRanch;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02001C43 RID: 7235
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchShopView : UiViewBase
{
	// Token: 0x0600D2EC RID: 53996 RVA: 0x00381F68 File Offset: 0x00380168
	public FloroRanchShopView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D2ED RID: 53997 RVA: 0x00381FC4 File Offset: 0x003801C4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 35;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(22, new Action(this.OnClickBuyButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickRefreshButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickHideButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D2EE RID: 53998 RVA: 0x00382530 File Offset: 0x00380730
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchShopView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchShopView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2EF RID: 53999 RVA: 0x00382574 File Offset: 0x00380774
	protected override void OnStart()
	{
		this.ActivityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		FloroRanchShopViewParam floroRanchShopViewParam = (FloroRanchShopViewParam)this.OpenParam;
		this.CloseCallback = floroRanchShopViewParam.CloseCallback;
		FloroRanchShop shopData = floroRanchShopViewParam.ShopData;
		this.InitShopItemDataList(shopData);
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(18),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.FloroRanch,
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch)
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D2F0 RID: 54000 RVA: 0x003825F4 File Offset: 0x003807F4
	protected override void OnBeforeShow()
	{
		this.RefreshGoodsView(true);
		this.ShowAllToy();
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FloroRanchGamePlayView);
		if (viewByName != null)
		{
			(viewByName as FloroRanchGamePlayView).SetToyPanelActive(false);
		}
		UUIInturnAnimController animController = this.AnimController;
		if (animController != null)
		{
			animController.Play("", -1, false);
		}
		this.UiBlur.SetEnableUiBlur(true);
	}

	// Token: 0x0600D2F1 RID: 54001 RVA: 0x00382654 File Offset: 0x00380854
	protected override void OnBeforeHide()
	{
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FloroRanchGamePlayView);
		if (viewByName != null)
		{
			(viewByName as FloroRanchGamePlayView).SetToyPanelActive(true);
		}
		this.UiBlur.SetEnableUiBlur(false);
	}

	// Token: 0x0600D2F2 RID: 54002 RVA: 0x0038268C File Offset: 0x0038088C
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(18));
	}

	// Token: 0x0600D2F3 RID: 54003 RVA: 0x003826A0 File Offset: 0x003808A0
	private FloroRanchGoodsItem CreateGoodsItem()
	{
		FloroRanchGoodsItem floroRanchGoodsItem = new FloroRanchGoodsItem();
		floroRanchGoodsItem.BindClickCallback(new Action<FloroRanchShopItemDataBase>(this.OnClickGoodItem));
		this.GoodsItemList.Add(floroRanchGoodsItem);
		return floroRanchGoodsItem;
	}

	// Token: 0x0600D2F4 RID: 54004 RVA: 0x003826D4 File Offset: 0x003808D4
	private UniTask CreateToyItem(int point)
	{
		FloroRanchShopView.<CreateToyItem>d__20 <CreateToyItem>d__;
		<CreateToyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateToyItem>d__.<>4__this = this;
		<CreateToyItem>d__.point = point;
		<CreateToyItem>d__.<>1__state = -1;
		<CreateToyItem>d__.<>t__builder.Start<FloroRanchShopView.<CreateToyItem>d__20>(ref <CreateToyItem>d__);
		return <CreateToyItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D2F5 RID: 54005 RVA: 0x0038271F File Offset: 0x0038091F
	private void InitUiBlur()
	{
		this.UiBlur = UE.NewObject<TsUiBlur>(this.RootActor, null, EObjectFlags.RF_NoFlags);
		this.UiBlur.SetEnableUiBlur(false);
	}

	// Token: 0x0600D2F6 RID: 54006 RVA: 0x00382740 File Offset: 0x00380940
	private void RefreshGoodsView(bool resetToFirst)
	{
		FloroRanchCurrencyData diamondData = ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData;
		this.ItemCost.SetCurrencyData(diamondData);
		bool allowedRefresh = this.ShopData.AllowedRefresh;
		UUIButtonComponent button = base.GetButton(1);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(allowedRefresh);
		}
		if (allowedRefresh)
		{
			int count = this.ShopData.Cost[0].Count;
			bool flag = ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData.GetAmount() >= count;
			UUIText text = base.GetText(3);
			UUIText uuitext = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			UUIItem uuiitem = text;
			bool bUseChangeColor = !flag;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			FloroRanchCurrencyConfigData floroRanchCurrencyConfig = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCurrencyConfig(ECurrencyType.Diamond);
			base.SetTextureByPath(floroRanchCurrencyConfig.GetSmallIcon(), base.GetTexture(2), null, null);
			int freeTimes = this.ShopData.FreeTimes;
			UUIText text2 = base.GetText(4);
			if (text2 != null)
			{
				text2.ShowTextNew((freeTimes > 0) ? "Farm_Edit5" : "Farm_Edit4");
			}
			UUIItem item = base.GetItem(29);
			if (item != null)
			{
				item.SetUIActive(freeTimes > 0);
			}
			UUIText text3 = base.GetText(30);
			if (text3 != null)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(freeTimes);
				text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}
		foreach (FloroRanchGoodsItem floroRanchGoodsItem in this.GoodsItemList)
		{
			floroRanchGoodsItem.SetSelectState(false);
		}
		this.GoodsScrollView.RefreshByDataAsync(this.ShopItemDataList, false).ContinueWith(delegate()
		{
			this.UpdateSelectionAfterDataChange(resetToFirst);
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		});
	}

	// Token: 0x0600D2F7 RID: 54007 RVA: 0x00382938 File Offset: 0x00380B38
	private void RefreshGoodsTip()
	{
		if (this.CurSelectGoods == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "商店没有选中商品！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		FloroRanchShopItemType type = this.CurSelectGoods.Type;
		UUIText text = base.GetText(10);
		if (text != null)
		{
			text.ShowTextNew(this.CurSelectGoods.GetName());
		}
		UUIText text2 = base.GetText(18);
		if (text2 != null)
		{
			text2.SetText(this.CurSelectGoods.Desc, true);
		}
		base.SetTextureByPath(this.CurSelectGoods.GetIcon(), base.GetTexture(11), null, null);
		bool flag = type == FloroRanchShopItemType.ShopToy;
		UUIItem item = base.GetItem(13);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUIItem item2 = base.GetItem(31);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		if (!flag)
		{
			int race = this.CurSelectGoods.GetRace();
			FloroRanchRaceData floroRanchRaceData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchRaceData(race);
			if (floroRanchRaceData != null)
			{
				base.SetTextureByPath(floroRanchRaceData.SmallIcon, base.GetTexture(14), null, null);
				UUIText text3 = base.GetText(15);
				if (text3 != null)
				{
					text3.ShowTextNew(floroRanchRaceData.GetRaceName());
				}
			}
		}
		else
		{
			FloroRanchRaceData toyRaceData = this.CurSelectGoods.GetToyRaceData();
			if (toyRaceData != null)
			{
				base.SetTextureByPath(toyRaceData.SmallIcon, base.GetTexture(32), null, null);
				UUIItem item3 = base.GetItem(31);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
			}
		}
		bool flag2 = this.CurSelectGoods.Type == FloroRanchShopItemType.Card;
		if (flag2)
		{
			FloroRanchCurrencyData floroRanchCurrencyData = new FloroRanchCurrencyData(ECurrencyType.Salary);
			base.SetTextureByPath(floroRanchCurrencyData.ConfigData.GetSmallIcon(), base.GetTexture(16), null, null);
			UUIText text4 = base.GetText(17);
			if (text4 != null)
			{
				text4.SetText(this.CurSelectGoods.GetEarnCount().ToString(), true);
			}
		}
		UUITexture texture = base.GetTexture(16);
		if (texture != null)
		{
			texture.SetUIActive(flag2);
		}
		UUIText text5 = base.GetText(17);
		if (text5 != null)
		{
			text5.SetUIActive(flag2);
		}
		UUIItem item4 = base.GetItem(33);
		if (item4 != null)
		{
			item4.SetUIActive(this.CurSelectGoods.GetIsSpecialPhantom());
		}
		FloroRanchCurrencyData diamondData = ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData;
		bool isSold = this.CurSelectGoods.IsSold;
		if (!isSold)
		{
			int price = this.CurSelectGoods.Price;
			UUIText text6 = base.GetText(25);
			UUIText uuitext = text6;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted<int>(price);
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			int amount = diamondData.GetAmount();
			UUIItem uuiitem = text6;
			bool bUseChangeColor = amount < price;
			FColor? fcolor = new FColor?(text6.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.SetTextureByPath(diamondData.ConfigData.GetSmallIcon(), base.GetTexture(24), null, null);
		}
		UUIButtonComponent button = base.GetButton(22);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(!isSold);
		}
		UUIItem item5 = base.GetItem(21);
		if (item5 != null)
		{
			item5.SetUIActive(isSold);
		}
		UUIText text7 = base.GetText(23);
		if (text7 != null)
		{
			text7.ShowTextNew("Farm_Edit1");
		}
		UUIText text8 = base.GetText(12);
		if (text8 != null)
		{
			text8.ShowTextNew(this.TypeTextId[(int)type]);
		}
		FloroRanchRarityData qualityData = this.CurSelectGoods.GetQualityData();
		base.SetTextureByPath(qualityData.GetRarityDetailCardBigBg(), base.GetTexture(19), null, null);
		base.SetTextureByPath(qualityData.GetRarityDetailCardSmallBg(), base.GetTexture(20), null, null);
		global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			return;
		}
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		EFloroRanchCardType? efloroRanchCardType = null;
		if (type == FloroRanchShopItemType.ShopToy)
		{
			efloroRanchCardType = new EFloroRanchCardType?(EFloroRanchCardType.Toy);
		}
		else if (type == FloroRanchShopItemType.Card)
		{
			efloroRanchCardType = new EFloroRanchCardType?(EFloroRanchCardType.Phantom);
		}
		bool flag3 = efloroRanchCardType != null && currentActivityData.IsSubDungeonRecommendItem(subInstanceId, this.CurSelectGoods.Id, efloroRanchCardType.Value);
		UUISprite sprite = base.GetSprite(34);
		if (!flag3)
		{
			if (sprite != null)
			{
				sprite.SetUIActive(false);
				return;
			}
		}
		else if (sprite != null)
		{
			sprite.SetUIActive(true);
		}
	}

	// Token: 0x0600D2F8 RID: 54008 RVA: 0x00382D50 File Offset: 0x00380F50
	private void ShowAllToy()
	{
		int enableToyCount = ModelBase<FloroRanchGamePlayModel>.Instance.EnableToyCount;
		for (int i = 0; i < enableToyCount; i++)
		{
			if (ModelBase<FloroRanchGamePlayModel>.Instance.GetToyEntityByPoint(i) != null)
			{
				this.ShowToy(i);
			}
			else
			{
				this.HideToy(i);
			}
		}
	}

	// Token: 0x0600D2F9 RID: 54009 RVA: 0x00382D94 File Offset: 0x00380F94
	private void ShowToy(int point)
	{
		FloroRanchToyGridItem floroRanchToyGridItem;
		if (this.ToyItemMap.TryGetValue(point, out floroRanchToyGridItem))
		{
			FloroRanchEntityBase toyEntityByPoint = ModelBase<FloroRanchGamePlayModel>.Instance.GetToyEntityByPoint(point);
			floroRanchToyGridItem.PlayShowAnim(toyEntityByPoint);
		}
	}

	// Token: 0x0600D2FA RID: 54010 RVA: 0x00382DC4 File Offset: 0x00380FC4
	private void HideToy(int point)
	{
		FloroRanchToyGridItem floroRanchToyGridItem;
		if (this.ToyItemMap.TryGetValue(point, out floroRanchToyGridItem))
		{
			floroRanchToyGridItem.SetInfoPanelActive(false);
		}
	}

	// Token: 0x0600D2FB RID: 54011 RVA: 0x00382DE8 File Offset: 0x00380FE8
	private void SetToyListActive(bool isActive)
	{
		base.GetItem(27).SetAlpha(isActive > false);
	}

	// Token: 0x0600D2FC RID: 54012 RVA: 0x00382DFC File Offset: 0x00380FFC
	private void ToySellCallback(int point)
	{
		this.HideToy(point);
		this.RefreshGoodsView(false);
	}

	// Token: 0x0600D2FD RID: 54013 RVA: 0x00382E0C File Offset: 0x0038100C
	private void OnClickGoodItem(FloroRanchShopItemDataBase data)
	{
		this.SelectGoodsData(data);
	}

	// Token: 0x0600D2FE RID: 54014 RVA: 0x00382E15 File Offset: 0x00381015
	private void SelectGoodsData(FloroRanchShopItemDataBase data)
	{
		if (this.CurSelectGoods != null)
		{
			this.RefreshGoodsItemToggleState(false, this.CurSelectGoods.IncId);
		}
		this.CurSelectGoods = data;
		if (data != null)
		{
			this.RefreshGoodsItemToggleState(true, data.IncId);
		}
		this.RefreshGoodsTip();
	}

	// Token: 0x0600D2FF RID: 54015 RVA: 0x00382E50 File Offset: 0x00381050
	private void RefreshGoodsItemToggleState(bool isSelected, int incId)
	{
		FloroRanchGoodsItem floroRanchGoodsItem = this.GoodsItemList.Find(delegate(FloroRanchGoodsItem item)
		{
			FloroRanchShopItemDataBase data = item.Data;
			return data != null && data.IncId == incId;
		});
		if (floroRanchGoodsItem != null)
		{
			floroRanchGoodsItem.SetSelectState(isSelected);
		}
	}

	// Token: 0x0600D300 RID: 54016 RVA: 0x00382E8C File Offset: 0x0038108C
	private void OnClickToyItem(int point)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchShopTipView, new FloroRanchShopTipViewParam
		{
			ToyPoint = point,
			SellCallback = new Action<int>(this.ToySellCallback),
			ShowToyListCallback = new Action<bool>(this.SetToyListActive)
		}, null);
		FloroRanchToyGridItem floroRanchToyGridItem;
		if (this.ToyItemMap.TryGetValue(point, out floroRanchToyGridItem))
		{
			floroRanchToyGridItem.SetSelectState(false);
		}
	}

	// Token: 0x0600D301 RID: 54017 RVA: 0x00382EFC File Offset: 0x003810FC
	private void OnClickBuyButton()
	{
		if (this.CurSelectGoods == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "商店没有选中商品！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int cardLimitCount = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData().CardLimitCount;
		if (ModelBase<FloroRanchGamePlayModel>.Instance.OwnCardEntityCount >= cardLimitCount)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhrolovaFarm_AnimalMax", Array.Empty<object>());
			return;
		}
		int amount = ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData.GetAmount();
		int price = this.CurSelectGoods.Price;
		if (amount < price)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_BuyFail", Array.Empty<object>());
			return;
		}
		int id = this.CurSelectGoods.Id;
		FloroRanchShopItemType type = this.CurSelectGoods.Type;
		if (type == FloroRanchShopItemType.ShopToy)
		{
			int curToyCount = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurToyCount();
			int enableToyCount = ModelBase<FloroRanchGamePlayModel>.Instance.EnableToyCount;
			if (curToyCount >= enableToyCount)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ToyFull", Array.Empty<object>());
				return;
			}
		}
		int activityId = ModelBase<FloroRanchGamePlayModel>.Instance.ActivityId;
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchPlayShopBuyRequest(activityId, ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId, this.ShopData.IncId, id, (int)type, this.CurSelectGoods.IncId, delegate(FloroRanchPlayShopBuyResponse response)
		{
			if (response == null)
			{
				return;
			}
			this.InitShopItemDataList(response.Shop);
			this.RefreshGoodsView(false);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_BuySuccess", Array.Empty<object>());
			if (response.Toy != null)
			{
				int point = response.Toy.NewToy.Point;
				this.ShowToy(point);
			}
		});
	}

	// Token: 0x0600D302 RID: 54018 RVA: 0x00383028 File Offset: 0x00381228
	private void OnClickRefreshButton()
	{
		if (!this.ShopData.AllowedRefresh)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "商店刷新 allowedRefresh 为 false", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData.GetAmount() < this.ShopData.Cost[0].Count)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_MoneyNotEnough", Array.Empty<object>());
			return;
		}
		FloroRanchGamePlayModel instance = ModelBase<FloroRanchGamePlayModel>.Instance;
		int activityId = instance.ActivityId;
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchPlayRefreshShopRequest(activityId, instance.SubInstanceId, this.ShopData.IncId, delegate(FloroRanchPlayRefreshShopResponse response)
		{
			this.InitShopItemDataList(response.Shop);
			this.RefreshGoodsView(true);
			UUIInturnAnimController animController = this.AnimController;
			if (animController == null)
			{
				return;
			}
			animController.Play("", -1, false);
		});
	}

	// Token: 0x0600D303 RID: 54019 RVA: 0x003830D4 File Offset: 0x003812D4
	private void SendCloseTaskRequest()
	{
		if (this.ShopData != null)
		{
			int activityId = ModelBase<FloroRanchGamePlayModel>.Instance.ActivityId;
			int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
			ControllerBase<FloroRanchController>.Instance.SendFloroRanchCloseTaskRequest(activityId, subInstanceId, this.ShopData.IncId, null);
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "商店数据为空！ 无法发送关闭任务请求", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600D304 RID: 54020 RVA: 0x00383137 File Offset: 0x00381337
	private void OnClickHideButton()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.HideRecordView();
	}

	// Token: 0x0600D305 RID: 54021 RVA: 0x00383143 File Offset: 0x00381343
	private void OnClickCloseButton()
	{
		this.SendCloseTaskRequest();
		base.CloseMe(null);
		Action closeCallback = this.CloseCallback;
		if (closeCallback == null)
		{
			return;
		}
		closeCallback();
	}

	// Token: 0x0600D306 RID: 54022 RVA: 0x00383164 File Offset: 0x00381364
	public void InitShopItemDataList(FloroRanchShop shopData)
	{
		this.ShopData = shopData;
		RepeatedField<FloroRanchShopItem> items = shopData.Items;
		this.ShopItemDataList.Clear();
		foreach (FloroRanchShopItem item in items)
		{
			FloroRanchShopItemDataBase floroRanchShopItemDataBase = this.CreateShopItem(item);
			if (floroRanchShopItemDataBase != null)
			{
				this.ShopItemDataList.Add(floroRanchShopItemDataBase);
			}
		}
		this.ActivityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
	}

	// Token: 0x0600D307 RID: 54023 RVA: 0x003831E8 File Offset: 0x003813E8
	private void UpdateSelectionAfterDataChange(bool resetToFirst)
	{
		FloroRanchShopView.<>c__DisplayClass40_0 CS$<>8__locals1 = new FloroRanchShopView.<>c__DisplayClass40_0();
		if (this.ShopItemDataList.Count == 0)
		{
			this.CurSelectGoods = null;
			return;
		}
		if (resetToFirst)
		{
			this.CurSelectGoods = null;
			this.SelectGoodsData(this.ShopItemDataList[0]);
			return;
		}
		FloroRanchShopView.<>c__DisplayClass40_0 CS$<>8__locals2 = CS$<>8__locals1;
		FloroRanchShopItemDataBase curSelectGoods = this.CurSelectGoods;
		CS$<>8__locals2.curSelectGoodIncId = ((curSelectGoods != null) ? new int?(curSelectGoods.IncId) : null);
		if (CS$<>8__locals1.curSelectGoodIncId != null && CS$<>8__locals1.curSelectGoodIncId.GetValueOrDefault() != 0)
		{
			FloroRanchShopItemDataBase floroRanchShopItemDataBase = this.ShopItemDataList.Find((FloroRanchShopItemDataBase item) => item.IncId == CS$<>8__locals1.curSelectGoodIncId.Value);
			if (floroRanchShopItemDataBase != null)
			{
				this.SelectGoodsData(floroRanchShopItemDataBase);
				return;
			}
			this.SelectGoodsData(this.ShopItemDataList[0]);
		}
	}

	// Token: 0x0600D308 RID: 54024 RVA: 0x003832A4 File Offset: 0x003814A4
	private FloroRanchShopItemDataBase CreateShopItem(FloroRanchShopItem item)
	{
		switch (item.Type)
		{
		case FloroRanchShopItemType.Card:
			return new FloroRanchShopItemCardData(item);
		case FloroRanchShopItemType.CardGroup:
			return new FloroRanchShopItemCardGroupData(item);
		case FloroRanchShopItemType.ShopToy:
			return new FloroRanchShopItemToyData(item);
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanch商店物品类型错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", item.Type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		}
	}

	// Token: 0x0400647D RID: 25725
	private FloroRanchCurrencyItem ItemCost;

	// Token: 0x0400647E RID: 25726
	private GenericScrollViewNew<FloroRanchGoodsItem, FloroRanchShopItemDataBase> GoodsScrollView;

	// Token: 0x0400647F RID: 25727
	private FloroRanchShop ShopData;

	// Token: 0x04006480 RID: 25728
	private global::FloroRanchActivityData ActivityData;

	// Token: 0x04006481 RID: 25729
	private readonly List<FloroRanchGoodsItem> GoodsItemList = new List<FloroRanchGoodsItem>();

	// Token: 0x04006482 RID: 25730
	private FloroRanchShopItemDataBase CurSelectGoods;

	// Token: 0x04006483 RID: 25731
	private readonly Dictionary<int, FloroRanchToyGridItem> ToyItemMap = new Dictionary<int, FloroRanchToyGridItem>();

	// Token: 0x04006484 RID: 25732
	private Action CloseCallback;

	// Token: 0x04006485 RID: 25733
	private UUIInturnAnimController AnimController;

	// Token: 0x04006486 RID: 25734
	private TsUiBlur UiBlur;

	// Token: 0x04006487 RID: 25735
	private readonly string[] TypeTextId = new string[]
	{
		"Farm_CardType1",
		"Farm_CardType3",
		"Farm_CardType2"
	};

	// Token: 0x04006488 RID: 25736
	public readonly List<FloroRanchShopItemDataBase> ShopItemDataList = new List<FloroRanchShopItemDataBase>();

	// Token: 0x02007F4C RID: 32588
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B533 RID: 177459
		public const int CloseButton = 0;

		// Token: 0x0402B534 RID: 177460
		public const int RefreshButton = 1;

		// Token: 0x0402B535 RID: 177461
		public const int RefreshTexture = 2;

		// Token: 0x0402B536 RID: 177462
		public const int RefreshPrice = 3;

		// Token: 0x0402B537 RID: 177463
		public const int RefreshButtonText = 4;

		// Token: 0x0402B538 RID: 177464
		public const int GoodsScrollView = 5;

		// Token: 0x0402B539 RID: 177465
		public const int GoodsItem = 6;

		// Token: 0x0402B53A RID: 177466
		public const int HideButton = 7;

		// Token: 0x0402B53B RID: 177467
		public const int ItemCost = 8;

		// Token: 0x0402B53C RID: 177468
		public const int GoodsTipItem = 9;

		// Token: 0x0402B53D RID: 177469
		public const int GoodsName = 10;

		// Token: 0x0402B53E RID: 177470
		public const int GoodsTexture = 11;

		// Token: 0x0402B53F RID: 177471
		public const int GoodsType = 12;

		// Token: 0x0402B540 RID: 177472
		public const int GoodsRaceItem = 13;

		// Token: 0x0402B541 RID: 177473
		public const int GoodsRaceTexture = 14;

		// Token: 0x0402B542 RID: 177474
		public const int GoodsRaceName = 15;

		// Token: 0x0402B543 RID: 177475
		public const int EarnTexture = 16;

		// Token: 0x0402B544 RID: 177476
		public const int EarnCount = 17;

		// Token: 0x0402B545 RID: 177477
		public const int GoodsDesc = 18;

		// Token: 0x0402B546 RID: 177478
		public const int QualityTexture = 19;

		// Token: 0x0402B547 RID: 177479
		public const int QualityBTexture = 20;

		// Token: 0x0402B548 RID: 177480
		public const int SoldItem = 21;

		// Token: 0x0402B549 RID: 177481
		public const int BuyButton = 22;

		// Token: 0x0402B54A RID: 177482
		public const int BuyButtonText = 23;

		// Token: 0x0402B54B RID: 177483
		public const int BuyTexture = 24;

		// Token: 0x0402B54C RID: 177484
		public const int BuyCount = 25;

		// Token: 0x0402B54D RID: 177485
		public const int ItemHidePanel = 26;

		// Token: 0x0402B54E RID: 177486
		public const int ToyLayout = 27;

		// Token: 0x0402B54F RID: 177487
		public const int ToyItemTemplate = 28;

		// Token: 0x0402B550 RID: 177488
		public const int RefreshTimePanel = 29;

		// Token: 0x0402B551 RID: 177489
		public const int RefreshTimeText = 30;

		// Token: 0x0402B552 RID: 177490
		public const int ToyRaceItem = 31;

		// Token: 0x0402B553 RID: 177491
		public const int ToyRaceIcon = 32;

		// Token: 0x0402B554 RID: 177492
		public const int ItemPhantomIcon = 33;

		// Token: 0x0402B555 RID: 177493
		public const int RecommendSprite = 34;
	}
}
