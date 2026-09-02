using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D61 RID: 28001
	public class LevelConditionCheckTrialRole : LevelConditionBase
	{
		// Token: 0x06044508 RID: 279816 RVA: 0x011C0178 File Offset: 0x011BE378
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (!ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				return false;
			}
			using (HashSet<int>.Enumerator enumerator = ModelBase<RoleModel>.Instance.RoleTrialIdList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (RoleUtils.GetTrialRoleType(enumerator.Current) == ETrialRoleType.NormalTrial)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
