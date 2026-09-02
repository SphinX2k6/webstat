using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C46 RID: 27718
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemCyberpunkCollaborationVehicleShare : OpenSystemBase
	{
		// Token: 0x06044224 RID: 279076 RVA: 0x011B14F5 File Offset: 0x011AF6F5
		public OpenSystemCyberpunkCollaborationVehicleShare(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044225 RID: 279077 RVA: 0x011B1500 File Offset: 0x011AF700
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemCyberpunkCollaborationVehicleShare.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemCyberpunkCollaborationVehicleShare.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044226 RID: 279078 RVA: 0x011B1543 File Offset: 0x011AF743
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.MoonTogetherInviteView);
		}
	}
}
