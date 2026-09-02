using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C69 RID: 27753
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemInteractiveComic : OpenSystemBase
	{
		// Token: 0x0604428C RID: 279180 RVA: 0x011B237B File Offset: 0x011B057B
		public OpenSystemInteractiveComic(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604428D RID: 279181 RVA: 0x011B2384 File Offset: 0x011B0584
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemInteractiveComic.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemInteractiveComic.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604428E RID: 279182 RVA: 0x011B23C8 File Offset: 0x011B05C8
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return null;
		}
	}
}
