using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FA6 RID: 28582
	public class LevelFlowResetMotorSpeed : LevelFlowActionBase
	{
		// Token: 0x06045216 RID: 283158 RVA: 0x0120965B File Offset: 0x0120785B
		[NullableContext(1)]
		public LevelFlowResetMotorSpeed Init(float speed)
		{
			this.Speed = speed;
			return this;
		}

		// Token: 0x06045217 RID: 283159 RVA: 0x01209668 File Offset: 0x01207868
		protected override void OnExecute()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (characterActorComponent == null)
			{
				base.FinishExecute(false);
				return;
			}
			Entity entity = characterActorComponent.Entity;
			CharacterDriveVehicleComponent characterDriveVehicleComponent = (entity != null) ? entity.CheckGetComponent<CharacterDriveVehicleComponent>() : null;
			if (characterDriveVehicleComponent != null)
			{
				Entity vehicleEntity = characterDriveVehicleComponent.VehicleEntity;
				if (vehicleEntity != null && vehicleEntity.Valid)
				{
					VehicleActorComponent vehicleActorComponent = characterDriveVehicleComponent.VehicleEntity.CheckGetComponent<VehicleActorComponent>();
					if (vehicleActorComponent == null)
					{
						base.FinishExecute(false);
						return;
					}
					Vector vector = Vector.Create(vehicleActorComponent.ActorForwardProxy);
					vector.Multiply((double)this.Speed, vector);
					vehicleActorComponent.SetActorVelocity(vector);
					base.FinishExecute(true);
					return;
				}
			}
			base.FinishExecute(false);
		}

		// Token: 0x04026924 RID: 157988
		private float Speed;
	}
}
