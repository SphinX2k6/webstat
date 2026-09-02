using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C99 RID: 27801
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemTrialRoleDescription : OpenSystemBase
	{
		// Token: 0x06044320 RID: 279328 RVA: 0x011B36F3 File Offset: 0x011B18F3
		public OpenSystemTrialRoleDescription(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044321 RID: 279329 RVA: 0x011B36FC File Offset: 0x011B18FC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemTrialRoleDescription.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemTrialRoleDescription.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044322 RID: 279330 RVA: 0x011B373F File Offset: 0x011B193F
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.JoinTeamView);
		}
	}
}
