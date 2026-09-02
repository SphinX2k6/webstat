using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A68 RID: 10856
[NullableContext(1)]
[Nullable(0)]
public class WeaponSkinData
{
	// Token: 0x17001C2C RID: 7212
	// (get) Token: 0x06015C19 RID: 89113 RVA: 0x00609AA5 File Offset: 0x00607CA5
	public bool IsEmptyData
	{
		get
		{
			return this.SkinId == -1;
		}
	}

	// Token: 0x17001C2D RID: 7213
	// (get) Token: 0x06015C1A RID: 89114 RVA: 0x00609AB0 File Offset: 0x00607CB0
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

	// Token: 0x06015C1B RID: 89115 RVA: 0x00609AF7 File Offset: 0x00607CF7
	public WeaponSkinData(int skinId, int roleId)
	{
		this.SkinId = skinId;
		this.RoleId = roleId;
	}

	// Token: 0x06015C1C RID: 89116 RVA: 0x00609B0D File Offset: 0x00607D0D
	public bool GetIsLock()
	{
		return !this.IsEmptyData && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.SkinId, 0) <= 0;
	}

	// Token: 0x06015C1D RID: 89117 RVA: 0x00609B30 File Offset: 0x00607D30
	public bool IsCurrentEquipSkinId()
	{
		int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(this.RoleId);
		return this.SkinId == skinIdByRoleId;
	}

	// Token: 0x17001C2E RID: 7214
	// (get) Token: 0x06015C1E RID: 89118 RVA: 0x00609B58 File Offset: 0x00607D58
	public string Name
	{
		get
		{
			if (this.IsEmptyData)
			{
				return ConfigBase<SkinConfig>.Instance.GetDefaultWeaponSkinName();
			}
			return ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(this.SkinId).Name;
		}
	}

	// Token: 0x17001C2F RID: 7215
	// (get) Token: 0x06015C1F RID: 89119 RVA: 0x00609B90 File Offset: 0x00607D90
	public string Description
	{
		get
		{
			if (this.IsEmptyData)
			{
				return ConfigBase<SkinConfig>.Instance.GetDefaultWeaponSkinDescription();
			}
			return ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(this.SkinId).BgDescription;
		}
	}

	// Token: 0x17001C30 RID: 7216
	// (get) Token: 0x06015C20 RID: 89120 RVA: 0x00609BC8 File Offset: 0x00607DC8
	public bool IsNew
	{
		get
		{
			return !this.IsEmptyData && ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.WeaponSkinRedDot, this.SkinId);
		}
	}

	// Token: 0x0400A6DF RID: 42719
	public readonly int SkinId;

	// Token: 0x0400A6E0 RID: 42720
	public readonly int RoleId;
}
