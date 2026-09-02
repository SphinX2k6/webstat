using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020020B1 RID: 8369
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class LanguageConfig : ConfigBase<LanguageConfig>
{
	// Token: 0x0600FF97 RID: 65431 RVA: 0x004627C9 File Offset: 0x004609C9
	public Aki.Config.LanguageDefine? GetLanguageDefineByLanguageCode(string code)
	{
		return ConfigLanguageDefineByLanguageCode.GetConfig(code, true);
	}

	// Token: 0x0600FF98 RID: 65432 RVA: 0x004627D2 File Offset: 0x004609D2
	public Aki.Config.LanguageDefine? GetLanguageDefineById(int id)
	{
		return ConfigLanguageDefineByLanguageType.GetConfig(id, true);
	}
}
