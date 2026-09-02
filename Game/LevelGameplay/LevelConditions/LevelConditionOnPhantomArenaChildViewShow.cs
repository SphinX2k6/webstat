using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DD7 RID: 28119
	public class LevelConditionOnPhantomArenaChildViewShow : LevelConditionBase
	{
		// Token: 0x060445F7 RID: 280055 RVA: 0x011C31C4 File Offset: 0x011C13C4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("ViewName");
			string b = (string)eventArgs[0];
			return limitParams == b;
		}
	}
}
