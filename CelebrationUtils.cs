using System;
using System.Runtime.CompilerServices;

// Token: 0x0200127F RID: 4735
public class CelebrationUtils
{
	// Token: 0x06007EC2 RID: 32450 RVA: 0x00218976 File Offset: 0x00216B76
	[NullableContext(1)]
	public static string GetActivityLogo()
	{
		if (Singleton<LanguageSystem>.Instance.PackageLanguage == "zh-Hans")
		{
			return "/Game/Aki/UI/UIResources/UiActivity/Image/WelfareB/T_ActivityWelfareBIcon.T_ActivityWelfareBIcon";
		}
		return "/Game/Aki/UI/UIResources/UiActivity/Image/WelfareB/T_ActivityWelfareBIconE.T_ActivityWelfareBIconE";
	}
}
