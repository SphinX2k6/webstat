using System;

// Token: 0x02001D46 RID: 7494
public class DigitScroll
{
	// Token: 0x0600DCF2 RID: 56562 RVA: 0x003B5FD9 File Offset: 0x003B41D9
	public void Init(float current, float target, float duration)
	{
		this.Current = current;
		this.Target = target;
		this.Duration = duration;
	}

	// Token: 0x0600DCF3 RID: 56563 RVA: 0x003B5FF0 File Offset: 0x003B41F0
	public float Tick(float delta)
	{
		if (this.Speed != 0f)
		{
			this.Current += this.Speed * delta;
			if (this.Current >= this.Target == this.Speed > 0f)
			{
				this.Current = this.Target;
				this.Speed = 0f;
			}
		}
		return this.Current;
	}

	// Token: 0x0600DCF4 RID: 56564 RVA: 0x003B605C File Offset: 0x003B425C
	public float SetTarget(float target)
	{
		if (this.Target == target)
		{
			return 0f;
		}
		this.Target = target;
		float num = target - this.Current;
		this.Speed = num / this.Duration;
		return num;
	}

	// Token: 0x0600DCF5 RID: 56565 RVA: 0x003B6097 File Offset: 0x003B4297
	public void Reset(float target)
	{
		this.Current = target;
		this.Target = target;
		this.Speed = 0f;
	}

	// Token: 0x0600DCF6 RID: 56566 RVA: 0x003B60B2 File Offset: 0x003B42B2
	public bool IsFinished()
	{
		return this.Speed == 0f;
	}

	// Token: 0x040069C5 RID: 27077
	public float Current;

	// Token: 0x040069C6 RID: 27078
	public float Target;

	// Token: 0x040069C7 RID: 27079
	public float Speed;

	// Token: 0x040069C8 RID: 27080
	public float Duration = 1000f;
}
