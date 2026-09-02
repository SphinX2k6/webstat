using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.SeekTrace.View
{
	// Token: 0x02006B11 RID: 27409
	[NullableContext(1)]
	[Nullable(0)]
	public class SeekTraceJoystickInput
	{
		// Token: 0x06043BAF RID: 277423 RVA: 0x0117A064 File Offset: 0x01178264
		public void RegisterMovePress(Action<ESeekTraceMoveDirection> onMovePress)
		{
			this.OnMovePress = onMovePress;
		}

		// Token: 0x06043BB0 RID: 277424 RVA: 0x0117A06D File Offset: 0x0117826D
		public void MoveAxisInput(ESeekTraceMoveDirection direction, double value)
		{
			if (direction == ESeekTraceMoveDirection.Up || direction == ESeekTraceMoveDirection.Down)
			{
				this.InputY = value;
				return;
			}
			this.InputX = value;
		}

		// Token: 0x06043BB1 RID: 277425 RVA: 0x0117A086 File Offset: 0x01178286
		public void Tick(double delta)
		{
			this.TickAxis(delta);
			if (this.IsTickRepeatAction)
			{
				this.RepeatPressHandle(this.ActionDirection, delta);
			}
		}

		// Token: 0x06043BB2 RID: 277426 RVA: 0x0117A0A4 File Offset: 0x011782A4
		private void TickAxis(double delta)
		{
			if (this.IsTickRepeatAction)
			{
				return;
			}
			double inputY = this.InputY;
			double inputX = this.InputX;
			if (this.IsSmallerThenPressThreshold(inputX) && this.IsSmallerThenPressThreshold(inputY) && !this.IsPress)
			{
				return;
			}
			if (this.IsSmallerThenReleaseThreshold(inputX) && this.IsSmallerThenReleaseThreshold(inputY) && this.IsPress)
			{
				this.IsPress = false;
				this.AxisDirection = ESeekTraceMoveDirection.None;
				this.RepeatPressTime = 0.0;
				return;
			}
			this.HandleDirectionPress(inputX, inputY);
			this.RepeatPressHandle(this.AxisDirection, delta);
			this.IsPress = true;
		}

		// Token: 0x06043BB3 RID: 277427 RVA: 0x0117A138 File Offset: 0x01178338
		private void HandleDirectionPress(double inputX, double inputY)
		{
			bool flag = this.IsSmallerThenPressThreshold(inputX);
			bool flag2 = this.IsSmallerThenPressThreshold(inputY);
			if (flag && flag2)
			{
				return;
			}
			ESeekTraceMoveDirection eseekTraceMoveDirection = ESeekTraceMoveDirection.Left;
			this.TempVector.Set(flag ? 0.0 : inputX, flag2 ? 0.0 : inputY, 0.0);
			double angleByVector2D = Vector.GetAngleByVector2D(this.TempVector);
			if (angleByVector2D >= -143.0 && angleByVector2D < -37.0)
			{
				eseekTraceMoveDirection = ESeekTraceMoveDirection.Down;
			}
			else if (angleByVector2D >= -37.0 && angleByVector2D < 37.0)
			{
				eseekTraceMoveDirection = ESeekTraceMoveDirection.Right;
			}
			else if (angleByVector2D >= 37.0 && angleByVector2D < 143.0)
			{
				eseekTraceMoveDirection = ESeekTraceMoveDirection.Up;
			}
			if (eseekTraceMoveDirection == this.AxisDirection)
			{
				return;
			}
			this.AxisDirection = eseekTraceMoveDirection;
			this.RepeatPressTime = 0.0;
			this.PressInterval = 500;
			this.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Release);
			Action<ESeekTraceMoveDirection> onMovePress = this.OnMovePress;
			if (onMovePress == null)
			{
				return;
			}
			onMovePress(eseekTraceMoveDirection);
		}

		// Token: 0x06043BB4 RID: 277428 RVA: 0x0117A235 File Offset: 0x01178435
		private bool IsSmallerThenPressThreshold(double value)
		{
			return Math.Abs(value) < 0.7;
		}

		// Token: 0x06043BB5 RID: 277429 RVA: 0x0117A248 File Offset: 0x01178448
		private bool IsSmallerThenReleaseThreshold(double value)
		{
			return Math.Abs(value) < 0.2;
		}

		// Token: 0x06043BB6 RID: 277430 RVA: 0x0117A25C File Offset: 0x0117845C
		private void RepeatPressHandle(ESeekTraceMoveDirection direction, double delta)
		{
			if (direction == ESeekTraceMoveDirection.None)
			{
				return;
			}
			this.RepeatPressTime += delta;
			InputDistributeDefine.EActionType? targetActionType = this.TargetActionType;
			InputDistributeDefine.EActionType eactionType = InputDistributeDefine.EActionType.Press;
			if (targetActionType.GetValueOrDefault() == eactionType & targetActionType != null)
			{
				if (this.RepeatPressTime > 100.0)
				{
					this.RepeatPressTime -= 100.0;
					this.PressInterval = 100;
					this.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Release);
					Action<ESeekTraceMoveDirection> onMovePress = this.OnMovePress;
					if (onMovePress == null)
					{
						return;
					}
					onMovePress(direction);
				}
				return;
			}
			if (this.TargetActionType.GetValueOrDefault() == InputDistributeDefine.EActionType.Release && this.RepeatPressTime > (double)this.PressInterval)
			{
				this.RepeatPressTime -= (double)this.PressInterval;
				this.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Press);
			}
		}

		// Token: 0x06043BB7 RID: 277431 RVA: 0x0117A324 File Offset: 0x01178524
		public void MoveActionInput(ESeekTraceMoveDirection direction, bool isPress)
		{
			if (this.IsPress)
			{
				return;
			}
			if (this.ActionDirection != ESeekTraceMoveDirection.None && this.ActionDirection != direction)
			{
				return;
			}
			if (!isPress)
			{
				this.ActionDirection = ESeekTraceMoveDirection.None;
				this.IsTickRepeatAction = false;
				this.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Press);
				return;
			}
			this.ActionDirection = direction;
			this.IsTickRepeatAction = true;
			this.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Release);
			this.RepeatPressTime = 0.0;
			this.PressInterval = 500;
			Action<ESeekTraceMoveDirection> onMovePress = this.OnMovePress;
			if (onMovePress == null)
			{
				return;
			}
			onMovePress(direction);
		}

		// Token: 0x06043BB8 RID: 277432 RVA: 0x0117A3AF File Offset: 0x011785AF
		public void ResetMoveActionInput()
		{
			if (this.ActionDirection != ESeekTraceMoveDirection.None)
			{
				this.ActionDirection = ESeekTraceMoveDirection.None;
				this.IsTickRepeatAction = false;
				this.TargetActionType = new InputDistributeDefine.EActionType?(InputDistributeDefine.EActionType.Press);
			}
		}

		// Token: 0x04025DD3 RID: 155091
		private const double PRESS_THRESHOLD = 0.7;

		// Token: 0x04025DD4 RID: 155092
		private const double RELEASE_THRESHOLD = 0.2;

		// Token: 0x04025DD5 RID: 155093
		private const int FIRST_PRESS_INTERVAL = 500;

		// Token: 0x04025DD6 RID: 155094
		private const int REPEAT_PRESS_INTERVAL = 100;

		// Token: 0x04025DD7 RID: 155095
		private const int RELEASE_INTERVAL = 100;

		// Token: 0x04025DD8 RID: 155096
		private double InputX;

		// Token: 0x04025DD9 RID: 155097
		private double InputY;

		// Token: 0x04025DDA RID: 155098
		private ESeekTraceMoveDirection AxisDirection;

		// Token: 0x04025DDB RID: 155099
		private int PressInterval;

		// Token: 0x04025DDC RID: 155100
		private double RepeatPressTime;

		// Token: 0x04025DDD RID: 155101
		private InputDistributeDefine.EActionType? TargetActionType;

		// Token: 0x04025DDE RID: 155102
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x04025DDF RID: 155103
		private bool IsPress;

		// Token: 0x04025DE0 RID: 155104
		private ESeekTraceMoveDirection ActionDirection;

		// Token: 0x04025DE1 RID: 155105
		private bool IsTickRepeatAction;

		// Token: 0x04025DE2 RID: 155106
		[Nullable(2)]
		private Action<ESeekTraceMoveDirection> OnMovePress;
	}
}
