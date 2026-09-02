using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005428 RID: 21544
	public class FlowActionOpenQuestChapterView : FlowActionBase
	{
		// Token: 0x06036F60 RID: 225120 RVA: 0x00DF36EC File Offset: 0x00DF18EC
		protected override void OnExecute()
		{
			PromptQuestChapterUI promptQuestChapterUI = this.ActionInfo.Params as PromptQuestChapterUI;
			if (promptQuestChapterUI == null)
			{
				return;
			}
			GeneralContext context = this.Context.Context;
			int? num = null;
			if (promptQuestChapterUI.QuestId != null)
			{
				num = promptQuestChapterUI.QuestId;
			}
			else
			{
				EGeneralContextType? type = context.Type;
				if (type != null)
				{
					EGeneralContextType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != EGeneralContextType.Quest)
					{
						if (valueOrDefault == EGeneralContextType.GeneralLogicTree)
						{
							GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
							num = ((generalLogicTreeContext != null) ? new int?(generalLogicTreeContext.TreeConfigId) : null);
						}
					}
					else
					{
						QuestContext questContext = context as QuestContext;
						num = ((questContext != null) ? new int?(questContext.QuestId) : null);
					}
				}
			}
			if (num == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "非任务系统不可使用章节提示事件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<GeneralLogicTreeUtil>.Instance.OpenQuestChapterView(promptQuestChapterUI, num.Value, new Action(this.OnCloseView));
		}

		// Token: 0x06036F61 RID: 225121 RVA: 0x00DF37E8 File Offset: 0x00DF19E8
		private void OnCloseView()
		{
			base.FinishExecute(true, true);
		}
	}
}
