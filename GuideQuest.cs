using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x0200264E RID: 9806
public class GuideQuest : global::Quest
{
	// Token: 0x06013573 RID: 79219 RVA: 0x00561C52 File Offset: 0x0055FE52
	[NullableContext(1)]
	public GuideQuest(EQuest type, IQuest questConfig) : base(type, questConfig)
	{
	}
}
