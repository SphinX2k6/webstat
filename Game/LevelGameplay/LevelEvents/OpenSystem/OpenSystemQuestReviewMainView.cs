using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C7B RID: 27771
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemQuestReviewMainView : OpenSystemBase
	{
		// Token: 0x060442C3 RID: 279235 RVA: 0x011B2AE7 File Offset: 0x011B0CE7
		public OpenSystemQuestReviewMainView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442C4 RID: 279236 RVA: 0x011B2AF0 File Offset: 0x011B0CF0
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.QuestReviewMainView);
		}

		// Token: 0x060442C5 RID: 279237 RVA: 0x011B2AFC File Offset: 0x011B0CFC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemQuestReviewMainView.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemQuestReviewMainView.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
