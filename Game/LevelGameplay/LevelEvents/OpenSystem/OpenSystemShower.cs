using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C8F RID: 27791
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemShower : OpenSystemBase
	{
		// Token: 0x060442FF RID: 279295 RVA: 0x011B3273 File Offset: 0x011B1473
		public OpenSystemShower(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044300 RID: 279296 RVA: 0x011B327C File Offset: 0x011B147C
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.ShowerInviteView);
		}

		// Token: 0x06044301 RID: 279297 RVA: 0x011B3288 File Offset: 0x011B1488
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemShower.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemShower.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
