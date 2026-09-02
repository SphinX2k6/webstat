using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C66 RID: 27750
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemInfrBuildSuccessView : OpenSystemBase
	{
		// Token: 0x06044283 RID: 279171 RVA: 0x011B21A1 File Offset: 0x011B03A1
		public OpenSystemInfrBuildSuccessView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044284 RID: 279172 RVA: 0x011B21AC File Offset: 0x011B03AC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemInfrBuildSuccessView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemInfrBuildSuccessView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044285 RID: 279173 RVA: 0x011B21EF File Offset: 0x011B03EF
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return new EUiViewName?(EUiViewName.InfrastructureMainView);
			}
			return new EUiViewName?((inParams.InfrActivityBuildStage.Type == EInfrActivityBuildStageType.Infrastructure) ? EUiViewName.InfrastructureMainView : EUiViewName.InfrRoadNetworkMainView);
		}
	}
}
