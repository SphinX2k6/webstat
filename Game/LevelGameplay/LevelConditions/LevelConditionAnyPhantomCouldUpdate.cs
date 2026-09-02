using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CB7 RID: 27831
	public class LevelConditionAnyPhantomCouldUpdate : LevelConditionBase
	{
		// Token: 0x06044370 RID: 279408 RVA: 0x011B4380 File Offset: 0x011B2580
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			foreach (KeyValuePair<int, PhantomBattleData> keyValuePair in ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleDataMap())
			{
				if (!keyValuePair.Value.IsMax() && ModelBase<PhantomBattleModel>.Instance.GetExpMaterialList(keyValuePair.Value.GetIncrId(), 0, false, false).Length != 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
