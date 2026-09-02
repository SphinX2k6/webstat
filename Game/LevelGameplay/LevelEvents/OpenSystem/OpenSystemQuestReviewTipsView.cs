using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C7C RID: 27772
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemQuestReviewTipsView : OpenSystemBase
	{
		// Token: 0x060442C6 RID: 279238 RVA: 0x011B2B3F File Offset: 0x011B0D3F
		public OpenSystemQuestReviewTipsView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442C7 RID: 279239 RVA: 0x011B2B48 File Offset: 0x011B0D48
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.QuestReviewTipsView);
		}

		// Token: 0x060442C8 RID: 279240 RVA: 0x011B2B54 File Offset: 0x011B0D54
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemQuestReviewTipsView.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemQuestReviewTipsView.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
