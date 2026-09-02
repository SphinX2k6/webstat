using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020023F2 RID: 9202
public class GiftPackageMonthlyCardItem : UiPanelBase
{
	// Token: 0x06011CF6 RID: 72950 RVA: 0x004E671D File Offset: 0x004E491D
	[NullableContext(1)]
	public GiftPackageMonthlyCardItem(int mothCardId, UUIItem uiItem)
	{
		this.MothCardId = mothCardId;
		base.CreateThenShowByResourceIdAsync("UiItem_GiftPackageMonthlyCard", uiItem, false).Forget();
	}

	// Token: 0x06011CF7 RID: 72951 RVA: 0x004E6740 File Offset: 0x004E4940
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011CF8 RID: 72952 RVA: 0x004E67EC File Offset: 0x004E49EC
	protected override void OnStart()
	{
		this.ImmediateRewardItem = new GiftPackageItem();
		this.ImmediateRewardItem.Initialize(base.GetItem(0));
		this.ImmediateRewardItem.SetBelongViewName(EUiViewName.GiftPackageDetailsView);
		this.DailyRewardItem = new GiftPackageItem();
		this.DailyRewardItem.Initialize(base.GetItem(1));
		this.ImmediateRewardItem.SetBelongViewName(EUiViewName.GiftPackageDetailsView);
		this.InitDailyRewardItem();
		this.Refresh();
		this.RefreshCloudGameInfo();
	}

	// Token: 0x06011CF9 RID: 72953 RVA: 0x004E6868 File Offset: 0x004E4A68
	public void InitDailyRewardItem()
	{
		int? intConfig = ConfigCommonParamById.GetIntConfig("MonthCardDailyItemId");
		int? intConfig2 = ConfigCommonParamById.GetIntConfig("MonthCardDailyItemCount");
		this.DailyRewardItem.UpdateItem(intConfig.Value, intConfig2.Value);
	}

	// Token: 0x06011CFA RID: 72954 RVA: 0x004E68A4 File Offset: 0x004E4AA4
	public void Update(int monthCardId)
	{
		this.MothCardId = monthCardId;
		this.Refresh();
	}

	// Token: 0x06011CFB RID: 72955 RVA: 0x004E68B4 File Offset: 0x004E4AB4
	public void Refresh()
	{
		if (base.InAsyncLoading())
		{
			return;
		}
		MonthCardContent value = ConfigBase<MonthCardConfig>.Instance.GetConfig(this.MothCardId).Value;
		this.ImmediateRewardItem.UpdateItem(value.ItemId, value.Count);
	}

	// Token: 0x06011CFC RID: 72956 RVA: 0x004E68FC File Offset: 0x004E4AFC
	private void RefreshCloudGameInfo()
	{
		PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(42);
		bool flag = payShopGoodsById.HasCloudGameInfo();
		UUIText text = base.GetText(3);
		text.SetUIActive(flag);
		if (flag)
		{
			text.SetText(payShopGoodsById.GetCloudGameDesc(), true);
		}
	}

	// Token: 0x04008B58 RID: 35672
	[Nullable(2)]
	private GiftPackageItem ImmediateRewardItem;

	// Token: 0x04008B59 RID: 35673
	[Nullable(2)]
	private GiftPackageItem DailyRewardItem;

	// Token: 0x04008B5A RID: 35674
	private int MothCardId;

	// Token: 0x0200872D RID: 34605
	private class EGiftPackageMonthlyCardItem
	{
		// Token: 0x0402DB9B RID: 187291
		public const int ImmediateRewardItem = 0;

		// Token: 0x0402DB9C RID: 187292
		public const int DailyRewardItem = 1;

		// Token: 0x0402DB9D RID: 187293
		public const int TipText = 2;

		// Token: 0x0402DB9E RID: 187294
		public const int CloudGameDesc = 3;
	}
}
