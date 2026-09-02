using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C9D RID: 27805
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemVillageInfrBuildSuccessView : OpenSystemBase
	{
		// Token: 0x0604432D RID: 279341 RVA: 0x011B38C9 File Offset: 0x011B1AC9
		public OpenSystemVillageInfrBuildSuccessView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604432E RID: 279342 RVA: 0x011B38D4 File Offset: 0x011B1AD4
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemVillageInfrBuildSuccessView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemVillageInfrBuildSuccessView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604432F RID: 279343 RVA: 0x011B3917 File Offset: 0x011B1B17
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return new EUiViewName?(EUiViewName.VillageInfrMainView);
			}
			return new EUiViewName?((inParams.VillageInfrBuildStage.Type == EVillageInfrBuildType.Tree) ? EUiViewName.VillageInfrMainView : EUiViewName.VillageInfrBuildFinishTipView);
		}
	}
}
