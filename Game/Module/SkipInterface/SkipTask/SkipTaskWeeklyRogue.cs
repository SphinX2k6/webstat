using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F3A RID: 20282
	public class SkipTaskWeeklyRogue : SkipTask
	{
		// Token: 0x060345D6 RID: 214486 RVA: 0x00D1AFF8 File Offset: 0x00D191F8
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WeeklyRogueActivityView))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsInView", Array.Empty<object>());
				base.Finish();
				return;
			}
			WeeklyRogueModel instance = ModelBase<WeeklyRogueModel>.Instance;
			WeeklyRogueData weeklyRogueData = (instance != null) ? instance.ActivityDataNew : null;
			if (weeklyRogueData == null)
			{
				base.Finish();
				return;
			}
			if (!weeklyRogueData.IsUnLock())
			{
				base.Finish();
				return;
			}
			int unFinishPreGuideQuestId = weeklyRogueData.GetUnFinishPreGuideQuestId();
			if (unFinishPreGuideQuestId > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				base.Finish();
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueActivityView, EWeeklyRogueOpenWay.UI, null);
			base.Finish();
		}
	}
}
