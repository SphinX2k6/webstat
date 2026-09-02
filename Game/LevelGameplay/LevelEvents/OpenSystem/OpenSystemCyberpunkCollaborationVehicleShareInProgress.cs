using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C47 RID: 27719
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemCyberpunkCollaborationVehicleShareInProgress : OpenSystemBase
	{
		// Token: 0x06044227 RID: 279079 RVA: 0x011B154F File Offset: 0x011AF74F
		public OpenSystemCyberpunkCollaborationVehicleShareInProgress(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044228 RID: 279080 RVA: 0x011B1558 File Offset: 0x011AF758
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemCyberpunkCollaborationVehicleShareInProgress.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemCyberpunkCollaborationVehicleShareInProgress.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044229 RID: 279081 RVA: 0x011B1593 File Offset: 0x011AF793
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.MoonTogetherMainView);
		}
	}
}
