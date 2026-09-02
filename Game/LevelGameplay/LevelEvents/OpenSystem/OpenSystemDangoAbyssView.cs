using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C48 RID: 27720
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemDangoAbyssView : OpenSystemBase
	{
		// Token: 0x0604422A RID: 279082 RVA: 0x011B159F File Offset: 0x011AF79F
		public OpenSystemDangoAbyssView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604422B RID: 279083 RVA: 0x011B15A8 File Offset: 0x011AF7A8
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.DangoAbyssEntranceView);
		}

		// Token: 0x0604422C RID: 279084 RVA: 0x011B15B4 File Offset: 0x011AF7B4
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemDangoAbyssView.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemDangoAbyssView.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}
	}
}
