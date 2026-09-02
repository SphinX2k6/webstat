using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;

// Token: 0x020025A1 RID: 9633
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PhotographConfig : ConfigBase<PhotographConfig>
{
	// Token: 0x06012C88 RID: 76936 RVA: 0x0052EA9A File Offset: 0x0052CC9A
	public PhotoMontage? GetPhotoMontageConfig(int montageId)
	{
		return ConfigPhotoMontageById.GetConfig(montageId, true);
	}

	// Token: 0x06012C89 RID: 76937 RVA: 0x0052EAA3 File Offset: 0x0052CCA3
	public IReadOnlyList<PhotoMontage> GetPhotoMontageConfigListBySkinIdAndMainAnim(int skinId, ERoleMainAnimInstanceType mainAnimInstanceType)
	{
		return ConfigPhotoMontageBySkinIdAndMainAnimInstanceType.GetConfigList(skinId, (int)mainAnimInstanceType, true);
	}

	// Token: 0x06012C8A RID: 76938 RVA: 0x0052EAAD File Offset: 0x0052CCAD
	public IReadOnlyList<PhotoMontage> GetPhotoMontageConfigByRoleId(int roleId, int sort)
	{
		return ConfigPhotoMontageByRoleIdAndSort.GetConfigList(roleId, sort, true);
	}

	// Token: 0x06012C8B RID: 76939 RVA: 0x0052EAB7 File Offset: 0x0052CCB7
	public PhotoSetup? GetPhotoSetupConfig(EPhotoSetupValueType valueType)
	{
		return ConfigPhotoSetupByValueType.GetConfig((int)valueType, true);
	}

	// Token: 0x06012C8C RID: 76940 RVA: 0x0052EAC0 File Offset: 0x0052CCC0
	public IReadOnlyList<PhotoSetup> GetAllPhotoSetupConfig()
	{
		return ConfigPhotoSetupAll.GetConfigList(true);
	}

	// Token: 0x06012C8D RID: 76941 RVA: 0x0052EAC8 File Offset: 0x0052CCC8
	public float GetDepthDistanceDefaultValue()
	{
		PhotoSetup? photoSetupConfig = this.GetPhotoSetupConfig(EPhotoSetupValueType.DepthOfFieldDistance);
		if (photoSetupConfig == null)
		{
			return 35f;
		}
		return photoSetupConfig.Value.ValueRange(2);
	}

	// Token: 0x06012C8E RID: 76942 RVA: 0x0052EAFC File Offset: 0x0052CCFC
	public float GetDepthOfFieldRadiusDefaultValue()
	{
		PhotoSetup? photoSetupConfig = this.GetPhotoSetupConfig(EPhotoSetupValueType.DepthOfFieldRadius);
		if (photoSetupConfig == null)
		{
			return 0f;
		}
		return photoSetupConfig.Value.ValueRange(2);
	}

	// Token: 0x06012C8F RID: 76943 RVA: 0x0052EB30 File Offset: 0x0052CD30
	public IReadOnlyList<PhotoFilter> GetAllPhotoFilterConfig()
	{
		return ConfigPhotoFilterAll.GetConfigList(true);
	}

	// Token: 0x06012C90 RID: 76944 RVA: 0x0052EB38 File Offset: 0x0052CD38
	public PhotoFilter? GetPhotoFilterConfigById(int filterId)
	{
		return ConfigPhotoFilterById.GetConfig(filterId, true);
	}

	// Token: 0x06012C91 RID: 76945 RVA: 0x0052EB41 File Offset: 0x0052CD41
	public IReadOnlyList<FightPhotoOption> GetAllFightPhotoOptionConfig()
	{
		return ConfigFightPhotoOptionAll.GetConfigList(true);
	}

	// Token: 0x06012C92 RID: 76946 RVA: 0x0052EB4C File Offset: 0x0052CD4C
	[NullableContext(1)]
	[return: Nullable(2)]
	public SUiCameraFightPhotographSettings GetUiCameraFightPhotographConfig(string handleName)
	{
		SUiCameraFightPhotographSettings dataTableRowFromName = DataTableUtil.GetDataTableRowFromName<SUiCameraFightPhotographSettings>(EDataTable.FightPhotographCameraConfig, handleName);
		if (dataTableRowFromName == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FightPhotograph;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "在UiCameraFightPhotographSettings表里未找到对应数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handleName", handleName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return dataTableRowFromName;
	}

	// Token: 0x06012C93 RID: 76947 RVA: 0x0052EB98 File Offset: 0x0052CD98
	public IReadOnlyList<PhotoDropDown> GetPhotoDropDownDataList(EPhotoSetupValueType setupType)
	{
		return ConfigPhotoDropDownBySetupType.GetConfigList((int)setupType, true);
	}

	// Token: 0x06012C94 RID: 76948 RVA: 0x0052EBA1 File Offset: 0x0052CDA1
	public IReadOnlyList<FightPhotoTab> GetAllFightPhotoTabConfig()
	{
		return ConfigFightPhotoTabAll.GetConfigList(true);
	}

	// Token: 0x06012C95 RID: 76949 RVA: 0x0052EBA9 File Offset: 0x0052CDA9
	public FightPhotoTab? GetFightPhotoTabConfigById(int id)
	{
		return ConfigFightPhotoTabById.GetConfig(id, true);
	}

	// Token: 0x06012C96 RID: 76950 RVA: 0x0052EBB2 File Offset: 0x0052CDB2
	public IReadOnlyList<FightPhotoSetup> GetAllFightPhotoSetupConfig()
	{
		return ConfigFightPhotoSetupAll.GetConfigList(true);
	}

	// Token: 0x06012C97 RID: 76951 RVA: 0x0052EBBA File Offset: 0x0052CDBA
	public FightPhotoSetup? GetFightPhotoSetupConfigById(int id)
	{
		return ConfigFightPhotoSetupById.GetConfig(id, true);
	}

	// Token: 0x06012C98 RID: 76952 RVA: 0x0052EBC4 File Offset: 0x0052CDC4
	public IReadOnlyList<FightPhotoFrameStyle> GetAllFightPhotoFrameStyleConfig()
	{
		IReadOnlyList<FightPhotoFrameStyle> configList = ConfigFightPhotoFrameStyleAll.GetConfigList(true);
		if (configList == null)
		{
			return null;
		}
		List<FightPhotoFrameStyle> list = new List<FightPhotoFrameStyle>(configList);
		list.Sort(delegate(FightPhotoFrameStyle a, FightPhotoFrameStyle b)
		{
			if (a.SortId != b.SortId)
			{
				return a.SortId - b.SortId;
			}
			return a.Id - b.Id;
		});
		return list;
	}

	// Token: 0x06012C99 RID: 76953 RVA: 0x0052EC08 File Offset: 0x0052CE08
	public FightPhotoFrameStyle? GetFightPhotoFrameStyleConfigById(int id)
	{
		return ConfigFightPhotoFrameStyleById.GetConfig(id, true);
	}
}
