using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Inventory
{
	// Token: 0x02005B89 RID: 23433
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemViewData
	{
		// Token: 0x0603B3D8 RID: 242648 RVA: 0x00EFF980 File Offset: 0x00EFDB80
		public ItemViewData(InventoryDefine.IItemViewDataInfo itemViewInfo)
		{
			this.ItemViewInfo = itemViewInfo;
		}

		// Token: 0x0603B3D9 RID: 242649 RVA: 0x00EFF98F File Offset: 0x00EFDB8F
		public void SetItemViewInfo(InventoryDefine.IItemViewDataInfo itemViewInfo)
		{
			this.ItemViewInfo = itemViewInfo;
		}

		// Token: 0x0603B3DA RID: 242650 RVA: 0x00EFF998 File Offset: 0x00EFDB98
		public InventoryDefine.IItemViewDataInfo GetItemViewInfo()
		{
			return this.ItemViewInfo;
		}

		// Token: 0x0603B3DB RID: 242651 RVA: 0x00EFF9A0 File Offset: 0x00EFDBA0
		private void SetIsNew(bool isNew)
		{
			this.ItemViewInfo.IsNewItem = isNew;
		}

		// Token: 0x0603B3DC RID: 242652 RVA: 0x00EFF9AE File Offset: 0x00EFDBAE
		public void SetIsLock(bool bIsLock)
		{
			this.ItemViewInfo.IsLock = bIsLock;
		}

		// Token: 0x0603B3DD RID: 242653 RVA: 0x00EFF9BC File Offset: 0x00EFDBBC
		public void SetIsDeprecate(bool isDeprecate)
		{
			this.ItemViewInfo.IsDeprecate = isDeprecate;
		}

		// Token: 0x0603B3DE RID: 242654 RVA: 0x00EFF9CA File Offset: 0x00EFDBCA
		public void SetHasRedDot(bool hasRedDot)
		{
			this.ItemViewInfo.HasRedDot = hasRedDot;
		}

		// Token: 0x0603B3DF RID: 242655 RVA: 0x00EFF9D8 File Offset: 0x00EFDBD8
		public InventoryDefine.ERedDotDisableRule GetRedDotDisableRule()
		{
			int configId = this.GetConfigId();
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(configId);
			if (itemConfigData == null)
			{
				return InventoryDefine.ERedDotDisableRule.None;
			}
			return itemConfigData.RedDotDisableRule;
		}

		// Token: 0x0603B3E0 RID: 242656 RVA: 0x00EFFA03 File Offset: 0x00EFDC03
		public int GetConfigId()
		{
			return this.ItemViewInfo.ConfigId;
		}

		// Token: 0x0603B3E1 RID: 242657 RVA: 0x00EFFA10 File Offset: 0x00EFDC10
		public int? GetUniqueId()
		{
			ItemDataBase itemDataBase = this.GetItemDataBase();
			if (itemDataBase == null)
			{
				return null;
			}
			return new int?(itemDataBase.GetUniqueId());
		}

		// Token: 0x0603B3E2 RID: 242658 RVA: 0x00EFFA3B File Offset: 0x00EFDC3B
		public int GetQuality()
		{
			ItemDataBase itemDataBase = this.GetItemDataBase();
			if (itemDataBase == null)
			{
				return 0;
			}
			return itemDataBase.GetQuality();
		}

		// Token: 0x0603B3E3 RID: 242659 RVA: 0x00EFFA4E File Offset: 0x00EFDC4E
		public void SetCount(int count)
		{
			this.ItemViewInfo.Count = count;
		}

		// Token: 0x0603B3E4 RID: 242660 RVA: 0x00EFFA5C File Offset: 0x00EFDC5C
		public int GetCount()
		{
			return this.ItemViewInfo.Count;
		}

		// Token: 0x0603B3E5 RID: 242661 RVA: 0x00EFFA69 File Offset: 0x00EFDC69
		public void SetStackId(int stackId)
		{
			this.ItemViewInfo.StackId = stackId;
		}

		// Token: 0x0603B3E6 RID: 242662 RVA: 0x00EFFA77 File Offset: 0x00EFDC77
		public int GetStackId()
		{
			return this.ItemViewInfo.StackId;
		}

		// Token: 0x0603B3E7 RID: 242663 RVA: 0x00EFFA84 File Offset: 0x00EFDC84
		public void SetSelectOn(bool isSelectOn)
		{
			this.ItemViewInfo.IsSelectOn = isSelectOn;
		}

		// Token: 0x0603B3E8 RID: 242664 RVA: 0x00EFFA92 File Offset: 0x00EFDC92
		public bool GetSelectOn()
		{
			return this.ItemViewInfo.IsSelectOn;
		}

		// Token: 0x0603B3E9 RID: 242665 RVA: 0x00EFFA9F File Offset: 0x00EFDC9F
		public void SetSelectNum(int selectNum)
		{
			this.ItemViewInfo.SelectOnNum = selectNum;
		}

		// Token: 0x0603B3EA RID: 242666 RVA: 0x00EFFAAD File Offset: 0x00EFDCAD
		public int GetSelectNum()
		{
			return this.ItemViewInfo.SelectOnNum;
		}

		// Token: 0x0603B3EB RID: 242667 RVA: 0x00EFFABA File Offset: 0x00EFDCBA
		[NullableContext(2)]
		public ItemDataBase GetItemDataBase()
		{
			return this.ItemViewInfo.ItemDataBase;
		}

		// Token: 0x0603B3EC RID: 242668 RVA: 0x00EFFAC7 File Offset: 0x00EFDCC7
		public InventoryDefine.EItemDataType GetItemDataType()
		{
			return this.ItemViewInfo.ItemDataType;
		}

		// Token: 0x0603B3ED RID: 242669 RVA: 0x00EFFAD4 File Offset: 0x00EFDCD4
		public int GetSortIndex()
		{
			ItemDataBase itemDataBase = this.GetItemDataBase();
			if (itemDataBase == null)
			{
				return 0;
			}
			return itemDataBase.GetSortIndex();
		}

		// Token: 0x0603B3EE RID: 242670 RVA: 0x00EFFAF4 File Offset: 0x00EFDCF4
		public void RemoveNewItem()
		{
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			bool itemDataType = this.GetItemDataType() != InventoryDefine.EItemDataType.CommonItem;
			int configId = this.GetConfigId();
			int? uniqueId = this.GetUniqueId();
			if (!itemDataType)
			{
				instance.RemoveNewCommonItem(configId, uniqueId.Value);
			}
			else
			{
				instance.RemoveNewAttributeItem(uniqueId.Value);
			}
			this.SetIsNew(false);
		}

		// Token: 0x0603B3EF RID: 242671 RVA: 0x00EFFB44 File Offset: 0x00EFDD44
		public void RemoveRedDotItem()
		{
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			bool itemDataType = this.GetItemDataType() != InventoryDefine.EItemDataType.CommonItem;
			int configId = this.GetConfigId();
			int? uniqueId = this.GetUniqueId();
			if (!itemDataType)
			{
				instance.RemoveRedDotCommonItem(configId, uniqueId.Value);
			}
			else
			{
				instance.RemoveRedDotAttributeItem(uniqueId.Value);
			}
			this.SetHasRedDot(false);
		}

		// Token: 0x0603B3F0 RID: 242672 RVA: 0x00EFFB93 File Offset: 0x00EFDD93
		public bool IsBuffItem()
		{
			return ConfigBase<BuffItemConfig>.Instance.IsBuffItem(this.GetConfigId());
		}

		// Token: 0x0603B3F1 RID: 242673 RVA: 0x00EFFBA5 File Offset: 0x00EFDDA5
		public bool IsTeamBuffItem()
		{
			return ConfigBase<BuffItemConfig>.Instance.IsTeamBuffItem(this.GetConfigId());
		}

		// Token: 0x0603B3F2 RID: 242674 RVA: 0x00EFFBB7 File Offset: 0x00EFDDB7
		public UiPlayItem? GetUiPlayItem()
		{
			return ConfigUiPlayItemById.GetConfig(this.GetConfigId(), true);
		}

		// Token: 0x0603B3F3 RID: 242675 RVA: 0x00EFFBC8 File Offset: 0x00EFDDC8
		public InventoryDefine.EItemType? GetItemType()
		{
			ItemDataBase itemDataBase = this.GetItemDataBase();
			if (itemDataBase == null)
			{
				return null;
			}
			return itemDataBase.GetType();
		}

		// Token: 0x0603B3F4 RID: 242676 RVA: 0x00EFFBF0 File Offset: 0x00EFDDF0
		public int GetAttributeLevel()
		{
			InventoryDefine.EItemDataType itemDataType = this.GetItemDataType();
			int? uniqueId = this.GetUniqueId();
			if (itemDataType == InventoryDefine.EItemDataType.PhantomItem)
			{
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId.Value);
				if (phantomBattleData == null)
				{
					return 0;
				}
				return phantomBattleData.GetPhantomLevel();
			}
			else
			{
				if (itemDataType == InventoryDefine.EItemDataType.WeaponItem)
				{
					return ModelBase<WeaponModel>.Instance.GetWeaponLevelById(uniqueId.GetValueOrDefault());
				}
				return 0;
			}
		}

		// Token: 0x0603B3F5 RID: 242677 RVA: 0x00EFFC44 File Offset: 0x00EFDE44
		public ItemViewDefine.EItemOperationMode GetItemOperationType()
		{
			return this.ItemViewInfo.ItemOperationMode;
		}

		// Token: 0x0603B3F6 RID: 242678 RVA: 0x00EFFC54 File Offset: 0x00EFDE54
		public bool IsItemCanDestroy()
		{
			switch (this.GetItemDataType())
			{
			case InventoryDefine.EItemDataType.CommonItem:
			{
				CommonItemData commonItemData = this.GetItemDataBase() as CommonItemData;
				return commonItemData != null && commonItemData.GetConfig().As<ItemInfo>().Value.Destructible;
			}
			case InventoryDefine.EItemDataType.WeaponItem:
			{
				WeaponItemData weaponItemData = this.GetItemDataBase() as WeaponItemData;
				if (weaponItemData == null)
				{
					return false;
				}
				int uniqueId = weaponItemData.GetUniqueId();
				WeaponInstance weaponInstance = (uniqueId > 0) ? ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(uniqueId) : null;
				bool isLock = weaponItemData.GetIsLock();
				bool flag = weaponInstance != null && weaponInstance.GetRoleId() != 0;
				bool destructible = weaponItemData.GetConfig().As<WeaponConf>().Value.Destructible;
				bool flag2 = weaponInstance != null && weaponInstance.HasWeaponCultivated();
				return destructible && !isLock && !flag && !flag2;
			}
			case InventoryDefine.EItemDataType.PhantomItem:
			{
				PhantomItemData phantomItemData = this.GetItemDataBase() as PhantomItemData;
				if (phantomItemData == null)
				{
					return false;
				}
				int uniqueId2 = phantomItemData.GetUniqueId();
				bool isLock2 = phantomItemData.GetIsLock();
				int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(uniqueId2);
				bool flag3 = equipRole != null && equipRole.Value != 0;
				return phantomItemData.GetConfig().As<PhantomItem>().Value.Destructible && !isLock2 && !flag3;
			}
			}
			return false;
		}

		// Token: 0x0603B3F7 RID: 242679 RVA: 0x00EFFDB8 File Offset: 0x00EFDFB8
		public bool IsEqual(ItemViewData itemViewDataB, bool? needStackEqual = null)
		{
			bool flag = this.GetConfigId() == itemViewDataB.GetConfigId();
			int? uniqueId = this.GetUniqueId();
			int? uniqueId2 = itemViewDataB.GetUniqueId();
			bool flag2 = uniqueId.GetValueOrDefault() == uniqueId2.GetValueOrDefault() & uniqueId != null == (uniqueId2 != null);
			bool flag3 = this.GetStackId() == itemViewDataB.GetStackId();
			if (needStackEqual.GetValueOrDefault())
			{
				return flag && flag2 && flag3;
			}
			return flag && flag2;
		}

		// Token: 0x04021679 RID: 136825
		private InventoryDefine.IItemViewDataInfo ItemViewInfo;
	}
}
