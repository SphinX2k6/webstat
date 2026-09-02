using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002015 RID: 8213
public class CalabashSkinItemData : ItemDataBase
{
	// Token: 0x0600F955 RID: 63829 RVA: 0x004457D2 File Offset: 0x004439D2
	public CalabashSkinItemData(int configId, int count, InventoryDefine.EItemDataType itemDataType) : base(configId, count, itemDataType)
	{
	}

	// Token: 0x0600F956 RID: 63830 RVA: 0x004457DD File Offset: 0x004439DD
	[NullableContext(2)]
	public override TItemConfig GetConfig()
	{
		return ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfig(this.ConfigId);
	}

	// Token: 0x17001292 RID: 4754
	// (get) Token: 0x0600F957 RID: 63831 RVA: 0x004457F4 File Offset: 0x004439F4
	public CalabashSkin CalabashSkin
	{
		get
		{
			return this.GetConfig().As<CalabashSkin>().Value;
		}
	}

	// Token: 0x0600F958 RID: 63832 RVA: 0x00445814 File Offset: 0x00443A14
	public override InventoryDefine.EItemMainTypeId? GetMainType()
	{
		if (this.GetConfig() == null)
		{
			return null;
		}
		return new InventoryDefine.EItemMainTypeId?((InventoryDefine.EItemMainTypeId)this.CalabashSkin.MainTypeId);
	}

	// Token: 0x0600F959 RID: 63833 RVA: 0x00445848 File Offset: 0x00443A48
	public override InventoryDefine.EItemType? GetType()
	{
		if (this.GetConfig() == null)
		{
			return null;
		}
		return new InventoryDefine.EItemType?((InventoryDefine.EItemType)this.CalabashSkin.ItemType);
	}

	// Token: 0x0600F95A RID: 63834 RVA: 0x0044587A File Offset: 0x00443A7A
	public override int GetMaxStackCount()
	{
		return 1;
	}

	// Token: 0x0600F95B RID: 63835 RVA: 0x00445880 File Offset: 0x00443A80
	public override int GetQuality()
	{
		if (this.GetConfig() == null)
		{
			return 0;
		}
		return this.CalabashSkin.QualityId;
	}

	// Token: 0x0600F95C RID: 63836 RVA: 0x004458A8 File Offset: 0x00443AA8
	public override int GetSortIndex()
	{
		if (this.GetConfig() == null)
		{
			return 0;
		}
		return this.CalabashSkin.SortIndex;
	}

	// Token: 0x0600F95D RID: 63837 RVA: 0x004458D0 File Offset: 0x00443AD0
	public override Span<int> GetItemAccess()
	{
		if (this.GetConfig() != null)
		{
			return this.CalabashSkin.GetItemAccessBytes();
		}
		return Span<int>.Empty;
	}

	// Token: 0x0600F95E RID: 63838 RVA: 0x004458F9 File Offset: 0x00443AF9
	public override int GetUseCountLimit()
	{
		return 1;
	}

	// Token: 0x0600F95F RID: 63839 RVA: 0x004458FC File Offset: 0x00443AFC
	public override InventoryDefine.ERedDotDisableRule GetRedDotDisableRule()
	{
		return (InventoryDefine.ERedDotDisableRule)this.CalabashSkin.RedDotDisableRule;
	}

	// Token: 0x0600F960 RID: 63840 RVA: 0x00445918 File Offset: 0x00443B18
	public override bool HasRedDot()
	{
		int configId = base.GetConfigId();
		return ModelBase<InventoryModel>.Instance.IsCommonItemHasRedDot(configId, 0);
	}

	// Token: 0x0600F961 RID: 63841 RVA: 0x00445938 File Offset: 0x00443B38
	public override bool IsValid()
	{
		return true;
	}

	// Token: 0x0600F962 RID: 63842 RVA: 0x0044593C File Offset: 0x00443B3C
	public override bool GetIsShowUseButton()
	{
		return this.GetConfig().As<CalabashSkin>().Value.ShowUseButton;
	}

	// Token: 0x0600F963 RID: 63843 RVA: 0x00445964 File Offset: 0x00443B64
	protected override bool OnIsShowInInventory()
	{
		InventoryDefine.EItemType? type = this.GetType();
		InventoryDefine.EItemType eitemType = InventoryDefine.EItemType.Virtual;
		return !(type.GetValueOrDefault() == eitemType & type != null) && this.GetConfig().As<CalabashSkin>().Value.ShowInInventory;
	}

	// Token: 0x0600F964 RID: 63844 RVA: 0x004459AC File Offset: 0x00443BAC
	[NullableContext(1)]
	public override InventoryDefine.IItemViewDataInfo GetItemViewDataInfo(ItemViewDefine.EItemOperationMode viewMode)
	{
		if (this.GetConfig() == null)
		{
			return null;
		}
		CalabashSkin value = this.GetConfig().As<CalabashSkin>().Value;
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		int uniqueId = this.GetUniqueId();
		return new InventoryDefine.ItemViewDataInfo(value.Id, 1, 0, value.QualityId, this.GetIsLock(), this.GetIsDeprecated(), instance.IsNewAttributeItem(uniqueId), this.ItemDataType, this, instance.IsCommonItemHasRedDot(uniqueId, 0), viewMode, false, 0);
	}
}
