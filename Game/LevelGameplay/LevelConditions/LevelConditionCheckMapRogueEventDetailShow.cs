using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB7 RID: 28087
	public class LevelConditionCheckMapRogueEventDetailShow : LevelConditionBase
	{
		// Token: 0x060445B7 RID: 279991 RVA: 0x011C296D File Offset: 0x011C0B6D
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (eventArgs != null && eventArgs.Length != 0)
			{
				this.IsShow = Convert.ToBoolean(eventArgs[0]);
			}
			return this.IsShow;
		}

		// Token: 0x040260F5 RID: 155893
		private bool IsShow;
	}
}
