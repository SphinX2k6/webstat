using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001DB1 RID: 7601
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GamepadConfig : ConfigBase<GamepadConfig>
{
	// Token: 0x0600E060 RID: 57440 RVA: 0x003C5638 File Offset: 0x003C3838
	public PsFeedback? GetPsFeedbackReason(string reason)
	{
		return ConfigPsFeedbackById.GetConfig(reason, true);
	}

	// Token: 0x0600E061 RID: 57441 RVA: 0x003C5641 File Offset: 0x003C3841
	[NullableContext(2)]
	public IReadOnlyList<PsFeedback> GetAllPsFeedbackConfig()
	{
		return ConfigPsFeedbackAll.GetConfigList(true);
	}
}
