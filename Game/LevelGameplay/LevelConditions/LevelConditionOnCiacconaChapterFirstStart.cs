using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D6C RID: 28012
	public class LevelConditionOnCiacconaChapterFirstStart : LevelConditionBase
	{
		// Token: 0x0604451E RID: 279838 RVA: 0x011C0516 File Offset: 0x011BE716
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
