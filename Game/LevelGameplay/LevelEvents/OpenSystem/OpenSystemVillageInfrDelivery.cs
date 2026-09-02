using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C9E RID: 27806
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemVillageInfrDelivery : OpenSystemBase
	{
		// Token: 0x06044330 RID: 279344 RVA: 0x011B3946 File Offset: 0x011B1B46
		public OpenSystemVillageInfrDelivery(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044331 RID: 279345 RVA: 0x011B3950 File Offset: 0x011B1B50
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemVillageInfrDelivery.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemVillageInfrDelivery.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044332 RID: 279346 RVA: 0x011B3993 File Offset: 0x011B1B93
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.VillageInfrWorldBuildView);
		}
	}
}
