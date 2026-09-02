using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C4E RID: 27726
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemDropCatchInMainStory : OpenSystemBase
	{
		// Token: 0x0604423C RID: 279100 RVA: 0x011B18AA File Offset: 0x011AFAAA
		public OpenSystemDropCatchInMainStory(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604423D RID: 279101 RVA: 0x011B18B4 File Offset: 0x011AFAB4
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemDropCatchInMainStory.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemDropCatchInMainStory.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604423E RID: 279102 RVA: 0x011B18F8 File Offset: 0x011AFAF8
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return null;
		}
	}
}
