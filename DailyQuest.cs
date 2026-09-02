using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x02002647 RID: 9799
[NullableContext(1)]
[Nullable(0)]
public class DailyQuest : global::Quest
{
	// Token: 0x06013546 RID: 79174 RVA: 0x0056121C File Offset: 0x0055F41C
	public DailyQuest(EQuest type, IQuest questConfig) : base(type, questConfig)
	{
	}

	// Token: 0x06013547 RID: 79175 RVA: 0x00561226 File Offset: 0x0055F426
	public override void SetUpBehaviorTree(BaseBehaviorTree behaviorTree)
	{
		base.SetUpBehaviorTree(behaviorTree);
		behaviorTree.SetMapMarkResident(true);
	}

	// Token: 0x040096D1 RID: 38609
	public bool TriggerQuestTips;
}
