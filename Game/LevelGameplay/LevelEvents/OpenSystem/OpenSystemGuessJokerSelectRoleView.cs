using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C5C RID: 27740
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemGuessJokerSelectRoleView : OpenSystemBase
	{
		// Token: 0x06044265 RID: 279141 RVA: 0x011B1D7A File Offset: 0x011AFF7A
		public OpenSystemGuessJokerSelectRoleView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044266 RID: 279142 RVA: 0x011B1D84 File Offset: 0x011AFF84
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemGuessJokerSelectRoleView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemGuessJokerSelectRoleView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044267 RID: 279143 RVA: 0x011B1DC0 File Offset: 0x011AFFC0
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return null;
		}
	}
}
