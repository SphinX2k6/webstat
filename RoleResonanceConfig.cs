using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020028E3 RID: 10467
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class RoleResonanceConfig : ConfigBase<RoleResonanceConfig>
{
	// Token: 0x06014CA0 RID: 85152 RVA: 0x005C2104 File Offset: 0x005C0304
	public List<ResonantChain> GetRoleResonanceList(int groupId)
	{
		List<ResonantChain> list = ConfigCommon.ToList<ResonantChain>(ConfigResonantChainByGroupId.GetConfigList(groupId, true));
		if (list == null)
		{
			return null;
		}
		list.Sort((ResonantChain a, ResonantChain b) => a.GroupIndex - b.GroupIndex);
		return list;
	}

	// Token: 0x06014CA1 RID: 85153 RVA: 0x005C2149 File Offset: 0x005C0349
	public ResonantChain? GetRoleResonanceById(int resonanceId)
	{
		return ConfigResonantChainById.GetConfig(resonanceId, true);
	}

	// Token: 0x06014CA2 RID: 85154 RVA: 0x005C2154 File Offset: 0x005C0354
	public int GetResonanceMaxLevel()
	{
		return ConfigCommonParamById.GetIntConfig("ResonantChainMaxLevel").Value;
	}
}
