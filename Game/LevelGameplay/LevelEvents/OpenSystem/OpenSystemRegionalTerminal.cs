using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C7D RID: 27773
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRegionalTerminal : OpenSystemBase
	{
		// Token: 0x060442C9 RID: 279241 RVA: 0x011B2B97 File Offset: 0x011B0D97
		public OpenSystemRegionalTerminal(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442CA RID: 279242 RVA: 0x011B2BA0 File Offset: 0x011B0DA0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRegionalTerminal.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRegionalTerminal.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442CB RID: 279243 RVA: 0x011B2BE4 File Offset: 0x011B0DE4
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return null;
		}
	}
}
