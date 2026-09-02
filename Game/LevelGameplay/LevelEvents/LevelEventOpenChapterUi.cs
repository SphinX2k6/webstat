using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BB9 RID: 27577
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventOpenChapterUi : LevelEventBase
	{
		// Token: 0x06044015 RID: 278549 RVA: 0x011A0B23 File Offset: 0x0119ED23
		public LevelEventOpenChapterUi(int id) : base(id)
		{
		}

		// Token: 0x06044016 RID: 278550 RVA: 0x011A0B2C File Offset: 0x0119ED2C
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06044017 RID: 278551 RVA: 0x011A0B38 File Offset: 0x0119ED38
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PromptQuestChapterUI promptQuestChapterUI = inParams as PromptQuestChapterUI;
			if (promptQuestChapterUI == null)
			{
				return;
			}
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
							num = new int?((context as GeneralLogicTreeContext).TreeConfigId);
						}
					}
					else
					{
						num = new int?((context as QuestContext).QuestId);
					}
				}
			}
			if (num == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "非任务系统不可使用章节提示事件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<GeneralLogicTreeUtil>.Instance.OpenQuestChapterView(promptQuestChapterUI, num.Value, null);
		}
	}
}
