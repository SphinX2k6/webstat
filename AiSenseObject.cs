using System;
using Aki.Config;

// Token: 0x02000D0A RID: 3338
public class AiSenseObject
{
	// Token: 0x060042DC RID: 17116 RVA: 0x00079C64 File Offset: 0x00077E64
	public AiSenseObject(AiSense aiSense)
	{
		this.AiSense = aiSense;
		this.WithAngleHorizontal = (this.AiSense.HorizontalAngle.Value.Min > -180f || this.AiSense.HorizontalAngle.Value.Max < 180f);
		this.WithAngleVertical = (this.AiSense.VerticalAngle.Value.Min > -90f || this.AiSense.VerticalAngle.Value.Max < 90f);
		this.SquaredDisMin = this.AiSense.SenseDistanceRange.Value.Min * this.AiSense.SenseDistanceRange.Value.Min;
		this.SquaredDisMax = this.AiSense.SenseDistanceRange.Value.Max * this.AiSense.SenseDistanceRange.Value.Max;
		this.SquaredWalkSenseRate = this.AiSense.WalkSenseRate * this.AiSense.WalkSenseRate;
		this.SquaredAirSenseRate = this.AiSense.AirSenseRate * this.AiSense.AirSenseRate;
	}

	// Token: 0x060042DD RID: 17117 RVA: 0x00079DCC File Offset: 0x00077FCC
	public bool InArea(double squaredDist, float angleHorizontal, float angleVertical, ECharPositionState positionState, ECharMoveState moveState, bool inSenseBefore)
	{
		if (this.WithAngleHorizontal && !Singleton<MathUtils>.Instance.InRange((double)angleHorizontal, this.AiSense.HorizontalAngle.Value))
		{
			return false;
		}
		if (this.WithAngleVertical && !Singleton<MathUtils>.Instance.InRange((double)angleVertical, this.AiSense.VerticalAngle.Value))
		{
			return false;
		}
		double num = squaredDist;
		if (positionState == ECharPositionState.Ground)
		{
			if (moveState == ECharMoveState.Other || moveState == ECharMoveState.Stand || moveState == ECharMoveState.Walk || moveState == ECharMoveState.WalkStop)
			{
				num /= (double)this.SquaredWalkSenseRate;
			}
		}
		else if (moveState == ECharMoveState.Glide)
		{
			num /= (double)this.SquaredAirSenseRate;
		}
		return !(inSenseBefore ? (num > (double)this.SquaredDisMax) : (num > (double)this.SquaredDisMin));
	}

	// Token: 0x04001124 RID: 4388
	public readonly bool WithAngleHorizontal;

	// Token: 0x04001125 RID: 4389
	public readonly bool WithAngleVertical;

	// Token: 0x04001126 RID: 4390
	private readonly float SquaredDisMin;

	// Token: 0x04001127 RID: 4391
	private readonly float SquaredDisMax;

	// Token: 0x04001128 RID: 4392
	private readonly float SquaredWalkSenseRate;

	// Token: 0x04001129 RID: 4393
	private readonly float SquaredAirSenseRate;

	// Token: 0x0400112A RID: 4394
	public readonly AiSense AiSense;

	// Token: 0x0400112B RID: 4395
	private const float MINUS_HALF = -180f;

	// Token: 0x0400112C RID: 4396
	private const float MINUS_QUATER = -90f;
}
