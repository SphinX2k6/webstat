using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C7A RID: 27770
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemQuestMultiLineView : OpenSystemBase
	{
		// Token: 0x060442C0 RID: 279232 RVA: 0x011B2A87 File Offset: 0x011B0C87
		public OpenSystemQuestMultiLineView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442C1 RID: 279233 RVA: 0x011B2A90 File Offset: 0x011B0C90
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemQuestMultiLineView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemQuestMultiLineView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442C2 RID: 279234 RVA: 0x011B2ADB File Offset: 0x011B0CDB
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.QuestMultiLineView);
		}
	}
}
