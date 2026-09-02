using System;
using Aki.Config;

// Token: 0x02000D06 RID: 3334
public class AiPatrolConfig
{
	// Token: 0x060042B2 RID: 17074 RVA: 0x000787D8 File Offset: 0x000769D8
	public void Init(AiPatrol config)
	{
		this.Id = config.Id;
		this.CirclePatrol = config.CirclePatrol;
		this.IsNavigation = config.IsNavigation;
		this.StartIndex = config.StartIndex;
		this.LimitNpcDistance = config.LimitNpcDistance;
		this.TurnSpeed = config.TurnSpeed;
		this.Loop = config.Loop;
		this.EndDistance = config.EndDistance;
		this.Sampling = config.Sampling;
		this.ContainZ = config.ContainZ;
	}

	// Token: 0x040010F3 RID: 4339
	public int Id;

	// Token: 0x040010F4 RID: 4340
	public bool CirclePatrol;

	// Token: 0x040010F5 RID: 4341
	public int SplineEntityId;

	// Token: 0x040010F6 RID: 4342
	public bool IsNavigation;

	// Token: 0x040010F7 RID: 4343
	public int StartIndex;

	// Token: 0x040010F8 RID: 4344
	public float LimitNpcDistance;

	// Token: 0x040010F9 RID: 4345
	public float TurnSpeed;

	// Token: 0x040010FA RID: 4346
	public bool Loop;

	// Token: 0x040010FB RID: 4347
	public float EndDistance;

	// Token: 0x040010FC RID: 4348
	public float Sampling;

	// Token: 0x040010FD RID: 4349
	public bool ContainZ;

	// Token: 0x040010FE RID: 4350
	public bool IsInverse;

	// Token: 0x040010FF RID: 4351
	public int Times;
}
