using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C75 RID: 27765
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemPhantomArenaChallengeView : OpenSystemBase
	{
		// Token: 0x060442B0 RID: 279216 RVA: 0x011B27FF File Offset: 0x011B09FF
		public OpenSystemPhantomArenaChallengeView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442B1 RID: 279217 RVA: 0x011B2808 File Offset: 0x011B0A08
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return null;
			}
			int boardId = inParams.BoardId;
			if (ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallengeConfig(boardId).CardGroupId > 0)
			{
				return null;
			}
			return new EUiViewName?(EUiViewName.PhantomArenaMainView);
		}

		// Token: 0x060442B2 RID: 279218 RVA: 0x011B2854 File Offset: 0x011B0A54
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemPhantomArenaChallengeView.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemPhantomArenaChallengeView.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
