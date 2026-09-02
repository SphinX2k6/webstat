using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D93 RID: 28051
	public class LevelConditionForMoonChasingCheckHasNotFinishedTask : LevelConditionBase
	{
		// Token: 0x0604456D RID: 279917 RVA: 0x011C1478 File Offset: 0x011BF678
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			using (List<EditTeamData>.Enumerator enumerator = ModelBase<MoonChasingBusinessModel>.Instance.GetHelpEditTeamDataList(false).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetTeamDataUnLockState() == EEditTeamDataUnLockState.TaskUnFinish)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
