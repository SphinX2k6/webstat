using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C7F RID: 27775
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemRogueAbilitySelect : OpenSystemBase
	{
		// Token: 0x060442CE RID: 279246 RVA: 0x011B2C0F File Offset: 0x011B0E0F
		public OpenSystemRogueAbilitySelect(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442CF RID: 279247 RVA: 0x011B2C18 File Offset: 0x011B0E18
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemRogueAbilitySelect.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemRogueAbilitySelect.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x060442D0 RID: 279248 RVA: 0x011B2C5C File Offset: 0x011B0E5C
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return null;
			}
			RoguelikeChooseData roguelikeChooseDataById = ModelBase<RoguelikeModel>.Instance.GetRoguelikeChooseDataById(inParams.BoardId);
			return ControllerBase<RoguelikeController>.Instance.GetViewNameByGainType(roguelikeChooseDataById.RoguelikeGainDataType.Value);
		}
	}
}
