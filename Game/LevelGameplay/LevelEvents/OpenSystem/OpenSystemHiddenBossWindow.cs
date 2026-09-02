using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C5D RID: 27741
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemHiddenBossWindow : OpenSystemBase
	{
		// Token: 0x06044268 RID: 279144 RVA: 0x011B1DD6 File Offset: 0x011AFFD6
		public OpenSystemHiddenBossWindow(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044269 RID: 279145 RVA: 0x011B1DE0 File Offset: 0x011AFFE0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemHiddenBossWindow.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemHiddenBossWindow.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604426A RID: 279146 RVA: 0x011B1E23 File Offset: 0x011B0023
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.HiddenBossWindow);
		}
	}
}
