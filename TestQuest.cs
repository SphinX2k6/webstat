using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x0200264C RID: 9804
public class TestQuest : global::Quest
{
	// Token: 0x06013571 RID: 79217 RVA: 0x00561C3E File Offset: 0x0055FE3E
	[NullableContext(1)]
	public TestQuest(EQuest type, IQuest questConfig) : base(type, questConfig)
	{
	}
}
