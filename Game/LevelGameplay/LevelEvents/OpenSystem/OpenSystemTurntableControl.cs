using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C9A RID: 27802
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemTurntableControl : OpenSystemBase
	{
		// Token: 0x06044323 RID: 279331 RVA: 0x011B374B File Offset: 0x011B194B
		public OpenSystemTurntableControl(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044324 RID: 279332 RVA: 0x011B3754 File Offset: 0x011B1954
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemTurntableControl.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemTurntableControl.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044325 RID: 279333 RVA: 0x011B3797 File Offset: 0x011B1997
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.TurntableControlView);
		}
	}
}
