using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C5E RID: 27742
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemHonamiChooseLevelView : OpenSystemBase
	{
		// Token: 0x0604426B RID: 279147 RVA: 0x011B1E2F File Offset: 0x011B002F
		public OpenSystemHonamiChooseLevelView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604426C RID: 279148 RVA: 0x011B1E38 File Offset: 0x011B0038
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemHonamiChooseLevelView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemHonamiChooseLevelView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604426D RID: 279149 RVA: 0x011B1E73 File Offset: 0x011B0073
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.HonamiStoryLevelInfoView);
		}
	}
}
