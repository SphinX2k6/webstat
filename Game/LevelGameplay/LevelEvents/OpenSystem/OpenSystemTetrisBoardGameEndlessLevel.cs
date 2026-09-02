using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C96 RID: 27798
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemTetrisBoardGameEndlessLevel : OpenSystemBase
	{
		// Token: 0x06044314 RID: 279316 RVA: 0x011B34BB File Offset: 0x011B16BB
		public OpenSystemTetrisBoardGameEndlessLevel(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044315 RID: 279317 RVA: 0x011B34C4 File Offset: 0x011B16C4
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemTetrisBoardGameEndlessLevel.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemTetrisBoardGameEndlessLevel.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044316 RID: 279318 RVA: 0x011B3507 File Offset: 0x011B1707
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.TetrisPlayView);
		}
	}
}
