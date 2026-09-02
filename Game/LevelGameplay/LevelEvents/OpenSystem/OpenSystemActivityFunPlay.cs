using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C39 RID: 27705
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemActivityFunPlay : OpenSystemBase
	{
		// Token: 0x060441FD RID: 279037 RVA: 0x011B0F9F File Offset: 0x011AF19F
		public OpenSystemActivityFunPlay(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060441FE RID: 279038 RVA: 0x011B0FA8 File Offset: 0x011AF1A8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemActivityFunPlay.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemActivityFunPlay.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060441FF RID: 279039 RVA: 0x011B0FE3 File Offset: 0x011AF1E3
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.ActivityFunPlayView);
		}
	}
}
