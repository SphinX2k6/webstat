using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020018C3 RID: 6339
[NullableContext(1)]
[Nullable(0)]
public class ConsumeItemUtil
{
	// Token: 0x0600B622 RID: 46626 RVA: 0x00306DA0 File Offset: 0x00304FA0
	[return: Nullable(2)]
	public static ConsumeItemData GetConsumeItemData(InventoryDefine.IGetItemData getItemData, int count)
	{
		ItemDataBase itemDataBase = ModelBase<InventoryModel>.Instance.GetItemDataBase(getItemData)[0];
		if (itemDataBase == null)
		{
			return null;
		}
		if (itemDataBase.GetType().GetValueOrDefault() == InventoryDefine.EItemType.Weapon)
		{
			return ConsumeItemUtil.WeaponConsumeData(itemDataBase);
		}
		return ConsumeItemUtil.MaterialConsumeData(itemDataBase, count);
	}

	// Token: 0x0600B623 RID: 46627 RVA: 0x00306DE4 File Offset: 0x00304FE4
	protected static ConsumeItemData WeaponConsumeData(ItemDataBase itemDataBase)
	{
		ConsumeItemData consumeItemData = new ConsumeItemData();
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(itemDataBase.GetUniqueId());
		consumeItemData.IncId = itemDataBase.GetUniqueId();
		consumeItemData.ItemId = itemDataBase.GetConfigId();
		consumeItemData.ResonanceLevel = weaponDataByIncId.GetResonanceLevel();
		string text = ConfigBase<TextConfig>.Instance.GetTextById("LevelShow") ?? "";
		consumeItemData.BottomText = text.Replace("{0}", weaponDataByIncId.GetLevel().ToString());
		return consumeItemData;
	}

	// Token: 0x0600B624 RID: 46628 RVA: 0x00306E64 File Offset: 0x00305064
	protected static ConsumeItemData MaterialConsumeData(ItemDataBase itemDataBase, int count)
	{
		return new ConsumeItemData
		{
			IncId = itemDataBase.GetUniqueId(),
			ItemId = itemDataBase.GetConfigId(),
			BottomText = count.ToString() + "/" + itemDataBase.GetCount().ToString()
		};
	}
}
