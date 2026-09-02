using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB1 RID: 28081
	public class LevelConditionMoveStateCheck : LevelConditionBase
	{
		// Token: 0x060445AB RID: 279979 RVA: 0x011C2800 File Offset: 0x011C0A00
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0 || inTrigger == null)
			{
				return false;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return false;
			}
			CharacterUnifiedStateComponent component = baseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterUnifiedStateComponent>();
			if (component == null)
			{
				return false;
			}
			switch (component.PositionState)
			{
			case ECharPositionState.Climb:
				if (!(inConditionInfo.GetLimitParams("Climb") == "1"))
				{
					return false;
				}
				break;
			case ECharPositionState.Air:
				if (!(inConditionInfo.GetLimitParams("Glide") == "1"))
				{
					return false;
				}
				break;
			case ECharPositionState.Water:
				if (!(inConditionInfo.GetLimitParams("Swim") == "1"))
				{
					return false;
				}
				break;
			}
			return true;
		}
	}
}
