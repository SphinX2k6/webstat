using System;
using System.Runtime.CompilerServices;

// Token: 0x02003296 RID: 12950
[NullableContext(1)]
[Nullable(0)]
public class KeepDrivingDurationAtSpeed : KeepDrivingInfo
{
	// Token: 0x0601B1E7 RID: 111079 RVA: 0x0082290C File Offset: 0x00820B0C
	[NullableContext(2)]
	public KeepDrivingDurationAtSpeed([Nullable(1)] double[] speed, float duration, Func<bool> condition = null, Action action = null, float? cd = null)
	{
		this.SpeedRange = speed;
		this.Duration = duration;
		this.CoolDown = cd.GetValueOrDefault();
		this.CheckCondition = condition;
		this.RunAction = action;
	}

	// Token: 0x0601B1E8 RID: 111080 RVA: 0x0082294C File Offset: 0x00820B4C
	public override bool UpdateDrivingInfo(float delta, VehicleMoveComponent moveComp)
	{
		if (Singleton<MathUtils>.Instance.InRangeArray((double)moveComp.Speed, this.SpeedRange))
		{
			this.CurrentDuration += delta;
			if (this.CurrentDuration > this.Duration)
			{
				if (Math.Abs(TimerSystem.Instance.Now - this.LastTime) > (double)this.CoolDown)
				{
					this.LastTime = TimerSystem.Instance.Now;
					return true;
				}
				return false;
			}
		}
		else
		{
			this.CurrentDuration = 0f;
		}
		return false;
	}

	// Token: 0x0601B1E9 RID: 111081 RVA: 0x008229D0 File Offset: 0x00820BD0
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 4);
		defaultInterpolatedStringHandler.AppendLiteral("保持速度在区间[");
		defaultInterpolatedStringHandler.AppendFormatted<double>(this.SpeedRange[0]);
		defaultInterpolatedStringHandler.AppendLiteral(",");
		defaultInterpolatedStringHandler.AppendFormatted<double>(this.SpeedRange[1]);
		defaultInterpolatedStringHandler.AppendLiteral("]内,持续");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Duration);
		defaultInterpolatedStringHandler.AppendLiteral("毫秒,冷却时间");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.CoolDown);
		defaultInterpolatedStringHandler.AppendLiteral("毫秒");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400DCBC RID: 56508
	protected double[] SpeedRange = new double[2];

	// Token: 0x0400DCBD RID: 56509
	protected float Duration;

	// Token: 0x0400DCBE RID: 56510
	protected float CurrentDuration;

	// Token: 0x0400DCBF RID: 56511
	protected float CoolDown;

	// Token: 0x0400DCC0 RID: 56512
	protected double LastTime;
}
