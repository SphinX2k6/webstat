using System;

// Token: 0x02002D88 RID: 11656
public class BulletActionInfoDelayDestroyBullet : BulletActionInfoBase
{
	// Token: 0x0601780E RID: 96270 RVA: 0x00683F1E File Offset: 0x0068211E
	public BulletActionInfoDelayDestroyBullet(EBulletAction type) : base(type)
	{
	}

	// Token: 0x0601780F RID: 96271 RVA: 0x00683F27 File Offset: 0x00682127
	public override void Clear()
	{
		this.DelayTime = 0f;
		this.SummonChild = false;
		this.IgnoreBulletActorTimeScale = false;
	}

	// Token: 0x0400B459 RID: 46169
	public float DelayTime;

	// Token: 0x0400B45A RID: 46170
	public bool SummonChild;

	// Token: 0x0400B45B RID: 46171
	public bool IgnoreBulletActorTimeScale;
}
