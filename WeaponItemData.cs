using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200201A RID: 8218
[NullableContext(1)]
[Nullable(0)]
public class WeaponItemData : AttributeItemData
{
	// Token: 0x0600F9BA RID: 63930 RVA: 0x0044625C File Offset: 0x0044445C
	public WeaponItemData(int configId, int uniqueId, int functionValue, InventoryDefine.EItemDataType itemDataType) : base(configId, uniqueId, functionValue, itemDataType)
	{
	}

	// Token: 0x0600F9BB RID: 63931 RVA: 0x0044626C File Offset: 0x0044446C
	public override TItemConfig GetConfig()
	{
		WeaponConf? weaponItemConfig = ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(this.ConfigId);
		if (weaponItemConfig == null)
		{
			return null;
		}
		return weaponItemConfig.GetValueOrDefault();
	}

	// Token: 0x17001295 RID: 4757
	// (get) Token: 0x0600F9BC RID: 63932 RVA: 0x004462A4 File Offset: 0x004444A4
	public WeaponConf WeaponConfig
	{
		get
		{
			return this.GetConfig().As<WeaponConf>().Value;
		}
	}

	// Token: 0x0600F9BD RID: 63933 RVA: 0x004462C4 File Offset: 0x004444C4
	public override InventoryDefine.EItemMainTypeId? GetMainType()
	{
		return new InventoryDefine.EItemMainTypeId?(InventoryDefine.EItemMainTypeId.Weapon);
	}

	// Token: 0x0600F9BE RID: 63934 RVA: 0x004462CC File Offset: 0x004444CC
	public override InventoryDefine.EItemType? GetType()
	{
		return new InventoryDefine.EItemType?(InventoryDefine.EItemType.Weapon);
	}

	// Token: 0x0600F9BF RID: 63935 RVA: 0x004462D4 File Offset: 0x004444D4
	public override int GetQuality()
	{
		return this.WeaponConfig.QualityId;
	}

	// Token: 0x0600F9C0 RID: 63936 RVA: 0x004462F0 File Offset: 0x004444F0
	public override int GetSortIndex()
	{
		return this.WeaponConfig.SortIndex;
	}

	// Token: 0x0600F9C1 RID: 63937 RVA: 0x0044630C File Offset: 0x0044450C
	[NullableContext(0)]
	public override Span<int> GetItemAccess()
	{
		return this.WeaponConfig.GetItemAccessBytes();
	}

	// Token: 0x0600F9C2 RID: 63938 RVA: 0x00446327 File Offset: 0x00444527
	public override int GetMaxStackCount()
	{
		return 1;
	}

	// Token: 0x0600F9C3 RID: 63939 RVA: 0x0044632A File Offset: 0x0044452A
	public override string GetDefaultDownText()
	{
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("LevelShow"), null) ?? "";
	}

	// Token: 0x0600F9C4 RID: 63940 RVA: 0x0044634C File Offset: 0x0044454C
	public override InventoryDefine.ERedDotDisableRule GetRedDotDisableRule()
	{
		return (InventoryDefine.ERedDotDisableRule)this.WeaponConfig.RedDotDisableRule;
	}

	// Token: 0x0600F9C5 RID: 63941 RVA: 0x00446368 File Offset: 0x00444568
	public override InventoryDefine.IItemViewDataInfo GetItemViewDataInfo(ItemViewDefine.EItemOperationMode viewMode)
	{
		if (this.GetConfig() == null)
		{
			return null;
		}
		WeaponConf weaponConfig = this.WeaponConfig;
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		int uniqueId = this.GetUniqueId();
		return new InventoryDefine.ItemViewDataInfo(weaponConfig.ItemId, 1, 0, weaponConfig.QualityId, this.GetIsLock(), this.GetIsDeprecated(), instance.IsNewAttributeItem(uniqueId), this.ItemDataType, this, instance.IsAttributeItemHasRedDot(uniqueId), viewMode, false, 0);
	}
}
