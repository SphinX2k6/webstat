using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C89 RID: 27785
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemScratchTicketMain : OpenSystemBase
	{
		// Token: 0x060442EC RID: 279276 RVA: 0x011B3053 File Offset: 0x011B1253
		public OpenSystemScratchTicketMain(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442ED RID: 279277 RVA: 0x011B305C File Offset: 0x011B125C
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemScratchTicketMain.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemScratchTicketMain.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442EE RID: 279278 RVA: 0x011B3097 File Offset: 0x011B1297
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.ScratchTicketMainView);
		}
	}
}
