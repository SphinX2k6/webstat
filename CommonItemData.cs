using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002016 RID: 8214
public class CommonItemData : ItemDataBase
{
	// Token: 0x0600F965 RID: 63845 RVA: 0x00445A1E File Offset: 0x00443C1E
	public CommonItemData(int configId, int uniqueId, int count, InventoryDefine.EItemDataType itemDataType, long? endTime = null) : base(configId, count, itemDataType)
	{
		this.UniqueId = uniqueId;
		this.EndTime = endTime.GetValueOrDefault();
	}

	// Token: 0x0600F966 RID: 63846 RVA: 0x00445A40 File Offset: 0x00443C40
	[NullableContext(2)]
	public override TItemConfig GetConfig()
	{
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(this.ConfigId);
		if (itemConfig == null)
		{
			return null;
		}
		return itemConfig.GetValueOrDefault();
	}

	// Token: 0x0600F967 RID: 63847 RVA: 0x00445A75 File Offset: 0x00443C75
	public override int GetUniqueId()
	{
		return this.UniqueId;
	}

	// Token: 0x0600F968 RID: 63848 RVA: 0x00445A80 File Offset: 0x00443C80
	public override InventoryDefine.EItemMainTypeId? GetMainType()
	{
		TItemConfig config = this.GetConfig();
		if (config == null)
		{
			return null;
		}
		return new InventoryDefine.EItemMainTypeId?((InventoryDefine.EItemMainTypeId)config.As<ItemInfo>().Value.MainTypeId);
	}

	// Token: 0x0600F969 RID: 63849 RVA: 0x00445ABC File Offset: 0x00443CBC
	public override InventoryDefine.EItemType? GetType()
	{
		TItemConfig config = this.GetConfig();
		if (config == null)
		{
			return null;
		}
		return new InventoryDefine.EItemType?((InventoryDefine.EItemType)config.As<ItemInfo>().Value.ItemType);
	}

	// Token: 0x0600F96A RID: 63850 RVA: 0x00445AF8 File Offset: 0x00443CF8
	public override int GetMaxStackCount()
	{
		TItemConfig config = this.GetConfig();
		if (config == null)
		{
			return 0;
		}
		if (config == null)
		{
			return 0;
		}
		return config.As<ItemInfo>().Value.MaxStackableNum;
	}

	// Token: 0x0600F96B RID: 63851 RVA: 0x00445B2C File Offset: 0x00443D2C
	public override int GetQuality()
	{
		TItemConfig config = this.GetConfig();
		if (config == null)
		{
			return 0;
		}
		return config.As<ItemInfo>().Value.QualityId;
	}

	// Token: 0x0600F96C RID: 63852 RVA: 0x00445B5C File Offset: 0x00443D5C
	public override int GetSortIndex()
	{
		TItemConfig config = this.GetConfig();
		if (config == null)
		{
			return 0;
		}
		return config.As<ItemInfo>().Value.SortIndex;
	}

	// Token: 0x0600F96D RID: 63853 RVA: 0x00445B8C File Offset: 0x00443D8C
	public override Span<int> GetItemAccess()
	{
		TItemConfig config = this.GetConfig();
		if (config == null)
		{
			return default(Span<int>);
		}
		return config.As<ItemInfo>().Value.GetItemAccessBytes();
	}

	// Token: 0x0600F96E RID: 63854 RVA: 0x00445BC4 File Offset: 0x00443DC4
	public Span<int> GetShowTypeList()
	{
		TItemConfig config = this.GetConfig();
		if (config == null)
		{
			return Span<int>.Empty;
		}
		return config.As<ItemInfo>().Value.GetShowTypesBytes();
	}

	// Token: 0x0600F96F RID: 63855 RVA: 0x00445BF8 File Offset: 0x00443DF8
	public override int GetUseCountLimit()
	{
		return this.GetConfig().As<ItemInfo>().Value.UseCountLimit;
	}

	// Token: 0x0600F970 RID: 63856 RVA: 0x00445C20 File Offset: 0x00443E20
	public override InventoryDefine.ERedDotDisableRule GetRedDotDisableRule()
	{
		return (InventoryDefine.ERedDotDisableRule)this.GetConfig().As<ItemInfo>().Value.RedDotDisableRule;
	}

	// Token: 0x0600F971 RID: 63857 RVA: 0x00445C48 File Offset: 0x00443E48
	public override bool HasRedDot()
	{
		int configId = base.GetConfigId();
		return ModelBase<InventoryModel>.Instance.IsCommonItemHasRedDot(configId, 0);
	}

	// Token: 0x0600F972 RID: 63858 RVA: 0x00445C68 File Offset: 0x00443E68
	public void SetEndTime(long endTime)
	{
		this.EndTime = endTime;
	}

	// Token: 0x0600F973 RID: 63859 RVA: 0x00445C71 File Offset: 0x00443E71
	public bool IsLimitTimeItem()
	{
		return this.EndTime > 0L && !this.IsOverTime();
	}

	// Token: 0x0600F974 RID: 63860 RVA: 0x00445C88 File Offset: 0x00443E88
	public long GetEndTime()
	{
		return this.EndTime;
	}

	// Token: 0x0600F975 RID: 63861 RVA: 0x00445C90 File Offset: 0x00443E90
	public bool IsOverTime()
	{
		return this.EndTime > 0L && (double)this.EndTime <= Singleton<TimeUtil>.Instance.GetServerTimeStamp();
	}

	// Token: 0x0600F976 RID: 63862 RVA: 0x00445CB4 File Offset: 0x00443EB4
	public override bool IsValid()
	{
		return !this.IsOverTime();
	}

	// Token: 0x0600F977 RID: 63863 RVA: 0x00445CBF File Offset: 0x00443EBF
	public override bool IsBuffEquipItem()
	{
		return ConfigBase<BuffItemConfig>.Instance.IsEquipBuffItem(this.ConfigId);
	}

	// Token: 0x0600F978 RID: 63864 RVA: 0x00445CD1 File Offset: 0x00443ED1
	public override bool IsBuffEquippedItem()
	{
		return this.IsBuffEquipItem() && ModelBase<BuffItemModel>.Instance.IsEquippedBuffItem(this.ConfigId);
	}

	// Token: 0x0600F979 RID: 63865 RVA: 0x00445CED File Offset: 0x00443EED
	public override bool IsBuffItem()
	{
		return ConfigBase<BuffItemConfig>.Instance.IsBuffItem(this.ConfigId);
	}

	// Token: 0x0600F97A RID: 63866 RVA: 0x00445D00 File Offset: 0x00443F00
	public override bool GetIsShowUseButton()
	{
		return this.GetConfig().As<ItemInfo>().Value.ShowUseButton;
	}

	// Token: 0x0600F97B RID: 63867 RVA: 0x00445D28 File Offset: 0x00443F28
	[NullableContext(2)]
	public override InventoryDefine.IItemViewDataInfo GetItemViewDataInfo(ItemViewDefine.EItemOperationMode viewMode)
	{
		return null;
	}

	// Token: 0x04007807 RID: 30727
	protected readonly int UniqueId;

	// Token: 0x04007808 RID: 30728
	protected long EndTime;
}
