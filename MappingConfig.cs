using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020018B0 RID: 6320
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MappingConfig : ConfigBase<MappingConfig>
{
	// Token: 0x0600B5AE RID: 46510 RVA: 0x00305A85 File Offset: 0x00303C85
	public string GetWeaponConfComment(string name)
	{
		return ConfigMultiTextLang.GetLocalTextNew(name, null) ?? "";
	}

	// Token: 0x0600B5AF RID: 46511 RVA: 0x00305A97 File Offset: 0x00303C97
	public IReadOnlyList<Mapping> GetWeaponConfList()
	{
		return ConfigMappingBySheetNameAndFieldName.GetConfigList("WeaponConf", "WeaponType", true);
	}
}
