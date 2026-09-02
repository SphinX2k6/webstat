using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001A90 RID: 6800
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class CreateCharacterConfig : ConfigBase<CreateCharacterConfig>
{
	// Token: 0x0600C2C6 RID: 49862 RVA: 0x00335578 File Offset: 0x00333778
	public IReadOnlyList<int> GetInitialRoles()
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("initial_role");
		if (intArrayConfig.Count != 2)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CreateCharacter;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "初始化角色数量错误, 应该为2";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("count", intArrayConfig.Count);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return intArrayConfig;
	}

	// Token: 0x0600C2C7 RID: 49863 RVA: 0x003355CA File Offset: 0x003337CA
	public string GetInitName()
	{
		return ConfigCommonParamById.GetStringConfig("default_name_prefix");
	}
}
