using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C79 RID: 27769
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemQuestMultiLineTipsView : OpenSystemBase
	{
		// Token: 0x060442BD RID: 279229 RVA: 0x011B2A24 File Offset: 0x011B0C24
		public OpenSystemQuestMultiLineTipsView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442BE RID: 279230 RVA: 0x011B2A30 File Offset: 0x011B0C30
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemQuestMultiLineTipsView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemQuestMultiLineTipsView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442BF RID: 279231 RVA: 0x011B2A7B File Offset: 0x011B0C7B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.QuestMultiLineTipsView);
		}
	}
}
