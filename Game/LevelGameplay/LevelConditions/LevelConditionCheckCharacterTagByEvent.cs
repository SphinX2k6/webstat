using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CCC RID: 27852
	public class LevelConditionCheckCharacterTagByEvent : LevelConditionBase
	{
		// Token: 0x060443B7 RID: 279479 RVA: 0x011B8090 File Offset: 0x011B6290
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (eventArgs == null || eventArgs.Length < 4)
			{
				return false;
			}
			if ((int)eventArgs[2] >= (int)eventArgs[3])
			{
				return false;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			return getCurrentEntity != null && (int)eventArgs[0] == getCurrentEntity.Id;
		}
	}
}
