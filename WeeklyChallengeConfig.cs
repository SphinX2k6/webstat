using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002D25 RID: 11557
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class WeeklyChallengeConfig : ConfigBase<WeeklyChallengeConfig>
{
	// Token: 0x06017532 RID: 95538 RVA: 0x00677E17 File Offset: 0x00676017
	public WeeklyFrameHelp? GetPlayConfigById(int playId)
	{
		return ConfigWeeklyFrameHelpById.GetConfig(playId, true);
	}

	// Token: 0x06017533 RID: 95539 RVA: 0x00677E20 File Offset: 0x00676020
	public IReadOnlyList<WeeklyFrameAward> GetAllScoreRewardTasks()
	{
		return ConfigWeeklyFrameAwardAll.GetConfigList(true);
	}

	// Token: 0x06017534 RID: 95540 RVA: 0x00677E28 File Offset: 0x00676028
	public WeeklyFrameAward? GetScoreRewardTaskById(int taskId)
	{
		return ConfigWeeklyFrameAwardById.GetConfig(taskId, true);
	}

	// Token: 0x06017535 RID: 95541 RVA: 0x00677E31 File Offset: 0x00676031
	public IReadOnlyList<ActivityTab> GetAllActivityTabConfigs()
	{
		return ConfigActivityTabAll.GetConfigList(true);
	}

	// Token: 0x06017536 RID: 95542 RVA: 0x00677E39 File Offset: 0x00676039
	public ActivityTab? GetActivityTabByType(int type)
	{
		return ConfigActivityTabByType.GetConfig(type, true);
	}
}
