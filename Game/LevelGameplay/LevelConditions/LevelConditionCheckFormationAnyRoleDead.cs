using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D07 RID: 27911
	public class LevelConditionCheckFormationAnyRoleDead : LevelConditionBase
	{
		// Token: 0x06044442 RID: 279618 RVA: 0x011BBC1C File Offset: 0x011B9E1C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			using (List<SceneTeamItem>.Enumerator enumerator = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsDead())
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
