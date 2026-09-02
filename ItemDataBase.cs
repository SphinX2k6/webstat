using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002017 RID: 8215
public abstract class ItemDataBase
{
	// Token: 0x0600F97C RID: 63868 RVA: 0x00445D2B File Offset: 0x00443F2B
	public ItemDataBase(int configId, int count, InventoryDefine.EItemDataType itemDataType)
	{
		this.ConfigId = configId;
		this.Count = count;
		this.ItemDataType = itemDataType;
	}

	// Token: 0x0600F97D RID: 63869 RVA: 0x00445D48 File Offset: 0x00443F48
	public int GetConfigId()
	{
		return this.ConfigId;
	}

	// Token: 0x0600F97E RID: 63870 RVA: 0x00445D50 File Offset: 0x00443F50
	public virtual int GetUniqueId()
	{
		return 0;
	}

	// Token: 0x0600F97F RID: 63871 RVA: 0x00445D53 File Offset: 0x00443F53
	public void SetCount(int count)
	{
		this.LastCount = this.Count;
		this.Count = count;
	}

	// Token: 0x0600F980 RID: 63872 RVA: 0x00445D68 File Offset: 0x00443F68
	public int GetCount()
	{
		return this.Count;
	}

	// Token: 0x0600F981 RID: 63873 RVA: 0x00445D70 File Offset: 0x00443F70
	public int GetLastCount()
	{
		return this.LastCount;
	}

	// Token: 0x0600F982 RID: 63874 RVA: 0x00445D78 File Offset: 0x00443F78
	public InventoryDefine.EItemDataType GetItemDataType()
	{
		return this.ItemDataType;
	}

	// Token: 0x0600F983 RID: 63875 RVA: 0x00445D80 File Offset: 0x00443F80
	public TypeInfo? GetItemTypeConfig()
	{
		InventoryDefine.EItemType? type = this.GetType();
		if (type == null)
		{
			return null;
		}
		return ConfigBase<InventoryConfig>.Instance.GetItemTypeConfig((int)type.Value);
	}

	// Token: 0x0600F984 RID: 63876 RVA: 0x00445DB8 File Offset: 0x00443FB8
	public bool CanLock()
	{
		TypeInfo? itemTypeConfig = this.GetItemTypeConfig();
		return itemTypeConfig != null && itemTypeConfig.Value.Lock;
	}

	// Token: 0x0600F985 RID: 63877 RVA: 0x00445DE8 File Offset: 0x00443FE8
	public bool CanDeprecate()
	{
		TypeInfo? itemTypeConfig = this.GetItemTypeConfig();
		return itemTypeConfig != null && itemTypeConfig.Value.Deprecate;
	}

	// Token: 0x0600F986 RID: 63878 RVA: 0x00445E18 File Offset: 0x00444018
	public QualityInfo GetQualityConfig()
	{
		int quality = this.GetQuality();
		return ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(quality).Value;
	}

	// Token: 0x0600F987 RID: 63879 RVA: 0x00445E3F File Offset: 0x0044403F
	public virtual bool GetIsLock()
	{
		return false;
	}

	// Token: 0x0600F988 RID: 63880 RVA: 0x00445E42 File Offset: 0x00444042
	public virtual bool GetIsDeprecated()
	{
		return false;
	}

	// Token: 0x0600F989 RID: 63881 RVA: 0x00445E45 File Offset: 0x00444045
	public virtual bool GetIsShowUseButton()
	{
		return false;
	}

	// Token: 0x0600F98A RID: 63882 RVA: 0x00445E48 File Offset: 0x00444048
	public virtual bool IsBuffEquipItem()
	{
		return false;
	}

	// Token: 0x0600F98B RID: 63883 RVA: 0x00445E4B File Offset: 0x0044404B
	public virtual bool IsBuffEquippedItem()
	{
		return false;
	}

	// Token: 0x0600F98C RID: 63884 RVA: 0x00445E4E File Offset: 0x0044404E
	public virtual bool IsBuffItem()
	{
		return false;
	}

	// Token: 0x0600F98D RID: 63885 RVA: 0x00445E51 File Offset: 0x00444051
	public bool IsShowInInventory()
	{
		return this.OnIsShowInInventory();
	}

	// Token: 0x0600F98E RID: 63886 RVA: 0x00445E5C File Offset: 0x0044405C
	protected virtual bool OnIsShowInInventory()
	{
		InventoryDefine.EItemType? type = this.GetType();
		InventoryDefine.EItemType eitemType = InventoryDefine.EItemType.Virtual;
		return !(type.GetValueOrDefault() == eitemType & type != null);
	}

	// Token: 0x0600F98F RID: 63887
	[NullableContext(1)]
	public abstract TItemConfig GetConfig();

	// Token: 0x0600F990 RID: 63888
	public abstract InventoryDefine.EItemMainTypeId? GetMainType();

	// Token: 0x0600F991 RID: 63889
	public new abstract InventoryDefine.EItemType? GetType();

	// Token: 0x0600F992 RID: 63890
	public abstract int GetSortIndex();

	// Token: 0x0600F993 RID: 63891
	public abstract Span<int> GetItemAccess();

	// Token: 0x0600F994 RID: 63892
	public abstract int GetQuality();

	// Token: 0x0600F995 RID: 63893
	public abstract int GetMaxStackCount();

	// Token: 0x0600F996 RID: 63894
	public abstract int GetUseCountLimit();

	// Token: 0x0600F997 RID: 63895
	public abstract InventoryDefine.ERedDotDisableRule GetRedDotDisableRule();

	// Token: 0x0600F998 RID: 63896
	public abstract bool HasRedDot();

	// Token: 0x0600F999 RID: 63897
	public abstract bool IsValid();

	// Token: 0x0600F99A RID: 63898
	[NullableContext(2)]
	public abstract InventoryDefine.IItemViewDataInfo GetItemViewDataInfo(ItemViewDefine.EItemOperationMode viewMode);

	// Token: 0x04007809 RID: 30729
	protected readonly int ConfigId;

	// Token: 0x0400780A RID: 30730
	protected int Count;

	// Token: 0x0400780B RID: 30731
	protected int LastCount;

	// Token: 0x0400780C RID: 30732
	protected InventoryDefine.EItemDataType ItemDataType;
}
