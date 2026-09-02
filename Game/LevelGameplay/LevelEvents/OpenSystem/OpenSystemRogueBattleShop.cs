using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C82 RID: 27778
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRogueBattleShop : OpenSystemBase
	{
		// Token: 0x060442D7 RID: 279255 RVA: 0x011B2D77 File Offset: 0x011B0F77
		public OpenSystemRogueBattleShop(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442D8 RID: 279256 RVA: 0x011B2D80 File Offset: 0x011B0F80
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRogueBattleShop.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRogueBattleShop.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442D9 RID: 279257 RVA: 0x011B2DBB File Offset: 0x011B0FBB
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.RogueBattleShopView);
		}
	}
}
