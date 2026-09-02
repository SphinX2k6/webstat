using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Battle;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C35 RID: 23605
	public class FlagChallengeExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA6D RID: 244333 RVA: 0x00F1CB0A File Offset: 0x00F1AD0A
		public override bool Checker()
		{
			return ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon;
		}

		// Token: 0x0603BA6E RID: 244334 RVA: 0x00F1CB16 File Offset: 0x00F1AD16
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			ControllerBase<FlagChallengeBattleController>.Instance.OpenPauseView();
		}
	}
}
