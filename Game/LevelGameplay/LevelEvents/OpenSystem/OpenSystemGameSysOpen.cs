using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C58 RID: 27736
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemGameSysOpen : OpenSystemBase
	{
		// Token: 0x0604425A RID: 279130 RVA: 0x011B1C4F File Offset: 0x011AFE4F
		public OpenSystemGameSysOpen(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604425B RID: 279131 RVA: 0x011B1C58 File Offset: 0x011AFE58
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemGameSysOpen.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemGameSysOpen.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604425C RID: 279132 RVA: 0x011B1C9B File Offset: 0x011AFE9B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.FunctionOpenView);
		}
	}
}
