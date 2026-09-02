using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C5A RID: 27738
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemGreatSwordSelectView : OpenSystemBase
	{
		// Token: 0x0604425F RID: 279135 RVA: 0x011B1CBC File Offset: 0x011AFEBC
		public OpenSystemGreatSwordSelectView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044260 RID: 279136 RVA: 0x011B1CC5 File Offset: 0x011AFEC5
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.GreatSwordLevelSelectView);
		}

		// Token: 0x06044261 RID: 279137 RVA: 0x011B1CD4 File Offset: 0x011AFED4
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemGreatSwordSelectView.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemGreatSwordSelectView.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
