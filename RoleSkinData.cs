using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A2A RID: 10794
[NullableContext(1)]
[Nullable(0)]
public class RoleSkinData
{
	// Token: 0x060158D8 RID: 88280 RVA: 0x005F94CC File Offset: 0x005F76CC
	public RoleSkinData(int itemId)
	{
		this.ItemId = itemId;
		this.RoleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(this.ItemId).GetValueOrDefault();
	}

	// Token: 0x060158D9 RID: 88281 RVA: 0x005F950B File Offset: 0x005F770B
	public ItemConfig GetItemConfig()
	{
		return ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId);
	}

	// Token: 0x060158DA RID: 88282 RVA: 0x005F951D File Offset: 0x005F771D
	public int GetItemId()
	{
		return this.ItemId;
	}

	// Token: 0x060158DB RID: 88283 RVA: 0x005F9525 File Offset: 0x005F7725
	public string GetName()
	{
		return this.GetItemConfig().Name;
	}

	// Token: 0x060158DC RID: 88284 RVA: 0x005F9534 File Offset: 0x005F7734
	public string GetTitleName()
	{
		return this.GetRoleSkinConfig().TitleName;
	}

	// Token: 0x060158DD RID: 88285 RVA: 0x005F9550 File Offset: 0x005F7750
	public string GetSubTitle()
	{
		return this.GetRoleSkinConfig().SubDecName;
	}

	// Token: 0x060158DE RID: 88286 RVA: 0x005F956B File Offset: 0x005F776B
	public string GetDesc()
	{
		return this.GetItemConfig().BgDescription;
	}

	// Token: 0x060158DF RID: 88287 RVA: 0x005F9578 File Offset: 0x005F7778
	public string GetFunctionDesc()
	{
		return this.GetRoleSkinConfig().FunctionDesc;
	}

	// Token: 0x060158E0 RID: 88288 RVA: 0x005F9593 File Offset: 0x005F7793
	public int GetQuality()
	{
		return this.GetItemConfig().QualityId;
	}

	// Token: 0x060158E1 RID: 88289 RVA: 0x005F95A0 File Offset: 0x005F77A0
	public bool IsLocked()
	{
		return this.IsLock;
	}

	// Token: 0x060158E2 RID: 88290 RVA: 0x005F95A8 File Offset: 0x005F77A8
	public void LockSkin()
	{
		this.IsLock = true;
	}

	// Token: 0x060158E3 RID: 88291 RVA: 0x005F95B1 File Offset: 0x005F77B1
	public void UnlockSkin()
	{
		this.IsLock = false;
	}

	// Token: 0x060158E4 RID: 88292 RVA: 0x005F95BC File Offset: 0x005F77BC
	public bool IsWear()
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.GetRoleId());
		return roleInstanceById != null && roleInstanceById.GetRoleSkinId() == this.ItemId;
	}

	// Token: 0x060158E5 RID: 88293 RVA: 0x005F95F0 File Offset: 0x005F77F0
	public bool IsOriginalSkin()
	{
		int roleId = this.RoleSkinConfig.RoleId;
		return ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.SkinId == this.ItemId;
	}

	// Token: 0x060158E6 RID: 88294 RVA: 0x005F962F File Offset: 0x005F782F
	public int GetItemCount()
	{
		return (!this.IsLocked()) ? 1 : 0;
	}

	// Token: 0x060158E7 RID: 88295 RVA: 0x005F963A File Offset: 0x005F783A
	public RoleSkin GetRoleSkinConfig()
	{
		return this.RoleSkinConfig;
	}

	// Token: 0x060158E8 RID: 88296 RVA: 0x005F9644 File Offset: 0x005F7844
	public int GetRoleId()
	{
		return this.GetRoleSkinConfig().RoleId;
	}

	// Token: 0x060158E9 RID: 88297 RVA: 0x005F9660 File Offset: 0x005F7860
	public int GetUiMeshId()
	{
		return this.RoleSkinConfig.UiMeshId;
	}

	// Token: 0x060158EA RID: 88298 RVA: 0x005F967B File Offset: 0x005F787B
	public bool GetIfHaveRole()
	{
		return ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.GetRoleId()) != null;
	}

	// Token: 0x060158EB RID: 88299 RVA: 0x005F9690 File Offset: 0x005F7890
	public bool IsWearWeaponSkin()
	{
		if (this.IsLocked())
		{
			return false;
		}
		if (!this.IsWear())
		{
			return false;
		}
		int suitWeaponSkinId = this.RoleSkinConfig.SuitWeaponSkinId;
		return suitWeaponSkinId > 0 && ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(this.GetRoleId()) == suitWeaponSkinId;
	}

	// Token: 0x060158EC RID: 88300 RVA: 0x005F96DC File Offset: 0x005F78DC
	public string GetBuyPreviewRoleCardPath()
	{
		return this.GetRoleSkinConfig().PreviewRoleCard;
	}

	// Token: 0x060158ED RID: 88301 RVA: 0x005F96F8 File Offset: 0x005F78F8
	public string GetBuyPreviewRoleQualityBgPath()
	{
		return ConfigQualityInfoById.GetConfig(this.GetQuality(), true).Value.RoleSkinQualityBg;
	}

	// Token: 0x060158EE RID: 88302 RVA: 0x005F9724 File Offset: 0x005F7924
	public string GetShopBuyPreviewCardPath()
	{
		return this.GetRoleSkinConfig().BuyShopPreviewRoleCard;
	}

	// Token: 0x060158EF RID: 88303 RVA: 0x005F9740 File Offset: 0x005F7940
	public string GetSuitWeaponPreviewTexturePath()
	{
		WeaponSkin? suitWeaponSkinConfig = this.GetSuitWeaponSkinConfig();
		return ((suitWeaponSkinConfig != null) ? suitWeaponSkinConfig.GetValueOrDefault().CardIconPath : null) ?? "";
	}

	// Token: 0x060158F0 RID: 88304 RVA: 0x005F9778 File Offset: 0x005F7978
	public string GetSuitWeaponQualityBgPath()
	{
		WeaponSkin? suitWeaponSkinConfig = this.GetSuitWeaponSkinConfig();
		return ConfigQualityInfoById.GetConfig((suitWeaponSkinConfig != null) ? suitWeaponSkinConfig.GetValueOrDefault().QualityId : 0, true).Value.WeaponSkinQualityBg;
	}

	// Token: 0x060158F1 RID: 88305 RVA: 0x005F97C0 File Offset: 0x005F79C0
	public WeaponSkin? GetSuitWeaponSkinConfig()
	{
		if (this.GetSuitWeaponSkinId() <= 0)
		{
			return null;
		}
		return new WeaponSkin?(ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(this.GetSuitWeaponSkinId()));
	}

	// Token: 0x060158F2 RID: 88306 RVA: 0x005F97F8 File Offset: 0x005F79F8
	public int[] GetSuitWeaponMeshData()
	{
		WeaponSkin? suitWeaponSkinConfig = this.GetSuitWeaponSkinConfig();
		if (suitWeaponSkinConfig == null)
		{
			return Array.Empty<int>();
		}
		return suitWeaponSkinConfig.Value.GetModelsArray();
	}

	// Token: 0x060158F3 RID: 88307 RVA: 0x005F982C File Offset: 0x005F7A2C
	public int GetRoleMeshId()
	{
		return this.GetRoleSkinConfig().MeshId;
	}

	// Token: 0x060158F4 RID: 88308 RVA: 0x005F9848 File Offset: 0x005F7A48
	public int GetRoleUiMeshId()
	{
		return this.GetRoleSkinConfig().UiMeshId;
	}

	// Token: 0x060158F5 RID: 88309 RVA: 0x005F9864 File Offset: 0x005F7A64
	public string GetRoleBody()
	{
		return this.GetRoleSkinConfig().RoleBody;
	}

	// Token: 0x060158F6 RID: 88310 RVA: 0x005F9880 File Offset: 0x005F7A80
	public int GetSuitWeaponSkinId()
	{
		int suitWeaponSkinId = this.GetRoleSkinConfig().SuitWeaponSkinId;
		if (suitWeaponSkinId <= 0)
		{
			return -1;
		}
		return suitWeaponSkinId;
	}

	// Token: 0x060158F7 RID: 88311 RVA: 0x005F98A4 File Offset: 0x005F7AA4
	public string GetRoleStandPath()
	{
		return this.GetRoleSkinConfig().RoleStand;
	}

	// Token: 0x060158F8 RID: 88312 RVA: 0x005F98C0 File Offset: 0x005F7AC0
	public string GetSpineSkeletonData()
	{
		return this.GetRoleSkinConfig().SpineSkeletonData;
	}

	// Token: 0x060158F9 RID: 88313 RVA: 0x005F98DC File Offset: 0x005F7ADC
	public string GetSmallSpineAtlas()
	{
		return this.GetRoleSkinConfig().SmallSpineAtlas;
	}

	// Token: 0x060158FA RID: 88314 RVA: 0x005F98F8 File Offset: 0x005F7AF8
	public string GetPayShopPreviewRoleTexturePath()
	{
		return this.GetRoleSkinConfig().PayShopPreviewRoleTexturePath;
	}

	// Token: 0x060158FB RID: 88315 RVA: 0x005F9914 File Offset: 0x005F7B14
	public string GetPayShopPreviewRoleTextureBgPath()
	{
		return this.GetRoleSkinConfig().PayShopPreviewRoleTextureBgPath;
	}

	// Token: 0x060158FC RID: 88316 RVA: 0x005F9930 File Offset: 0x005F7B30
	public string GetPayShopPreviewWeaponTexturePath()
	{
		return this.GetRoleSkinConfig().PayShopPreviewWeaponTexturePath;
	}

	// Token: 0x060158FD RID: 88317 RVA: 0x005F994C File Offset: 0x005F7B4C
	public string GetObtainFrameColor1()
	{
		return this.GetRoleSkinConfig().RoleObtainColor1;
	}

	// Token: 0x060158FE RID: 88318 RVA: 0x005F9968 File Offset: 0x005F7B68
	public string GetObtainFrameColor2()
	{
		return this.GetRoleSkinConfig().RoleObtainColor2;
	}

	// Token: 0x060158FF RID: 88319 RVA: 0x005F9984 File Offset: 0x005F7B84
	public string GetPayShopPreviewBuyRoleTexturePath()
	{
		return this.GetRoleSkinConfig().PayShopPreviewBuyRoleTexturePath;
	}

	// Token: 0x06015900 RID: 88320 RVA: 0x005F99A0 File Offset: 0x005F7BA0
	public string GetPayShopPreviewBuyRoleSuitWeaponTexturePath()
	{
		return this.GetRoleSkinConfig().PayShopPreviewBuyRoleSuitWeaponTexturePath;
	}

	// Token: 0x06015901 RID: 88321 RVA: 0x005F99BC File Offset: 0x005F7BBC
	public string GetShareTexturePath()
	{
		return this.GetRoleSkinConfig().ShareTexturePath;
	}

	// Token: 0x06015902 RID: 88322 RVA: 0x005F99D7 File Offset: 0x005F7BD7
	public bool GetHasNewFlag()
	{
		return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RoleSkinRedDot, this.GetItemId());
	}

	// Token: 0x0400A5F1 RID: 42481
	public readonly int ItemId;

	// Token: 0x0400A5F2 RID: 42482
	private readonly RoleSkin RoleSkinConfig;

	// Token: 0x0400A5F3 RID: 42483
	private bool IsLock = true;
}
