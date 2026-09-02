using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DC4 RID: 28100
	public class LevelConditionOnPickUpHonamiStoryItem : LevelConditionBase
	{
		// Token: 0x060445D1 RID: 280017 RVA: 0x011C2CC4 File Offset: 0x011C0EC4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("HighPrice");
			float num;
			return limitParams == null || (float.TryParse(limitParams, out num) && (float)((HonamiStoryItemDataBase)eventArgs[0]).GetSellPrice() >= num);
		}
	}
}
