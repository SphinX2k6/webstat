using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001EB6 RID: 7862
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class HelpConfig : ConfigBase<HelpConfig>
{
	// Token: 0x0600E886 RID: 59526 RVA: 0x003EE10E File Offset: 0x003EC30E
	public IReadOnlyList<HelpText> GetHelpContentInfoByGroupId(int groupId)
	{
		return ConfigHelpTextByGroupId.GetConfigList(groupId, true);
	}

	// Token: 0x0600E887 RID: 59527 RVA: 0x003EE118 File Offset: 0x003EC318
	public bool IsGroupIdValid(int groupId)
	{
		IReadOnlyList<HelpText> configList = ConfigHelpTextByGroupId.GetConfigList(groupId, true);
		return configList != null && configList.Count > 0;
	}
}
