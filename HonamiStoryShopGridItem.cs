using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.PayShop;

// Token: 0x02001F67 RID: 8039
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryShopGridItem : ActivityGrid
{
	// Token: 0x0600F0C1 RID: 61633 RVA: 0x0041CBA2 File Offset: 0x0041ADA2
	protected override void OnStart()
	{
		base.OnStart();
		base.SetExtraFunction(new Action<PayShopItem, PayShopGoods>(this.ClearNewFlagState));
		base.SetRedDotState(false);
	}

	// Token: 0x0600F0C2 RID: 61634 RVA: 0x0041CBC4 File Offset: 0x0041ADC4
	public override void Refresh(IPayShopUnionData data, bool isSelected, int gridIndex)
	{
		PayShopGoods payShopGoods = data as PayShopGoods;
		if (payShopGoods == null)
		{
			return;
		}
		base.Refresh(data, isSelected, gridIndex);
		PayShopGoods payShopGoods2 = payShopGoods;
		bool redDotState = !ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, payShopGoods2.GetGoodsId());
		base.SetRedDotState(redDotState);
		PayShopExchangeExtraData payShopExchangeExtraData = new PayShopExchangeExtraData();
		int itemId = payShopGoods2.GetGoodsData().ItemId;
		if (HonamiStoryUtil.CheckIsPluginBoxItem(itemId))
		{
			HonamiStoryPluginBoxItem? pluginBoxConfig = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryPluginBoxItemById(itemId);
			payShopExchangeExtraData.GetMaxBuyCount = (() => pluginBoxConfig.Value.BuyLimit);
		}
		payShopExchangeExtraData.CheckIfCanBuy = delegate()
		{
			if (ModelBase<HonamiStoryModel>.Instance.GetBackPackData(1, false).GetOverflowCapacity() > 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_WarehouseFullShop", Array.Empty<object>());
				return false;
			}
			return true;
		};
		base.SetExchangeExtraData(payShopExchangeExtraData);
	}

	// Token: 0x0600F0C3 RID: 61635 RVA: 0x0041CC79 File Offset: 0x0041AE79
	private void ClearNewFlagState(PayShopItem item, PayShopGoods data)
	{
		base.SetRedDotState(false);
		ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, data.GetGoodsId());
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.PayShopTabItemChecked);
	}
}
