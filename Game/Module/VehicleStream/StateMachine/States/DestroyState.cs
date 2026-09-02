using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.VehicleStream.StateMachine.States
{
	// Token: 0x02004C55 RID: 19541
	public class DestroyState : VehicleStateBase
	{
		// Token: 0x06032E88 RID: 208520 RVA: 0x00CC057E File Offset: 0x00CBE77E
		[NullableContext(1)]
		public DestroyState(VehicleSmBlackBoard blackBoard) : base(EVehicleStateType.Destroy, blackBoard)
		{
		}

		// Token: 0x06032E89 RID: 208521 RVA: 0x00CC0588 File Offset: 0x00CBE788
		[NullableContext(2)]
		protected override void OnEnter(EVehicleStateType lastState, string reason = null)
		{
			ControllerBase<VehicleStreamController>.Instance.RequestNetworkEntityUpdateCurRoadPush(this.BlackBoard.CreatureDataId, this.BlackBoard.DestRoadId, this.BlackBoard.DestRoadIndex);
		}
	}
}
