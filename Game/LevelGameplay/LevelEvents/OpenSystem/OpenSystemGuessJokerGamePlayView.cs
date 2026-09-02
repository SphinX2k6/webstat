using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C5B RID: 27739
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemGuessJokerGamePlayView : OpenSystemBase
	{
		// Token: 0x06044262 RID: 279138 RVA: 0x011B1D17 File Offset: 0x011AFF17
		public OpenSystemGuessJokerGamePlayView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044263 RID: 279139 RVA: 0x011B1D20 File Offset: 0x011AFF20
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemGuessJokerGamePlayView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemGuessJokerGamePlayView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044264 RID: 279140 RVA: 0x011B1D64 File Offset: 0x011AFF64
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return null;
		}
	}
}
