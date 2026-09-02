using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C8E RID: 27790
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemShopView : OpenSystemBase
	{
		// Token: 0x060442FC RID: 279292 RVA: 0x011B321B File Offset: 0x011B141B
		public OpenSystemShopView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442FD RID: 279293 RVA: 0x011B3224 File Offset: 0x011B1424
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemShopView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemShopView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442FE RID: 279294 RVA: 0x011B3267 File Offset: 0x011B1467
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.ShopView);
		}
	}
}
