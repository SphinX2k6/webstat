using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002645 RID: 9797
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DailyTaskModel : ModelBase<DailyTaskModel>
{
	// Token: 0x060134EE RID: 79086 RVA: 0x0055F30C File Offset: 0x0055D50C
	protected override bool OnInit()
	{
		this.DailyQuestMap = new Dictionary<int, DailyQuest>();
		return true;
	}

	// Token: 0x060134EF RID: 79087 RVA: 0x0055F31A File Offset: 0x0055D51A
	protected override bool OnClear()
	{
		Dictionary<int, DailyQuest> dailyQuestMap = this.DailyQuestMap;
		if (dailyQuestMap != null)
		{
			dailyQuestMap.Clear();
		}
		this.DailyQuestMap = null;
		return true;
	}

	// Token: 0x060134F0 RID: 79088 RVA: 0x0055F335 File Offset: 0x0055D535
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, DailyQuest> GetAllDailyQuest()
	{
		return this.DailyQuestMap;
	}

	// Token: 0x060134F1 RID: 79089 RVA: 0x0055F340 File Offset: 0x0055D540
	public List<int> GetDailyTaskCorrelativeEntities()
	{
		List<int> list = new List<int>();
		foreach (DailyQuest dailyQuest in this.DailyQuestMap.Values)
		{
			IReadOnlyList<int> currentCorrelativeEntities = dailyQuest.GetCurrentCorrelativeEntities();
			if (currentCorrelativeEntities != null)
			{
				foreach (int item in currentCorrelativeEntities)
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	// Token: 0x060134F2 RID: 79090 RVA: 0x0055F3DC File Offset: 0x0055D5DC
	public void AddDailyQuest(DailyQuest quest)
	{
		if (quest == null)
		{
			return;
		}
		this.DailyQuestMap[quest.Id] = quest;
		Singleton<EventSystem>.Instance.Emit(EEventName.DailyTaskChange);
	}

	// Token: 0x060134F3 RID: 79091 RVA: 0x0055F404 File Offset: 0x0055D604
	public void RemoveDailyQuest(int questId)
	{
		this.DailyQuestMap.Remove(questId);
	}

	// Token: 0x040096B8 RID: 38584
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, DailyQuest> DailyQuestMap;
}
