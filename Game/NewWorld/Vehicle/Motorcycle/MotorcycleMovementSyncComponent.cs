using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047A7 RID: 18343
	public class MotorcycleMovementSyncComponent : VehicleMovementSyncComponent
	{
		// Token: 0x0602F9A5 RID: 194981 RVA: 0x00B5AFF4 File Offset: 0x00B591F4
		private void MotorSubStateChanged(EMotorSubState newState, EMotorSubState oldState)
		{
			if (!this.ActorComp.IsMoveAutonomousProxy)
			{
				return;
			}
			MotorPositionStatePush motorPositionStatePush = MotorPositionStatePush.Create();
			motorPositionStatePush.PositionState = (int)newState;
			motorPositionStatePush.EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.ActorComp.CreatureData.GetCreatureDataId());
			Singleton<Net>.Instance.Send(EPushMessageId.MotorPositionStatePush, motorPositionStatePush);
		}

		// Token: 0x0602F9A6 RID: 194982 RVA: 0x00B5B04C File Offset: 0x00B5924C
		protected override void OnPostActivate()
		{
			base.OnPostActivate();
			Singleton<EventSystem>.Instance.AddWithTarget<EMotorSubState, EMotorSubState>(base.Entity, EEventName.MotorSubStateModeChange, new Action<EMotorSubState, EMotorSubState>(this.MotorSubStateChanged));
		}

		// Token: 0x0602F9A7 RID: 194983 RVA: 0x00B5B076 File Offset: 0x00B59276
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<EMotorSubState, EMotorSubState>(base.Entity, EEventName.MotorSubStateModeChange, new Action<EMotorSubState, EMotorSubState>(this.MotorSubStateChanged));
			return base.OnEnd();
		}

		// Token: 0x0602F9A8 RID: 194984 RVA: 0x00B5B0A0 File Offset: 0x00B592A0
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			MotorcycleMovementSyncComponent motorcycleMovementSyncComponent = (MotorcycleMovementSyncComponent)componentTemplate;
			return true;
		}
	}
}
