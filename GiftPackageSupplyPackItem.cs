using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020023F3 RID: 9203
[NullableContext(1)]
[Nullable(0)]
public class GiftPackageSupplyPackItem : UiPanelBase
{
	// Token: 0x06011CFD RID: 72957 RVA: 0x004E693C File Offset: 0x004E4B3C
	public GiftPackageSupplyPackItem(int packId, UUIItem uiItem, PayShopGoods goods)
	{
		this.PackId = packId;
		this.Goods = goods;
		base.CreateThenShowByResourceIdAsync("UiItem_GiftPackageSupplyPack", uiItem, false).Forget();
	}

	// Token: 0x06011CFE RID: 72958 RVA: 0x004E6970 File Offset: 0x004E4B70
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011CFF RID: 72959 RVA: 0x004E6A9F File Offset: 0x004E4C9F
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollView<GiftPackageItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<GiftPackageItem>(this.InitItem), null);
		this.Refresh();
	}

	// Token: 0x06011D00 RID: 72960 RVA: 0x004E6AC8 File Offset: 0x004E4CC8
	public void Refresh()
	{
		if (base.InAsyncLoading())
		{
			return;
		}
		GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(this.PackId);
		int num = 0;
		foreach (KeyValuePair<int, int> keyValuePair in giftPackageConfig.Value.Content())
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(key)) == InventoryDefine.EItemDataType.RoleSkinItem)
			{
				num = key;
				break;
			}
			this.RewardList.Add(new int[]
			{
				key,
				value
			});
		}
		if (num > 0)
		{
			this.RewardList = new List<int[]>();
			foreach (TItem titem in ShopSkinData.Create(this.Goods).GetAllReward())
			{
				this.RewardList.Add(new int[]
				{
					titem.ItemData.ItemId,
					titem.Count
				});
			}
		}
		this.ScrollView.RefreshByData<int[]>(this.RewardList, null);
		this.SetEndTime();
		this.RefreshTitle();
		this.RefreshLeftTimeText();
		this.RefreshTimeItemShowState();
	}

	// Token: 0x06011D01 RID: 72961 RVA: 0x004E6C20 File Offset: 0x004E4E20
	private ILayoutItem<GiftPackageItem> InitItem(object data, UUIItem uiItem, int index)
	{
		GiftPackageItem giftPackageItem = new GiftPackageItem();
		giftPackageItem.Initialize(uiItem);
		giftPackageItem.SetBelongViewName(EUiViewName.GiftPackageDetailsView);
		if (data != null && ((int[])data).Length >= 2)
		{
			giftPackageItem.UpdateItem(((int[])data)[0], ((int[])data)[1]);
		}
		return new LayoutItem<GiftPackageItem>
		{
			Key = index,
			Value = giftPackageItem
		};
	}

	// Token: 0x06011D02 RID: 72962 RVA: 0x004E6C81 File Offset: 0x004E4E81
	private void RefreshTitle()
	{
	}

	// Token: 0x06011D03 RID: 72963 RVA: 0x004E6C83 File Offset: 0x004E4E83
	private void RefreshTimeItemShowState()
	{
		base.GetItem(6).SetUIActive(this.LeftBuyShowState || this.LeftTimeShowState);
	}

	// Token: 0x06011D04 RID: 72964 RVA: 0x004E6CA4 File Offset: 0x004E4EA4
	private void RefreshLeftTimeText()
	{
		base.GetText(2).SetUIActive(false);
		base.GetText(7).SetUIActive(false);
		string exchangeViewShopTipsText = this.Goods.GetExchangeViewShopTipsText();
		UUIText text;
		if (this.LeftTimeShowState)
		{
			text = base.GetText(2);
		}
		else
		{
			text = base.GetText(7);
		}
		text.SetUIActive(exchangeViewShopTipsText != "");
		text.SetText(exchangeViewShopTipsText, true);
		text.SetColor(FColor.FromHex("FED12E"));
		this.LeftBuyShowState = (exchangeViewShopTipsText != "");
	}

	// Token: 0x06011D05 RID: 72965 RVA: 0x004E6D30 File Offset: 0x004E4F30
	protected void SetEndTime()
	{
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = this.Goods.GetCountDownData();
		if (countDownData.Item3 == 0.0)
		{
			base.GetItem(3).SetUIActive(false);
			this.LeftTimeShowState = false;
			return;
		}
		CommonDefine.IPayShowCountDownRemainTime item = this.Goods.GetCountDownData().Item2;
		if (countDownData.Item1 == EPayCountTimeType.NeverResell)
		{
			base.GetText(4).ShowTextNew("DownShopItem");
			base.GetText(4).SetUIActive(true);
		}
		else if (countDownData.Item1 == EPayCountTimeType.Resell)
		{
			base.GetText(4).ShowTextNew("ReUpShopItem");
			base.GetText(4).SetUIActive(true);
		}
		else if (countDownData.Item1 == EPayCountTimeType.Discount)
		{
			base.GetText(4).ShowTextNew("DiscountItem");
			base.GetText(4).SetUIActive(true);
		}
		else
		{
			base.GetText(4).SetUIActive(false);
		}
		this.LeftTimeShowState = (item != null);
		if (item != null)
		{
			base.GetItem(3).SetUIActive(true);
			UUIText text = base.GetText(5);
			CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = item as CommonDefine.PayShowCountDownRemainTime<string>;
			if (payShowCountDownRemainTime != null)
			{
				text.SetText(payShowCountDownRemainTime.Value, true);
				return;
			}
			CommonDefine.IRemainTime remainTime = item as CommonDefine.IRemainTime;
			if (remainTime != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue));
				return;
			}
		}
		else
		{
			base.GetItem(3).SetUIActive(false);
		}
	}

	// Token: 0x06011D06 RID: 72966 RVA: 0x004E6E7F File Offset: 0x004E507F
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x04008B5B RID: 35675
	private const string COLOR = "FED12E";

	// Token: 0x04008B5C RID: 35676
	private bool LeftBuyShowState;

	// Token: 0x04008B5D RID: 35677
	private bool LeftTimeShowState;

	// Token: 0x04008B5E RID: 35678
	[Nullable(2)]
	private readonly PayShopGoods Goods;

	// Token: 0x04008B5F RID: 35679
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<GiftPackageItem> ScrollView;

	// Token: 0x04008B60 RID: 35680
	private List<int[]> RewardList = new List<int[]>();

	// Token: 0x04008B61 RID: 35681
	private int PackId;

	// Token: 0x0200872E RID: 34606
	[NullableContext(0)]
	private class EGiftPackageSupplyPackItem
	{
		// Token: 0x0402DB9F RID: 187295
		public const int ScrollView = 0;

		// Token: 0x0402DBA0 RID: 187296
		public const int GiftItem = 1;

		// Token: 0x0402DBA1 RID: 187297
		public const int LeftTimeText = 2;

		// Token: 0x0402DBA2 RID: 187298
		public const int EndTimeItem = 3;

		// Token: 0x0402DBA3 RID: 187299
		public const int DownItemText = 4;

		// Token: 0x0402DBA4 RID: 187300
		public const int EndTimeText = 5;

		// Token: 0x0402DBA5 RID: 187301
		public const int TitleItem = 6;

		// Token: 0x0402DBA6 RID: 187302
		public const int LeftLimitText = 7;
	}
}
