using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DD6 RID: 28118
	public class LevelConditionCheckPhantomArenaChallengeId : LevelConditionBase
	{
		// Token: 0x060445F5 RID: 280053 RVA: 0x011C318C File Offset: 0x011C138C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num;
			int.TryParse(inConditionInfo.GetLimitParams("ChallengeId"), out num);
			int challengeId = ModelBase<PhantomArenaBattleModel>.Instance.ChallengeId;
			return num == challengeId;
		}
	}
}
