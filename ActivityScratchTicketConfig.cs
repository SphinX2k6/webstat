using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001591 RID: 5521
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityScratchTicketConfig : ConfigBase<ActivityScratchTicketConfig>
{
	// Token: 0x06009B71 RID: 39793 RVA: 0x0028B5FC File Offset: 0x002897FC
	public ScratchCardActivityRe? GetScratchTicketConfig(int activityId)
	{
		ScratchCardActivityRe? config = ConfigScratchCardActivityReById.GetConfig(activityId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ScratchTicket;
			ELogAuthor author = ELogAuthor.BB;
			string message = "ScratchCardActivityRe读表失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06009B72 RID: 39794 RVA: 0x0028B64C File Offset: 0x0028984C
	public ScratchCardRoundRe? GetScratchTicketRoundConfig(int id)
	{
		ScratchCardRoundRe? config = ConfigScratchCardRoundReByRoundId.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ScratchTicket;
			ELogAuthor author = ELogAuthor.BB;
			string message = "ScratchCardRoundRe读表失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06009B73 RID: 39795 RVA: 0x0028B69C File Offset: 0x0028989C
	public ScratchCardRewardRe? GetScratchTicketRewardConfig(int id)
	{
		ScratchCardRewardRe? config = ConfigScratchCardRewardReById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ScratchTicket;
			ELogAuthor author = ELogAuthor.BB;
			string message = "ScratchCardRewardRe读表失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06009B74 RID: 39796 RVA: 0x0028B6EC File Offset: 0x002898EC
	public IReadOnlyList<ScratchCardRewardRe> GetScratchTicketRewardConfigList(int roundId)
	{
		IReadOnlyList<ScratchCardRewardRe> configList = ConfigScratchCardRewardReByType.GetConfigList(roundId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ScratchTicket;
			ELogAuthor author = ELogAuthor.BB;
			string message = "ScratchCardRewardRe读表失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roundId", roundId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return configList;
	}

	// Token: 0x06009B75 RID: 39797 RVA: 0x0028B734 File Offset: 0x00289934
	public ScratchCardTimesRe? GetScratchTicketConditionConfig(int id)
	{
		ScratchCardTimesRe? config = ConfigScratchCardTimesReByTaskId.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ScratchTicket;
			ELogAuthor author = ELogAuthor.BB;
			string message = "ScratchCardTimesRe读表失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}
}
