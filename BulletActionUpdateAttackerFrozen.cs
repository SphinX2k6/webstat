using System;

// Token: 0x02002D94 RID: 11668
public class BulletActionUpdateAttackerFrozen : BulletActionBase
{
	// Token: 0x0601786B RID: 96363 RVA: 0x0068A864 File Offset: 0x00688A64
	public BulletActionUpdateAttackerFrozen(EBulletAction type) : base(type)
	{
	}

	// Token: 0x0601786C RID: 96364 RVA: 0x0068A870 File Offset: 0x00688A70
	protected override void OnTick(float delta)
	{
		BulletInfo bulletInfo = this.BulletInfo;
		Entity attacker = bulletInfo.Attacker;
		if (((attacker != null) ? attacker.GetComponent<BaseFrozenComponent>() : null).IsFrozen())
		{
			ControllerBase<BulletController>.Instance.DestroyBullet(bulletInfo.BulletEntityId, false, EBulletDestroyReason.Normal, false);
		}
	}
}
