using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DD4 RID: 28116
	public class LevelConditionOnMonsterNumReachLimit : LevelConditionBase
	{
		// Token: 0x060445F1 RID: 280049 RVA: 0x011C30C8 File Offset: 0x011C12C8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			PhantomArenaOwnData ownData = ModelBase<PhantomArenaBattleModel>.Instance.OwnData;
			int? num;
			if (ownData == null)
			{
				num = null;
			}
			else
			{
				List<PhantomCardData> battleCardDataList = ownData.GetBattleCardDataList();
				num = ((battleCardDataList != null) ? new int?(battleCardDataList.Count) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault() >= 4;
		}

		// Token: 0x040260FA RID: 155898
		private const int BATTLE_CARD_NUM_LIMIT = 4;
	}
}
