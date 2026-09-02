using System;

// Token: 0x02002D86 RID: 11654
public class BulletActionInfoDestroyBullet : BulletActionInfoBase
{
	// Token: 0x0601780A RID: 96266 RVA: 0x00683E86 File Offset: 0x00682086
	public BulletActionInfoDestroyBullet(EBulletAction type) : base(type)
	{
	}

	// Token: 0x0601780B RID: 96267 RVA: 0x00683E8F File Offset: 0x0068208F
	public override void Clear()
	{
		this.SummonChild = false;
		this.DestroyEffectImmediately = false;
		this.DestroyReason = null;
	}

	// Token: 0x0400B44D RID: 46157
	public bool SummonChild;

	// Token: 0x0400B44E RID: 46158
	public bool DestroyEffectImmediately;

	// Token: 0x0400B44F RID: 46159
	public EBulletDestroyReason? DestroyReason;
}
