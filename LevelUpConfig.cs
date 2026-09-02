using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020020C4 RID: 8388
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class LevelUpConfig : ConfigBase<LevelUpConfig>
{
	// Token: 0x06010068 RID: 65640 RVA: 0x00466F94 File Offset: 0x00465194
	public int? GetExpBarAnimationLength()
	{
		return ConfigCommonParamById.GetIntConfig("LevelUpAnimationLength");
	}

	// Token: 0x06010069 RID: 65641 RVA: 0x00466FA0 File Offset: 0x004651A0
	public int? GetLevelUpViewCloseDelay()
	{
		return ConfigCommonParamById.GetIntConfig("LevelUpViewCloseDelay");
	}

	// Token: 0x0601006A RID: 65642 RVA: 0x00466FAC File Offset: 0x004651AC
	public int? GetMaxExpCloseDelay()
	{
		return ConfigCommonParamById.GetIntConfig("MaxExpCloseDelay");
	}

	// Token: 0x0601006B RID: 65643 RVA: 0x00466FB8 File Offset: 0x004651B8
	public int? GetHiddenLevelUpLevel()
	{
		return ConfigCommonParamById.GetIntConfig("HiddenLevelUpView");
	}
}
