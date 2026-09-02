using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Item;
using CSharpScript.Launcher.Platform.PlatformSdk;

// Token: 0x02002373 RID: 9075
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PayItemModel : ModelBase<PayItemModel>
{
	// Token: 0x060115D2 RID: 71122 RVA: 0x004C88E4 File Offset: 0x004C6AE4
	public void UpdateProductInfoMap(IEnumerable<DisplayProductInfo> data)
	{
		foreach (DisplayProductInfo displayProductInfo in data)
		{
			this.ProductInfoMap[displayProductInfo.GoodId] = displayProductInfo;
		}
	}

	// Token: 0x060115D3 RID: 71123 RVA: 0x004C8938 File Offset: 0x004C6B38
	[return: Nullable(2)]
	public string GetProductLabelByGoodsId(string goodsId)
	{
		DisplayProductInfo displayProductInfo;
		if (!this.ProductInfoMap.TryGetValue(goodsId, out displayProductInfo))
		{
			return null;
		}
		return displayProductInfo.GoodLabel;
	}

	// Token: 0x060115D4 RID: 71124 RVA: 0x004C8960 File Offset: 0x004C6B60
	[return: Nullable(2)]
	public string GetProductChannelGoodsIdByGoodsId(string goodsId)
	{
		DisplayProductInfo displayProductInfo;
		if (!this.ProductInfoMap.TryGetValue(goodsId, out displayProductInfo))
		{
			return null;
		}
		return displayProductInfo.ChannelGoodId;
	}

	// Token: 0x060115D5 RID: 71125 RVA: 0x004C8988 File Offset: 0x004C6B88
	[return: Nullable(2)]
	public DisplayProductInfo GetProductInfoByGoodsId(string goodsId)
	{
		DisplayProductInfo result;
		if (!this.ProductInfoMap.TryGetValue(goodsId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x060115D6 RID: 71126 RVA: 0x004C89A8 File Offset: 0x004C6BA8
	[return: Nullable(2)]
	public string GetProductCurrencyByGoodsId(string goodsId)
	{
		DisplayProductInfo displayProductInfo2;
		DisplayProductInfo displayProductInfo = this.ProductInfoMap.TryGetValue(goodsId, out displayProductInfo2) ? displayProductInfo2 : null;
		string text = (displayProductInfo != null && displayProductInfo.Price != null) ? displayProductInfo.Price : null;
		if (text == null)
		{
			return null;
		}
		Match match = Regex.Match(text, "[a-zA-Z]+$");
		if (!match.Success)
		{
			return null;
		}
		return match.Value;
	}

	// Token: 0x060115D7 RID: 71127 RVA: 0x004C8A00 File Offset: 0x004C6C00
	[return: Nullable(2)]
	public string GetProductPriceByGoodsId(string goodsId)
	{
		DisplayProductInfo displayProductInfo2;
		DisplayProductInfo displayProductInfo = this.ProductInfoMap.TryGetValue(goodsId, out displayProductInfo2) ? displayProductInfo2 : null;
		string text = (displayProductInfo != null && displayProductInfo.Price != null) ? displayProductInfo.Price : null;
		if (text == null)
		{
			return null;
		}
		Match match = Regex.Match(text, "^[\\d,.]+");
		if (!match.Success)
		{
			return null;
		}
		return match.Value;
	}

	// Token: 0x060115D8 RID: 71128 RVA: 0x004C8A58 File Offset: 0x004C6C58
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<PayItemData> GetDataList()
	{
		return this.CurrentPayItemDataList;
	}

	// Token: 0x060115D9 RID: 71129 RVA: 0x004C8A60 File Offset: 0x004C6C60
	[NullableContext(2)]
	public string GetPayingItemName()
	{
		return this.PayingItemName;
	}

	// Token: 0x060115DA RID: 71130 RVA: 0x004C8A68 File Offset: 0x004C6C68
	public void CleanPayingItemName()
	{
		this.PayingItemName = null;
	}

	// Token: 0x060115DB RID: 71131 RVA: 0x004C8A71 File Offset: 0x004C6C71
	public PayShopItemBaseSt ConvertPayItemDataToPayShopItemBaseSt(PayItemData source)
	{
		return source.ConvertPayItemDataToPayShopItemBaseSt();
	}

	// Token: 0x060115DC RID: 71132 RVA: 0x004C8A7C File Offset: 0x004C6C7C
	public void UpdatePayingItemName(int payItemId)
	{
		PayItem? payItem = ConfigBase<PayItemConfig>.Instance.GetPayItem(payItemId);
		string itemName = ConfigBase<ItemConfig>.Instance.GetItemName(payItem.Value.ItemId);
		this.PayingItemName = itemName;
	}

	// Token: 0x060115DD RID: 71133 RVA: 0x004C8AB8 File Offset: 0x004C6CB8
	public void ResetSpecialBonus(int[] ids)
	{
		foreach (int key in ids)
		{
			PayItemData payItemData;
			if (this.CurrencyPayItemMap.TryGetValue(key, out payItemData))
			{
				payItemData.CanSpecialBonus = true;
			}
		}
	}

	// Token: 0x060115DE RID: 71134 RVA: 0x004C8AF0 File Offset: 0x004C6CF0
	public void InitDataListByServer(PayItemInfo[] infos)
	{
		if (this.CurrentPayItemDataList.Count != 0 && infos.Length != 0)
		{
			this.CurrentPayItemDataList.Clear();
		}
		foreach (PayItemInfo payItemInfo in infos)
		{
			PayItemData payItemData = new PayItemData();
			payItemData.Phrase(payItemInfo);
			this.CurrentPayItemDataList.Add(payItemData);
			this.CurrencyPayItemMap[payItemInfo.Id] = payItemData;
		}
	}

	// Token: 0x060115DF RID: 71135 RVA: 0x004C8B58 File Offset: 0x004C6D58
	protected override bool OnClear()
	{
		this.CurrentPayItemDataList.Clear();
		this.CurrentPayItemDataList = null;
		this.CurrencyPayItemMap.Clear();
		this.Version = "";
		this.PayingItemName = null;
		return true;
	}

	// Token: 0x060115E0 RID: 71136 RVA: 0x004C8B8C File Offset: 0x004C6D8C
	public ISDKPayment CreateSdkPayment(int payItemId, string orderId, string callBackUrl)
	{
		PayItem? payItem = ConfigBase<PayItemConfig>.Instance.GetPayItem(payItemId);
		string itemName = ConfigBase<ItemConfig>.Instance.GetItemName(payItem.Value.ItemId);
		string itemDesc = ConfigBase<ItemConfig>.Instance.GetItemDesc(payItem.Value.ItemId);
		int payId = payItem.Value.PayId;
		string payIdAmount = ModelBase<RechargeModel>.Instance.GetPayIdAmount(payId);
		string payIdProductId = ModelBase<RechargeModel>.Instance.GetPayIdProductId(payId);
		SDKPayment sdkpayment = new SDKPayment();
		sdkpayment.product_id = payIdProductId;
		sdkpayment.cpOrderId = orderId;
		sdkpayment.price = payIdAmount;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted(itemName);
		defaultInterpolatedStringHandler.AppendFormatted<int>(payItem.Value.ItemCount);
		sdkpayment.goodsName = defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted(itemDesc);
		defaultInterpolatedStringHandler.AppendFormatted<int>(payItem.Value.ItemCount);
		sdkpayment.goodsDesc = defaultInterpolatedStringHandler.ToStringAndClear();
		sdkpayment.extraParams = " ";
		sdkpayment.callbackUrl = callBackUrl;
		sdkpayment.currency = "";
		return sdkpayment;
	}

	// Token: 0x060115E1 RID: 71137 RVA: 0x004C8CB0 File Offset: 0x004C6EB0
	public bool HasBonusData()
	{
		if (this.CurrentPayItemDataList.Count == 0)
		{
			return false;
		}
		using (List<PayItemData>.Enumerator enumerator = this.CurrentPayItemDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CanSpecialBonus)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x04008879 RID: 34937
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<PayItemData> CurrentPayItemDataList = new List<PayItemData>();

	// Token: 0x0400887A RID: 34938
	private readonly Dictionary<int, PayItemData> CurrencyPayItemMap = new Dictionary<int, PayItemData>();

	// Token: 0x0400887B RID: 34939
	public string Version = "";

	// Token: 0x0400887C RID: 34940
	[Nullable(2)]
	private string PayingItemName;

	// Token: 0x0400887D RID: 34941
	private readonly Dictionary<string, DisplayProductInfo> ProductInfoMap = new Dictionary<string, DisplayProductInfo>();
}
