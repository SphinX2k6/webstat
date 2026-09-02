using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C80 RID: 27776
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRogueEventSelect : OpenSystemBase
	{
		// Token: 0x060442D1 RID: 279249 RVA: 0x011B2C9C File Offset: 0x011B0E9C
		public OpenSystemRogueEventSelect(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442D2 RID: 279250 RVA: 0x011B2CA8 File Offset: 0x011B0EA8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRogueEventSelect.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRogueEventSelect.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442D3 RID: 279251 RVA: 0x011B2CE3 File Offset: 0x011B0EE3
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.RoguelikeRandomEventView);
		}
	}
}
