using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C6A RID: 27754
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemLifePointDraw : OpenSystemBase
	{
		// Token: 0x0604428F RID: 279183 RVA: 0x011B23DE File Offset: 0x011B05DE
		public OpenSystemLifePointDraw(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044290 RID: 279184 RVA: 0x011B23E8 File Offset: 0x011B05E8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemLifePointDraw.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemLifePointDraw.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044291 RID: 279185 RVA: 0x011B2423 File Offset: 0x011B0623
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.LifePointDrawEntranceView);
		}
	}
}
