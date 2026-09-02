using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C94 RID: 27796
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemSynthetic : OpenSystemBase
	{
		// Token: 0x0604430E RID: 279310 RVA: 0x011B341B File Offset: 0x011B161B
		public OpenSystemSynthetic(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604430F RID: 279311 RVA: 0x011B3424 File Offset: 0x011B1624
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemSynthetic.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemSynthetic.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044310 RID: 279312 RVA: 0x011B345F File Offset: 0x011B165F
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.ComposeCarryOnView);
		}
	}
}
