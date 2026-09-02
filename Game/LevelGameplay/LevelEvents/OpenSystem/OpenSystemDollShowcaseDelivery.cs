using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C4A RID: 27722
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemDollShowcaseDelivery : OpenSystemBase
	{
		// Token: 0x06044230 RID: 279088 RVA: 0x011B16D0 File Offset: 0x011AF8D0
		public OpenSystemDollShowcaseDelivery(LevelEventOpenSystem levelEventOpenSystem) : base(levelEventOpenSystem)
		{
		}

		// Token: 0x06044231 RID: 279089 RVA: 0x011B16DC File Offset: 0x011AF8DC
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemDollShowcaseDelivery.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemDollShowcaseDelivery.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044232 RID: 279090 RVA: 0x011B171F File Offset: 0x011AF91F
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.DollGrabDeliveryView);
		}
	}
}
