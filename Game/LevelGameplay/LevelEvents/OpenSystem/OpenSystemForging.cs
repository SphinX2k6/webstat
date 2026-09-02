using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C55 RID: 27733
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemForging : OpenSystemBase
	{
		// Token: 0x06044251 RID: 279121 RVA: 0x011B1B57 File Offset: 0x011AFD57
		public OpenSystemForging(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044252 RID: 279122 RVA: 0x011B1B60 File Offset: 0x011AFD60
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemForging.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemForging.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044253 RID: 279123 RVA: 0x011B1B9B File Offset: 0x011AFD9B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.ForgingRootView);
		}
	}
}
