using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C84 RID: 27780
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRoguelikeActivity : OpenSystemBase
	{
		// Token: 0x060442DD RID: 279261 RVA: 0x011B2E17 File Offset: 0x011B1017
		public OpenSystemRoguelikeActivity(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442DE RID: 279262 RVA: 0x011B2E20 File Offset: 0x011B1020
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRoguelikeActivity.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRoguelikeActivity.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442DF RID: 279263 RVA: 0x011B2E63 File Offset: 0x011B1063
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return new EUiViewName?(EUiViewName.RoguelikeActivityView);
			}
			if (inParams.BoardId == 100)
			{
				return new EUiViewName?(EUiViewName.WeeklyRogueActivityView);
			}
			return new EUiViewName?(EUiViewName.RoguelikeActivityView);
		}
	}
}
