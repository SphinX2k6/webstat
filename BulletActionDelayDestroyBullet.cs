using System;
using UnrealEngine;

// Token: 0x02002D80 RID: 11648
public class BulletActionDelayDestroyBullet : BulletActionBase
{
	// Token: 0x060177F7 RID: 96247 RVA: 0x006836AB File Offset: 0x006818AB
	public BulletActionDelayDestroyBullet(EBulletAction type) : base(type)
	{
	}

	// Token: 0x060177F8 RID: 96248 RVA: 0x006836B4 File Offset: 0x006818B4
	protected override void OnExecute()
	{
		BulletActionInfoDelayDestroyBullet bulletActionInfoDelayDestroyBullet = (BulletActionInfoDelayDestroyBullet)this.ActionInfo;
		if (bulletActionInfoDelayDestroyBullet.DelayTime <= 0f)
		{
			this.DestroyBullet();
			return;
		}
		this.RemainingTime = bulletActionInfoDelayDestroyBullet.DelayTime;
	}

	// Token: 0x060177F9 RID: 96249 RVA: 0x006836F0 File Offset: 0x006818F0
	protected override void OnTick(float delta)
	{
		BulletInfo bulletInfo = this.BulletInfo;
		if (this.BulletInfo.NeedDestroy)
		{
			return;
		}
		BulletActionInfoDelayDestroyBullet bulletActionInfoDelayDestroyBullet = (BulletActionInfoDelayDestroyBullet)this.ActionInfo;
		float timeDilation = bulletInfo.Entity.TimeDilation;
		if (bulletActionInfoDelayDestroyBullet.IgnoreBulletActorTimeScale)
		{
			this.RemainingTime -= delta * timeDilation;
		}
		else
		{
			AActor actor = bulletInfo.Actor;
			if (actor == null || !actor.IsValid())
			{
				this.RemainingTime -= delta * timeDilation;
			}
			else
			{
				this.RemainingTime -= delta * actor.CustomTimeDilation * timeDilation;
			}
		}
		if (this.RemainingTime <= 0f)
		{
			this.DestroyBullet();
		}
	}

	// Token: 0x060177FA RID: 96250 RVA: 0x00683798 File Offset: 0x00681998
	private void DestroyBullet()
	{
		BulletActionInfoDelayDestroyBullet bulletActionInfoDelayDestroyBullet = (BulletActionInfoDelayDestroyBullet)this.ActionInfo;
		ControllerBase<BulletController>.Instance.DestroyBullet(this.BulletInfo.BulletEntityId, bulletActionInfoDelayDestroyBullet.SummonChild, EBulletDestroyReason.Normal, false);
		this.IsFinish = true;
	}

	// Token: 0x060177FB RID: 96251 RVA: 0x006837D5 File Offset: 0x006819D5
	public override void Clear()
	{
		base.Clear();
		this.RemainingTime = 0f;
	}

	// Token: 0x0400B429 RID: 46121
	private float RemainingTime;
}
