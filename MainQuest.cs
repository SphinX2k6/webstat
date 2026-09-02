using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x0200264A RID: 9802
[NullableContext(1)]
[Nullable(0)]
public class MainQuest : global::Quest
{
	// Token: 0x0601356E RID: 79214 RVA: 0x00561C1A File Offset: 0x0055FE1A
	public MainQuest(EQuest type, IQuest questConfig) : base(type, questConfig)
	{
	}

	// Token: 0x0601356F RID: 79215 RVA: 0x00561C24 File Offset: 0x0055FE24
	public override void SetUpBehaviorTree(BaseBehaviorTree behaviorTree)
	{
		base.SetUpBehaviorTree(behaviorTree);
		behaviorTree.SetMapMarkResident(true);
	}
}
