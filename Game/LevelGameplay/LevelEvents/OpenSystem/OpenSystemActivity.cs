using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C38 RID: 27704
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemActivity : OpenSystemBase
	{
		// Token: 0x060441FA RID: 279034 RVA: 0x011B0F45 File Offset: 0x011AF145
		public OpenSystemActivity(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060441FB RID: 279035 RVA: 0x011B0F50 File Offset: 0x011AF150
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemActivity.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemActivity.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060441FC RID: 279036 RVA: 0x011B0F93 File Offset: 0x011AF193
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.CommonActivityView);
		}
	}
}
