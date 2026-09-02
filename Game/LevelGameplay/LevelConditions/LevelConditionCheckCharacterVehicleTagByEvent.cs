using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CD0 RID: 27856
	public class LevelConditionCheckCharacterVehicleTagByEvent : LevelConditionBase
	{
		// Token: 0x060443CD RID: 279501 RVA: 0x011B8710 File Offset: 0x011B6910
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
			if (getCurrentEntity == null)
			{
				return false;
			}
			int num = (int)eventArgs[0];
			if (num == getCurrentEntity.Id)
			{
				return true;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (characterActorComponent == null)
			{
				return false;
			}
			CharacterDriveVehicleComponent characterDriveVehicleComponent = characterActorComponent.Entity.CheckGetComponent<CharacterDriveVehicleComponent>();
			if (characterDriveVehicleComponent == null)
			{
				return false;
			}
			Entity vehicleEntity = characterDriveVehicleComponent.VehicleEntity;
			int? num2 = (vehicleEntity != null) ? new int?(vehicleEntity.Id) : null;
			int num3 = num;
			int? num4 = num2;
			return num3 == num4.GetValueOrDefault() & num4 != null;
		}
	}
}
