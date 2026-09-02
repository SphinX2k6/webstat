using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C72 RID: 27762
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemMotorcycleDiy : OpenSystemBase
	{
		// Token: 0x060442A7 RID: 279207 RVA: 0x011B2707 File Offset: 0x011B0907
		public OpenSystemMotorcycleDiy(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442A8 RID: 279208 RVA: 0x011B2710 File Offset: 0x011B0910
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemMotorcycleDiy.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemMotorcycleDiy.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442A9 RID: 279209 RVA: 0x011B274B File Offset: 0x011B094B
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.MotorcycleDiyRootView);
		}
	}
}
