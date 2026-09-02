using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D9B RID: 28059
	public class LevelConditionHasNotInvitedRoleInSpring25 : LevelConditionBase
	{
		// Token: 0x0604457E RID: 279934 RVA: 0x011C1A15 File Offset: 0x011BFC15
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return !ModelBase<Spring25Model>.Instance.IsLetterListViewAvailable;
		}
	}
}
