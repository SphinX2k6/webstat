using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.Elevator
{
	// Token: 0x0200486C RID: 18540
	[NullableContext(1)]
	public interface IElevatorMoveStrategy
	{
		// Token: 0x06030402 RID: 197634
		void InitFromConfig(LiftComponent config, ElevatorContext ctx, float initLocationX, float initLocationY, float initLocationZ);

		// Token: 0x06030403 RID: 197635
		void OnInit();

		// Token: 0x06030404 RID: 197636
		void OnStart(Action tryStartAutoRun);

		// Token: 0x06030405 RID: 197637
		void OnClear();

		// Token: 0x06030406 RID: 197638
		void OnEnterMovePhase();

		// Token: 0x06030407 RID: 197639
		void TickMove(float deltaSeconds);

		// Token: 0x06030408 RID: 197640
		void CheckAndFinishMove(Action onMoveArrived);

		// Token: 0x06030409 RID: 197641
		void PrepareMoveToFloor(Action onReady);

		// Token: 0x0603040A RID: 197642
		bool OnBeforeEnterMoving();

		// Token: 0x0603040B RID: 197643
		int GetFloorCount();

		// Token: 0x0603040C RID: 197644
		float GetMoveDuration();
	}
}
