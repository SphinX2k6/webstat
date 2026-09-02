using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C3C RID: 27708
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class OpenSystemBase
	{
		// Token: 0x06044206 RID: 279046 RVA: 0x011B10DF File Offset: 0x011AF2DF
		public OpenSystemBase(LevelEventOpenSystem eventBase)
		{
			this.EventBase = eventBase;
		}

		// Token: 0x06044207 RID: 279047
		[NullableContext(2)]
		public abstract EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null);

		// Token: 0x06044208 RID: 279048 RVA: 0x011B10F0 File Offset: 0x011AF2F0
		[return: Nullable(0)]
		public virtual UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemBase.<ExecuteOpenView>d__3 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemBase.<ExecuteOpenView>d__3>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x040260A7 RID: 155815
		protected LevelEventOpenSystem EventBase;
	}
}
