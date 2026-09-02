using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C6F RID: 27759
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemMoraleAreaSum : OpenSystemBase
	{
		// Token: 0x0604429E RID: 279198 RVA: 0x011B2642 File Offset: 0x011B0842
		public OpenSystemMoraleAreaSum(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604429F RID: 279199 RVA: 0x011B264C File Offset: 0x011B084C
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemMoraleAreaSum.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemMoraleAreaSum.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442A0 RID: 279200 RVA: 0x011B268F File Offset: 0x011B088F
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.MoraleAreaSumView);
		}
	}
}
