using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200186E RID: 6254
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ComboTeachingConfig : ConfigBase<ComboTeachingConfig>
{
	// Token: 0x0600B331 RID: 45873 RVA: 0x002FD781 File Offset: 0x002FB981
	public ComboTeaching? GetComboTeachingConfig(int comboId)
	{
		return ConfigComboTeachingById.GetConfig(comboId, true);
	}

	// Token: 0x0600B332 RID: 45874 RVA: 0x002FD78A File Offset: 0x002FB98A
	public ComboTeachingCondition? GetComboTeachingConditionConfig(int comboConditionId)
	{
		return ConfigComboTeachingConditionById.GetConfig(comboConditionId, true);
	}
}
