using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.GamePlay.InteractiveObject;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D32 RID: 27954
	public class LevelConditionCheckOnTrap : LevelConditionBase
	{
		// Token: 0x060444A1 RID: 279713 RVA: 0x011BDB0C File Offset: 0x011BBD0C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("TrapState");
			IBPI_PhysicInteraction_C ibpi_PhysicInteraction_C = inTrigger as IBPI_PhysicInteraction_C;
			if (ibpi_PhysicInteraction_C == null || limitParams == null)
			{
				return false;
			}
			bool flag = false;
			ibpi_PhysicInteraction_C.IsPhysicInteracted(ref flag);
			if (limitParams == "1")
			{
				return flag;
			}
			return !flag;
		}
	}
}
