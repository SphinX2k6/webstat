using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C4C RID: 27724
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemDrinksGamePlayView : OpenSystemBase
	{
		// Token: 0x06044236 RID: 279094 RVA: 0x011B17F0 File Offset: 0x011AF9F0
		public OpenSystemDrinksGamePlayView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044237 RID: 279095 RVA: 0x011B17FC File Offset: 0x011AF9FC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemDrinksGamePlayView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemDrinksGamePlayView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044238 RID: 279096 RVA: 0x011B1838 File Offset: 0x011AFA38
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return null;
		}
	}
}
