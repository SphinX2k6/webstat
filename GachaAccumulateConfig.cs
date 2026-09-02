using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001CB7 RID: 7351
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class GachaAccumulateConfig : ConfigBase<GachaAccumulateConfig>
{
	// Token: 0x0600D7C3 RID: 55235 RVA: 0x0039B238 File Offset: 0x00399438
	public GachaAccumulate? GetGachaAccumulateConfig(int accumulateId)
	{
		return ConfigGachaAccumulateById.GetConfig(accumulateId, true);
	}

	// Token: 0x0600D7C4 RID: 55236 RVA: 0x0039B244 File Offset: 0x00399444
	public string GetGachaAccumulateTipsPrefabPath(int accumulateId)
	{
		return ConfigGachaAccumulateById.GetConfig(accumulateId, true).Value.TipsPrefabPath;
	}

	// Token: 0x0600D7C5 RID: 55237 RVA: 0x0039B268 File Offset: 0x00399468
	public string GetGachaAccumulatePrefabPath(int accumulateId)
	{
		return ConfigGachaAccumulateById.GetConfig(accumulateId, true).Value.GachaAccumulatePrefabPath;
	}

	// Token: 0x0600D7C6 RID: 55238 RVA: 0x0039B28C File Offset: 0x0039948C
	public EGachaAccumulateShowType GetShowType(int accumulateId)
	{
		GachaAccumulate? config = ConfigGachaAccumulateById.GetConfig(accumulateId, true);
		if (config == null)
		{
			return EGachaAccumulateShowType.Default;
		}
		return (EGachaAccumulateShowType)config.GetValueOrDefault().ShowType;
	}

	// Token: 0x0600D7C7 RID: 55239 RVA: 0x0039B2BC File Offset: 0x003994BC
	public int GetHelpId(int accumulateId)
	{
		if (ConfigGachaAccumulateById.GetConfig(accumulateId, true) == null)
		{
			return 0;
		}
		GachaAccumulate? gachaAccumulate;
		return gachaAccumulate.GetValueOrDefault().HelpId;
	}

	// Token: 0x0600D7C8 RID: 55240 RVA: 0x0039B2EB File Offset: 0x003994EB
	public SelectRolePerformance? GetSelectRolePerformanceConfig(int itemId)
	{
		return ConfigSelectRolePerformanceById.GetConfig(itemId, true);
	}

	// Token: 0x0600D7C9 RID: 55241 RVA: 0x0039B2F4 File Offset: 0x003994F4
	public SelectRoleItemPerformance? GetSelectRoleItemPerformance(int itemId)
	{
		return ConfigSelectRoleItemPerformanceById.GetConfig(itemId, true);
	}
}
