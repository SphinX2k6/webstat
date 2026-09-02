using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D37 RID: 27959
	public class LevelConditionCheckPhantomTeam : LevelConditionBase
	{
		// Token: 0x060444AB RID: 279723 RVA: 0x011BDC40 File Offset: 0x011BBE40
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<SceneTeamModel>.Instance.IsPhantomTeam;
		}
	}
}
