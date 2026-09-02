using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A57 RID: 10839
[NullableContext(1)]
[Nullable(0)]
public class FlySkinGridData
{
	// Token: 0x17001C1C RID: 7196
	// (get) Token: 0x06015B4A RID: 88906 RVA: 0x00606035 File Offset: 0x00604235
	public bool IsEmptyData
	{
		get
		{
			return this.SkinId == 0;
		}
	}

	// Token: 0x06015B4B RID: 88907 RVA: 0x00606040 File Offset: 0x00604240
	public FlySkinGridData(int skinId, int roleDataId, EFlySkinType skinType, FlySkinConfig? skinConfig = null)
	{
		this.SkinId = skinId;
		this.RoleDataId = roleDataId;
		this.SkinType = skinType;
		this.SkinConfig = skinConfig;
	}

	// Token: 0x06015B4C RID: 88908 RVA: 0x00606065 File Offset: 0x00604265
	public bool GetIsLock()
	{
		return !this.IsEmptyData && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.SkinId, 0) <= 0;
	}

	// Token: 0x06015B4D RID: 88909 RVA: 0x00606088 File Offset: 0x00604288
	public bool IsCurrentEquipSkinId()
	{
		return ModelBase<FlySkinModel>.Instance.GetRoleEquipFlySkinId(this.RoleDataId, this.SkinType) == this.SkinId;
	}

	// Token: 0x06015B4E RID: 88910 RVA: 0x006060A8 File Offset: 0x006042A8
	public string GetName()
	{
		if (this.IsEmptyData)
		{
			return ConfigBase<CSharpScript.Game.Module.Skin.SkinConfig>.Instance.GetDefaultFlySkinName(this.SkinType);
		}
		return this.SkinConfig.Value.Name;
	}

	// Token: 0x06015B4F RID: 88911 RVA: 0x006060E4 File Offset: 0x006042E4
	public string GetTypeDescription()
	{
		if (this.IsEmptyData)
		{
			return ConfigBase<CSharpScript.Game.Module.Skin.SkinConfig>.Instance.GetDefaultFlySkinTypeDescription(this.SkinType);
		}
		return this.SkinConfig.Value.TypeDescription;
	}

	// Token: 0x06015B50 RID: 88912 RVA: 0x00606120 File Offset: 0x00604320
	public string GetDescription()
	{
		if (this.IsEmptyData)
		{
			return ConfigBase<CSharpScript.Game.Module.Skin.SkinConfig>.Instance.GetDefaultFlySkinDescription(this.SkinType);
		}
		return this.SkinConfig.Value.BgDescription;
	}

	// Token: 0x06015B51 RID: 88913 RVA: 0x0060615C File Offset: 0x0060435C
	public int GetModelId()
	{
		if (this.IsEmptyData)
		{
			return ConfigBase<CSharpScript.Game.Module.Skin.SkinConfig>.Instance.GetDefaultFlySkinModelId(this.SkinType);
		}
		return this.SkinConfig.Value.ModelId;
	}

	// Token: 0x06015B52 RID: 88914 RVA: 0x00606198 File Offset: 0x00604398
	public string GetStandAnimPath()
	{
		if (this.IsEmptyData)
		{
			return ConfigBase<CSharpScript.Game.Module.Skin.SkinConfig>.Instance.GetDefaultFlySkinStandAnimPath(this.SkinType);
		}
		return this.SkinConfig.Value.StandAnim;
	}

	// Token: 0x06015B53 RID: 88915 RVA: 0x006061D1 File Offset: 0x006043D1
	public bool GetIsNew()
	{
		return !this.IsEmptyData && ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.FlySkinRedDot, this.SkinId);
	}

	// Token: 0x0400A6A1 RID: 42657
	public readonly int SkinId;

	// Token: 0x0400A6A2 RID: 42658
	public readonly int RoleDataId;

	// Token: 0x0400A6A3 RID: 42659
	public readonly EFlySkinType SkinType;

	// Token: 0x0400A6A4 RID: 42660
	public readonly FlySkinConfig? SkinConfig;
}
