using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006260 RID: 25184
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpRolePackageData
	{
		// Token: 0x0603F776 RID: 259958 RVA: 0x01045380 File Offset: 0x01043580
		[NullableContext(2)]
		public static TotalTopUpRolePackageData TryParsePackageData(int itemId)
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
			if (giftPackageConfig == null || giftPackageConfig.Value.Type != GiftType.TotalTopUpRole)
			{
				return null;
			}
			TotalTopUpRolePackageData totalTopUpRolePackageData = new TotalTopUpRolePackageData();
			foreach (DicIntInt dicIntInt in giftPackageConfig.Value.ContentIter())
			{
				int key = dicIntInt.Key;
				int value = dicIntInt.Value;
				CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(key);
				if (itemConfigData != null && itemConfigData.ItemDataType == InventoryDefine.EItemDataType.RoleItem)
				{
					RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(key);
					totalTopUpRolePackageData.RoleList.Add((roleConfig != null) ? key : 0);
				}
				else if (totalTopUpRolePackageData.ItemId > 0)
				{
					string message = "TotalTopUpRolePackageData解析错误，包含多个非角色道具";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("GiftBagId", num);
					TotalTopUpUtil.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					totalTopUpRolePackageData.ItemId = key;
					totalTopUpRolePackageData.ItemCount = value;
				}
			}
			totalTopUpRolePackageData.GiftBagItemId = itemId;
			totalTopUpRolePackageData.RoleTrialIdList = new List<int>();
			foreach (int roleId in totalTopUpRolePackageData.RoleList)
			{
				totalTopUpRolePackageData.RoleTrialIdList.Add(TotalTopUpRolePackageData.RoleIdToTrialId(roleId));
			}
			TotalTopUpUtil.Debug("TotalTopUpRolePackageData解析成功", default(ReadOnlySpan<ValueTuple<string, object>>));
			return totalTopUpRolePackageData;
		}

		// Token: 0x0603F777 RID: 259959 RVA: 0x0104554C File Offset: 0x0104374C
		private static int RoleIdToTrialId(int roleId)
		{
			GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(roleId);
			if (gachaTextureInfo == null)
			{
				return 0;
			}
			return gachaTextureInfo.GetValueOrDefault().TrialId;
		}

		// Token: 0x040239EA RID: 145898
		public int GiftBagItemId;

		// Token: 0x040239EB RID: 145899
		public List<int> RoleList = new List<int>();

		// Token: 0x040239EC RID: 145900
		public List<int> RoleTrialIdList = new List<int>();

		// Token: 0x040239ED RID: 145901
		public int ItemId;

		// Token: 0x040239EE RID: 145902
		public int ItemCount;
	}
}
