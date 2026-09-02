using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020020BC RID: 8380
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class LevelPlayConfig : ConfigBase<LevelPlayConfig>
{
	// Token: 0x0601000F RID: 65551 RVA: 0x00464424 File Offset: 0x00462624
	public unsafe ExchangeReward? GetExchangeRewardInfo(int id)
	{
		ExchangeReward? config = ConfigExchangeRewardById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneGameplay;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到兑换奖励表配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("配置表路径", "Source/Config/Raw/Tables/d.兑换奖励配置");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config;
	}

	// Token: 0x06010010 RID: 65552 RVA: 0x004644A0 File Offset: 0x004626A0
	public LevelPlayData? GetLevelPlayConfig(int levelPlayId)
	{
		LevelPlayData? config = ConfigLevelPlayDataById.GetConfig(levelPlayId, false);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneGameplay;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到任务配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("玩法Id", levelPlayId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06010011 RID: 65553 RVA: 0x004644EC File Offset: 0x004626EC
	public unsafe LevelPlayNodeData? GetLevelPlayNodeConfig(int levelPlayId, int nodeId)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(levelPlayId);
		defaultInterpolatedStringHandler.AppendLiteral("_");
		defaultInterpolatedStringHandler.AppendFormatted<int>(nodeId);
		LevelPlayNodeData? config = ConfigLevelPlayNodeDataByKey.GetConfig(defaultInterpolatedStringHandler.ToStringAndClear(), false);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到玩法节点配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("玩法Id", levelPlayId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("节点Id", nodeId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config;
	}
}
