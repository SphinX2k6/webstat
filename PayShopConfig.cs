using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020023AC RID: 9132
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PayShopConfig : ConfigBase<PayShopConfig>
{
	// Token: 0x0601199A RID: 72090 RVA: 0x004D3C0D File Offset: 0x004D1E0D
	public string GetPayShopGoodsLocalText(string textId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(textId, null);
	}

	// Token: 0x0601199B RID: 72091 RVA: 0x004D3C18 File Offset: 0x004D1E18
	public PayShop GetPayShopConfig(int payShopId)
	{
		PayShop? config = ConfigPayShopById.GetConfig(payShopId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "查询商城数据失败,查看商业化商城表格PayShop";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("商城ID", payShopId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x0601199C RID: 72092 RVA: 0x004D3C6C File Offset: 0x004D1E6C
	public PayShopDirectGoods GetPayShopDirectGoods(int goodsId)
	{
		PayShopDirectGoods? config = ConfigPayShopDirectGoodsByGoodsId.GetConfig(goodsId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "查询直购商品ID数据失败,查看商业化商城表格PayShopDirectGoods";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("直购商品ID", goodsId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x0601199D RID: 72093 RVA: 0x004D3CC0 File Offset: 0x004D1EC0
	public PayShopCondition GetPayShopCondition(int conditionId)
	{
		PayShopCondition? config = ConfigPayShopConditionById.GetConfig(conditionId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "查询商品条件ID数据失败,查看商业化商城表格PayShopCondition";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("商品条件ID", conditionId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x0601199E RID: 72094 RVA: 0x004D3D11 File Offset: 0x004D1F11
	public string GetPayShopConditionLocalText(string textId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(textId, null);
	}

	// Token: 0x0601199F RID: 72095 RVA: 0x004D3D1C File Offset: 0x004D1F1C
	public string GetShopDiscountLabel(int type)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("ShopDiscountLabel_");
		defaultInterpolatedStringHandler.AppendFormatted<int>(type);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060119A0 RID: 72096 RVA: 0x004D3D50 File Offset: 0x004D1F50
	public int GetMonthCardShopId()
	{
		return ConfigCommonParamById.GetIntConfig("MonthCardPayItemId").Value;
	}

	// Token: 0x060119A1 RID: 72097 RVA: 0x004D3D70 File Offset: 0x004D1F70
	public int GetMonthCardRewardId()
	{
		return ConfigCommonParamById.GetIntConfig("MonthCardRewardId").Value;
	}

	// Token: 0x060119A2 RID: 72098 RVA: 0x004D3D8F File Offset: 0x004D1F8F
	public IReadOnlyList<int> GetRecommendRoleSkinIdList()
	{
		return ConfigCommonParamById.GetIntArrayConfig("RecommendRoleSkinId");
	}

	// Token: 0x060119A3 RID: 72099 RVA: 0x004D3D9C File Offset: 0x004D1F9C
	public PayShopRecommend GetRecommendDataById(int id)
	{
		return ConfigPayShopRecommendById.GetConfig(id, true).Value;
	}

	// Token: 0x060119A4 RID: 72100 RVA: 0x004D3DB8 File Offset: 0x004D1FB8
	public int GetBuySkinDetailWeaponCameraId()
	{
		return ConfigCommonParamById.GetIntConfig("BuySkinDetailWeaponCameraId").Value;
	}

	// Token: 0x060119A5 RID: 72101 RVA: 0x004D3DD8 File Offset: 0x004D1FD8
	public int GetBuySkinDetailRoleCameraId()
	{
		return ConfigCommonParamById.GetIntConfig("BuySkinDetailRoleCameraId").Value;
	}

	// Token: 0x060119A6 RID: 72102 RVA: 0x004D3DF7 File Offset: 0x004D1FF7
	public string GetBuySkinDetailRoleCameraConfigId()
	{
		return ConfigCommonParamById.GetStringConfig("BuySkinDetailRoleCameraConfigId");
	}

	// Token: 0x060119A7 RID: 72103 RVA: 0x004D3E03 File Offset: 0x004D2003
	public string GetBuySkinDetailWeaponCameraConfigId()
	{
		return ConfigCommonParamById.GetStringConfig("BuySkinDetailWeaponCameraConfigId");
	}

	// Token: 0x060119A8 RID: 72104 RVA: 0x004D3E10 File Offset: 0x004D2010
	public int GetPreviewPayGiftItemTemplateId()
	{
		return ConfigCommonParamById.GetIntConfig("PayGiftTemplateId").Value;
	}
}
