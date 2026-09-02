using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.Elevator
{
	// Token: 0x0200486D RID: 18541
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class ElevatorMoveStrategyBase : IElevatorMoveStrategy
	{
		// Token: 0x0603040D RID: 197645
		public abstract void InitFromConfig(LiftComponent config, ElevatorContext ctx, float initLocationX, float initLocationY, float initLocationZ);

		// Token: 0x0603040E RID: 197646
		public abstract void OnInit();

		// Token: 0x0603040F RID: 197647
		public abstract void OnStart(Action tryStartAutoRun);

		// Token: 0x06030410 RID: 197648
		public abstract void TickMove(float deltaSeconds);

		// Token: 0x06030411 RID: 197649
		public abstract void CheckAndFinishMove(Action onMoveArrived);

		// Token: 0x06030412 RID: 197650
		public abstract int GetFloorCount();

		// Token: 0x06030413 RID: 197651
		public abstract float GetMoveDuration();

		// Token: 0x06030414 RID: 197652 RVA: 0x00BBD34D File Offset: 0x00BBB54D
		public virtual void OnEnterMovePhase()
		{
		}

		// Token: 0x06030415 RID: 197653 RVA: 0x00BBD34F File Offset: 0x00BBB54F
		public virtual void PrepareMoveToFloor(Action onReady)
		{
			onReady();
		}

		// Token: 0x06030416 RID: 197654 RVA: 0x00BBD357 File Offset: 0x00BBB557
		public virtual bool OnBeforeEnterMoving()
		{
			return true;
		}

		// Token: 0x06030417 RID: 197655 RVA: 0x00BBD35A File Offset: 0x00BBB55A
		public virtual void OnClear()
		{
		}

		// Token: 0x0401BB62 RID: 113506
		protected ElevatorContext Ctx;
	}
}
