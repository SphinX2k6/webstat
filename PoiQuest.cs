using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x0200264F RID: 9807
public class PoiQuest : global::Quest
{
	// Token: 0x06013574 RID: 79220 RVA: 0x00561C5C File Offset: 0x0055FE5C
	[NullableContext(1)]
	public PoiQuest(EQuest type, IQuest questConfig) : base(type, questConfig)
	{
	}
}
