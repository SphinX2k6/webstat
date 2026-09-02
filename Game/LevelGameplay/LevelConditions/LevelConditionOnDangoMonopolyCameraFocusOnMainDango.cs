using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D82 RID: 28034
	public class LevelConditionOnDangoMonopolyCameraFocusOnMainDango : LevelConditionBase
	{
		// Token: 0x0604454B RID: 279883 RVA: 0x011C0F8D File Offset: 0x011BF18D
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
