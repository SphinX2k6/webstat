using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C8C RID: 27788
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemSheriffMainStoryError : OpenSystemBase
	{
		// Token: 0x060442F5 RID: 279285 RVA: 0x011B3153 File Offset: 0x011B1353
		public OpenSystemSheriffMainStoryError(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442F6 RID: 279286 RVA: 0x011B315C File Offset: 0x011B135C
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemSheriffMainStoryError.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>4__this = this;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemSheriffMainStoryError.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442F7 RID: 279287 RVA: 0x011B319F File Offset: 0x011B139F
		private void OnWorldMapExtraUiOpen(EWorldMapExtraUiPanelName panelName)
		{
			if (panelName == EWorldMapExtraUiPanelName.SheriffMapPanel)
			{
				CustomPromise openMapPromise = this.OpenMapPromise;
				if (openMapPromise == null)
				{
					return;
				}
				openMapPromise.SetResult();
			}
		}

		// Token: 0x060442F8 RID: 279288 RVA: 0x011B31B5 File Offset: 0x011B13B5
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.SheriffErrorView);
		}

		// Token: 0x040260AB RID: 155819
		[Nullable(2)]
		private CustomPromise OpenMapPromise;
	}
}
