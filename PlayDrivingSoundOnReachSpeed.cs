using System;
using System.Runtime.CompilerServices;

// Token: 0x02003297 RID: 12951
[NullableContext(1)]
[Nullable(0)]
public class PlayDrivingSoundOnReachSpeed : KeepDrivingInfo
{
	// Token: 0x0601B1EA RID: 111082 RVA: 0x00822A62 File Offset: 0x00820C62
	public PlayDrivingSoundOnReachSpeed(double[] speed, float cd, [Nullable(2)] Func<bool> condition, Action action)
	{
		this.SpeedRange = speed;
		this.CoolDown = cd;
		this.CheckCondition = condition;
		this.RunAction = action;
	}

	// Token: 0x0601B1EB RID: 111083 RVA: 0x00822A94 File Offset: 0x00820C94
	public override bool UpdateDrivingInfo(float delta, VehicleMoveComponent moveComp)
	{
		bool flag = !Singleton<MathUtils>.Instance.InRangeArray((double)this.LastSpeed, this.SpeedRange) && Singleton<MathUtils>.Instance.InRangeArray((double)moveComp.Speed, this.SpeedRange);
		this.LastSpeed = moveComp.Speed;
		if (flag && Math.Abs(TimerSystem.Instance.Now - this.LastTime) > (double)this.CoolDown)
		{
			this.LastTime = TimerSystem.Instance.Now;
			return true;
		}
		return false;
	}

	// Token: 0x0601B1EC RID: 111084 RVA: 0x00822B14 File Offset: 0x00820D14
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 3);
		defaultInterpolatedStringHandler.AppendLiteral("速度每次进入区间[");
		defaultInterpolatedStringHandler.AppendFormatted<double>(this.SpeedRange[0]);
		defaultInterpolatedStringHandler.AppendLiteral(",");
		defaultInterpolatedStringHandler.AppendFormatted<double>(this.SpeedRange[1]);
		defaultInterpolatedStringHandler.AppendLiteral("]内,触发事件,冷却时间");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.CoolDown);
		defaultInterpolatedStringHandler.AppendLiteral("毫秒");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400DCC1 RID: 56513
	protected double[] SpeedRange = new double[2];

	// Token: 0x0400DCC2 RID: 56514
	protected float CoolDown;

	// Token: 0x0400DCC3 RID: 56515
	protected float LastSpeed;

	// Token: 0x0400DCC4 RID: 56516
	protected double LastTime;
}
