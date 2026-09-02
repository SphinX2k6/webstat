using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DAF RID: 28079
	public class LevelConditionCheckNoMoraleAreaFinished : LevelConditionBase
	{
		// Token: 0x060445A7 RID: 279975 RVA: 0x011C2728 File Offset: 0x011C0928
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			using (List<MoraleAreaData>.Enumerator enumerator = ModelBase<MoraleModel>.Instance.AreaDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HighDifficultyFlagSomeActive())
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
