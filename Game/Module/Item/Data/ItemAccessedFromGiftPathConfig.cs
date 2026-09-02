using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Item.Data
{
	// Token: 0x02005B82 RID: 23426
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ItemAccessedFromGiftPathConfig : ConfigBase<ItemAccessedFromGiftPathConfig>
	{
		// Token: 0x0603B384 RID: 242564 RVA: 0x00EFC467 File Offset: 0x00EFA667
		public ItemAccessedPath? GetItemAccessedFromGiftPathConfig(int id)
		{
			return ConfigItemAccessedPathById.GetConfig(id, true);
		}

		// Token: 0x0603B385 RID: 242565 RVA: 0x00EFC470 File Offset: 0x00EFA670
		public unsafe List<int> GetGiftItemGroupById(int itemID, bool ignoreNotExistError = false)
		{
			List<int> list = new List<int>();
			ItemAccessedPath? config = ConfigItemAccessedPathById.GetConfig(itemID, true);
			if (config == null)
			{
				if (!ignoreNotExistError)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SkipInterface;
					ELogAuthor author = ELogAuthor.WHJ;
					string message = "[SkipInterface]道具ID不存在，找不到ItemAccessedPath配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemID", itemID);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				return list;
			}
			foreach (int num in config.Value.GiftItemGroup())
			{
				ItemInfo? config2 = ConfigItemInfoById.GetConfig(num, true);
				if (config2 == null || config2.Value.ItemType != 11 || !config2.Value.Parameters().ContainsKey(2))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SkipInterface;
					ELogAuthor author2 = ELogAuthor.WHJ;
					string message2 = "[SkipInterface]道具存在异常";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("giftItemID", num);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else
				{
					int num2 = config2.Value.Parameters()[2];
					GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(num2);
					if (giftPackageConfig == null || !giftPackageConfig.Value.Content().ContainsKey(itemID))
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.SkipInterface;
						ELogAuthor author3 = ELogAuthor.WHJ;
						string message3 = "[SkipInterface]礼包内不存在对应道具";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("itemID", itemID);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("giftItemID", num);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("giftID", num2);
						instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					}
					else
					{
						list.Add(num);
					}
				}
			}
			return list;
		}
	}
}
