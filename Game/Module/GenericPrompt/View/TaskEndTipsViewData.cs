using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CBF RID: 23743
	public class TaskEndTipsViewData : UiViewData
	{
		// Token: 0x04021AB6 RID: 137910
		public EQuestCommonTipType QuestType;

		// Token: 0x04021AB7 RID: 137911
		[Nullable(1)]
		public string TipTextKey = "";

		// Token: 0x04021AB8 RID: 137912
		public int? Duration;
	}
}
