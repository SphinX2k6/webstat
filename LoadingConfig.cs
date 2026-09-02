using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020020CE RID: 8398
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LoadingConfig : ConfigBase<LoadingConfig>
{
	// Token: 0x060100C1 RID: 65729 RVA: 0x004684DE File Offset: 0x004666DE
	public IReadOnlyList<LoadingTipsText> GetLoadingTipsTextList(int levelAreaId)
	{
		return ConfigLoadingTipsTextByLevelAreaId.GetConfigList(levelAreaId, true);
	}

	// Token: 0x060100C2 RID: 65730 RVA: 0x004684E7 File Offset: 0x004666E7
	public BroadcastImage? GetBroadcastImageConfig(int id)
	{
		return ConfigBroadcastImageById.GetConfig(id, true);
	}

	// Token: 0x060100C3 RID: 65731 RVA: 0x004684F0 File Offset: 0x004666F0
	public IReadOnlyList<LoadingLevelArea> GetLevelArea()
	{
		return ConfigLoadingLevelAreaAll.GetConfigList(true);
	}

	// Token: 0x060100C4 RID: 65732 RVA: 0x004684F8 File Offset: 0x004666F8
	public LoadingLevelArea? GetLevelAreaById(int id)
	{
		return ConfigLoadingLevelAreaById.GetConfig(id, true);
	}

	// Token: 0x060100C5 RID: 65733 RVA: 0x00468504 File Offset: 0x00466704
	public int GetLoadingTipsTime()
	{
		return ConfigCommonParamById.GetIntConfig("loadingtips_time").GetValueOrDefault(1);
	}

	// Token: 0x04007B09 RID: 31497
	public int LoadingConfigRequestTimeoutMs = 3000;
}
