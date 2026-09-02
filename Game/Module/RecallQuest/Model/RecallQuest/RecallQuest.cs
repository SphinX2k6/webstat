using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.RecallQuest.Model.RecallQuest
{
	// Token: 0x02005299 RID: 21145
	public class RecallQuest : global::Quest
	{
		// Token: 0x060360ED RID: 221421 RVA: 0x00D9BE9C File Offset: 0x00D9A09C
		[NullableContext(1)]
		public RecallQuest(EQuest questType, IQuest questConfig) : base(questType, questConfig)
		{
			IQuestRecallConfig recallConfig = questConfig.RecallConfig;
			IQuest questConfig2 = ModelBase<QuestNewModel>.Instance.GetQuestConfig((recallConfig != null) ? recallConfig.RecallId : 0);
			this.SourceQuest = questConfig2;
		}

		// Token: 0x060360EE RID: 221422 RVA: 0x00D9BED6 File Offset: 0x00D9A0D6
		protected override bool CanShowInRecall()
		{
			IQuest sourceQuest = this.SourceQuest;
			return sourceQuest == null || sourceQuest.Type != EQuest.Hidden;
		}

		// Token: 0x0401F10F RID: 127247
		[Nullable(2)]
		public readonly IQuest SourceQuest;
	}
}
