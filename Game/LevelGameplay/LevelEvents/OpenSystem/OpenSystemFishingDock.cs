using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C53 RID: 27731
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemFishingDock : OpenSystemBase
	{
		// Token: 0x0604424B RID: 279115 RVA: 0x011B1A9F File Offset: 0x011AFC9F
		public OpenSystemFishingDock(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604424C RID: 279116 RVA: 0x011B1AA8 File Offset: 0x011AFCA8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemFishingDock.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemFishingDock.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604424D RID: 279117 RVA: 0x011B1AEB File Offset: 0x011AFCEB
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.FishingDockView);
		}
	}
}
