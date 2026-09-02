using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C85 RID: 27781
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRogueSettlement : OpenSystemBase
	{
		// Token: 0x060442E0 RID: 279264 RVA: 0x011B2E92 File Offset: 0x011B1092
		public OpenSystemRogueSettlement(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442E1 RID: 279265 RVA: 0x011B2E9C File Offset: 0x011B109C
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRogueSettlement.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRogueSettlement.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442E2 RID: 279266 RVA: 0x011B2ED8 File Offset: 0x011B10D8
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return null;
		}
	}
}
