using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x02002650 RID: 9808
public class ActivityQuest : global::Quest
{
	// Token: 0x06013575 RID: 79221 RVA: 0x00561C66 File Offset: 0x0055FE66
	[NullableContext(1)]
	public ActivityQuest(EQuest type, IQuest questConfig) : base(type, questConfig)
	{
	}
}
