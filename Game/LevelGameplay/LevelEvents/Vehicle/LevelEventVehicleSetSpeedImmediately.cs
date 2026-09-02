using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.Vehicle
{
	// Token: 0x02006C2D RID: 27693
	public class LevelEventVehicleSetSpeedImmediately : LevelEventBase
	{
		// Token: 0x060441DA RID: 279002 RVA: 0x011B0903 File Offset: 0x011AEB03
		public LevelEventVehicleSetSpeedImmediately(int id) : base(id)
		{
		}

		// Token: 0x060441DB RID: 279003 RVA: 0x011B090C File Offset: 0x011AEB0C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ISetVehicleSpeedImmediatelyType setSpeedConfig = (inParams as VehicleSetSpeedImmediately).SetSpeedConfig;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (characterActorComponent == null || !characterActorComponent.Valid)
			{
				return;
			}
			CharacterDriveVehicleComponent characterDriveVehicleComponent = characterActorComponent.Entity.CheckGetComponent<CharacterDriveVehicleComponent>();
			Entity entity = (characterDriveVehicleComponent != null) ? characterDriveVehicleComponent.VehicleEntity : null;
			if (entity == null || !entity.Valid)
			{
				return;
			}
			VehicleMoveComponent vehicleMoveComponent = entity.CheckGetComponent<VehicleMoveComponent>();
			VehicleActorComponent vehicleActorComponent = entity.CheckGetComponent<VehicleActorComponent>();
			if (vehicleMoveComponent == null || !vehicleMoveComponent.Valid || (vehicleActorComponent == null || !vehicleActorComponent.Valid))
			{
				return;
			}
			ESetVehicleSpeedImmediatelyType type = setSpeedConfig.Type;
			if (type == ESetVehicleSpeedImmediatelyType.TotalSpeed)
			{
				double inB = ControllerBase<LevelGamePlayController>.Instance.ConstraintProcessedValue((setSpeedConfig as ISetTotalVehicleSpeedImmediately).Speed, vehicleActorComponent.ActorVelocityProxy.Size());
				vehicleActorComponent.ActorVelocityProxy.GetSafeNormal(Singleton<MathUtils>.Instance.CommonTempVector, 9.99999993922529E-09);
				vehicleMoveComponent.SetForceSpeed(Singleton<MathUtils>.Instance.CommonTempVector.MultiplyEqual(inB));
				return;
			}
			if (type != ESetVehicleSpeedImmediatelyType.HorizontalVerticalSpeed)
			{
				return;
			}
			ISetHorizontalVerticalSpeedImmediately setHorizontalVerticalSpeedImmediately = setSpeedConfig as ISetHorizontalVerticalSpeedImmediately;
			Singleton<MathUtils>.Instance.CommonTempVector2.DeepCopy(vehicleActorComponent.ActorVelocityProxy);
			double num = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(vehicleActorComponent, vehicleActorComponent.ActorVelocityProxy);
			if (setHorizontalVerticalSpeedImmediately.VerticalSpeed != null)
			{
				num = ControllerBase<LevelGamePlayController>.Instance.ConstraintProcessedValue(setHorizontalVerticalSpeedImmediately.VerticalSpeed, num);
			}
			if (setHorizontalVerticalSpeedImmediately.HorizontalSpeed != null)
			{
				Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(vehicleActorComponent.ActorVelocityProxy);
				Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(vehicleActorComponent, Singleton<MathUtils>.Instance.CommonTempVector);
				double inB2 = ControllerBase<LevelGamePlayController>.Instance.ConstraintProcessedValue(setHorizontalVerticalSpeedImmediately.HorizontalSpeed, Singleton<MathUtils>.Instance.CommonTempVector.Size());
				Singleton<MathUtils>.Instance.CommonTempVector.GetSafeNormal(Singleton<MathUtils>.Instance.CommonTempVector2, 9.99999993922529E-09);
				Singleton<MathUtils>.Instance.CommonTempVector2.MultiplyEqual(inB2);
			}
			Singleton<GravityUtils>.Instance.SetZnInGravityForActor(vehicleActorComponent, Singleton<MathUtils>.Instance.CommonTempVector2, num);
			vehicleMoveComponent.SetForceSpeed(Singleton<MathUtils>.Instance.CommonTempVector2);
		}
	}
}
