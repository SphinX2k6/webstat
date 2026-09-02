using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C73 RID: 27763
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemMowBuffDistribute : OpenSystemBase
	{
		// Token: 0x060442AA RID: 279210 RVA: 0x011B2757 File Offset: 0x011B0957
		public OpenSystemMowBuffDistribute(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442AB RID: 279211 RVA: 0x011B2760 File Offset: 0x011B0960
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemMowBuffDistribute.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemMowBuffDistribute.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442AC RID: 279212 RVA: 0x011B279B File Offset: 0x011B099B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.BossRushBuffInGameView);
		}
	}
}
