using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C8B RID: 27787
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemSheriffCriminalIdentityConfirmed : OpenSystemBase
	{
		// Token: 0x060442F2 RID: 279282 RVA: 0x011B30FB File Offset: 0x011B12FB
		public OpenSystemSheriffCriminalIdentityConfirmed(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442F3 RID: 279283 RVA: 0x011B3104 File Offset: 0x011B1304
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemSheriffCriminalIdentityConfirmed.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemSheriffCriminalIdentityConfirmed.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442F4 RID: 279284 RVA: 0x011B3147 File Offset: 0x011B1347
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.SheriffCriminalIdentityConfirmedView);
		}
	}
}
