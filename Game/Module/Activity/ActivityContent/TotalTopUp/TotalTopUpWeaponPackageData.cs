using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006261 RID: 25185
	public class TotalTopUpWeaponPackageData
	{
		// Token: 0x0603F779 RID: 259961 RVA: 0x010455A0 File Offset: 0x010437A0
		[NullableContext(2)]
		public unsafe static TotalTopUpWeaponPackageData TryParseWeaponPackageData(int itemId)
		{
			ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(itemId);
			if (config == null)
			{
				return null;
			}
			int num;
			if (!config.Value.Parameters().TryGetValue(2, out num))
			{
				return null;
			}
			GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(num);
			if (giftPackageConfig == null)
			{
				return null;
			}
			TotalTopUpWeaponPackageData totalTopUpWeaponPackageData = new TotalTopUpWeaponPackageData();
			foreach (DicIntInt dicIntInt in giftPackageConfig.Value.ContentIter())
			{
				int key = dicIntInt.Key;
				CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(key);
				if (itemConfigData == null || itemConfigData.ItemDataType != InventoryDefine.EItemDataType.WeaponItem)
				{
					string message = "TotalTopUpWeaponPackageData解析错误，包含非武器道具";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GiftBagId", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ItemId", key);
					TotalTopUpUtil.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return null;
				}
				WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(key);
				if (weaponConfigByItemId != null)
				{
					totalTopUpWeaponPackageData.WeaponTrialIdList.Add(weaponConfigByItemId.Value.HandBookTrialId);
				}
			}
			if (totalTopUpWeaponPackageData.WeaponTrialIdList.Count == 0)
			{
				return null;
			}
			string message2 = "TotalTopUpWeaponPackageData解析成功";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TrialIds", string.Join<int>(",", totalTopUpWeaponPackageData.WeaponTrialIdList));
			TotalTopUpUtil.Debug(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return totalTopUpWeaponPackageData;
		}

		// Token: 0x040239EF RID: 145903
		[Nullable(1)]
		public List<int> WeaponTrialIdList = new List<int>();
	}
}
