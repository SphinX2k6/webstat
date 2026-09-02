using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C9F RID: 27807
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemWeeklyRogueToken : OpenSystemBase
	{
		// Token: 0x06044333 RID: 279347 RVA: 0x011B399F File Offset: 0x011B1B9F
		public OpenSystemWeeklyRogueToken(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044334 RID: 279348 RVA: 0x011B39A8 File Offset: 0x011B1BA8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemWeeklyRogueToken.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemWeeklyRogueToken.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044335 RID: 279349 RVA: 0x011B39EC File Offset: 0x011B1BEC
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return null;
			}
			WeeklyRogueModel instance = ModelBase<WeeklyRogueModel>.Instance;
			RogueWeeklyOption rogueWeeklyOption = (instance != null) ? instance.GetOptionByBindId(inParams.BoardId) : null;
			return ControllerBase<WeeklyRogueController>.Instance.GetViewNameByType(rogueWeeklyOption.Type);
		}
	}
}
