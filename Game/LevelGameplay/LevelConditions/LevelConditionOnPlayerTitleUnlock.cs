using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DC6 RID: 28102
	public class LevelConditionOnPlayerTitleUnlock : LevelConditionBase
	{
		// Token: 0x060445D5 RID: 280021 RVA: 0x011C2D60 File Offset: 0x011C0F60
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
