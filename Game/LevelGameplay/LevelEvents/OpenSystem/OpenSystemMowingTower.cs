using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C74 RID: 27764
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemMowingTower : OpenSystemBase
	{
		// Token: 0x060442AD RID: 279213 RVA: 0x011B27A7 File Offset: 0x011B09A7
		public OpenSystemMowingTower(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442AE RID: 279214 RVA: 0x011B27B0 File Offset: 0x011B09B0
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemMowingTower.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemMowingTower.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442AF RID: 279215 RVA: 0x011B27F3 File Offset: 0x011B09F3
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.MowingTowerMainView);
		}
	}
}
