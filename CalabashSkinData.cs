using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A46 RID: 10822
[NullableContext(1)]
[Nullable(0)]
public class CalabashSkinData
{
	// Token: 0x17001C08 RID: 7176
	// (get) Token: 0x06015AC0 RID: 88768 RVA: 0x00604602 File Offset: 0x00602802
	public int SkinId { get; }

	// Token: 0x06015AC1 RID: 88769 RVA: 0x0060460A File Offset: 0x0060280A
	public CalabashSkinData(int skinId)
	{
		this.SkinId = skinId;
	}

	// Token: 0x17001C09 RID: 7177
	// (get) Token: 0x06015AC2 RID: 88770 RVA: 0x00604619 File Offset: 0x00602819
	public bool IsEmptyData
	{
		get
		{
			return this.SkinId == 0;
		}
	}

	// Token: 0x17001C0A RID: 7178
	// (get) Token: 0x06015AC3 RID: 88771 RVA: 0x00604624 File Offset: 0x00602824
	public int? QualityId
	{
		get
		{
			if (this.IsEmptyData)
			{
				return null;
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.SkinId);
			if (itemConfigData == null)
			{
				return null;
			}
			return new int?(itemConfigData.QualityId);
		}
	}

	// Token: 0x17001C0B RID: 7179
	// (get) Token: 0x06015AC4 RID: 88772 RVA: 0x0060466C File Offset: 0x0060286C
	public int SortIndex
	{
		get
		{
			if (this.IsEmptyData)
			{
				return 0;
			}
			return ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfig(this.SkinId).SortIndex;
		}
	}

	// Token: 0x06015AC5 RID: 88773 RVA: 0x0060469B File Offset: 0x0060289B
	public bool GetIsLock()
	{
		return !this.IsEmptyData && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.SkinId, 0) <= 0;
	}

	// Token: 0x06015AC6 RID: 88774 RVA: 0x006046C0 File Offset: 0x006028C0
	public bool IsCurrentEquipSkinId()
	{
		int currentEquipSkinId = ModelBase<CalabashSkinModel>.Instance.GetCurrentEquipSkinId();
		return this.SkinId == currentEquipSkinId;
	}

	// Token: 0x17001C0C RID: 7180
	// (get) Token: 0x06015AC7 RID: 88775 RVA: 0x006046E4 File Offset: 0x006028E4
	public string Name
	{
		get
		{
			if (this.IsEmptyData)
			{
				return ConfigBase<SkinConfig>.Instance.GetDefaultCalabashSkinName();
			}
			return ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfig(this.SkinId).Name;
		}
	}

	// Token: 0x17001C0D RID: 7181
	// (get) Token: 0x06015AC8 RID: 88776 RVA: 0x0060471C File Offset: 0x0060291C
	public string Description
	{
		get
		{
			if (this.IsEmptyData)
			{
				return ConfigBase<SkinConfig>.Instance.GetDefaultCalabashSkinDescription();
			}
			return ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfig(this.SkinId).BgDescription;
		}
	}

	// Token: 0x17001C0E RID: 7182
	// (get) Token: 0x06015AC9 RID: 88777 RVA: 0x00604754 File Offset: 0x00602954
	public bool IsNew
	{
		get
		{
			return !this.IsEmptyData && ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.CalabashSkinRedDot, this.SkinId);
		}
	}
}
