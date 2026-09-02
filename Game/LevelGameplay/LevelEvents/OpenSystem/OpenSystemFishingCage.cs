using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C52 RID: 27730
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemFishingCage : OpenSystemBase
	{
		// Token: 0x06044248 RID: 279112 RVA: 0x011B1A47 File Offset: 0x011AFC47
		public OpenSystemFishingCage(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044249 RID: 279113 RVA: 0x011B1A50 File Offset: 0x011AFC50
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemFishingCage.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemFishingCage.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604424A RID: 279114 RVA: 0x011B1A93 File Offset: 0x011AFC93
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.DockyardCageView);
		}
	}
}
