using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002D68 RID: 11624
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class WorldLevelConfig : ConfigBase<WorldLevelConfig>
{
	// Token: 0x06017777 RID: 96119 RVA: 0x00681510 File Offset: 0x0067F710
	public WorldLevel? GetWorldLevelConfig(int worldLevel)
	{
		WorldLevel? config = ConfigWorldLevelById.GetConfig(worldLevel, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WorldLevel;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到worldLevel = 的配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("worldLevel", worldLevel);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06017778 RID: 96120 RVA: 0x00681565 File Offset: 0x0067F765
	public int? GetCommonValue(string keyName)
	{
		return ConfigCommonParamById.GetIntConfig(keyName);
	}
}
