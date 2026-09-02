using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F43 RID: 20291
	public class SkipToDailyActivityWeeklyTab : SkipTask
	{
		// Token: 0x060345E8 RID: 214504 RVA: 0x00D1B6A8 File Offset: 0x00D198A8
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.WeeklyChallenge) || ModelBase<WeeklyChallengeModel>.Instance.WeeklyConfigId == 0)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
				return;
			}
			base.Finish();
			ControllerBase<AdventureGuideController>.Instance.OpenGuideView(new EUiTabViewName?(EUiTabViewName.DailyActivityTabView), new int?(2), null);
		}
	}
}
