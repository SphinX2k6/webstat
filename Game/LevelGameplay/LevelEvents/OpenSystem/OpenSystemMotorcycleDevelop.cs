using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C71 RID: 27761
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemMotorcycleDevelop : OpenSystemBase
	{
		// Token: 0x060442A4 RID: 279204 RVA: 0x011B26B4 File Offset: 0x011B08B4
		public OpenSystemMotorcycleDevelop(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442A5 RID: 279205 RVA: 0x011B26C0 File Offset: 0x011B08C0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemMotorcycleDevelop.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemMotorcycleDevelop.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442A6 RID: 279206 RVA: 0x011B26FB File Offset: 0x011B08FB
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.MotorcycleRootView);
		}
	}
}
