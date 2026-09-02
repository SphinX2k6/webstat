using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PermanentRogue;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB2 RID: 28082
	public class LevelConditionOnMovieRogueInfoRefreshWithMultipleEnds : LevelConditionBase
	{
		// Token: 0x060445AD RID: 279981 RVA: 0x011C28B0 File Offset: 0x011C0AB0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int instId = Convert.ToInt32(eventArgs[0]);
			return ModelBase<ActivityPermanentRogueModel>.Instance.GetInstDungeonEndingTotalCount(instId) > 1;
		}
	}
}
