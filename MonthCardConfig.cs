using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020023A3 RID: 9123
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MonthCardConfig : ConfigBase<MonthCardConfig>
{
	// Token: 0x06011942 RID: 72002 RVA: 0x004D1F18 File Offset: 0x004D0118
	public MonthCardContent? GetConfig(int key)
	{
		MonthCardContent? config = ConfigMonthCardContentById.GetConfig(key, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "获取物品配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MonthCardConfig", key);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}
}
