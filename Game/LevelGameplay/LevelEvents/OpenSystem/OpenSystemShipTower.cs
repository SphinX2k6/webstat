using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C8D RID: 27789
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemShipTower : OpenSystemBase
	{
		// Token: 0x060442F9 RID: 279289 RVA: 0x011B31C1 File Offset: 0x011B13C1
		public OpenSystemShipTower(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442FA RID: 279290 RVA: 0x011B31CC File Offset: 0x011B13CC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemShipTower.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemShipTower.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442FB RID: 279291 RVA: 0x011B320F File Offset: 0x011B140F
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.ShipTowerView);
		}
	}
}
