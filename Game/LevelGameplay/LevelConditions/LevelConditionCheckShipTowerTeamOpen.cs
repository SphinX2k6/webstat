using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D51 RID: 27985
	public class LevelConditionCheckShipTowerTeamOpen : LevelConditionBase
	{
		// Token: 0x060444E1 RID: 279777 RVA: 0x011BF501 File Offset: 0x011BD701
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
