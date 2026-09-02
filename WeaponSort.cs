using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200194E RID: 6478
[NullableContext(1)]
[Nullable(0)]
public class WeaponSort : CommonSort<EWeaponSortWayType>
{
	// Token: 0x0600B9CA RID: 47562 RVA: 0x00317E40 File Offset: 0x00316040
	private int SortLevel(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(itemDataBase.GetUniqueId());
		WeaponInstance weaponDataByIncId2 = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(itemDataBase2.GetUniqueId());
		int num = (weaponDataByIncId != null) ? weaponDataByIncId.GetLevel() : 0;
		int num2 = (weaponDataByIncId2 != null) ? weaponDataByIncId2.GetLevel() : 0;
		if (num != num2)
		{
			return (num2 - num) * (isAscending ? -1 : 1);
		}
		int num3 = (weaponDataByIncId != null) ? weaponDataByIncId.GetResonanceLevel() : 0;
		int num4 = (weaponDataByIncId2 != null) ? weaponDataByIncId2.GetResonanceLevel() : 0;
		if (num3 != num4)
		{
			return (num4 - num3) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B9CB RID: 47563 RVA: 0x00317EE0 File Offset: 0x003160E0
	private int SortBreachLevel(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(itemDataBase.GetUniqueId());
		WeaponInstance weaponDataByIncId2 = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(itemDataBase2.GetUniqueId());
		int num = (weaponDataByIncId != null) ? weaponDataByIncId.GetBreachLevel() : 0;
		int num2 = (weaponDataByIncId2 != null) ? weaponDataByIncId2.GetBreachLevel() : 0;
		if (num != num2)
		{
			return (num2 - num) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B9CC RID: 47564 RVA: 0x00317F50 File Offset: 0x00316150
	private int SortResonanceLevel(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(itemDataBase.GetUniqueId());
		WeaponInstance weaponDataByIncId2 = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(itemDataBase2.GetUniqueId());
		int num = (weaponDataByIncId != null) ? weaponDataByIncId.GetResonanceLevel() : 0;
		int num2 = (weaponDataByIncId2 != null) ? weaponDataByIncId2.GetResonanceLevel() : 0;
		if (num != num2)
		{
			return (num2 - num) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B9CD RID: 47565 RVA: 0x00317FC0 File Offset: 0x003161C0
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		if (itemDataBase.GetQuality() != itemDataBase2.GetQuality())
		{
			return (itemDataBase2.GetQuality() - itemDataBase.GetQuality()) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B9CE RID: 47566 RVA: 0x00318000 File Offset: 0x00316200
	private int SortLock(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		if (itemDataBase.GetIsLock() != itemDataBase2.GetIsLock())
		{
			int num = (itemDataBase.GetIsLock() > false) ? 1 : 0;
			int num2 = (itemDataBase2.GetIsLock() > false) ? 1 : 0;
			return -1 * (num - num2);
		}
		return 0;
	}

	// Token: 0x0600B9CF RID: 47567 RVA: 0x00318044 File Offset: 0x00316244
	private int SortExp(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemData = a as ItemDataBase;
		ItemDataBase itemData2 = b as ItemDataBase;
		int weaponItemBaseExp = ModelBase<WeaponModel>.Instance.GetWeaponItemBaseExp(itemData);
		int weaponItemBaseExp2 = ModelBase<WeaponModel>.Instance.GetWeaponItemBaseExp(itemData2);
		if (weaponItemBaseExp != weaponItemBaseExp2)
		{
			return (weaponItemBaseExp2 - weaponItemBaseExp) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B9D0 RID: 47568 RVA: 0x00318088 File Offset: 0x00316288
	private int SortUniqueId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		return ((b as ItemDataBase).GetUniqueId() - itemDataBase.GetUniqueId()) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B9D1 RID: 47569 RVA: 0x003180B8 File Offset: 0x003162B8
	private int SortConfigId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		return ((b as ItemDataBase).GetConfigId() - itemDataBase.GetConfigId()) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B9D2 RID: 47570 RVA: 0x003180E8 File Offset: 0x003162E8
	private int SortExpFirst(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		bool flag = itemDataBase.GetType().GetValueOrDefault() == InventoryDefine.EItemType.WeaponMaterial;
		bool flag2 = itemDataBase2.GetType().GetValueOrDefault() == InventoryDefine.EItemType.WeaponMaterial;
		if (flag != flag2)
		{
			int num = (flag > false) ? 1 : 0;
			return ((flag2 > false) ? 1 : 0) - num;
		}
		return 0;
	}

	// Token: 0x0600B9D3 RID: 47571 RVA: 0x00318138 File Offset: 0x00316338
	private int SortWeaponExpItemType(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemData = a as ItemDataBase;
		ItemDataBase itemData2 = b as ItemDataBase;
		EWeaponExpItemType? weaponExpItemType = this.GetWeaponExpItemType(itemData);
		EWeaponExpItemType? weaponExpItemType2 = this.GetWeaponExpItemType(itemData2);
		if (weaponExpItemType == null || weaponExpItemType2 == null)
		{
			return 0;
		}
		EWeaponExpItemType? eweaponExpItemType = weaponExpItemType;
		EWeaponExpItemType? eweaponExpItemType2 = weaponExpItemType2;
		if (!(eweaponExpItemType.GetValueOrDefault() == eweaponExpItemType2.GetValueOrDefault() & eweaponExpItemType != null == (eweaponExpItemType2 != null)))
		{
			return weaponExpItemType.Value - weaponExpItemType2.Value;
		}
		return 0;
	}

	// Token: 0x0600B9D4 RID: 47572 RVA: 0x003181B4 File Offset: 0x003163B4
	private int SortWeaponFirst(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		bool flag = itemDataBase.GetType().GetValueOrDefault() == InventoryDefine.EItemType.Weapon;
		bool flag2 = itemDataBase2.GetType().GetValueOrDefault() == InventoryDefine.EItemType.Weapon;
		if (flag != flag2)
		{
			int num = (flag > false) ? 1 : 0;
			return ((flag2 > false) ? 1 : 0) - num;
		}
		return 0;
	}

	// Token: 0x0600B9D5 RID: 47573 RVA: 0x00318204 File Offset: 0x00316404
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EWeaponSortWayType.Level, new TSortResult(this.SortLevel));
		this.SortMap.Add(EWeaponSortWayType.Quality, new TSortResult(this.SortQuality));
		this.SortMap.Add(EWeaponSortWayType.Lock, new TSortResult(this.SortLock));
		this.SortMap.Add(EWeaponSortWayType.Exp, new TSortResult(this.SortExp));
		this.SortMap.Add(EWeaponSortWayType.UniqueId, new TSortResult(this.SortUniqueId));
		this.SortMap.Add(EWeaponSortWayType.BreachLevel, new TSortResult(this.SortBreachLevel));
		this.SortMap.Add(EWeaponSortWayType.ResonanceLevel, new TSortResult(this.SortResonanceLevel));
		this.SortMap.Add(EWeaponSortWayType.ConfigId, new TSortResult(this.SortConfigId));
		this.SortMap.Add(EWeaponSortWayType.ExpFirst, new TSortResult(this.SortExpFirst));
		this.SortMap.Add(EWeaponSortWayType.WeaponExpItemType, new TSortResult(this.SortWeaponExpItemType));
		this.SortMap.Add(EWeaponSortWayType.WeaponFirst, new TSortResult(this.SortWeaponFirst));
	}

	// Token: 0x0600B9D6 RID: 47574 RVA: 0x0031831C File Offset: 0x0031651C
	private EWeaponExpItemType? GetWeaponExpItemType(ItemDataBase itemData)
	{
		if (itemData == null)
		{
			return null;
		}
		InventoryDefine.EItemType? type = itemData.GetType();
		if (type.GetValueOrDefault() == InventoryDefine.EItemType.WeaponMaterial)
		{
			return new EWeaponExpItemType?(EWeaponExpItemType.ExpItem);
		}
		if (type.GetValueOrDefault() != InventoryDefine.EItemType.Weapon)
		{
			return null;
		}
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(itemData.GetUniqueId());
		if (weaponDataByIncId != null && weaponDataByIncId.HasWeaponCultivated())
		{
			return new EWeaponExpItemType?(EWeaponExpItemType.CultivatedWeapon);
		}
		return new EWeaponExpItemType?(EWeaponExpItemType.OriginalWeapon);
	}
}
