using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C56 RID: 27734
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemFragmentMemory : OpenSystemBase
	{
		// Token: 0x06044254 RID: 279124 RVA: 0x011B1BA7 File Offset: 0x011AFDA7
		public OpenSystemFragmentMemory(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044255 RID: 279125 RVA: 0x011B1BB0 File Offset: 0x011AFDB0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemFragmentMemory.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemFragmentMemory.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044256 RID: 279126 RVA: 0x011B1BF3 File Offset: 0x011AFDF3
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.MemoryDetailView);
		}
	}
}
