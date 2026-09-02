using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C9B RID: 27803
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemVersionPreheat : OpenSystemBase
	{
		// Token: 0x06044326 RID: 279334 RVA: 0x011B37A3 File Offset: 0x011B19A3
		public OpenSystemVersionPreheat(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044327 RID: 279335 RVA: 0x011B37AC File Offset: 0x011B19AC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemVersionPreheat.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemVersionPreheat.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044328 RID: 279336 RVA: 0x011B37EF File Offset: 0x011B19EF
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.VersionPreheatVoteView);
		}
	}
}
