using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002A11 RID: 10769
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class SignalDecodeConfig : ConfigBase<SignalDecodeConfig>
{
	// Token: 0x060157EA RID: 88042 RVA: 0x005F579C File Offset: 0x005F399C
	public CatchSignalGameplay? GetGameplayConfig(string id)
	{
		CatchSignalGameplay? config = ConfigCatchSignalGameplayById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GeneralLogicTree;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "无法找到捕捉信号的配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x060157EB RID: 88043 RVA: 0x005F57E8 File Offset: 0x005F39E8
	public CatchSignalDifficulty? GetDifficultyConfig(int id)
	{
		CatchSignalDifficulty? config = ConfigCatchSignalDifficultyById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GeneralLogicTree;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "无法找到捕捉信号难度的配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}
}
