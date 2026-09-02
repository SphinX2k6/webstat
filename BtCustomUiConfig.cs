using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x02001DE1 RID: 7649
[NullableContext(1)]
[Nullable(0)]
public class BtCustomUiConfig
{
	// Token: 0x0600E221 RID: 57889 RVA: 0x003CE57D File Offset: 0x003CC77D
	public BtCustomUiConfig(int sourceOfAdd, IQuestScheduleConfig customUiConfig)
	{
	}

	// Token: 0x04006C77 RID: 27767
	public readonly int SourceOfAdd = sourceOfAdd;

	// Token: 0x04006C78 RID: 27768
	public IQuestScheduleConfig CustomUiConfig = customUiConfig;
}
