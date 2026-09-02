using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DAA RID: 28074
	public class LevelConditionOnKingShipFirstAttrShow : LevelConditionBase
	{
		// Token: 0x0604459D RID: 279965 RVA: 0x011C25D0 File Offset: 0x011C07D0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num = (int)eventArgs[0];
			bool flag = (bool)eventArgs[1];
			return num == 1 && flag;
		}
	}
}
