using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using FilterDefine;

// Token: 0x02002019 RID: 8217
public class PhantomItemData : AttributeItemData, IPhantomFilterData
{
	// Token: 0x0600F9AB RID: 63915 RVA: 0x00446064 File Offset: 0x00444264
	public PhantomItemData(int configId, int uniqueId, int functionValue, InventoryDefine.EItemDataType itemDataType) : base(configId, uniqueId, functionValue, itemDataType)
	{
	}

	// Token: 0x0600F9AC RID: 63916 RVA: 0x00446071 File Offset: 0x00444271
	public void SetFetterGroupId(int id)
	{
		this.FetterGroupId = id;
	}

	// Token: 0x0600F9AD RID: 63917 RVA: 0x0044607C File Offset: 0x0044427C
	[NullableContext(1)]
	public override TItemConfig GetConfig()
	{
		PhantomItem? phantomItemConfig = ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfig(this.ConfigId);
		if (phantomItemConfig == null)
		{
			return null;
		}
		return phantomItemConfig.GetValueOrDefault();
	}

	// Token: 0x17001294 RID: 4756
	// (get) Token: 0x0600F9AE RID: 63918 RVA: 0x004460B4 File Offset: 0x004442B4
	public PhantomItem PhantomItem
	{
		get
		{
			return this.GetConfig().As<PhantomItem>().Value;
		}
	}

	// Token: 0x0600F9AF RID: 63919 RVA: 0x004460D4 File Offset: 0x004442D4
	public override InventoryDefine.EItemMainTypeId? GetMainType()
	{
		return new InventoryDefine.EItemMainTypeId?(InventoryDefine.EItemMainTypeId.Phantom);
	}

	// Token: 0x0600F9B0 RID: 63920 RVA: 0x004460DC File Offset: 0x004442DC
	public override InventoryDefine.EItemType? GetType()
	{
		return new InventoryDefine.EItemType?(InventoryDefine.EItemType.Phantom);
	}

	// Token: 0x0600F9B1 RID: 63921 RVA: 0x004460E8 File Offset: 0x004442E8
	public override int GetQuality()
	{
		return this.PhantomItem.QualityId;
	}

	// Token: 0x0600F9B2 RID: 63922 RVA: 0x00446104 File Offset: 0x00444304
	public override int GetSortIndex()
	{
		return this.PhantomItem.SortIndex;
	}

	// Token: 0x0600F9B3 RID: 63923 RVA: 0x00446120 File Offset: 0x00444320
	public override Span<int> GetItemAccess()
	{
		return this.PhantomItem.GetItemAccessBytes();
	}

	// Token: 0x0600F9B4 RID: 63924 RVA: 0x0044613B File Offset: 0x0044433B
	public override int GetMaxStackCount()
	{
		return 1;
	}

	// Token: 0x0600F9B5 RID: 63925 RVA: 0x00446140 File Offset: 0x00444340
	protected override void OnSetFunctionValue(int functionValue)
	{
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.UniqueId);
		if (phantomBattleData != null)
		{
			phantomBattleData.OnFunctionValueChange(functionValue);
		}
	}

	// Token: 0x0600F9B6 RID: 63926 RVA: 0x00446168 File Offset: 0x00444368
	[NullableContext(1)]
	public override string GetDefaultDownText()
	{
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("VisionLevel"), null) ?? "";
	}

	// Token: 0x0600F9B7 RID: 63927 RVA: 0x00446188 File Offset: 0x00444388
	public override InventoryDefine.ERedDotDisableRule GetRedDotDisableRule()
	{
		return (InventoryDefine.ERedDotDisableRule)this.PhantomItem.RedDotDisableRule;
	}

	// Token: 0x0600F9B8 RID: 63928 RVA: 0x004461A4 File Offset: 0x004443A4
	public PhantomFetterGroup? GetFetterGroupConfig()
	{
		if (this.FetterGroupId != 0)
		{
			return new PhantomFetterGroup?(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.FetterGroupId));
		}
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.UniqueId);
		if (phantomBattleData == null)
		{
			return null;
		}
		return new PhantomFetterGroup?(phantomBattleData.GetFetterGroupConfig());
	}

	// Token: 0x0600F9B9 RID: 63929 RVA: 0x004461F8 File Offset: 0x004443F8
	[NullableContext(1)]
	public override InventoryDefine.IItemViewDataInfo GetItemViewDataInfo(ItemViewDefine.EItemOperationMode viewMode)
	{
		if (this.GetConfig() == null)
		{
			return null;
		}
		PhantomItem phantomItem = this.PhantomItem;
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		int uniqueId = this.GetUniqueId();
		return new InventoryDefine.ItemViewDataInfo(phantomItem.ItemId, 1, 0, phantomItem.QualityId, this.GetIsLock(), this.GetIsDeprecated(), instance.IsNewAttributeItem(uniqueId), this.ItemDataType, this, instance.IsAttributeItemHasRedDot(uniqueId), viewMode, false, 0);
	}

	// Token: 0x0400780D RID: 30733
	private int FetterGroupId;
}
