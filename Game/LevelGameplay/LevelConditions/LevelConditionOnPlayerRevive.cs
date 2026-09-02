using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DC5 RID: 28101
	public class LevelConditionOnPlayerRevive : LevelConditionBase
	{
		// Token: 0x060445D3 RID: 280019 RVA: 0x011C2D18 File Offset: 0x011C0F18
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			bool flag = (bool)eventArgs[0];
			ETeamGroupType eteamGroupType = (ETeamGroupType)eventArgs[1];
			ETeamLivingState eteamLivingState = (ETeamLivingState)eventArgs[2];
			ETeamLivingState eteamLivingState2 = (ETeamLivingState)eventArgs[3];
			return flag && eteamGroupType == ETeamGroupType.Battle && eteamLivingState == ETeamLivingState.Alive && eteamLivingState2 == ETeamLivingState.Dead;
		}
	}
}
