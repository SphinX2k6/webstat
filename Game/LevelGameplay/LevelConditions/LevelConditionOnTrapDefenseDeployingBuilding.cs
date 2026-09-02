using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DFC RID: 28156
	public class LevelConditionOnTrapDefenseDeployingBuilding : LevelConditionBase
	{
		// Token: 0x06044653 RID: 280147 RVA: 0x011C4AEC File Offset: 0x011C2CEC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num;
			return int.TryParse(inConditionInfo.GetLimitParams("MachineId"), out num) && num != 0 && (int)eventArgs[0] == num;
		}
	}
}
