using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020018B1 RID: 6321
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PropertyIndexConfig : ConfigBase<PropertyIndexConfig>
{
	// Token: 0x0600B5B1 RID: 46513 RVA: 0x00305AB1 File Offset: 0x00303CB1
	public PropertyIndex? GetPropertyIndexInfo(int id)
	{
		return ConfigPropertyIndexById.GetConfig(id, true);
	}

	// Token: 0x0600B5B2 RID: 46514 RVA: 0x00305ABC File Offset: 0x00303CBC
	public string GetPropertyIndexIcon(int id)
	{
		return this.GetPropertyIndexInfo(id).Value.Icon;
	}

	// Token: 0x0600B5B3 RID: 46515 RVA: 0x00305AE0 File Offset: 0x00303CE0
	public string GetPropertyIndexLocalName(int id)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetPropertyIndexInfo(id).Value.Name, null) ?? "";
	}

	// Token: 0x0600B5B4 RID: 46516 RVA: 0x00305B14 File Offset: 0x00303D14
	public string GetPropertyIndexName(int id)
	{
		return this.GetPropertyIndexInfo(id).Value.Name;
	}

	// Token: 0x0600B5B5 RID: 46517 RVA: 0x00305B38 File Offset: 0x00303D38
	[NullableContext(2)]
	public IReadOnlyList<PropertyIndex> GetPropertyIndexList()
	{
		return ConfigPropertyIndexAll.GetConfigList(true);
	}
}
