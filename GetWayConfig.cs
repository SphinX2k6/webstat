using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002070 RID: 8304
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class GetWayConfig : ConfigBase<GetWayConfig>
{
	// Token: 0x0600FD3B RID: 64827 RVA: 0x00457860 File Offset: 0x00455A60
	public string GetWayName(int getWayId)
	{
		AccessPath? config = ConfigAccessPathById.GetConfig(getWayId, true);
		if (config != null)
		{
			return ConfigMultiTextLang.GetLocalTextNew(config.Value.Description, null);
		}
		return null;
	}

	// Token: 0x0600FD3C RID: 64828 RVA: 0x00457895 File Offset: 0x00455A95
	public AccessPath? GetConfigById(int getWayId)
	{
		return ConfigAccessPathById.GetConfig(getWayId, true);
	}
}
