using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C54 RID: 27732
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemFixCook : OpenSystemBase
	{
		// Token: 0x0604424E RID: 279118 RVA: 0x011B1AF7 File Offset: 0x011AFCF7
		public OpenSystemFixCook(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604424F RID: 279119 RVA: 0x011B1B00 File Offset: 0x011AFD00
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemFixCook.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemFixCook.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044250 RID: 279120 RVA: 0x011B1B4B File Offset: 0x011AFD4B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.CookPopFixView);
		}
	}
}
