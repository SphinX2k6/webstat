using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;

// Token: 0x0200236F RID: 9071
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PayItemConfig : ConfigBase<PayItemConfig>
{
	// Token: 0x060115A0 RID: 71072 RVA: 0x004C7A85 File Offset: 0x004C5C85
	public IReadOnlyList<PayItem> GetPayItemList()
	{
		return ConfigPayItemAll.GetConfigList(true);
	}

	// Token: 0x060115A1 RID: 71073 RVA: 0x004C7A90 File Offset: 0x004C5C90
	public string GetProductIdByPayId(int id)
	{
		Pay? config = ConfigPayById.GetConfig(id, true);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().ProductId;
	}

	// Token: 0x060115A2 RID: 71074 RVA: 0x004C7AC0 File Offset: 0x004C5CC0
	public string GetProductIdByPayItemId(int payItemId)
	{
		PayItem? payItem;
		int? num = (ConfigPayItemById.GetConfig(payItemId, true) != null) ? new int?(payItem.GetValueOrDefault().PayId) : null;
		if (num == null)
		{
			return null;
		}
		Pay? config = ConfigPayById.GetConfig(num.Value, true);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().ProductId;
	}

	// Token: 0x060115A3 RID: 71075 RVA: 0x004C7B34 File Offset: 0x004C5D34
	public Pay? GetPayConf(int payId)
	{
		string currentSelectPayServerName = ModelBase<LoginServerModel>.Instance.GetCurrentSelectPayServerName();
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			IReadOnlyList<Pay> configList = ConfigPayByPayIdAndRegion.GetConfigList(payId, currentSelectPayServerName, true);
			if (configList != null && configList.Count > 0)
			{
				return new Pay?(configList[0]);
			}
		}
		IReadOnlyList<Pay> configList2 = ConfigPayByPayIdAndRegion.GetConfigList(payId, currentSelectPayServerName, true);
		if (configList2 != null && configList2.Count > 0)
		{
			return new Pay?(configList2[0]);
		}
		return null;
	}

	// Token: 0x060115A4 RID: 71076 RVA: 0x004C7BA5 File Offset: 0x004C5DA5
	public IReadOnlyList<Pay> GetCurrentRegionPayConfigList()
	{
		return ConfigPayByRegion.GetConfigList(ModelBase<LoginServerModel>.Instance.GetCurrentSelectPayServerName(), true);
	}

	// Token: 0x060115A5 RID: 71077 RVA: 0x004C7BB7 File Offset: 0x004C5DB7
	[NullableContext(1)]
	public string GetPayShowCurrency()
	{
		if (ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
		{
			return this.GetGlobalCurrencyChar();
		}
		return this.GetMainlandCurrencyChar();
	}

	// Token: 0x060115A6 RID: 71078 RVA: 0x004C7BD4 File Offset: 0x004C5DD4
	[NullableContext(1)]
	public string GetPayShow(int payId)
	{
		KuroSdkModel instance = ModelBase<KuroSdkModel>.Instance;
		string text = (instance != null) ? instance.GetQueryProductShowPrice(payId.ToString()) : null;
		if (text != null)
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string payShowCurrency = this.GetPayShowCurrency();
		stringBuilder.Append(payShowCurrency);
		string payIdAmount = ModelBase<RechargeModel>.Instance.GetPayIdAmount(payId);
		stringBuilder.Append(payIdAmount);
		return stringBuilder.ToString();
	}

	// Token: 0x060115A7 RID: 71079 RVA: 0x004C7C2C File Offset: 0x004C5E2C
	public int? GetPayIdByPayItemId(int payItemId)
	{
		if (ConfigPayItemById.GetConfig(payItemId, true) == null)
		{
			return null;
		}
		PayItem? payItem;
		return new int?(payItem.GetValueOrDefault().PayId);
	}

	// Token: 0x060115A8 RID: 71080 RVA: 0x004C7C68 File Offset: 0x004C5E68
	public PayItem? GetPayItem(int payItemId)
	{
		return ConfigPayItemById.GetConfig(payItemId, true);
	}

	// Token: 0x060115A9 RID: 71081 RVA: 0x004C7C71 File Offset: 0x004C5E71
	public int? GetWaitPaySuccessTime()
	{
		return ConfigCommonParamById.GetIntConfig("MaxWaitSuccessTime");
	}

	// Token: 0x060115AA RID: 71082 RVA: 0x004C7C7D File Offset: 0x004C5E7D
	public string GetMainlandCurrencyChar()
	{
		return ConfigCommonParamById.GetStringConfig("MainlandCurrencyChar");
	}

	// Token: 0x060115AB RID: 71083 RVA: 0x004C7C89 File Offset: 0x004C5E89
	public string GetGlobalCurrencyChar()
	{
		return ConfigCommonParamById.GetStringConfig("GlobalCurrencyChar");
	}

	// Token: 0x060115AC RID: 71084 RVA: 0x004C7C98 File Offset: 0x004C5E98
	public PayGift? GetRechargeGiftConfig(int id)
	{
		foreach (PayGift value in ConfigPayGiftAll.GetConfigList(true))
		{
			if (value.Id == id)
			{
				return new PayGift?(value);
			}
		}
		return null;
	}

	// Token: 0x060115AD RID: 71085 RVA: 0x004C7CFC File Offset: 0x004C5EFC
	public int GetRechargeItemRate()
	{
		return ConfigCommonParamById.GetIntConfig("RechargeItemRate").GetValueOrDefault();
	}

	// Token: 0x060115AE RID: 71086 RVA: 0x004C7D1C File Offset: 0x004C5F1C
	[NullableContext(1)]
	public string GetRegionMainCurrency()
	{
		IReadOnlyList<string> readOnlyList = ConfigCommonParamById.GetStringArrayConfig("RegionMainCurrency") ?? Array.Empty<string>();
		string currentSelectPayServerName = ModelBase<LoginServerModel>.Instance.GetCurrentSelectPayServerName();
		int count = readOnlyList.Count;
		for (int i = 0; i < count; i++)
		{
			string[] array = readOnlyList[i].Split(":", StringSplitOptions.None);
			if (array.Length == 2 && array[0] == currentSelectPayServerName)
			{
				return array[1];
			}
		}
		return "";
	}
}
