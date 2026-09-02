using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020010AB RID: 4267
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class GolemHackingConfig : ConfigBase<GolemHackingConfig>
{
	// Token: 0x06006F4B RID: 28491 RVA: 0x001CF818 File Offset: 0x001CDA18
	public DaemonHackConfigCsv? GetPlayConfig(int configId)
	{
		DaemonHackConfigCsv? config = ConfigDaemonHackConfigCsvById.GetConfig(configId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GolemHacking;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DaemonHackConfigCsv数据无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", configId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}
}
