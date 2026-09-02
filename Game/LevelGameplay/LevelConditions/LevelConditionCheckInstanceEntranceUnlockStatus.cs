using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D17 RID: 27927
	public class LevelConditionCheckInstanceEntranceUnlockStatus : LevelConditionBase
	{
		// Token: 0x06044463 RID: 279651 RVA: 0x011BC728 File Offset: 0x011BA928
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			Singleton<Log>.Instance.Info(ELogModule.InstanceDungeon, ELogAuthor.LJQ, "注意，该条件已经废弃，通知程序处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
	}
}
