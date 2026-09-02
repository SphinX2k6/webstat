using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200124B RID: 4683
[NullableContext(1)]
[Nullable(0)]
public class ActivityBeginnerBookData : ActivityBaseData
{
	// Token: 0x06007CD4 RID: 31956 RVA: 0x0020DA5C File Offset: 0x0020BC5C
	protected override void PhraseEx(ActivityData data)
	{
		this.AllBeginnerTargetList.Clear();
		ActivityBeginnerBookConfig instance = ConfigBase<ActivityBeginnerBookConfig>.Instance;
		List<WorldNewJourney> list = ConfigCommon.ToList<WorldNewJourney>((instance != null) ? instance.GetAllActivityBeginnerConfig() : null);
		if (list != null)
		{
			list.Sort((WorldNewJourney a, WorldNewJourney b) => a.Sort - b.Sort);
			foreach (WorldNewJourney worldNewJourney in list)
			{
				this.AllBeginnerTargetList.Add(worldNewJourney.Id);
			}
		}
	}

	// Token: 0x06007CD5 RID: 31957 RVA: 0x0020DB00 File Offset: 0x0020BD00
	protected override bool GetExDataFinishShowState()
	{
		foreach (int beginnerId in this.AllBeginnerTargetList)
		{
			if (!this.GetFinishState(beginnerId))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06007CD6 RID: 31958 RVA: 0x0020DB5C File Offset: 0x0020BD5C
	public bool GetEnableJump(int beginnerId)
	{
		ActivityBeginnerBookConfig instance = ConfigBase<ActivityBeginnerBookConfig>.Instance;
		bool flag;
		return (instance != null && instance.GetActivityBeginnerConfig(beginnerId).ConditionId == 0) || (this.UnLockBeginnerMap.TryGetValue(beginnerId, out flag) && flag);
	}

	// Token: 0x06007CD7 RID: 31959 RVA: 0x0020DBA0 File Offset: 0x0020BDA0
	public bool GetFinishState(int beginnerId)
	{
		bool flag;
		return this.FinishBeginnerMap.TryGetValue(beginnerId, out flag) && flag;
	}

	// Token: 0x04003BAF RID: 15279
	public List<int> AllBeginnerTargetList = new List<int>();

	// Token: 0x04003BB0 RID: 15280
	public Dictionary<int, bool> UnLockBeginnerMap = new Dictionary<int, bool>();

	// Token: 0x04003BB1 RID: 15281
	public Dictionary<int, bool> FinishBeginnerMap = new Dictionary<int, bool>();
}
