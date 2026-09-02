using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002018 RID: 8216
public class OrnamentItemData : ItemDataBase
{
	// Token: 0x17001293 RID: 4755
	// (get) Token: 0x0600F99B RID: 63899 RVA: 0x00445E88 File Offset: 0x00444088
	public Ornament Ornament
	{
		get
		{
			return this.GetConfig().As<Ornament>().Value;
		}
	}

	// Token: 0x0600F99C RID: 63900 RVA: 0x00445EA8 File Offset: 0x004440A8
	public OrnamentItemData(int configId, int count, InventoryDefine.EItemDataType itemDataType) : base(configId, count, itemDataType)
	{
	}

	// Token: 0x0600F99D RID: 63901 RVA: 0x00445EB4 File Offset: 0x004440B4
	[NullableContext(2)]
	public override TItemConfig GetConfig()
	{
		Ornament? ornamentConfig = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(this.ConfigId);
		if (ornamentConfig == null)
		{
			return null;
		}
		return ornamentConfig.GetValueOrDefault();
	}

	// Token: 0x0600F99E RID: 63902 RVA: 0x00445EE9 File Offset: 0x004440E9
	public override InventoryDefine.EItemMainTypeId? GetMainType()
	{
		return new InventoryDefine.EItemMainTypeId?(InventoryDefine.EItemMainTypeId.Special);
	}

	// Token: 0x0600F99F RID: 63903 RVA: 0x00445EF1 File Offset: 0x004440F1
	public override InventoryDefine.EItemType? GetType()
	{
		return new InventoryDefine.EItemType?(InventoryDefine.EItemType.Ornament);
	}

	// Token: 0x0600F9A0 RID: 63904 RVA: 0x00445EFA File Offset: 0x004440FA
	public override int GetMaxStackCount()
	{
		return 1;
	}

	// Token: 0x0600F9A1 RID: 63905 RVA: 0x00445F00 File Offset: 0x00444100
	public override int GetQuality()
	{
		if (this.GetConfig() == null)
		{
			return 0;
		}
		return this.Ornament.QualityId;
	}

	// Token: 0x0600F9A2 RID: 63906 RVA: 0x00445F28 File Offset: 0x00444128
	public override int GetSortIndex()
	{
		if (this.GetConfig() == null)
		{
			return 0;
		}
		return this.Ornament.SortIndex;
	}

	// Token: 0x0600F9A3 RID: 63907 RVA: 0x00445F50 File Offset: 0x00444150
	public override Span<int> GetItemAccess()
	{
		if (this.GetConfig() == null)
		{
			return Span<int>.Empty;
		}
		return this.Ornament.GetItemAccessArray();
	}

	// Token: 0x0600F9A4 RID: 63908 RVA: 0x00445F7E File Offset: 0x0044417E
	public override int GetUseCountLimit()
	{
		return 1;
	}

	// Token: 0x0600F9A5 RID: 63909 RVA: 0x00445F84 File Offset: 0x00444184
	public override InventoryDefine.ERedDotDisableRule GetRedDotDisableRule()
	{
		return (InventoryDefine.ERedDotDisableRule)this.Ornament.RedDotDisableRule;
	}

	// Token: 0x0600F9A6 RID: 63910 RVA: 0x00445FA0 File Offset: 0x004441A0
	public override bool HasRedDot()
	{
		int configId = base.GetConfigId();
		return ModelBase<InventoryModel>.Instance.IsCommonItemHasRedDot(configId, 0);
	}

	// Token: 0x0600F9A7 RID: 63911 RVA: 0x00445FC0 File Offset: 0x004441C0
	public override bool IsValid()
	{
		return true;
	}

	// Token: 0x0600F9A8 RID: 63912 RVA: 0x00445FC4 File Offset: 0x004441C4
	public override bool GetIsShowUseButton()
	{
		return this.Ornament.ShowUseButton && ModelBase<RoleOrnamentModel>.Instance.IsOwnOrnament(this.ConfigId);
	}

	// Token: 0x0600F9A9 RID: 63913 RVA: 0x00445FF3 File Offset: 0x004441F3
	protected override bool OnIsShowInInventory()
	{
		return true;
	}

	// Token: 0x0600F9AA RID: 63914 RVA: 0x00445FF8 File Offset: 0x004441F8
	[NullableContext(1)]
	public override InventoryDefine.IItemViewDataInfo GetItemViewDataInfo(ItemViewDefine.EItemOperationMode viewMode)
	{
		if (this.GetConfig() == null)
		{
			return null;
		}
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		int uniqueId = this.GetUniqueId();
		return new InventoryDefine.ItemViewDataInfo(this.Ornament.Id, 1, 0, this.Ornament.QualityId, this.GetIsLock(), this.GetIsDeprecated(), instance.IsNewAttributeItem(uniqueId), this.ItemDataType, this, instance.IsCommonItemHasRedDot(uniqueId, 0), viewMode, false, 0);
	}
}
