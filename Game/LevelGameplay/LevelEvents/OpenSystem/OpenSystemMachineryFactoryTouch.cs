using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C6D RID: 27757
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemMachineryFactoryTouch : OpenSystemBase
	{
		// Token: 0x06044298 RID: 279192 RVA: 0x011B24EF File Offset: 0x011B06EF
		public OpenSystemMachineryFactoryTouch(LevelEventOpenSystem levelEventOpenSystem) : base(levelEventOpenSystem)
		{
		}

		// Token: 0x06044299 RID: 279193 RVA: 0x011B24F8 File Offset: 0x011B06F8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemMachineryFactoryTouch.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemMachineryFactoryTouch.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x0604429A RID: 279194 RVA: 0x011B253B File Offset: 0x011B073B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.MachineryFactoryTouchMoveView);
		}
	}
}
