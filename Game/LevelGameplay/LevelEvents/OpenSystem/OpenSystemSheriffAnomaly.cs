using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C8A RID: 27786
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemSheriffAnomaly : OpenSystemBase
	{
		// Token: 0x060442EF RID: 279279 RVA: 0x011B30A3 File Offset: 0x011B12A3
		public OpenSystemSheriffAnomaly(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442F0 RID: 279280 RVA: 0x011B30AC File Offset: 0x011B12AC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemSheriffAnomaly.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemSheriffAnomaly.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442F1 RID: 279281 RVA: 0x011B30EF File Offset: 0x011B12EF
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.SheriffReportPop);
		}
	}
}
