using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C98 RID: 27800
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemTrapDefenseMapChange : OpenSystemBase
	{
		// Token: 0x0604431D RID: 279325 RVA: 0x011B36A2 File Offset: 0x011B18A2
		public OpenSystemTrapDefenseMapChange(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604431E RID: 279326 RVA: 0x011B36AC File Offset: 0x011B18AC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemTrapDefenseMapChange.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemTrapDefenseMapChange.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604431F RID: 279327 RVA: 0x011B36E7 File Offset: 0x011B18E7
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.TrapDefenseEventTerrainChangeTips);
		}
	}
}
