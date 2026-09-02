using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using FilterDefine;

// Token: 0x0200205B RID: 8283
[NullableContext(1)]
[Nullable(0)]
public class ItemViewData : IPhantomFilterData
{
	// Token: 0x0600FC53 RID: 64595 RVA: 0x004550F4 File Offset: 0x004532F4
	public ItemViewData(InventoryDefine.IItemViewDataInfo itemViewInfo)
	{
		this.ItemViewInfo = itemViewInfo;
	}

	// Token: 0x0600FC54 RID: 64596 RVA: 0x00455103 File Offset: 0x00453303
	public void SetItemViewInfo(InventoryDefine.IItemViewDataInfo itemViewInfo)
	{
		this.ItemViewInfo = itemViewInfo;
	}

	// Token: 0x0600FC55 RID: 64597 RVA: 0x0045510C File Offset: 0x0045330C
	public InventoryDefine.IItemViewDataInfo GetItemViewInfo()
	{
		return this.ItemViewInfo;
	}

	// Token: 0x0600FC56 RID: 64598 RVA: 0x00455114 File Offset: 0x00453314
	private void SetIsNew(bool isNew)
	{
		this.ItemViewInfo.IsNewItem = isNew;
	}

	// Token: 0x0600FC57 RID: 64599 RVA: 0x00455122 File Offset: 0x00453322
	public void SetIsLock(bool bIsLock)
	{
		this.ItemViewInfo.IsLock = bIsLock;
	}

	// Token: 0x0600FC58 RID: 64600 RVA: 0x00455130 File Offset: 0x00453330
	public void SetIsDeprecate(bool isDeprecate)
	{
		this.ItemViewInfo.IsDeprecate = isDeprecate;
	}

	// Token: 0x0600FC59 RID: 64601 RVA: 0x0045513E File Offset: 0x0045333E
	public void SetHasRedDot(bool hasRedDot)
	{
		this.ItemViewInfo.HasRedDot = hasRedDot;
	}

	// Token: 0x0600FC5A RID: 64602 RVA: 0x0045514C File Offset: 0x0045334C
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

	// Token: 0x0600FC5B RID: 64603 RVA: 0x00455177 File Offset: 0x00453377
	public int GetConfigId()
	{
		return this.ItemViewInfo.ConfigId;
	}

	// Token: 0x0600FC5C RID: 64604 RVA: 0x00455184 File Offset: 0x00453384
	public int GetUniqueId()
	{
		ItemDataBase itemDataBase = this.GetItemDataBase();
		if (itemDataBase == null)
		{
			return 0;
		}
		return itemDataBase.GetUniqueId();
	}

	// Token: 0x0600FC5D RID: 64605 RVA: 0x004551A4 File Offset: 0x004533A4
	public int GetQuality()
	{
		ItemDataBase itemDataBase = this.GetItemDataBase();
		if (itemDataBase == null)
		{
			return 0;
		}
		return itemDataBase.GetQuality();
	}

	// Token: 0x0600FC5E RID: 64606 RVA: 0x004551C3 File Offset: 0x004533C3
	public void SetCount(int count)
	{
		this.ItemViewInfo.Count = count;
	}

	// Token: 0x0600FC5F RID: 64607 RVA: 0x004551D1 File Offset: 0x004533D1
	public int GetCount()
	{
		return this.ItemViewInfo.Count;
	}

	// Token: 0x0600FC60 RID: 64608 RVA: 0x004551DE File Offset: 0x004533DE
	public void SetStackId(int stackId)
	{
		this.ItemViewInfo.StackId = stackId;
	}

	// Token: 0x0600FC61 RID: 64609 RVA: 0x004551EC File Offset: 0x004533EC
	public int GetStackId()
	{
		return this.ItemViewInfo.StackId;
	}

	// Token: 0x0600FC62 RID: 64610 RVA: 0x004551F9 File Offset: 0x004533F9
	public void SetSelectOn(bool isSelectOn)
	{
		this.ItemViewInfo.IsSelectOn = isSelectOn;
	}

	// Token: 0x0600FC63 RID: 64611 RVA: 0x00455207 File Offset: 0x00453407
	public bool GetSelectOn()
	{
		return this.ItemViewInfo.IsSelectOn;
	}

	// Token: 0x0600FC64 RID: 64612 RVA: 0x00455214 File Offset: 0x00453414
	public void SetSelectNum(int selectNum)
	{
		this.ItemViewInfo.SelectOnNum = selectNum;
	}

	// Token: 0x0600FC65 RID: 64613 RVA: 0x00455222 File Offset: 0x00453422
	public int GetSelectNum()
	{
		return this.ItemViewInfo.SelectOnNum;
	}

	// Token: 0x0600FC66 RID: 64614 RVA: 0x0045522F File Offset: 0x0045342F
	public ItemDataBase GetItemDataBase()
	{
		return this.ItemViewInfo.ItemDataBase;
	}

	// Token: 0x0600FC67 RID: 64615 RVA: 0x0045523C File Offset: 0x0045343C
	public InventoryDefine.EItemDataType GetItemDataType()
	{
		return this.ItemViewInfo.ItemDataType;
	}

	// Token: 0x0600FC68 RID: 64616 RVA: 0x00455249 File Offset: 0x00453449
	public int GetSortIndex()
	{
		return this.GetItemDataBase().GetSortIndex();
	}

	// Token: 0x0600FC69 RID: 64617 RVA: 0x00455258 File Offset: 0x00453458
	public void RemoveNewItem()
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		bool itemDataType = this.GetItemDataType() != InventoryDefine.EItemDataType.CommonItem;
		int configId = this.GetConfigId();
		int uniqueId = this.GetUniqueId();
		if (!itemDataType)
		{
			instance.RemoveNewCommonItem(configId, uniqueId);
		}
		else
		{
			instance.RemoveNewAttributeItem(uniqueId);
		}
		this.SetIsNew(false);
	}

	// Token: 0x0600FC6A RID: 64618 RVA: 0x0045529C File Offset: 0x0045349C
	public void RemoveRedDotItem()
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		bool itemDataType = this.GetItemDataType() != InventoryDefine.EItemDataType.CommonItem;
		int configId = this.GetConfigId();
		int uniqueId = this.GetUniqueId();
		if (!itemDataType)
		{
			instance.RemoveRedDotCommonItem(configId, uniqueId);
		}
		else
		{
			instance.RemoveRedDotAttributeItem(uniqueId);
		}
		this.SetHasRedDot(false);
	}

	// Token: 0x0600FC6B RID: 64619 RVA: 0x004552DF File Offset: 0x004534DF
	public bool IsBuffItem()
	{
		return ConfigBase<BuffItemConfig>.Instance.IsBuffItem(this.GetConfigId());
	}

	// Token: 0x0600FC6C RID: 64620 RVA: 0x004552F1 File Offset: 0x004534F1
	public bool IsTeamBuffItem()
	{
		return ConfigBase<BuffItemConfig>.Instance.IsTeamBuffItem(this.GetConfigId());
	}

	// Token: 0x0600FC6D RID: 64621 RVA: 0x00455304 File Offset: 0x00453504
	public UiPlayItem GetUiPlayItem()
	{
		return ConfigUiPlayItemById.GetConfig(this.GetConfigId(), true).Value;
	}

	// Token: 0x0600FC6E RID: 64622 RVA: 0x00455328 File Offset: 0x00453528
	public InventoryDefine.EItemType GetItemType()
	{
		return this.GetItemDataBase().GetType().Value;
	}

	// Token: 0x0600FC6F RID: 64623 RVA: 0x00455348 File Offset: 0x00453548
	public int GetAttributeLevel()
	{
		InventoryDefine.EItemDataType itemDataType = this.GetItemDataType();
		int uniqueId = this.GetUniqueId();
		if (itemDataType == InventoryDefine.EItemDataType.PhantomItem)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
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
				return ModelBase<WeaponModel>.Instance.GetWeaponLevelById(uniqueId);
			}
			return 0;
		}
	}

	// Token: 0x0600FC70 RID: 64624 RVA: 0x00455390 File Offset: 0x00453590
	public ItemViewDefine.EItemOperationMode GetItemOperationType()
	{
		return this.ItemViewInfo.ItemOperationMode;
	}

	// Token: 0x0600FC71 RID: 64625 RVA: 0x004553A0 File Offset: 0x004535A0
	public bool IsItemCanDestroy()
	{
		switch (this.GetItemDataType())
		{
		case InventoryDefine.EItemDataType.CommonItem:
			return (this.GetItemDataBase() as CommonItemData).GetConfig().As<ItemInfo>().Value.Destructible;
		case InventoryDefine.EItemDataType.WeaponItem:
		{
			WeaponItemData weaponItemData = this.GetItemDataBase() as WeaponItemData;
			int uniqueId = weaponItemData.GetUniqueId();
			WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(uniqueId);
			bool isLock = weaponItemData.GetIsLock();
			bool flag = weaponDataByIncId != null && weaponDataByIncId.GetRoleId() != 0;
			bool destructible = weaponItemData.WeaponConfig.Destructible;
			bool flag2 = weaponDataByIncId != null && weaponDataByIncId.HasWeaponCultivated();
			return destructible && !isLock && !flag && !flag2;
		}
		case InventoryDefine.EItemDataType.PhantomItem:
		{
			PhantomItemData phantomItemData = this.GetItemDataBase() as PhantomItemData;
			int uniqueId2 = phantomItemData.GetUniqueId();
			bool isLock2 = phantomItemData.GetIsLock();
			int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(uniqueId2);
			bool flag3;
			if (equipRole == null)
			{
				flag3 = false;
			}
			else
			{
				int? num = equipRole;
				int num2 = 0;
				flag3 = !(num.GetValueOrDefault() == num2 & num != null);
			}
			bool flag4 = flag3;
			return phantomItemData.GetConfig().As<PhantomItem>().Value.Destructible && !isLock2 && !flag4;
		}
		}
		return false;
	}

	// Token: 0x0600FC72 RID: 64626 RVA: 0x004554E0 File Offset: 0x004536E0
	public bool IsEqual(global::ItemViewData itemViewDataB, bool? needStackEqual = null)
	{
		bool flag = this.GetConfigId() == itemViewDataB.GetConfigId();
		bool flag2 = this.GetUniqueId() == itemViewDataB.GetUniqueId();
		bool flag3 = this.GetStackId() == itemViewDataB.GetStackId();
		if (needStackEqual != null && needStackEqual.Value)
		{
			return flag && flag2 && flag3;
		}
		return flag && flag2;
	}

	// Token: 0x04007916 RID: 30998
	private InventoryDefine.IItemViewDataInfo ItemViewInfo;
}
