using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VehicleStream.StateMachine.States
{
	// Token: 0x02004C54 RID: 19540
	public class BrakingState : VehicleStateBase
	{
		// Token: 0x06032E84 RID: 208516 RVA: 0x00CC0444 File Offset: 0x00CBE644
		[NullableContext(1)]
		public BrakingState(VehicleSmBlackBoard blackBoard) : base(EVehicleStateType.Braking, blackBoard)
		{
		}

		// Token: 0x06032E85 RID: 208517 RVA: 0x00CC044E File Offset: 0x00CBE64E
		[NullableContext(2)]
		protected override void OnEnter(EVehicleStateType lastState, string reason = null)
		{
		}

		// Token: 0x06032E86 RID: 208518 RVA: 0x00CC0450 File Offset: 0x00CBE650
		protected override void OnUpdate(float delta)
		{
			EVehicleStateType evehicleStateType = this.CheckGetNextState();
			if (evehicleStateType != EVehicleStateType.None)
			{
				this.BlackBoard.SwitchState(evehicleStateType, null);
			}
		}

		// Token: 0x06032E87 RID: 208519 RVA: 0x00CC0478 File Offset: 0x00CBE678
		protected override EVehicleStateType CheckGetNextState()
		{
			string a = base.CheckObstruction(this.BlackBoard.CurrentRootDistance, "VehicleStream.braking");
			if (a != EObstructionCheckResult.None.ToEnumString())
			{
				this.BlackBoard.BlockTarget = this.ObstructionCheckInfo.HitEntityType;
				if ((a == EObstructionCheckResult.TraceBlock.ToEnumString() || a == EObstructionCheckResult.CheckPlayerBlock.ToEnumString()) && this.BlackBoard.HornAudio != null && Singleton<TimeUtil>.Instance.GetServerTimeStamp() - this.LastPlayHornAudioTime >= 10000.0)
				{
					this.BlackBoard.OpenAudio(this.BlackBoard.HornAudio, false);
					this.LastPlayHornAudioTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
				}
				return EVehicleStateType.None;
			}
			this.BlackBoard.BlockTarget = null;
			UKuroRoadway nextRoadway = this.BlackBoard.NextRoadway;
			if (nextRoadway != null && nextRoadway is UKuroRoadwayIntersection)
			{
				if (!this.BlackBoard.CheckArrivedSplineEndPoint())
				{
					return EVehicleStateType.Running;
				}
				if (ModelBase<VehicleStreamModel>.Instance.CheckIntersectionRoadwayOccupied(nextRoadway.Id))
				{
					return EVehicleStateType.None;
				}
			}
			return EVehicleStateType.Running;
		}

		// Token: 0x0401DA3F RID: 121407
		private double LastPlayHornAudioTime;
	}
}
