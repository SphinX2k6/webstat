using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DD5 RID: 28117
	public class LevelConditionOnGetSpCard : LevelConditionBase
	{
		// Token: 0x060445F3 RID: 280051 RVA: 0x011C3124 File Offset: 0x011C1324
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (eventArgs.Length != 0)
			{
				IReadOnlyList<int> readOnlyList = eventArgs[0] as IReadOnlyList<int>;
				if (readOnlyList != null)
				{
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						int cardId = readOnlyList[i];
						PhantomArenaOwnData ownData = ModelBase<PhantomArenaBattleModel>.Instance.OwnData;
						PhantomCardData phantomCardData = (ownData != null) ? ownData.GetHandCardDataByCardId(cardId) : null;
						if (phantomCardData != null && phantomCardData.IsFourCost)
						{
							return true;
						}
					}
					return false;
				}
			}
			return false;
		}
	}
}
