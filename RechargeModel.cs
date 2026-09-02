using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200274A RID: 10058
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RechargeModel : ModelBase<RechargeModel>
{
	// Token: 0x06013DBC RID: 81340 RVA: 0x00588F80 File Offset: 0x00587180
	public void SetRechargeInfo(int payId, string amount, string productId)
	{
		RechargeInfo rechargeInfo;
		if (!this.RechargeInfoMap.TryGetValue(payId, out rechargeInfo))
		{
			rechargeInfo = new RechargeInfo();
		}
		rechargeInfo.Init(payId, this.FormatNumberString(amount), productId);
		this.RechargeInfoMap[payId] = rechargeInfo;
	}

	// Token: 0x06013DBD RID: 81341 RVA: 0x00588FC0 File Offset: 0x005871C0
	public string GetPayIdAmount(int payId)
	{
		RechargeInfo rechargeInfo;
		if (this.RechargeInfoMap.TryGetValue(payId, out rechargeInfo))
		{
			return rechargeInfo.Amount;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "获取PayId的服务器价格失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", payId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return "0";
	}

	// Token: 0x06013DBE RID: 81342 RVA: 0x00589018 File Offset: 0x00587218
	private string FormatNumberString(string s)
	{
		float num;
		if (!float.TryParse(s, out num))
		{
			return s;
		}
		string text = num.ToString();
		int num2 = text.IndexOf('.');
		if (num2 == -1 || (num2 != -1 && text.Length - num2 - 1 == 1))
		{
			return num.ToString("F2");
		}
		return text;
	}

	// Token: 0x06013DBF RID: 81343 RVA: 0x00589068 File Offset: 0x00587268
	public string GetPayIdProductId(int payId)
	{
		RechargeInfo rechargeInfo;
		if (this.RechargeInfoMap.TryGetValue(payId, out rechargeInfo))
		{
			return rechargeInfo.ProductId;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "获取PayId的商品名称价格失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", payId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return "";
	}

	// Token: 0x04009A73 RID: 39539
	private readonly Dictionary<int, RechargeInfo> RechargeInfoMap = new Dictionary<int, RechargeInfo>();
}
