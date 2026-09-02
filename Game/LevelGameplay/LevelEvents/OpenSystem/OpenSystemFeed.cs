using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C51 RID: 27729
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemFeed : OpenSystemBase
	{
		// Token: 0x06044245 RID: 279109 RVA: 0x011B19DE File Offset: 0x011AFBDE
		public OpenSystemFeed(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044246 RID: 279110 RVA: 0x011B19E8 File Offset: 0x011AFBE8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemFeed.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>4__this = this;
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemFeed.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044247 RID: 279111 RVA: 0x011B1A3B File Offset: 0x011AFC3B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.ItemDeliverView);
		}
	}
}
