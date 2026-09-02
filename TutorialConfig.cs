using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002C21 RID: 11297
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class TutorialConfig : ConfigBase<TutorialConfig>
{
	// Token: 0x060169C9 RID: 92617 RVA: 0x0064656C File Offset: 0x0064476C
	public GuideTutorial? GetTutorial(int tutorialId)
	{
		return ConfigGuideTutorialById.GetConfig(tutorialId, true);
	}

	// Token: 0x060169CA RID: 92618 RVA: 0x00646578 File Offset: 0x00644778
	public bool HasUnlockReward(int tutorialId)
	{
		GuideTutorial? tutorial = this.GetTutorial(tutorialId);
		return tutorial != null && !tutorial.GetValueOrDefault().DisableDropReward;
	}
}
