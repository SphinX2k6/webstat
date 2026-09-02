using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DD2 RID: 28114
	public class LevelConditionOnHandCardsShow : LevelConditionBase
	{
		// Token: 0x060445ED RID: 280045 RVA: 0x011C30A8 File Offset: 0x011C12A8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}

		// Token: 0x040260F9 RID: 155897
		private const int BATTLE_CARD_NUM_LIMIT = 4;
	}
}
