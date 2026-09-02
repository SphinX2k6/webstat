using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C68 RID: 27752
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemInstanceFailure : OpenSystemBase
	{
		// Token: 0x06044289 RID: 279177 RVA: 0x011B232A File Offset: 0x011B052A
		public OpenSystemInstanceFailure(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604428A RID: 279178 RVA: 0x011B2334 File Offset: 0x011B0534
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemInstanceFailure.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemInstanceFailure.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604428B RID: 279179 RVA: 0x011B236F File Offset: 0x011B056F
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.InstanceDungeonFailView);
		}
	}
}
