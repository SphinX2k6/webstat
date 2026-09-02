using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001AAD RID: 6829
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class DamageUiConfig : ConfigBase<DamageUiConfig>
{
	// Token: 0x0600C3AA RID: 50090 RVA: 0x003395E1 File Offset: 0x003377E1
	public IReadOnlyList<DamageText> GetAllDamageTextConfig()
	{
		return ConfigDamageTextAll.GetConfigList(true);
	}

	// Token: 0x0600C3AB RID: 50091 RVA: 0x003395E9 File Offset: 0x003377E9
	public IReadOnlyList<DamageTextArea> GetAllDamageTextArea()
	{
		return ConfigDamageTextAreaAll.GetConfigList(true);
	}
}
