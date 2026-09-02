using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C81 RID: 27777
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRogueBattleAbilitySelect : OpenSystemBase
	{
		// Token: 0x060442D4 RID: 279252 RVA: 0x011B2CEF File Offset: 0x011B0EEF
		public OpenSystemRogueBattleAbilitySelect(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442D5 RID: 279253 RVA: 0x011B2CF8 File Offset: 0x011B0EF8
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRogueBattleAbilitySelect.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRogueBattleAbilitySelect.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442D6 RID: 279254 RVA: 0x011B2D3C File Offset: 0x011B0F3C
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return null;
			}
			RogueResOption optionDataById = ModelBase<RogueBattleModel>.Instance.GetOptionDataById(inParams.BoardId);
			return ControllerBase<RogueBattleController>.Instance.GetViewNameByGainType(optionDataById.RogueResDataType);
		}
	}
}
