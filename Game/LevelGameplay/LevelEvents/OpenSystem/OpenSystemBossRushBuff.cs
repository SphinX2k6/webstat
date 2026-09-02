using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C3D RID: 27709
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemBossRushBuff : OpenSystemBase
	{
		// Token: 0x06044209 RID: 279049 RVA: 0x011B112B File Offset: 0x011AF32B
		public OpenSystemBossRushBuff(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604420A RID: 279050 RVA: 0x011B1134 File Offset: 0x011AF334
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemBossRushBuff.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemBossRushBuff.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604420B RID: 279051 RVA: 0x011B1177 File Offset: 0x011AF377
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.SoundAreaPlayTips);
		}
	}
}
