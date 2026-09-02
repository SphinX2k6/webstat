using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B78 RID: 23416
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ItemConfig : ConfigBase<ItemConfig>
	{
		// Token: 0x0603B336 RID: 242486 RVA: 0x00EFB214 File Offset: 0x00EF9414
		public ItemInfo? GetConfig(int itemConfigId)
		{
			ItemInfo? config = ConfigItemInfoById.GetConfig(itemConfigId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Item;
				ELogAuthor author = ELogAuthor.TL;
				string message = "获取物品配置错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemConfigId", itemConfigId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x0603B337 RID: 242487 RVA: 0x00EFB269 File Offset: 0x00EF9469
		public IReadOnlyList<ItemInfo> GetConfigListByItemType(int itemType)
		{
			return ConfigItemInfoByItemType.GetConfigList(itemType, true);
		}

		// Token: 0x0603B338 RID: 242488 RVA: 0x00EFB274 File Offset: 0x00EF9474
		public SpecialItem? GetSpecialItemConfig(int specialItemId)
		{
			SpecialItem? config = ConfigSpecialItemById.GetConfig(specialItemId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Item;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "获取特殊物品配置错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("specialItemId", specialItemId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x0603B339 RID: 242489 RVA: 0x00EFB2CC File Offset: 0x00EF94CC
		public ItemMainType? GetMainTypeConfig(int mainType)
		{
			ItemMainType? config = ConfigItemMainTypeById.GetConfig(mainType, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Item;
				ELogAuthor author = ELogAuthor.TL;
				string message = "获取物品主类型配置错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mainType", mainType);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x0603B33A RID: 242490 RVA: 0x00EFB324 File Offset: 0x00EF9524
		public QualityInfo? GetQualityConfig(int qualityId)
		{
			QualityInfo? config = ConfigQualityInfoById.GetConfig(qualityId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Item;
				ELogAuthor author = ELogAuthor.TL;
				string message = "获取获取物品品质配置错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("qualityId", qualityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x0603B33B RID: 242491 RVA: 0x00EFB37C File Offset: 0x00EF957C
		public int GetItemListMaxSize()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("item_list_max_size");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.ZJC, "外入包列表最大数量无法找到, 请检测c.参数字段\"item_list_max_size\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return intConfig.Value;
		}

		// Token: 0x0603B33C RID: 242492 RVA: 0x00EFB3C0 File Offset: 0x00EF95C0
		public int GetPriorItemListMaxSize()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("item_prior_list_max_size");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.LJQ, "外入包列表最大数量无法找到, 请检测c.参数字段\"item_prior_list_max_size\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return intConfig.Value;
		}

		// Token: 0x0603B33D RID: 242493 RVA: 0x00EFB404 File Offset: 0x00EF9604
		[NullableContext(1)]
		public string GetItemName(int itemId)
		{
			ItemInfo? itemInfo;
			string text = (this.GetConfig(itemId) != null) ? itemInfo.GetValueOrDefault().Name : null;
			if (text != null)
			{
				return ConfigMultiTextLang.GetLocalTextNew(text, null) ?? string.Empty;
			}
			return string.Empty;
		}

		// Token: 0x0603B33E RID: 242494 RVA: 0x00EFB450 File Offset: 0x00EF9650
		public unsafe string GetItemDesc(int itemId)
		{
			ItemInfo? config = this.GetConfig(itemId);
			if (config == null)
			{
				return null;
			}
			Span<int> showTypesBytes = config.Value.GetShowTypesBytes();
			int num = (showTypesBytes.Length > 0) ? (*showTypesBytes[0]) : 0;
			if (num == 0)
			{
				return null;
			}
			ItemShowType? itemShowTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemShowTypeConfig(num);
			if (itemShowTypeConfig == null)
			{
				return null;
			}
			return ConfigMultiTextLang.GetLocalTextNew(itemShowTypeConfig.Value.Name, null);
		}

		// Token: 0x0603B33F RID: 242495 RVA: 0x00EFB4CC File Offset: 0x00EF96CC
		public string GetItemAttributeDesc(int itemId)
		{
			ItemInfo? config = this.GetConfig(itemId);
			if (config == null)
			{
				return null;
			}
			return ConfigMultiTextLang.GetLocalTextNew(config.Value.AttributesDescription, null);
		}
	}
}
