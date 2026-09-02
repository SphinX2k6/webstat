using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C83 RID: 27779
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRogueResMain : OpenSystemBase
	{
		// Token: 0x060442DA RID: 279258 RVA: 0x011B2DC7 File Offset: 0x011B0FC7
		public OpenSystemRogueResMain(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442DB RID: 279259 RVA: 0x011B2DD0 File Offset: 0x011B0FD0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRogueResMain.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRogueResMain.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442DC RID: 279260 RVA: 0x011B2E0B File Offset: 0x011B100B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.RogueSeasonEntranceView);
		}
	}
}
