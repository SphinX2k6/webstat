using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020029F3 RID: 10739
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ShopConfig : ConfigBase<ShopConfig>
{
	// Token: 0x060156CE RID: 87758 RVA: 0x005EFC68 File Offset: 0x005EDE68
	[return: Nullable(2)]
	public string GetTextConfig(string key)
	{
		return ConfigBase<TextConfig>.Instance.GetTextById(key);
	}

	// Token: 0x060156CF RID: 87759 RVA: 0x005EFC75 File Offset: 0x005EDE75
	[return: Nullable(2)]
	public string GetShopName(string shopNameId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(shopNameId, null);
	}

	// Token: 0x060156D0 RID: 87760 RVA: 0x005EFC80 File Offset: 0x005EDE80
	public ShopInfo GetShopInfoConfig(int shopId)
	{
		ShopInfo? config = ConfigShopInfoById.GetConfig(shopId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Shop;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "查表ShopInfo错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", shopId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x060156D1 RID: 87761 RVA: 0x005EFCD4 File Offset: 0x005EDED4
	public IReadOnlyList<ShopFixed> GetFixedShopList(int shopId)
	{
		IReadOnlyList<ShopFixed> configList = ConfigShopFixedByShopId.GetConfigList(shopId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Shop;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "表ShopFixed配置找不到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ShopId", shopId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return configList;
	}

	// Token: 0x060156D2 RID: 87762 RVA: 0x005EFD18 File Offset: 0x005EDF18
	public unsafe ShopFixed? GetShopFixedInfoByItemId(int shopId, int id)
	{
		ShopFixed? config = ConfigShopFixedByShopIdAndId.GetConfig(shopId, id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Shop;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "表ShopFixed配置找不到";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ShopId", shopId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config;
	}
}
