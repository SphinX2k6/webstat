using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.Elevator
{
	// Token: 0x0200486B RID: 18539
	[NullableContext(1)]
	[Nullable(0)]
	public class ElevatorContext
	{
		// Token: 0x0401BB58 RID: 113496
		public BaseActorComponent ActorComp;

		// Token: 0x0401BB59 RID: 113497
		public Entity Entity;

		// Token: 0x0401BB5A RID: 113498
		public int? EntityConfigId;

		// Token: 0x0401BB5B RID: 113499
		public int CurFloor = 1;

		// Token: 0x0401BB5C RID: 113500
		public int TargetFloor;

		// Token: 0x0401BB5D RID: 113501
		public EGamePlayElevatorState State;

		// Token: 0x0401BB5E RID: 113502
		public bool IsAnnular;

		// Token: 0x0401BB5F RID: 113503
		public float? MaxSpeed;

		// Token: 0x0401BB60 RID: 113504
		public bool? UniformMovement;

		// Token: 0x0401BB61 RID: 113505
		public float? DelayMoveTime;
	}
}
