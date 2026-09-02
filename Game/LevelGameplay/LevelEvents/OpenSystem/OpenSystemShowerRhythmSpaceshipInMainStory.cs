using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C90 RID: 27792
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemShowerRhythmSpaceshipInMainStory : OpenSystemBase
	{
		// Token: 0x06044302 RID: 279298 RVA: 0x011B32CB File Offset: 0x011B14CB
		public OpenSystemShowerRhythmSpaceshipInMainStory(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044303 RID: 279299 RVA: 0x011B32D4 File Offset: 0x011B14D4
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams, GeneralContext context)
		{
			return new EUiViewName?(EUiViewName.RhythmShipChoseLevelView);
		}

		// Token: 0x06044304 RID: 279300 RVA: 0x011B32E0 File Offset: 0x011B14E0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemShowerRhythmSpaceshipInMainStory.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemShowerRhythmSpaceshipInMainStory.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
